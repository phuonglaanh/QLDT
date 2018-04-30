using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class Phanquyen
	{
		private String MenuID { get; set; }
		private String TenTaiKhoan { get; set; }
		private bool PhanQuyen { get; set; }
		private bool MatKhau { get; set; }
		private bool NguoiDung { get; set; }
		private bool DangXuat { get; set; }
		private bool HoaDon { get; set; }
		private bool XemSanPham { get; set; }
		private bool BaoHanh { get; set; }
		private bool NhapHang { get; set; }
		private bool TraHang { get; set; }
		private bool KhachHang { get; set; }
		private bool MatHang { get; set; }
		private bool ThongTinNhanVien { get; set; }
		private bool BangGia { get; set; }
		private bool ThongKeDoanhThu { get; set; }
		private bool ThongKeKhachhang { get; set; }
		private bool ThongKeMatHang { get; set; }

		public Phanquyen()
		{

		}

		public Phanquyen(String menuID, String tenTaiKhoan, bool phanQuyen, bool matKhau, bool nguoiDung, bool dangXuat, bool hoaDon, bool xemSanPham, bool baoHanh, bool nhapHang, bool traHang, bool khachHang, bool matHang, bool thongTinNhanVien, bool bangGia, bool thongKeDoanhThu, bool thongKeKhachhang, bool thongKeMatHang)
		{
			this.MenuID = menuID;
			this.TenTaiKhoan = tenTaiKhoan;
			this.PhanQuyen = phanQuyen;
			this.MatKhau = matHang;
			this.NguoiDung = nguoiDung;
			this.DangXuat = dangXuat;
			this.HoaDon = hoaDon;
			this.XemSanPham = xemSanPham;
			this.BangGia = bangGia;
			this.NhapHang = nhapHang;
			this.TraHang = traHang;
			this.KhachHang = khachHang;
			this.MatHang = matHang;
			this.ThongTinNhanVien = thongTinNhanVien;
			this.BangGia = bangGia;
			this.ThongKeDoanhThu = thongKeDoanhThu;
			this.ThongKeKhachhang = thongKeKhachhang;
			this.ThongKeMatHang = thongKeMatHang;
		}

		string[] name;
		object[] value;
		public void PhanQuyen_Insert(String MenuID, String TenTaiKhoan, bool PhanQuyen, bool MatKhau, bool NguoiDung, bool DangXuat, bool HoaDon, bool XemSanPham, bool BaoHanh, bool NhapHang, bool TraHang, bool KhachHang, bool MatHang, bool ThongTinNhanVien, bool BangGia, bool ThongKeDoanhThu, bool ThongKeKhachhang, bool ThongKeMatHang)
		{
			name = new string[18];
			value = new object[18];
			name[0] = "@MenuID"; value[0] = MenuID;
			name[1] = "@TenTaiKhoan"; value[1] = TenTaiKhoan;
			name[2] = "@PhanQuyen"; value[2] = PhanQuyen;
			name[3] = "@MatKhau"; value[3] = MatKhau;
			name[4] = "@NguoiDung"; value[4] = NguoiDung;
			name[5] = "@DangXuat"; value[5] = DangXuat;
			name[6] = "@HoaDon"; value[6] = HoaDon;
			name[7] = "@XemSanPham"; value[7] = XemSanPham;
			name[8] = "@BaoHanh"; value[8] = BaoHanh;
			name[9] = "@NhapHang"; value[9] = NhapHang;
			name[10] = "@TraHang"; value[10] = TraHang;
			name[11] = "@KhachHang"; value[11] = KhachHang;
			name[12] = "@MatHang"; value[12] = MatHang;
			name[13] = "@ThongTinNhanVien"; value[13] = ThongTinNhanVien;
			name[14] = "@BangGia"; value[14] = BangGia;
			name[15] = "@ThongKeDoanhThu"; value[15] = ThongKeDoanhThu;
			name[16] = "@ThongKeKhachhang"; value[16] = ThongKeKhachhang;
			name[17] = "@ThongKeMatHang"; value[17] = ThongKeMatHang;
		}
	}
}
