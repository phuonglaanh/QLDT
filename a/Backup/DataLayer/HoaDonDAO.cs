using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class HoaDonDAO
    {
        #region Fields
        public static readonly string Key = "__HoaDonData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static HoaDonDAO()
        {
            try
            {
                //<add key="Cache_HoaDon" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_HoaDon"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<HoaDonInfo> GetAll()
        {
            if (Cache)
            {
                List<HoaDonInfo> list = DataCache.GetCache(Key) as List<HoaDonInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<HoaDonInfo>(DataProvider.Instance().GetAll(
                    	Table.HoaDon,
                    	PagingHelper.CreateOrder(new OrderObject(TableHoaDon.SoHoaDon, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<HoaDonInfo>(DataProvider.Instance().GetAll(
            	Table.HoaDon,
            	PagingHelper.CreateOrder(new OrderObject(TableHoaDon.SoHoaDon, SortOrder.Desc))));
        }
        public static List<HoaDonInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<HoaDonInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<HoaDonInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static HoaDonInfo Find(object columnName, object value)
        {
            return CBO.FillObject<HoaDonInfo>(DataProvider.Instance().Find(Table.HoaDon, columnName, value));
        }
        public static HoaDonInfo Find(int soHoaDon)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(HoaDonInfo objObject)
                {
                    return objObject.SoHoaDon == soHoaDon;
                });
            }
            return Find(TableHoaDon.SoHoaDon, soHoaDon);
        }
        #endregion

        #region Common
        public static Comparison<HoaDonInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(HoaDonInfo x, HoaDonInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "sohoadon":
                        	rs = PagingHelper.Compare<int>(x.SoHoaDon, y.SoHoaDon, obj.Order);
                        	break;
                        case "manv":
                        	rs = PagingHelper.Compare<int>(x.MaNV, y.MaNV, obj.Order);
                        	break;
                        case "makh":
                        	rs = PagingHelper.Compare<int>(x.MaKH, y.MaKH, obj.Order);
                        	break;
                        case "ngaylap":
                        	rs = PagingHelper.Compare<string>(x.NgayLap, y.NgayLap, obj.Order);
                        	break;
                        case "tongtien":
                        	rs = PagingHelper.Compare<float>(x.TongTien, y.TongTien, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableHoaDon.SoHoaDon, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<HoaDonInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<HoaDonInfo>(DataProvider.Instance().GetByPage(
            	Table.HoaDon, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<HoaDonInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<HoaDonInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<HoaDonInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<HoaDonInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<HoaDonInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<HoaDonInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(HoaDonInfo hoaDonInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_HoaDon,
            	"@" + TableHoaDon.SoHoaDon,
            	hoaDonInfo.SoHoaDon, hoaDonInfo.MaNV, hoaDonInfo.MaKH, hoaDonInfo.NgayLap, hoaDonInfo.TongTien, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(HoaDonInfo hoaDonInfo)
        {
            return InsertUpdateDelete(hoaDonInfo, DataProviderAction.Insert);
        }
        public static int Update(HoaDonInfo hoaDonInfo)
        {
            return InsertUpdateDelete(hoaDonInfo, DataProviderAction.Update);
        }
        public static int Delete(HoaDonInfo hoaDonInfo)
        {
            return InsertUpdateDelete(hoaDonInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
