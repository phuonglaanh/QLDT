using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class HangHoaDAO
    {
        #region Fields
        public static readonly string Key = "__HangHoaData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static HangHoaDAO()
        {
            try
            {
                //<add key="Cache_HangHoa" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_HangHoa"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<HangHoaInfo> GetAll()
        {
            if (Cache)
            {
                List<HangHoaInfo> list = DataCache.GetCache(Key) as List<HangHoaInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<HangHoaInfo>(DataProvider.Instance().GetAll(
                    	Table.HangHoa,
                    	PagingHelper.CreateOrder(new OrderObject(TableHangHoa.MaHH, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<HangHoaInfo>(DataProvider.Instance().GetAll(
            	Table.HangHoa,
            	PagingHelper.CreateOrder(new OrderObject(TableHangHoa.MaHH, SortOrder.Desc))));
        }
        public static List<HangHoaInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<HangHoaInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<HangHoaInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static HangHoaInfo Find(object columnName, object value)
        {
            return CBO.FillObject<HangHoaInfo>(DataProvider.Instance().Find(Table.HangHoa, columnName, value));
        }
        public static HangHoaInfo Find(int maHH)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(HangHoaInfo objObject)
                {
                    return objObject.MaHH == maHH;
                });
            }
            return Find(TableHangHoa.MaHH, maHH);
        }
        #endregion

        #region Common
        public static Comparison<HangHoaInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(HangHoaInfo x, HangHoaInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "mahh":
                        	rs = PagingHelper.Compare<int>(x.MaHH, y.MaHH, obj.Order);
                        	break;
                        case "tenhh":
                        	rs = PagingHelper.Compare<string>(x.TenHH, y.TenHH, obj.Order);
                        	break;
                        case "soluong":
                        	rs = PagingHelper.Compare<int>(x.SoLuong, y.SoLuong, obj.Order);
                        	break;
                        case "nhacc":
                        	rs = PagingHelper.Compare<string>(x.NhaCC, y.NhaCC, obj.Order);
                        	break;
                        case "maloai":
                        	rs = PagingHelper.Compare<int>(x.MaLoai, y.MaLoai, obj.Order);
                        	break;
                        case "donvitinh":
                        	rs = PagingHelper.Compare<string>(x.DonViTinh, y.DonViTinh, obj.Order);
                        	break;
                        case "hinh":
                        	rs = PagingHelper.Compare<string>(x.Hinh, y.Hinh, obj.Order);
                        	break;
                        case "tinhnang":
                        	rs = PagingHelper.Compare<string>(x.TinhNang, y.TinhNang, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableHangHoa.MaHH, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<HangHoaInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<HangHoaInfo>(DataProvider.Instance().GetByPage(
            	Table.HangHoa, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<HangHoaInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<HangHoaInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<HangHoaInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<HangHoaInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<HangHoaInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<HangHoaInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(HangHoaInfo hangHoaInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_HangHoa,
            	"@" + TableHangHoa.MaHH,
            	hangHoaInfo.MaHH, hangHoaInfo.TenHH, hangHoaInfo.SoLuong, hangHoaInfo.NhaCC, hangHoaInfo.MaLoai, hangHoaInfo.DonViTinh, hangHoaInfo.Hinh, hangHoaInfo.TinhNang, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(HangHoaInfo hangHoaInfo)
        {
            return InsertUpdateDelete(hangHoaInfo, DataProviderAction.Insert);
        }
        public static int Update(HangHoaInfo hangHoaInfo)
        {
            return InsertUpdateDelete(hangHoaInfo, DataProviderAction.Update);
        }
        public static int Delete(HangHoaInfo hangHoaInfo)
        {
            return InsertUpdateDelete(hangHoaInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
