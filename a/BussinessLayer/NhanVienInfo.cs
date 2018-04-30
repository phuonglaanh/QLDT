using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class NhanVienInfo
    {
        #region Fields
        private int _MaNV;
        private string _TenNV;
        private bool _GioiTinh;
        private string _NgaySinh;
        private string _SDT;
        private string _DiaChi;
        private string _Mail;
        private string _CMND;
        private string _Hinh;
        private string _TinhTrang;
        private string _TenTaiKhoan;

        #endregion

        #region Properties
        public int MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
        public string TenNV
        {
            get { return _TenNV; }
            set { _TenNV = value; }
        }
        public bool GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }
        public string NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        public string CMND
        {
            get { return _CMND; }
            set { _CMND = value; }
        }
        public string Hinh
        {
            get { return _Hinh; }
            set { _Hinh = value; }
        }
        public string TinhTrang
        {
            get { return _TinhTrang; }
            set { _TinhTrang = value; }
        }
        public string TenTaiKhoan
        {
            get { return _TenTaiKhoan; }
            set { _TenTaiKhoan = value; }
        }

        #endregion

        #region Contructors
        public NhanVienInfo()
        {
        }
        public NhanVienInfo(int maNV)
        {
            _MaNV = maNV;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return NhanVienDAO.Insert(this);
        }
        public int Update()
        {
            return NhanVienDAO.Update(this);
        }
        public int Delete()
        {
            return NhanVienDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<HoaDonInfo> GetHoaDon()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableHoaDon.MaNV, EqualityOperator.Equal, this.MaNV)
            };
            return HoaDonDAO.GetTop(filters, null, -1);
        }

        public List<NhapHangInfo> GetNhapHang()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableNhapHang.MaNV, EqualityOperator.Equal, this.MaNV)
            };
            return NhapHangDAO.GetTop(filters, null, -1);
        }

        public List<TraHangInfo> GetTraHang()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableTraHang.MaNV, EqualityOperator.Equal, this.MaNV)
            };
            return TraHangDAO.GetTop(filters, null, -1);
        }

        public TaiKhoanInfo GetTaiKhoanOwner()
        {
            return TaiKhoanDAO.Find(this.TenTaiKhoan);
        }

        #endregion
      
        #endregion
    }
}
