using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ChiTietTraHang
    {
        public int MaPhieuTra { get; set; }
        public int MaHH { get; set; }
        public int SoLuong { get; set; }

        public ChiTietTraHang()
        { }
        public ChiTietTraHang(int maPhieuTra, int maHH, int soLuong)
        {
            this.MaPhieuTra = maPhieuTra;
            this.MaHH = maHH;
            this.SoLuong = soLuong;
        }
    }
}
