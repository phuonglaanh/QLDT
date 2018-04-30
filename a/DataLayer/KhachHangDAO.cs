using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class KhachHangDAO
    {
        #region Fields
        public static readonly string Key = "__KhachHangData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static KhachHangDAO()
        {
            try
            {
                //<add key="Cache_KhachHang" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_KhachHang"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<KhachHangInfo> GetAll()
        {
            if (Cache)
            {
                List<KhachHangInfo> list = DataCache.GetCache(Key) as List<KhachHangInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<KhachHangInfo>(DataProvider.Instance().GetAll(
                    	Table.KhachHang,
                    	PagingHelper.CreateOrder(new OrderObject(TableKhachHang.MaKH, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<KhachHangInfo>(DataProvider.Instance().GetAll(
            	Table.KhachHang,
            	PagingHelper.CreateOrder(new OrderObject(TableKhachHang.MaKH, SortOrder.Desc))));
        }
        public static List<KhachHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<KhachHangInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<KhachHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static KhachHangInfo Find(object columnName, object value)
        {
            return CBO.FillObject<KhachHangInfo>(DataProvider.Instance().Find(Table.KhachHang, columnName, value));
        }
        public static KhachHangInfo Find(int maKH)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(KhachHangInfo objObject)
                {
                    return objObject.MaKH == maKH;
                });
            }
            return Find(TableKhachHang.MaKH, maKH);
        }
        #endregion

        #region Common
        public static Comparison<KhachHangInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(KhachHangInfo x, KhachHangInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "makh":
                        	rs = PagingHelper.Compare<int>(x.MaKH, y.MaKH, obj.Order);
                        	break;
                        case "tenkh":
                        	rs = PagingHelper.Compare<string>(x.TenKH, y.TenKH, obj.Order);
                        	break;
                        case "diachi":
                        	rs = PagingHelper.Compare<string>(x.DiaChi, y.DiaChi, obj.Order);
                        	break;
                        case "sdt":
                        	rs = PagingHelper.Compare<string>(x.SDT, y.SDT, obj.Order);
                        	break;
                        case "mail":
                        	rs = PagingHelper.Compare<string>(x.Mail, y.Mail, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableKhachHang.MaKH, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<KhachHangInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<KhachHangInfo>(DataProvider.Instance().GetByPage(
            	Table.KhachHang, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<KhachHangInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<KhachHangInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<KhachHangInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<KhachHangInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<KhachHangInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<KhachHangInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(KhachHangInfo khachHangInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_KhachHang,
            	"@" + TableKhachHang.MaKH,
            	khachHangInfo.MaKH, khachHangInfo.TenKH, khachHangInfo.DiaChi, khachHangInfo.SDT, khachHangInfo.Mail, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(KhachHangInfo khachHangInfo)
        {
            return InsertUpdateDelete(khachHangInfo, DataProviderAction.Insert);
        }
        public static int Update(KhachHangInfo khachHangInfo)
        {
            return InsertUpdateDelete(khachHangInfo, DataProviderAction.Update);
        }
        public static int Delete(KhachHangInfo khachHangInfo)
        {
            return InsertUpdateDelete(khachHangInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
