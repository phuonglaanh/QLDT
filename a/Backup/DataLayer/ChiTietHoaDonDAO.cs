using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ChiTietHoaDonDAO
    {
        #region Fields
        public static readonly string Key = "__ChiTietHoaDonData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static ChiTietHoaDonDAO()
        {
            try
            {
                //<add key="Cache_ChiTietHoaDon" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_ChiTietHoaDon"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<ChiTietHoaDonInfo> GetAll()
        {
            if (Cache)
            {
                List<ChiTietHoaDonInfo> list = DataCache.GetCache(Key) as List<ChiTietHoaDonInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<ChiTietHoaDonInfo>(DataProvider.Instance().GetAll(
                    	Table.ChiTietHoaDon,
                    	PagingHelper.CreateOrder(new OrderObject(TableChiTietHoaDon.MaKH, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<ChiTietHoaDonInfo>(DataProvider.Instance().GetAll(
            	Table.ChiTietHoaDon,
            	PagingHelper.CreateOrder(new OrderObject(TableChiTietHoaDon.MaKH, SortOrder.Desc))));
        }
        public static List<ChiTietHoaDonInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<ChiTietHoaDonInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietHoaDonInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static ChiTietHoaDonInfo Find(object columnName, object value)
        {
            return CBO.FillObject<ChiTietHoaDonInfo>(DataProvider.Instance().Find(Table.ChiTietHoaDon, columnName, value));
        }
        #endregion

        #region Common
        public static Comparison<ChiTietHoaDonInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(ChiTietHoaDonInfo x, ChiTietHoaDonInfo y)
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
                        case "mahh":
                        	rs = PagingHelper.Compare<int>(x.MaHH, y.MaHH, obj.Order);
                        	break;
                        case "soluong":
                        	rs = PagingHelper.Compare<int>(x.SoLuong, y.SoLuong, obj.Order);
                        	break;
                        case "giaban":
                        	rs = PagingHelper.Compare<int>(x.GiaBan, y.GiaBan, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableChiTietHoaDon.MaKH, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<ChiTietHoaDonInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<ChiTietHoaDonInfo>(DataProvider.Instance().GetByPage(
            	Table.ChiTietHoaDon, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<ChiTietHoaDonInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<ChiTietHoaDonInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<ChiTietHoaDonInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietHoaDonInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietHoaDonInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietHoaDonInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(ChiTietHoaDonInfo chiTietHoaDonInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_ChiTietHoaDon,
            	"",
            	chiTietHoaDonInfo.MaKH, chiTietHoaDonInfo.MaHH, chiTietHoaDonInfo.SoLuong, chiTietHoaDonInfo.GiaBan, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(ChiTietHoaDonInfo chiTietHoaDonInfo)
        {
            return InsertUpdateDelete(chiTietHoaDonInfo, DataProviderAction.Insert);
        }
        public static int Update(ChiTietHoaDonInfo chiTietHoaDonInfo)
        {
            return InsertUpdateDelete(chiTietHoaDonInfo, DataProviderAction.Update);
        }
        public static int Delete(ChiTietHoaDonInfo chiTietHoaDonInfo)
        {
            return InsertUpdateDelete(chiTietHoaDonInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
