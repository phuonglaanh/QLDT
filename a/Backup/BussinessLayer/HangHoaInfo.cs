using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class HangHoaInfo
    {
        #region Fields
        private int _MaHH;
        private string _TenHH;
        private int _SoLuong;
        private string _NhaCC;
        private int _MaLoai;
        private string _DonViTinh;
        private string _Hinh;
        private string _TinhNang;

        #endregion

        #region Properties
        public int MaHH
        {
            get { return _MaHH; }
            set { _MaHH = value; }
        }
        public string TenHH
        {
            get { return _TenHH; }
            set { _TenHH = value; }
        }
        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        public string NhaCC
        {
            get { return _NhaCC; }
            set { _NhaCC = value; }
        }
        public int MaLoai
        {
            get { return _MaLoai; }
            set { _MaLoai = value; }
        }
        public string DonViTinh
        {
            get { return _DonViTinh; }
            set { _DonViTinh = value; }
        }
        public string Hinh
        {
            get { return _Hinh; }
            set { _Hinh = value; }
        }
        public string TinhNang
        {
            get { return _TinhNang; }
            set { _TinhNang = value; }
        }

        #endregion

        #region Contructors
        public HangHoaInfo()
        {
        }
        public HangHoaInfo(int maHH)
        {
            _MaHH = maHH;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return HangHoaDAO.Insert(this);
        }
        public int Update()
        {
            return HangHoaDAO.Update(this);
        }
        public int Delete()
        {
            return HangHoaDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<BangGiaInfo> GetBangGia()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableBangGia.MaHH, EqualityOperator.Equal, this.MaHH)
            };
            return BangGiaDAO.GetTop(filters, null, -1);
        }

        public List<ChiTietHoaDonInfo> GetChiTietHoaDon()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableChiTietHoaDon.MaHH, EqualityOperator.Equal, this.MaHH)
            };
            return ChiTietHoaDonDAO.GetTop(filters, null, -1);
        }

        public List<BaoHanhInfo> GetBaoHanh()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableBaoHanh.MaHH, EqualityOperator.Equal, this.MaHH)
            };
            return BaoHanhDAO.GetTop(filters, null, -1);
        }

        public List<ChiTietNhapHangInfo> GetChiTietNhapHang()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableChiTietNhapHang.MaHH, EqualityOperator.Equal, this.MaHH)
            };
            return ChiTietNhapHangDAO.GetTop(filters, null, -1);
        }

        public List<ChiTietTraHangInfo> GetChiTietTraHang()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableChiTietTraHang.MaHH, EqualityOperator.Equal, this.MaHH)
            };
            return ChiTietTraHangDAO.GetTop(filters, null, -1);
        }

        public LoaiInfo GetLoaiOwner()
        {
            return LoaiDAO.Find(this.MaLoai);
        }

        #endregion
      
        #endregion
    }
}
