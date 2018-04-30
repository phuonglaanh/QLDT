using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ChiTietTraHangDAO
    {
        #region Fields
        public static readonly string Key = "__ChiTietTraHangData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static ChiTietTraHangDAO()
        {
            try
            {
                //<add key="Cache_ChiTietTraHang" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_ChiTietTraHang"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<ChiTietTraHangInfo> GetAll()
        {
            if (Cache)
            {
                List<ChiTietTraHangInfo> list = DataCache.GetCache(Key) as List<ChiTietTraHangInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<ChiTietTraHangInfo>(DataProvider.Instance().GetAll(
                    	Table.ChiTietTraHang,
                    	PagingHelper.CreateOrder(new OrderObject(TableChiTietTraHang.MaPhieuTra, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<ChiTietTraHangInfo>(DataProvider.Instance().GetAll(
            	Table.ChiTietTraHang,
            	PagingHelper.CreateOrder(new OrderObject(TableChiTietTraHang.MaPhieuTra, SortOrder.Desc))));
        }
        public static List<ChiTietTraHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<ChiTietTraHangInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietTraHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static ChiTietTraHangInfo Find(object columnName, object value)
        {
            return CBO.FillObject<ChiTietTraHangInfo>(DataProvider.Instance().Find(Table.ChiTietTraHang, columnName, value));
        }
        #endregion

        #region Common
        public static Comparison<ChiTietTraHangInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(ChiTietTraHangInfo x, ChiTietTraHangInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "maphieutra":
                        	rs = PagingHelper.Compare<int>(x.MaPhieuTra, y.MaPhieuTra, obj.Order);
                        	break;
                        case "mahh":
                        	rs = PagingHelper.Compare<int>(x.MaHH, y.MaHH, obj.Order);
                        	break;
                        case "soluong":
                        	rs = PagingHelper.Compare<int>(x.SoLuong, y.SoLuong, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableChiTietTraHang.MaPhieuTra, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<ChiTietTraHangInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<ChiTietTraHangInfo>(DataProvider.Instance().GetByPage(
            	Table.ChiTietTraHang, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<ChiTietTraHangInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<ChiTietTraHangInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<ChiTietTraHangInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietTraHangInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietTraHangInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietTraHangInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(ChiTietTraHangInfo chiTietTraHangInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_ChiTietTraHang,
            	"",
            	chiTietTraHangInfo.MaPhieuTra, chiTietTraHangInfo.MaHH, chiTietTraHangInfo.SoLuong, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(ChiTietTraHangInfo chiTietTraHangInfo)
        {
            return InsertUpdateDelete(chiTietTraHangInfo, DataProviderAction.Insert);
        }
        public static int Update(ChiTietTraHangInfo chiTietTraHangInfo)
        {
            return InsertUpdateDelete(chiTietTraHangInfo, DataProviderAction.Update);
        }
        public static int Delete(ChiTietTraHangInfo chiTietTraHangInfo)
        {
            return InsertUpdateDelete(chiTietTraHangInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
