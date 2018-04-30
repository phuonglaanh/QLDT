using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class LoaiDAO
    {
        #region Fields
        public static readonly string Key = "__LoaiData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static LoaiDAO()
        {
            try
            {
                //<add key="Cache_Loai" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Loai"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<LoaiInfo> GetAll()
        {
            if (Cache)
            {
                List<LoaiInfo> list = DataCache.GetCache(Key) as List<LoaiInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<LoaiInfo>(DataProvider.Instance().GetAll(
                    	Table.Loai,
                    	PagingHelper.CreateOrder(new OrderObject(TableLoai.MaLoai, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<LoaiInfo>(DataProvider.Instance().GetAll(
            	Table.Loai,
            	PagingHelper.CreateOrder(new OrderObject(TableLoai.MaLoai, SortOrder.Desc))));
        }
        public static List<LoaiInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<LoaiInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<LoaiInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static LoaiInfo Find(object columnName, object value)
        {
            return CBO.FillObject<LoaiInfo>(DataProvider.Instance().Find(Table.Loai, columnName, value));
        }
        public static LoaiInfo Find(int maLoai)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(LoaiInfo objObject)
                {
                    return objObject.MaLoai == maLoai;
                });
            }
            return Find(TableLoai.MaLoai, maLoai);
        }
        #endregion

        #region Common
        public static Comparison<LoaiInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(LoaiInfo x, LoaiInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "maloai":
                        	rs = PagingHelper.Compare<int>(x.MaLoai, y.MaLoai, obj.Order);
                        	break;
                        case "tenloai":
                        	rs = PagingHelper.Compare<string>(x.TenLoai, y.TenLoai, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableLoai.MaLoai, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<LoaiInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<LoaiInfo>(DataProvider.Instance().GetByPage(
            	Table.Loai, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<LoaiInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<LoaiInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<LoaiInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<LoaiInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<LoaiInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<LoaiInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(LoaiInfo loaiInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Loai,
            	"@" + TableLoai.MaLoai,
            	loaiInfo.MaLoai, loaiInfo.TenLoai, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(LoaiInfo loaiInfo)
        {
            return InsertUpdateDelete(loaiInfo, DataProviderAction.Insert);
        }
        public static int Update(LoaiInfo loaiInfo)
        {
            return InsertUpdateDelete(loaiInfo, DataProviderAction.Update);
        }
        public static int Delete(LoaiInfo loaiInfo)
        {
            return InsertUpdateDelete(loaiInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
