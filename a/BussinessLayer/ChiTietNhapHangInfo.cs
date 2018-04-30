using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ChiTietNhapHangInfo
    {
        #region Fields
        private int _MaPhieuNhap;
        private int _MaHH;
        private int _SoLuong;
        private int _DonGia;
        private float _ThanhTien;

        #endregion

        #region Properties
        public int MaPhieuNhap
        {
            get { return _MaPhieuNhap; }
            set { _MaPhieuNhap = value; }
        }
        public int MaHH
        {
            get { return _MaHH; }
            set { _MaHH = value; }
        }
        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        public int DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        public float ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }

        #endregion

        #region Contructors
        public ChiTietNhapHangInfo()
        {
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return ChiTietNhapHangDAO.Insert(this);
        }
        public int Update()
        {
            return ChiTietNhapHangDAO.Update(this);
        }
        public int Delete()
        {
            return ChiTietNhapHangDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public HangHoaInfo GetHangHoaOwner()
        {
            return HangHoaDAO.Find(this.MaHH);
        }

        public NhapHangInfo GetNhapHangOwner()
        {
            return NhapHangDAO.Find(this.MaPhieuNhap);
        }

        #endregion
      
        #endregion
    }
}
