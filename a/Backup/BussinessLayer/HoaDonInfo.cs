using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class HoaDonInfo
    {
        #region Fields
        private int _SoHoaDon;
        private int _MaNV;
        private int _MaKH;
        private string _NgayLap;
        private float _TongTien;

        #endregion

        #region Properties
        public int SoHoaDon
        {
            get { return _SoHoaDon; }
            set { _SoHoaDon = value; }
        }
        public int MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
        public int MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }
        public string NgayLap
        {
            get { return _NgayLap; }
            set { _NgayLap = value; }
        }
        public float TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }

        #endregion

        #region Contructors
        public HoaDonInfo()
        {
        }
        public HoaDonInfo(int soHoaDon)
        {
            _SoHoaDon = soHoaDon;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return HoaDonDAO.Insert(this);
        }
        public int Update()
        {
            return HoaDonDAO.Update(this);
        }
        public int Delete()
        {
            return HoaDonDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public KhachHangInfo GetKhachHangOwner()
        {
            return KhachHangDAO.Find(this.MaKH);
        }

        public NhanVienInfo GetNhanVienOwner()
        {
            return NhanVienDAO.Find(this.MaNV);
        }

        #endregion
      
        #endregion
    }
}
