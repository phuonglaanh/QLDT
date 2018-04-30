using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class TaiKhoanDAO
    {
        #region Fields
        public static readonly string Key = "__TaiKhoanData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static TaiKhoanDAO()
        {
            try
            {
                //<add key="Cache_TaiKhoan" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_TaiKhoan"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<TaiKhoanInfo> GetAll()
        {
            if (Cache)
            {
                List<TaiKhoanInfo> list = DataCache.GetCache(Key) as List<TaiKhoanInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<TaiKhoanInfo>(DataProvider.Instance().GetAll(
                    	Table.TaiKhoan,
                    	PagingHelper.CreateOrder(new OrderObject(TableTaiKhoan.TenTaiKhoan, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<TaiKhoanInfo>(DataProvider.Instance().GetAll(
            	Table.TaiKhoan,
            	PagingHelper.CreateOrder(new OrderObject(TableTaiKhoan.TenTaiKhoan, SortOrder.Desc))));
        }
        public static List<TaiKhoanInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<TaiKhoanInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<TaiKhoanInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static TaiKhoanInfo Find(object columnName, object value)
        {
            return CBO.FillObject<TaiKhoanInfo>(DataProvider.Instance().Find(Table.TaiKhoan, columnName, value));
        }
        public static TaiKhoanInfo Find(string tenTaiKhoan)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(TaiKhoanInfo objObject)
                {
                    return objObject.TenTaiKhoan == tenTaiKhoan;
                });
            }
            return Find(TableTaiKhoan.TenTaiKhoan, tenTaiKhoan);
        }
        #endregion

        #region Common
        public static Comparison<TaiKhoanInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(TaiKhoanInfo x, TaiKhoanInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "tentaikhoan":
                        	rs = PagingHelper.Compare<string>(x.TenTaiKhoan, y.TenTaiKhoan, obj.Order);
                        	break;
                        case "matkhau":
                        	rs = PagingHelper.Compare<string>(x.MatKhau, y.MatKhau, obj.Order);
                        	break;
                        case "chucnang":
                        	rs = PagingHelper.Compare<string>(x.ChucNang, y.ChucNang, obj.Order);
                        	break;
                        case "quyen":
                        	rs = PagingHelper.Compare<string>(x.Quyen, y.Quyen, obj.Order);
                        	break;
                    }
                    if (rs != 0) return rs;
                }
                return 0;
            };
        }
        public static OrderObject[] DefaultOrder()
        {
            if (orderObjects == null)
            	orderObjects = new OrderObject[] { new OrderObject(TableTaiKhoan.TenTaiKhoan, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<TaiKhoanInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<TaiKhoanInfo>(DataProvider.Instance().GetByPage(
            	Table.TaiKhoan, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<TaiKhoanInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<TaiKhoanInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<TaiKhoanInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<TaiKhoanInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<TaiKhoanInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<TaiKhoanInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(TaiKhoanInfo taiKhoanInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_TaiKhoan,
            	"@" + TableTaiKhoan.TenTaiKhoan,
            	taiKhoanInfo.TenTaiKhoan, taiKhoanInfo.MatKhau, taiKhoanInfo.ChucNang, taiKhoanInfo.Quyen, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(TaiKhoanInfo taiKhoanInfo)
        {
            return InsertUpdateDelete(taiKhoanInfo, DataProviderAction.Insert);
        }
        public static int Update(TaiKhoanInfo taiKhoanInfo)
        {
            return InsertUpdateDelete(taiKhoanInfo, DataProviderAction.Update);
        }
        public static int Delete(TaiKhoanInfo taiKhoanInfo)
        {
            return InsertUpdateDelete(taiKhoanInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
