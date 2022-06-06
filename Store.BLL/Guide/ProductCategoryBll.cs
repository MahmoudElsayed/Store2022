using Store.DAL;
using Store.DTO;
using Store.DTO.Guide;
using Store.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Store.BLL
{
    public class ProductCategoryBll
    {
        private const string sp_ProductCategory_Get = "[Guide].[sp_ProductCategory_Get]";
        private const string sp_ProductCategory_Update = "[Guide].[sp_ProductCategory_Update]";
        private readonly IRepository<ProductCategory> _repoProductCategory;

        public ProductCategoryBll(IRepository<ProductCategory> repoProductCategory)
        {
            _repoProductCategory = repoProductCategory;
        }
        public ResultViewModel Update(ProductCategoryUpdateDTO mdl)
        {
            var SqlParameters = new List<SqlParameter>();
            SqlParameters.Add(new SqlParameter("@Seq_Id", mdl.Seq_Id));

            var Category_Name = new SqlParameter() {Value=mdl.Category_Name,SqlDbType=SqlDbType.VarChar,Size=250,ParameterName= "@Category_Name" };

            SqlParameters.Add(Category_Name);

            var Category_Description = new SqlParameter() { Value = mdl.Category_Description, SqlDbType = SqlDbType.VarChar, Size = 500, ParameterName = "@Category_Description" };

            SqlParameters.Add(Category_Description);

            var data = _repoProductCategory.ExecuteStoredProcedure<ResultViewModel>
                (sp_ProductCategory_Update, SqlParameters.ToArray(), CommandType.StoredProcedure);

            return data.FirstOrDefault();
        }

        #region LoadData
        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoProductCategory.ExecuteStoredProcedure<ProductCategoryDTO>
                (sp_ProductCategory_Get, mdl.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { AaData = data, ITotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
        

        #endregion
    }
}
