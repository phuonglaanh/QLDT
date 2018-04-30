using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class BangGiaInfo
    {
        #region Fields
        private int _SoBangGia;
        private int _MaHH;
        private int _GiaBan;
        private string _NgayApDung;
        private string _NgayKetThuc;
        private int _GiamGia;

        #endregion

        #region Properties
        public int SoBangGia
        {
            get { return _SoBangGia; }
            set { _SoBangGia = value; }
        }
        public int MaHH
        {
            get { return _MaHH; }
            set { _MaHH = value; }
        }
        public int GiaBan
        {
            get { return _GiaBan; }
            set { _GiaBan = value; }
        }
        public string NgayApDung
        {
            get { return _NgayApDung; }
            set { _NgayApDung = value; }
        }
        public string NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set { _NgayKetThuc = value; }
        }
        public int GiamGia
        {
            get { return _GiamGia; }
            set { _GiamGia = value; }
        }

        #endregion

        #region Contructors
        public BangGiaInfo()
        {
        }
        public BangGiaInfo(int soBangGia)
        {
            _SoBangGia = soBangGia;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return BangGiaDAO.Insert(this);
        }
        public int Update()
        {
            return BangGiaDAO.Update(this);
        }
        public int Delete()
        {
            return BangGiaDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public HangHoaInfo GetHangHoaOwner()
        {
            return HangHoaDAO.Find(this.MaHH);
        }

        #endregion
      
        #endregion
    }
}
