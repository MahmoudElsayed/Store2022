
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DAL
{
    public interface IRepository<T> where T : class
    {

        #region Props

       

        public bool IsDisposed { get; }

        #endregion

        #region Delete

        bool Delete(T entity);
        void DeleteWithoutSaveChange(T entity);
        bool DeleteRange(IEnumerable<T> entity);
        void DeleteRangeWithoutSaveChange(IEnumerable<T> entity);
        Task<bool> DeleteAsync(T entity);

        #endregion

        #region Insert

        bool Insert(T entity);
        bool InsertRange(IEnumerable<T> entities);

        void InsertWithoutSaveChange(T entity);
        void InsertRangeWithoutSaveChange(IEnumerable<T> entities);
        void Dispose();
        Task<bool> InsertAsync(T entity);

        #endregion

        #region Update

        bool Update(T entity);
        void UpdateWithoutSaveChange(T entity);
        Task<bool> UpdateAsync(T entity);

        #endregion

        #region Get

        IQueryable<T> GetAll();
        IQueryable<T> GetAllAsNoTracking();
        Task<IQueryable<T>> GetAllAsync();

        T GetById(object Id);
        IQueryable<T> Find(Func<T, bool> predicate);

        T GetByIdDetached(object id);
        T Detached(T entity);

        #endregion

        #region Sql

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="U">The Result Class It Will Be List< <see cref="U"/> ></typeparam>
        /// <param name="query">Query string or Stored Procedure name</param>
        /// <param name="parameters">Parameters </param>
        /// <param name="commandType">Query or StoredProcedure default is StoredProcedure</param>
        /// <returns></returns> 
        List<U> ExecuteStoredProcedure<U>(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.StoredProcedure);

        #endregion

        #region Save

        bool SaveChange();
        Task<bool> SaveChangeAsnc();

        #endregion
    }

}
