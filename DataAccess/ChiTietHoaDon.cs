using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ChiTietHoaDon
    {
        public int SoHoaDon { get; set; }
        public int MaKH { get; set; }
        public int MaHH { get; set; }
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }


        public ChiTietHoaDon()
        { }
        public ChiTietHoaDon(int soHD,int maKH,int maHH,int soLuong,int giaBan)
        {
            this.SoHoaDon = soHD;
            this.MaKH = maKH;
            this.MaHH = maHH;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
        }
    }
}
