using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class LoaiInfo
    {
        #region Fields
        private int _MaLoai;
        private string _TenLoai;

        #endregion

        #region Properties
        public int MaLoai
        {
            get { return _MaLoai; }
            set { _MaLoai = value; }
        }
        public string TenLoai
        {
            get { return _TenLoai; }
            set { _TenLoai = value; }
        }

        #endregion

        #region Contructors
        public LoaiInfo()
        {
        }
        public LoaiInfo(int maLoai)
        {
            _MaLoai = maLoai;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return LoaiDAO.Insert(this);
        }
        public int Update()
        {
            return LoaiDAO.Update(this);
        }
        public int Delete()
        {
            return LoaiDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<HangHoaInfo> GetHangHoa()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableHangHoa.MaLoai, EqualityOperator.Equal, this.MaLoai)
            };
            return HangHoaDAO.GetTop(filters, null, -1);
        }

        #endregion
      
        #endregion
    }
}
