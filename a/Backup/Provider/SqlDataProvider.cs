using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class SqlDataProvider : DataProvider
    {
        #region Fields
        private static readonly string _connectionString;
        #endregion

        #region Contructors
        static SqlDataProvider()
        {
            //_connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            _connectionString = @"server=.\SQLEXPRESS;integrated security=true;database=QLCuaHangDienThoai";
        }
        #endregion

        #region Methods

        protected static SqlConnection GetSqlConnection()
        {
            try
            {
                return new SqlConnection(_connectionString);
            }
            catch
            {
                throw new Exception("ConnectionString");
            }
        }

        #region Common
        public override IDataReader GetAll(object tableName, string orderBy)
        {
            return ExecuteReader(StoredProcedureName.GetAll, tableName.ToString(), orderBy);
        }
        public override IDataReader GetByPage(object tableName, string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            string filter = PagingHelper.CreateSafeFilter(filterObjects);
            try
            {
                totalRowCount = (int)SqlHelper.ExecuteScalar(_connectionString, StoredProcedureName.TotalRowCount, tableName, filter);
            }
            catch
            {
                totalRowCount = 0;
            }
            if (totalRowCount == 0)
            {
                pageCount = 0;
                return null;
            }
            if (pageSize <= 0 || totalRowCount <= pageSize)
                pageCount = 1;
            else
                pageCount = (totalRowCount + pageSize - 1) / pageSize;
            if (pageNum < 1 || pageNum > pageCount)
                return null;
            return SqlHelper.ExecuteReader(_connectionString, StoredProcedureName.GetByPage, tableName, fieldList, filter, 
                PagingHelper.CreateOrder(orderObjects), pageNum, pageSize, pageCount);
        }
        public override IDataReader Find(object tableName, object columnName, object key)
        {
            return ExecuteReader(StoredProcedureName.Find, tableName.ToString(), columnName.ToString(), DataTools.ConvertType.Escape(key.ToString()));
        }
        public override int InsertUpdateDelete(DataProviderAction action, string spName, string outputName, params object[] parameterValues)
        {
            using (SqlConnection cnn = GetSqlConnection())
            {
                SqlCommand cmd = SqlHelper.CreateCommand(cnn, spName, parameterValues);
                cnn.Open();
                int rs = cmd.ExecuteNonQuery();
                cnn.Close();
                if (rs > 0 && action == DataProviderAction.Insert && !string.IsNullOrEmpty(outputName))
                    return (int)cmd.Parameters[outputName].Value;
                return rs;
            }
        }
        #endregion

        #region Generic
        public override int ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteNonQuery(_connectionString, spName, parameterValues);
        }
        public override DataSet ExecuteDataset(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteDataset(_connectionString, spName, parameterValues);
        }
        public override IDataReader ExecuteReader(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteReader(_connectionString, spName, parameterValues);
        }
        public override object ExecuteScalar(string spName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteScalar(_connectionString, spName, parameterValues);
        }
        public override IDataReader ExecuteSQL(string SQL, IDbDataParameter[] commandParameters)
        {
            SqlParameter[] sqlParams = null;
            if (commandParameters != null)
            {
                sqlParams = new SqlParameter[commandParameters.Length];
                for (int i = 0; i < commandParameters.Length; i++)
                    sqlParams[i] = (SqlParameter)commandParameters[i];
            }
            try
            {
                return SqlHelper.ExecuteReader(_connectionString, CommandType.Text, SQL, sqlParams);
            }
            catch
            {
                return null;
            }
        }
        public override DataSet ExecuteDataset(string SQL, IDbDataParameter[] commandParameters)
        {
            SqlParameter[] sqlParams = null;
            if (commandParameters != null)
            {
                sqlParams = new SqlParameter[commandParameters.Length];
                for (int i = 0; i < commandParameters.Length; i++)
                    sqlParams[i] = (SqlParameter)commandParameters[i];
            }
            try
            {
                return SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, SQL, sqlParams);
            }
            catch
            {
                return new DataSet();
            }
        }
        #endregion
        #endregion
    }
}
