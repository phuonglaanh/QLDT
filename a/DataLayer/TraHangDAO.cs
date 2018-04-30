using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class TraHangDAO
    {
        #region Fields
        public static readonly string Key = "__TraHangData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static TraHangDAO()
        {
            try
            {
                //<add key="Cache_TraHang" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_TraHang"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<TraHangInfo> GetAll()
        {
            if (Cache)
            {
                List<TraHangInfo> list = DataCache.GetCache(Key) as List<TraHangInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<TraHangInfo>(DataProvider.Instance().GetAll(
                    	Table.TraHang,
                    	PagingHelper.CreateOrder(new OrderObject(TableTraHang.MaPhieuTra, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<TraHangInfo>(DataProvider.Instance().GetAll(
            	Table.TraHang,
            	PagingHelper.CreateOrder(new OrderObject(TableTraHang.MaPhieuTra, SortOrder.Desc))));
        }
        public static List<TraHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<TraHangInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<TraHangInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static TraHangInfo Find(object columnName, object value)
        {
            return CBO.FillObject<TraHangInfo>(DataProvider.Instance().Find(Table.TraHang, columnName, value));
        }
        public static TraHangInfo Find(int maPhieuTra)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(TraHangInfo objObject)
                {
                    return objObject.MaPhieuTra == maPhieuTra;
                });
            }
            return Find(TableTraHang.MaPhieuTra, maPhieuTra);
        }
        #endregion

        #region Common
        public static Comparison<TraHangInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(TraHangInfo x, TraHangInfo y)
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
                        case "manv":
                        	rs = PagingHelper.Compare<int>(x.MaNV, y.MaNV, obj.Order);
                        	break;
                        case "tongsoluong":
                        	rs = PagingHelper.Compare<int>(x.TongSoLuong, y.TongSoLuong, obj.Order);
                        	break;
                        case "ngaytra":
                        	rs = PagingHelper.Compare<string>(x.NgayTra, y.NgayTra, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableTraHang.MaPhieuTra, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<TraHangInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<TraHangInfo>(DataProvider.Instance().GetByPage(
            	Table.TraHang, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<TraHangInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<TraHangInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<TraHangInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<TraHangInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<TraHangInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<TraHangInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(TraHangInfo traHangInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_TraHang,
            	"@" + TableTraHang.MaPhieuTra,
            	traHangInfo.MaPhieuTra, traHangInfo.MaNV, traHangInfo.TongSoLuong, traHangInfo.NgayTra, traHangInfo.NhaCC, traHangInfo.DienThoaiNCC, traHangInfo.DiaChiNhaCC, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(TraHangInfo traHangInfo)
        {
            return InsertUpdateDelete(traHangInfo, DataProviderAction.Insert);
        }
        public static int Update(TraHangInfo traHangInfo)
        {
            return InsertUpdateDelete(traHangInfo, DataProviderAction.Update);
        }
        public static int Delete(TraHangInfo traHangInfo)
        {
            return InsertUpdateDelete(traHangInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
