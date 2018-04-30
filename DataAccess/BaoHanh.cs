using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaoHanh
    {
        public int SoPhieu { get; set; }
        public string TenHH { get; set; }
        public string SoEmei { get; set; }
        public string TenKH { get; set; }
        public DateTime NgayMua { get; set; }
        public string ThoiGianBaoHanh { get; set; }

        public BaoHanh()
        {

        }
        public BaoHanh(int soPhieu, string tenHH,string soEmei,string tenKH, DateTime ngayMua, string thoiGianBaoHanh)
        {
            this.SoPhieu = soPhieu;
            this.TenHH = tenHH;
            this.SoEmei = soEmei;
            this.TenHH = tenKH;
            this.NgayMua = ngayMua;
            this.ThoiGianBaoHanh = thoiGianBaoHanh;
        }
    }
}
