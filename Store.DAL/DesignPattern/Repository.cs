using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Data.Common;

namespace Store.DAL
{
    /// <summary>
    /// Repository Pattern
    /// </summary>
    /// <typeparam name="T"> <see cref="T"/> is a class</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {

        #region Fields Props

        public StoreContext _db;
        private readonly IUnitOfWork<StoreContext> _uow;
        private readonly DbSet<T> data;
        private readonly IConfiguration _configuration;

   

        public bool IsDisposed { get => _uow.IsDisposed; }

        public void Dispose()
        {
            _uow.Dispose();
        }

        
        public Repository(IUnitOfWork<StoreContext> unitOfWork, IHttpContextAccessor httpContext, IConfiguration configuration)
        {
            _uow = unitOfWork;
            _db = _uow.StoreContext;
            _configuration = configuration;
            data = _db.Set<T>();
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete The Current Entity <see cref="T"/>
        /// </summary>
        /// <param name="entity"><see cref="T"/></param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            data.Remove(entity);
            return SaveChange();
        }

        /// <summary>
        /// Delete The Current Entity <see cref="T"/>
        /// </summary>
        /// <param name="entity"><see cref="T"/></param>
        /// <returns></returns>
        public virtual Task<bool> DeleteAsync(T entity)
        {
            data.Remove(entity);
            return SaveChangeAsnc();
        }

        /// <summary>
        /// Delete The Current Entity <see cref="T"/> Without Save
        /// </summary>
        /// <param name="entity"><see cref="T"/></param>
        /// <returns></returns>
        public virtual void DeleteWithoutSaveChange(T entity) => data.Remove(entity);

        /// <summary>
        /// Delete The Current Entities <see cref="T"/>
        /// </summary>
        /// <param name="entity"><see cref="T"/></param>
        /// <returns></returns>
        public virtual bool DeleteRange(IEnumerable<T> entity)
        {
            data.RemoveRange(entity);
            bool IsSuccess = SaveChange();
            return IsSuccess;
        }

        /// <summary>
        /// Delete The Current Entities <see cref="T"/> Without Save
        /// </summary>
        /// <param name="entity"><see cref="T"/></param>
        /// <returns></returns>
        public virtual void DeleteRangeWithoutSaveChange(IEnumerable<T> entity)
        {
            data.RemoveRange(entity);
        }

        #endregion

        #region Insert

        public virtual bool Insert(T entity)
        {
            data.Add(entity);
            return SaveChange();
        }

        public virtual Task<bool> InsertAsync(T entity)
        {
            data.AddAsync(entity);
            return SaveChangeAsnc();
        }

        public virtual void InsertWithoutSaveChange(T entity) => data.Add(entity);

        public virtual bool InsertRange(IEnumerable<T> entities)
        {
            if (entities != null)
            {
                data.AddRange(entities);
                return SaveChange();
            }
            return false;
        }

        public virtual void InsertRangeWithoutSaveChange(IEnumerable<T> entities)
        {
            data.AddRange(entities);
        }

        #endregion

        #region Update

        public virtual bool Update(T entity)
        {
            _db.Entry<T>(entity).CurrentValues.SetValues(entity);
            _db.Entry<T>(entity).State = EntityState.Modified;
            return SaveChange();
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
            data.Update(entity).State = EntityState.Modified;
            return SaveChangeAsnc();
        }

        public virtual void UpdateWithoutSaveChange(T entity) => data.Update(entity).State = EntityState.Modified;


        #endregion

        #region Get

        public virtual IQueryable<T> Find(Func<T, bool> predicate) => data.Where(predicate).AsQueryable<T>();


        public virtual IQueryable<T> GetAll() => data.AsQueryable();

        public virtual IQueryable<T> GetAllAsNoTracking() => data.AsNoTracking().AsQueryable();


        public virtual async Task<IQueryable<T>> GetAllAsync() => await Task.FromResult(data.AsQueryable());


        public virtual T GetById(object Id) => data.Find(Id);

        public virtual T GetByIdDetached(object Id)
        {
            var data = GetById(Id);
            _db.Entry(data).State = EntityState.Detached;

            return data;
        }

        public virtual T Detached(T entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        #endregion

        #region Save

        public virtual bool SaveChange() => _uow.SaveChanges();

        public virtual Task<bool> SaveChangeAsnc() => _uow.SaveChangesAsync();

        #endregion

        #region SQL Query

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="U">The Result Class It Will Be List< <see cref="U"/> ></typeparam>
        /// <param name="query">Query string or Stored Procedure name</param>
        /// <param name="parameters">Parameters </param>
        /// <param name="commandType">Query or StoredProcedure default is StoredProcedure</param>
        /// <returns></returns>
        public List<U> ExecuteStoredProcedure<U>(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.StoredProcedure)
        
        {
            /// in _db.Database.GetDbConnection().ConnectionString if the password didn't get inside connection string
            /// please make sure you add => "Persist Security Info=true;" inside your connection string in appsetting.json
            SqlConnection sqlConnection = new SqlConnection(_db.Database.GetDbConnection().ConnectionString);
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            if(sqlConnection.State!=ConnectionState.Open)
            sqlConnection.Open();
            cmd.CommandType = commandType;
            var reader = cmd.ExecuteReader();

            DataTable tbl = new DataTable();
            tbl.Load(reader, LoadOption.PreserveChanges);
            sqlConnection.Close();
            return ConvertDataTable<U>(tbl);
        }

        private List<U> ConvertDataTable<U>(DataTable dt)
        {
            List<U> data = new List<U>();
            Type temp = typeof(U);
            foreach (DataRow row in dt.Rows) data.Add(GetItem<U>(row, temp));
            return data;
        }

        private U GetItem<U>(DataRow dr, Type temp)
        {
            U obj = Activator.CreateInstance<U>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                PropertyInfo pro = temp.GetProperty(column.ColumnName);
                if (pro != null && pro.CanWrite)
                {
                    try
                    {
                        object col = dr[column.ColumnName];
                        if (pro.PropertyType.Name == nameof(Boolean) && (col.ToString() == "0" || col.ToString() == "1")) col = !(col.ToString() == "0");
                        pro.SetValue(obj, col, null);
                    }
                    catch
                    {
                        pro.SetValue(obj, null, null);
                    }
                }
            }
            return obj;
        }

        #endregion
    }

}
