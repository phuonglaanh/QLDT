using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class KhachHangInfo
    {
        #region Fields
        private int _MaKH;
        private string _TenKH;
        private string _DiaChi;
        private string _SDT;
        private string _Mail;

        #endregion

        #region Properties
        public int MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }
        public string TenKH
        {
            get { return _TenKH; }
            set { _TenKH = value; }
        }
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }

        #endregion

        #region Contructors
        public KhachHangInfo()
        {
        }
        public KhachHangInfo(int maKH)
        {
            _MaKH = maKH;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return KhachHangDAO.Insert(this);
        }
        public int Update()
        {
            return KhachHangDAO.Update(this);
        }
        public int Delete()
        {
            return KhachHangDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<HoaDonInfo> GetHoaDon()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableHoaDon.MaKH, EqualityOperator.Equal, this.MaKH)
            };
            return HoaDonDAO.GetTop(filters, null, -1);
        }

        public List<ChiTietHoaDonInfo> GetChiTietHoaDon()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableChiTietHoaDon.MaKH, EqualityOperator.Equal, this.MaKH)
            };
            return ChiTietHoaDonDAO.GetTop(filters, null, -1);
        }

        public List<BaoHanhInfo> GetBaoHanh()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableBaoHanh.MaKH, EqualityOperator.Equal, this.MaKH)
            };
            return BaoHanhDAO.GetTop(filters, null, -1);
        }

        #endregion
      
        #endregion
    }
}
