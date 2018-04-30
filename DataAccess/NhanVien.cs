using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class NhanVien
	{
		public int MaNV {get;set; }
		public string TenNV {get;set; }
		public bool GioiTinh {get;set; }
		public DateTime NgaySinh {get;set; }
		public string SDT {get;set; }
		public string DiaChi {get;set; }
		public string Mail {get;set;}
		public string CMND { get; set; }
		public string Hinh {get;set; }
		public bool TinhTrang {get;set; }
		public string TenTaiKhoan {get;set; }

		public NhanVien()
		{
		}
		public NhanVien(int maNV, string tenNV, bool gioiTinh, DateTime ngaySinh, string sDT, string diaChi, string mail, string cMND, string hinh, string tenTaiKhoan)
		{
			MaNV = maNV;
			TenNV = tenNV;
			GioiTinh = gioiTinh;
			NgaySinh = ngaySinh;
			SDT = sDT;
			DiaChi = diaChi;
			Mail = mail;
			CMND = cMND;
			Hinh = hinh;
			TenTaiKhoan = TenTaiKhoan;

		}
	}
}
