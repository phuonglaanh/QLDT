using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class TraHangInfo
    {
        #region Fields
        private int _MaPhieuTra;
        private int _MaNV;
        private int _TongSoLuong;
        private string _NgayTra;
        private string _NhaCC;
        private string _DienThoaiNCC;
        private string _DiaChiNhaCC;

        #endregion

        #region Properties
        public int MaPhieuTra
        {
            get { return _MaPhieuTra; }
            set { _MaPhieuTra = value; }
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
        public string NgayTra
        {
            get { return _NgayTra; }
            set { _NgayTra = value; }
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
        public TraHangInfo()
        {
        }
        public TraHangInfo(int maPhieuTra)
        {
            _MaPhieuTra = maPhieuTra;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return TraHangDAO.Insert(this);
        }
        public int Update()
        {
            return TraHangDAO.Update(this);
        }
        public int Delete()
        {
            return TraHangDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<ChiTietTraHangInfo> GetChiTietTraHang()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableChiTietTraHang.MaPhieuTra, EqualityOperator.Equal, this.MaPhieuTra)
            };
            return ChiTietTraHangDAO.GetTop(filters, null, -1);
        }

        public NhanVienInfo GetNhanVienOwner()
        {
            return NhanVienDAO.Find(this.MaNV);
        }

        #endregion
      
        #endregion
    }
}
