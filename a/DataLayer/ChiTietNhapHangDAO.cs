using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ChiTietNhapHangDAO
    {
        #region Fields
        public static readonly string Key = "__ChiTietNhapHangData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static ChiTietNhapHangDAO()
        {
            try
            {
                //<add key="Cache_ChiTietNhapHang" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_ChiTietNhapHang"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<ChiTietNhapHangInfo> GetAll()
        {
            if (Cache)
            {
                List<ChiTietNhapHangInfo> list = DataCache.GetCache(Key) as List<ChiTietNhapHangInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<ChiTietNhapHangInfo>(DataProvider.Instance().GetAll(
                    	Table.ChiTietNhapHang,
                    	PagingHelper.CreateOrder(new OrderObject(TableChiTietNhapHang.MaPhieuNhap, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<ChiTietNhapHangInfo>(DataProvider.Instance().GetAll(
            	Table.ChiTietNhapHang,
            	PagingHelper.CreateOrder(new OrderObject(TableChiTietNhapHang.MaPhieuNhap, SortOrder.Desc))));
        }
        public static List<ChiTietNhapHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<ChiTietNhapHangInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietNhapHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static ChiTietNhapHangInfo Find(object columnName, object value)
        {
            return CBO.FillObject<ChiTietNhapHangInfo>(DataProvider.Instance().Find(Table.ChiTietNhapHang, columnName, value));
        }
        #endregion

        #region Common
        public static Comparison<ChiTietNhapHangInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(ChiTietNhapHangInfo x, ChiTietNhapHangInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "maphieunhap":
                        	rs = PagingHelper.Compare<int>(x.MaPhieuNhap, y.MaPhieuNhap, obj.Order);
                        	break;
                        case "mahh":
                        	rs = PagingHelper.Compare<int>(x.MaHH, y.MaHH, obj.Order);
                        	break;
                        case "soluong":
                        	rs = PagingHelper.Compare<int>(x.SoLuong, y.SoLuong, obj.Order);
                        	break;
                        case "dongia":
                        	rs = PagingHelper.Compare<int>(x.DonGia, y.DonGia, obj.Order);
                        	break;
                        case "thanhtien":
                        	rs = PagingHelper.Compare<float>(x.ThanhTien, y.ThanhTien, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableChiTietNhapHang.MaPhieuNhap, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<ChiTietNhapHangInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<ChiTietNhapHangInfo>(DataProvider.Instance().GetByPage(
            	Table.ChiTietNhapHang, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<ChiTietNhapHangInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<ChiTietNhapHangInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<ChiTietNhapHangInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietNhapHangInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietNhapHangInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ChiTietNhapHangInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(ChiTietNhapHangInfo chiTietNhapHangInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_ChiTietNhapHang,
            	"",
            	chiTietNhapHangInfo.MaPhieuNhap, chiTietNhapHangInfo.MaHH, chiTietNhapHangInfo.SoLuong, chiTietNhapHangInfo.DonGia, chiTietNhapHangInfo.ThanhTien, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(ChiTietNhapHangInfo chiTietNhapHangInfo)
        {
            return InsertUpdateDelete(chiTietNhapHangInfo, DataProviderAction.Insert);
        }
        public static int Update(ChiTietNhapHangInfo chiTietNhapHangInfo)
        {
            return InsertUpdateDelete(chiTietNhapHangInfo, DataProviderAction.Update);
        }
        public static int Delete(ChiTietNhapHangInfo chiTietNhapHangInfo)
        {
            return InsertUpdateDelete(chiTietNhapHangInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
