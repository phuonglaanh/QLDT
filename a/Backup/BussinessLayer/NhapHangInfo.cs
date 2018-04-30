using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class NhapHangInfo
    {
        #region Fields
        private int _MaPhieuNhap;
        private int _MaNV;
        private int _TongSoLuong;
        private string _NgayNhap;
        private string _NhaCC;
        private string _DienThoaiNCC;
        private string _DiaChiNhaCC;

        #endregion

        #region Properties
        public int MaPhieuNhap
        {
            get { return _MaPhieuNhap; }
            set { _MaPhieuNhap = value; }
        }
        public int MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
        public int TongSoLuong
        {
            get { return _TongSoLuong; }
            set { _TongSoLuong = value; }
        }
        public string NgayNhap
        {
            get { return _NgayNhap; }
            set { _NgayNhap = value; }
        }
        public string NhaCC
        {
            get { return _NhaCC; }
            set { _NhaCC = value; }
        }
        public string DienThoaiNCC
        {
            get { return _DienThoaiNCC; }
            set { _DienThoaiNCC = value; }
        }
        public string DiaChiNhaCC
        {
            get { return _DiaChiNhaCC; }
            set { _DiaChiNhaCC = value; }
        }

        #endregion

        #region Contructors
        public NhapHangInfo()
        {
        }
        public NhapHangInfo(int maPhieuNhap)
        {
            _MaPhieuNhap = maPhieuNhap;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return NhapHangDAO.Insert(this);
        }
        public int Update()
        {
            return NhapHangDAO.Update(this);
        }
        public int Delete()
        {
            return NhapHangDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<ChiTietNhapHangInfo> GetChiTietNhapHang()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableChiTietNhapHang.MaPhieuNhap, EqualityOperator.Equal, this.MaPhieuNhap)
            };
            return ChiTietNhapHangDAO.GetTop(filters, null, -1);
        }

        public NhanVienInfo GetNhanVienOwner()
        {
            return NhanVienDAO.Find(this.MaNV);
        }

        #endregion
      
        #endregion
    }
}
