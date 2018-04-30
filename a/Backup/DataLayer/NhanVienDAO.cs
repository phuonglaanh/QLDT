using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class NhanVienDAO
    {
        #region Fields
        public static readonly string Key = "__NhanVienData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static NhanVienDAO()
        {
            try
            {
                //<add key="Cache_NhanVien" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_NhanVien"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<NhanVienInfo> GetAll()
        {
            if (Cache)
            {
                List<NhanVienInfo> list = DataCache.GetCache(Key) as List<NhanVienInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<NhanVienInfo>(DataProvider.Instance().GetAll(
                    	Table.NhanVien,
                    	PagingHelper.CreateOrder(new OrderObject(TableNhanVien.MaNV, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<NhanVienInfo>(DataProvider.Instance().GetAll(
            	Table.NhanVien,
            	PagingHelper.CreateOrder(new OrderObject(TableNhanVien.MaNV, SortOrder.Desc))));
        }
        public static List<NhanVienInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<NhanVienInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<NhanVienInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static NhanVienInfo Find(object columnName, object value)
        {
            return CBO.FillObject<NhanVienInfo>(DataProvider.Instance().Find(Table.NhanVien, columnName, value));
        }
        public static NhanVienInfo Find(int maNV)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(NhanVienInfo objObject)
                {
                    return objObject.MaNV == maNV;
                });
            }
            return Find(TableNhanVien.MaNV, maNV);
        }
        #endregion

        #region Common
        public static Comparison<NhanVienInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(NhanVienInfo x, NhanVienInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "manv":
                        	rs = PagingHelper.Compare<int>(x.MaNV, y.MaNV, obj.Order);
                        	break;
                        case "tennv":
                        	rs = PagingHelper.Compare<string>(x.TenNV, y.TenNV, obj.Order);
                        	break;
                        case "gioitinh":
                        	rs = PagingHelper.Compare<bool>(x.GioiTinh, y.GioiTinh, obj.Order);
                        	break;
                        case "ngaysinh":
                        	rs = PagingHelper.Compare<string>(x.NgaySinh, y.NgaySinh, obj.Order);
                        	break;
                        case "sdt":
                        	rs = PagingHelper.Compare<string>(x.SDT, y.SDT, obj.Order);
                        	break;
                        case "diachi":
                        	rs = PagingHelper.Compare<string>(x.DiaChi, y.DiaChi, obj.Order);
                        	break;
                        case "mail":
                        	rs = PagingHelper.Compare<string>(x.Mail, y.Mail, obj.Order);
                        	break;
                        case "cmnd":
                        	rs = PagingHelper.Compare<string>(x.CMND, y.CMND, obj.Order);
                        	break;
                        case "hinh":
                        	rs = PagingHelper.Compare<string>(x.Hinh, y.Hinh, obj.Order);
                        	break;
                        case "tinhtrang":
                        	rs = PagingHelper.Compare<string>(x.TinhTrang, y.TinhTrang, obj.Order);
                        	break;
                        case "tentaikhoan":
                        	rs = PagingHelper.Compare<string>(x.TenTaiKhoan, y.TenTaiKhoan, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableNhanVien.MaNV, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<NhanVienInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<NhanVienInfo>(DataProvider.Instance().GetByPage(
            	Table.NhanVien, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<NhanVienInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<NhanVienInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<NhanVienInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<NhanVienInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<NhanVienInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<NhanVienInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(NhanVienInfo nhanVienInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_NhanVien,
            	"@" + TableNhanVien.MaNV,
            	nhanVienInfo.MaNV, nhanVienInfo.TenNV, nhanVienInfo.GioiTinh, nhanVienInfo.NgaySinh, nhanVienInfo.SDT, nhanVienInfo.DiaChi, nhanVienInfo.Mail, nhanVienInfo.CMND, nhanVienInfo.Hinh, nhanVienInfo.TinhTrang, nhanVienInfo.TenTaiKhoan, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(NhanVienInfo nhanVienInfo)
        {
            return InsertUpdateDelete(nhanVienInfo, DataProviderAction.Insert);
        }
        public static int Update(NhanVienInfo nhanVienInfo)
        {
            return InsertUpdateDelete(nhanVienInfo, DataProviderAction.Update);
        }
        public static int Delete(NhanVienInfo nhanVienInfo)
        {
            return InsertUpdateDelete(nhanVienInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}
