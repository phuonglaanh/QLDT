using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class TaiKhoanInfo
    {
        #region Fields
        private string _TenTaiKhoan;
        private string _MatKhau;
        private string _ChucNang;
        private string _Quyen;

        #endregion

        #region Properties
        public string TenTaiKhoan
        {
            get { return _TenTaiKhoan; }
            set { _TenTaiKhoan = value; }
        }
        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }
        public string ChucNang
        {
            get { return _ChucNang; }
            set { _ChucNang = value; }
        }
        public string Quyen
        {
            get { return _Quyen; }
            set { _Quyen = value; }
        }

        #endregion

        #region Contructors
        public TaiKhoanInfo()
        {
        }
        public TaiKhoanInfo(string tenTaiKhoan)
        {
            _TenTaiKhoan = tenTaiKhoan;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return TaiKhoanDAO.Insert(this);
        }
        public int Update()
        {
            return TaiKhoanDAO.Update(this);
        }
        public int Delete()
        {
            return TaiKhoanDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<NhanVienInfo> GetNhanVien()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableNhanVien.TenTaiKhoan, EqualityOperator.Equal, this.TenTaiKhoan)
            };
            return NhanVienDAO.GetTop(filters, null, -1);
        }

        #endregion
      
        #endregion
    }
}
