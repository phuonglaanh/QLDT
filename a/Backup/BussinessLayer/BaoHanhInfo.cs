using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class BaoHanhInfo
    {
        #region Fields
        private int _SoPhieu;
        private int _MaHH;
        private string _SoEmei;
        private int _MaKH;
        private string _NgayMua;
        private int _ThoiGianBaoHanh;

        #endregion

        #region Properties
        public int SoPhieu
        {
            get { return _SoPhieu; }
            set { _SoPhieu = value; }
        }
        public int MaHH
        {
            get { return _MaHH; }
            set { _MaHH = value; }
        }
        public string SoEmei
        {
            get { return _SoEmei; }
            set { _SoEmei = value; }
        }
        public int MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }
        public string NgayMua
        {
            get { return _NgayMua; }
            set { _NgayMua = value; }
        }
        public int ThoiGianBaoHanh
        {
            get { return _ThoiGianBaoHanh; }
            set { _ThoiGianBaoHanh = value; }
        }

        #endregion

        #region Contructors
        public BaoHanhInfo()
        {
        }
        public BaoHanhInfo(int soPhieu)
        {
            _SoPhieu = soPhieu;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return BaoHanhDAO.Insert(this);
        }
        public int Update()
        {
            return BaoHanhDAO.Update(this);
        }
        public int Delete()
        {
            return BaoHanhDAO.Delete(this);
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
