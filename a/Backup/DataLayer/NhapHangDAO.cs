using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class NhapHangDAO
    {
        #region Fields
        public static readonly string Key = "__NhapHangData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static NhapHangDAO()
        {
            try
            {
                //<add key="Cache_NhapHang" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_NhapHang"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<NhapHangInfo> GetAll()
        {
            if (Cache)
            {
                List<NhapHangInfo> list = DataCache.GetCache(Key) as List<NhapHangInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<NhapHangInfo>(DataProvider.Instance().GetAll(
                    	Table.NhapHang,
                    	PagingHelper.CreateOrder(new OrderObject(TableNhapHang.MaPhieuNhap, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<NhapHangInfo>(DataProvider.Instance().GetAll(
            	Table.NhapHang,
            	PagingHelper.CreateOrder(new OrderObject(TableNhapHang.MaPhieuNhap, SortOrder.Desc))));
        }
        public static List<NhapHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<NhapHangInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<NhapHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static NhapHangInfo Find(object columnName, object value)
        {
            return CBO.FillObject<NhapHangInfo>(DataProvider.Instance().Find(Table.NhapHang, columnName, value));
        }
        public static NhapHangInfo Find(int maPhieuNhap)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(NhapHangInfo objObject)
                {
                    return objObject.MaPhieuNhap == maPhieuNhap;
                });
            }
            return Find(TableNhapHang.MaPhieuNhap, maPhieuNhap);
        }
        #endregion

        #region Common
        public static Comparison<NhapHangInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(NhapHangInfo x, NhapHangInfo y)
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
                        case "manv":
                        	rs = PagingHelper.Compare<int>(x.MaNV, y.MaNV, obj.Order);
                        	break;
                        case "tongsoluong":
                        	rs = PagingHelper.Compare<int>(x.TongSoLuong, y.TongSoLuong, obj.Order);
                        	break;
                        case "ngaynhap":
                        	rs = PagingHelper.Compare<string>(x.NgayNhap, y.NgayNhap, obj.Order);
                        	break;
                        case "nhacc":
                        	rs = PagingHelper.Compare<string>(x.NhaCC, y.NhaCC, obj.Order);
                        	break;
                        case "dienthoaincc":
                        	rs = PagingHelper.Compare<string>(x.DienThoaiNCC, y.DienThoaiNCC, obj.Order);
                        	break;
                        case "diachinhacc":
                        	rs = PagingHelper.Compare<string>(x.DiaChiNhaCC, y.DiaChiNhaCC, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableNhapHang.MaPhieuNhap, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<NhapHangInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<NhapHangInfo>(DataProvider.Instance().GetByPage(
            	Table.NhapHang, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<NhapHangInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<NhapHangInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<NhapHangInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<NhapHangInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<NhapHangInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<NhapHangInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(NhapHangInfo nhapHangInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_NhapHang,
            	"@" + TableNhapHang.MaPhieuNhap,
            	nhapHangInfo.MaPhieuNhap, nhapHangInfo.MaNV, nhapHangInfo.TongSoLuong, nhapHangInfo.NgayNhap, nhapHangInfo.NhaCC, nhapHangInfo.DienThoaiNCC, nhapHangInfo.DiaChiNhaCC, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(NhapHangInfo nhapHangInfo)
        {
            return InsertUpdateDelete(nhapHangInfo, DataProviderAction.Insert);
        }
        public static int Update(NhapHangInfo nhapHangInfo)
        {
            return InsertUpdateDelete(nhapHangInfo, DataProviderAction.Update);
        }
        public static int Delete(NhapHangInfo nhapHangInfo)
        {
            return InsertUpdateDelete(nhapHangInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
