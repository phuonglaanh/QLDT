using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ChiTietNhapHang
    {
        public int MaPhieuNhap { get; set; }
        public int MaHH { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public float ThanhTien { get; set; }

        public ChiTietNhapHang()
        { }
        public ChiTietNhapHang(int maPhieuNhap, int maHH, int soLuong, int donGia,float thanhTien)
        {
            this.MaPhieuNhap = maPhieuNhap;
            this.MaHH = maHH;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }
    }
}
