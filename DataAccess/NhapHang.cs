using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NhapHang
    {
        public int MaPhieuNhap { get; set; }
        public int MaNV { get; set; }
        public int TongSoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
        public string NhaCC { get; set; }
        public string DienThoaiNCC { get; set; }
        public string DiaChiNhaCC { get; set; }



        public NhapHang()
        { }
        public NhapHang(int maPhieuNhap, int maNV, int tongSoLuong, DateTime ngayNhap, string nhaCC, string dienThoaiNCC, string diaChiNhaCC)
        {
            this.MaPhieuNhap = maPhieuNhap;
            this.MaNV = maNV;
            this.TongSoLuong = tongSoLuong;
            this.NgayNhap = ngayNhap;
            this.NhaCC = nhaCC;
            this.DienThoaiNCC = dienThoaiNCC;
            this.DiaChiNhaCC = diaChiNhaCC;
        }


    }
}
