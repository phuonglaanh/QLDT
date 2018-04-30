using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class BangGiaDAO
    {
        #region Fields
        public static readonly string Key = "__BangGiaData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static BangGiaDAO()
        {
            try
            {
                //<add key="Cache_BangGia" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_BangGia"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<BangGiaInfo> GetAll()
        {
            if (Cache)
            {
                List<BangGiaInfo> list = DataCache.GetCache(Key) as List<BangGiaInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<BangGiaInfo>(DataProvider.Instance().GetAll(
                    	Table.BangGia,
                    	PagingHelper.CreateOrder(new OrderObject(TableBangGia.SoBangGia, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<BangGiaInfo>(DataProvider.Instance().GetAll(
            	Table.BangGia,
            	PagingHelper.CreateOrder(new OrderObject(TableBangGia.SoBangGia, SortOrder.Desc))));
        }
        public static List<BangGiaInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<BangGiaInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<BangGiaInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static BangGiaInfo Find(object columnName, object value)
        {
            return CBO.FillObject<BangGiaInfo>(DataProvider.Instance().Find(Table.BangGia, columnName, value));
        }
        public static BangGiaInfo Find(int soBangGia)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(BangGiaInfo objObject)
                {
                    return objObject.SoBangGia == soBangGia;
                });
            }
            return Find(TableBangGia.SoBangGia, soBangGia);
        }
        #endregion

        #region Common
        public static Comparison<BangGiaInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(BangGiaInfo x, BangGiaInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "sobanggia":
                        	rs = PagingHelper.Compare<int>(x.SoBangGia, y.SoBangGia, obj.Order);
                        	break;
                        case "mahh":
                        	rs = PagingHelper.Compare<int>(x.MaHH, y.MaHH, obj.Order);
                        	break;
                        case "giaban":
                        	rs = PagingHelper.Compare<int>(x.GiaBan, y.GiaBan, obj.Order);
                        	break;
                        case "ngayapdung":
                        	rs = PagingHelper.Compare<string>(x.NgayApDung, y.NgayApDung, obj.Order);
                        	break;
                        case "ngayketthuc":
                        	rs = PagingHelper.Compare<string>(x.NgayKetThuc, y.NgayKetThuc, obj.Order);
                        	break;
                        case "giamgia":
                        	rs = PagingHelper.Compare<int>(x.GiamGia, y.GiamGia, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableBangGia.SoBangGia, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<BangGiaInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<BangGiaInfo>(DataProvider.Instance().GetByPage(
            	Table.BangGia, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<BangGiaInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<BangGiaInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<BangGiaInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<BangGiaInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<BangGiaInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<BangGiaInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(BangGiaInfo bangGiaInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_BangGia,
            	"@" + TableBangGia.SoBangGia,
            	bangGiaInfo.SoBangGia, bangGiaInfo.MaHH, bangGiaInfo.GiaBan, bangGiaInfo.NgayApDung, bangGiaInfo.NgayKetThuc, bangGiaInfo.GiamGia, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(BangGiaInfo bangGiaInfo)
        {
            return InsertUpdateDelete(bangGiaInfo, DataProviderAction.Insert);
        }
        public static int Update(BangGiaInfo bangGiaInfo)
        {
            return InsertUpdateDelete(bangGiaInfo, DataProviderAction.Update);
        }
        public static int Delete(BangGiaInfo bangGiaInfo)
        {
            return InsertUpdateDelete(bangGiaInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
