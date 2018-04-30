using System;
using System.Collections.Generic;
using System.Data;
using DataTools.PagingUtils;

namespace DataAccess
{
    public abstract class DataProvider
    {
        #region Fields
        private static DataProvider _instance;
        private static object _syncLock = new object();
        #endregion

        #region Methods

        public static DataProvider Instance()
        {
            if (_instance == null)
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                        _instance = new SqlDataProvider();
                }
            }
            return _instance;
        }

        #region Common
        public abstract IDataReader GetAll(object tableName, string orderBy);
        public abstract IDataReader GetByPage(object tableName, string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount);
        public abstract IDataReader Find(object tableName, object columnName, object key);
        public abstract int InsertUpdateDelete(DataProviderAction action, string spName, string outputName, params object[] parameterValues);
        #endregion

        #region Generic
        public abstract int ExecuteNonQuery(string spName, params object[] parameterValues);
        public abstract DataSet ExecuteDataset(string spName, params object[] parameterValues);
        public abstract IDataReader ExecuteReader(string spName, params object[] parameterValues);
        public abstract object ExecuteScalar(string spName, params object[] parameterValues);
        public abstract IDataReader ExecuteSQL(string SQL, IDbDataParameter[] commandParameters);
        public abstract DataSet ExecuteDataset(string SQL, IDbDataParameter[] commandParameters);
        #endregion
        #endregion
    }
}
