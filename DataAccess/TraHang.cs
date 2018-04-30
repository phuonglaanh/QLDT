using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class TraHang
    {
        public int MaPhieuTra { get; set; }
        public int MaNV { get; set; }
        public int TongSoLuong { get; set; }
        public DateTime NgayTra { get; set; }
        public string NhaCC { get; set; }
        public string DienThoaiNCC { get; set; }
        public string DiaChiNhaCC { get; set; }



        public TraHang()
        {

        }
        public TraHang(int maPhieuTra, int maNV, int tongSoLuong, DateTime ngayTra, string nhaCC, string dienThoaiNCC, string diaChiNhaCC)
        {
            this.MaPhieuTra = maPhieuTra;
            this.MaNV = maNV;
            this.TongSoLuong = tongSoLuong;
            this.NgayTra = ngayTra;
            this.NhaCC = nhaCC;
            this.DienThoaiNCC = dienThoaiNCC;
            this.DiaChiNhaCC = diaChiNhaCC;
        }
    }
}
