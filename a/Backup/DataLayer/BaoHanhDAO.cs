using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class BaoHanhDAO
    {
        #region Fields
        public static readonly string Key = "__BaoHanhData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static BaoHanhDAO()
        {
            try
            {
                //<add key="Cache_BaoHanh" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_BaoHanh"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<BaoHanhInfo> GetAll()
        {
            if (Cache)
            {
                List<BaoHanhInfo> list = DataCache.GetCache(Key) as List<BaoHanhInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<BaoHanhInfo>(DataProvider.Instance().GetAll(
                    	Table.BaoHanh,
                    	PagingHelper.CreateOrder(new OrderObject(TableBaoHanh.SoPhieu, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<BaoHanhInfo>(DataProvider.Instance().GetAll(
            	Table.BaoHanh,
            	PagingHelper.CreateOrder(new OrderObject(TableBaoHanh.SoPhieu, SortOrder.Desc))));
        }
        public static List<BaoHanhInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<BaoHanhInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<BaoHanhInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static BaoHanhInfo Find(object columnName, object value)
        {
            return CBO.FillObject<BaoHanhInfo>(DataProvider.Instance().Find(Table.BaoHanh, columnName, value));
        }
        public static BaoHanhInfo Find(int soPhieu)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(BaoHanhInfo objObject)
                {
                    return objObject.SoPhieu == soPhieu;
                });
            }
            return Find(TableBaoHanh.SoPhieu, soPhieu);
        }
        #endregion

        #region Common
        public static Comparison<BaoHanhInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(BaoHanhInfo x, BaoHanhInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "sophieu":
                        	rs = PagingHelper.Compare<int>(x.SoPhieu, y.SoPhieu, obj.Order);
                        	break;
                        case "mahh":
                        	rs = PagingHelper.Compare<int>(x.MaHH, y.MaHH, obj.Order);
                        	break;
                        case "soemei":
                        	rs = PagingHelper.Compare<string>(x.SoEmei, y.SoEmei, obj.Order);
                        	break;
                        case "makh":
                        	rs = PagingHelper.Compare<int>(x.MaKH, y.MaKH, obj.Order);
                        	break;
                        case "ngaymua":
                        	rs = PagingHelper.Compare<string>(x.NgayMua, y.NgayMua, obj.Order);
                        	break;
                        case "thoigianbaohanh":
                        	rs = PagingHelper.Compare<int>(x.ThoiGianBaoHanh, y.ThoiGianBaoHanh, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableBaoHanh.SoPhieu, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<BaoHanhInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<BaoHanhInfo>(DataProvider.Instance().GetByPage(
            	Table.BaoHanh, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<BaoHanhInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<BaoHanhInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<BaoHanhInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<BaoHanhInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<BaoHanhInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<BaoHanhInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(BaoHanhInfo baoHanhInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_BaoHanh,
            	"@" + TableBaoHanh.SoPhieu,
            	baoHanhInfo.SoPhieu, baoHanhInfo.MaHH, baoHanhInfo.SoEmei, baoHanhInfo.MaKH, baoHanhInfo.NgayMua, baoHanhInfo.ThoiGianBaoHanh, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(BaoHanhInfo baoHanhInfo)
        {
            return InsertUpdateDelete(baoHanhInfo, DataProviderAction.Insert);
        }
        public static int Update(BaoHanhInfo baoHanhInfo)
        {
            return InsertUpdateDelete(baoHanhInfo, DataProviderAction.Update);
        }
        public static int Delete(BaoHanhInfo baoHanhInfo)
        {
            return InsertUpdateDelete(baoHanhInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
