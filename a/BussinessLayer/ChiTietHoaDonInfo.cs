using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ChiTietHoaDonInfo
    {
        #region Fields
        private int _MaKH;
        private int _MaHH;
        private int _SoLuong;
        private int _GiaBan;

        #endregion

        #region Properties
        public int MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
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
        public int GiaBan
        {
            get { return _GiaBan; }
            set { _GiaBan = value; }
        }

        #endregion

        #region Contructors
        public ChiTietHoaDonInfo()
        {
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return ChiTietHoaDonDAO.Insert(this);
        }
        public int Update()
        {
            return ChiTietHoaDonDAO.Update(this);
        }
        public int Delete()
        {
            return ChiTietHoaDonDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public HangHoaInfo GetHangHoaOwner()
        {
            return HangHoaDAO.Find(this.MaHH);
        }

        public KhachHangInfo GetKhachHangOwner()
        {
            return KhachHangDAO.Find(this.MaKH);
        }

        #endregion
      
        #endregion
    }
}
