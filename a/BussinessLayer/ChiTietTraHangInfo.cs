using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ChiTietTraHangInfo
    {
        #region Fields
        private int _MaPhieuTra;
        private int _MaHH;
        private int _SoLuong;

        #endregion

        #region Properties
        public int MaPhieuTra
        {
            get { return _MaPhieuTra; }
            set { _MaPhieuTra = value; }
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

        #endregion

        #region Contructors
        public ChiTietTraHangInfo()
        {
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return ChiTietTraHangDAO.Insert(this);
        }
        public int Update()
        {
            return ChiTietTraHangDAO.Update(this);
        }
        public int Delete()
        {
            return ChiTietTraHangDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public HangHoaInfo GetHangHoaOwner()
        {
            return HangHoaDAO.Find(this.MaHH);
        }

        public TraHangInfo GetTraHangOwner()
        {
            return TraHangDAO.Find(this.MaPhieuTra);
        }

        #endregion
      
        #endregion
    }
}
