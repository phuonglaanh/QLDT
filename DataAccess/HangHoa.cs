using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HangHoa
    {
        public int MaHH { get; set; }
        public string TenHH { get; set; }
        public int SoLuong { get; set; }
        public string NhaCC { get; set; }
        public int MaLoai { get; set; }
        public string DonViTinh { get; set; }
        public string Hinh { get; set; }
        public string TinhNang { get; set; }



        public HangHoa()
        { }
        public HangHoa(int maHH, string tenHH, int soLuong, string nhaCC, int maLoai, string donViTinh, string hinh, string tinhNang)
        {
            this.MaHH = maHH;
            this.TenHH = tenHH;
            this.SoLuong = soLuong;
            this.NhaCC = nhaCC;
            this.MaLoai = maLoai;
            this.DonViTinh = donViTinh;
            this.Hinh = hinh;
            this.TinhNang = tinhNang;
        }

		public override string ToString()
		{
			return this.TenHH;
		}
	}
}
