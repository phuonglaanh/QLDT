using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class KetNois
	{
		
		SqlConnection conn;
		private void KetNoi()
		{
			conn = new SqlConnection(@"Server=DESKTOP-75UITL3\SQLEXPRESS;Initial Catalog=QLCuaHangDienThoai;Integrated Security=True");
			conn.Open();
		}

		private void NgatKetNoi()
		{
			conn.Close();
			conn.Dispose();
		}

		public DataTable LayDuLieu(String Ten)
		{
			KetNoi();
			SqlCommand cmd = new SqlCommand(Ten, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			NgatKetNoi();
			return dt;
		}

		public DataTable LayDuLieuCoDieuKien(String Ten, String[] name, object[] value, int Napra)
		{
			KetNoi();
			SqlCommand cmd = new SqlCommand(Ten, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < Napra; i++)
			{
				cmd.Parameters.AddWithValue(name[i], value[i]);
			}
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			NgatKetNoi();
			return dt;
		}

		public void ThucHien(string TenSanPham, string[] name, object[] value, int Napra)
		{
			KetNoi();
			SqlCommand cmd = new SqlCommand(TenSanPham, conn);
			for(int i =0; i<Napra; i++)
			{
				cmd.Parameters.AddWithValue(name[i], value[i]);
			}
			cmd.ExecuteNonQuery();
		}
		public enum DataProviderAction
		{
			Insert, Update, Delete
		}
		public enum Table
		{
			BangGia,
			BaoHanh,
			ChiTietHoaDon,
			ChiTietNhapHang,
			ChiTietTraHang,
			HangHoa,
			HoaDon,
			KhachHang,
			Loai,
			NhanVien,
			NhapHang,
			TaiKhoan,
			TraHang,
		}
		public enum TableBangGia
		{
			SoBangGia,
			MaHH,
			GiaBan,
			NgayApDung,
			NgayKetThuc,
			GiamGia,
		}
		public enum TableBaoHanh
		{
			SoPhieu,
			MaHH,
			SoEmei,
			MaKH,
			NgayMua,
			ThoiGianBaoHanh,
		}
		public enum TableChiTietHoaDon
		{
			MaKH,
			MaHH,
			SoLuong,
			GiaBan,
		}
		public enum TableChiTietNhapHang
		{
			MaPhieuNhap,
			MaHH,
			SoLuong,
			DonGia,
			ThanhTien,
		}
		public enum TableChiTietTraHang
		{
			MaPhieuTra,
			MaHH,
			SoLuong,
		}
		public enum TableHangHoa
		{
			MaHH,
			TenHH,
			SoLuong,
			NhaCC,
			MaLoai,
			DonViTinh,
			Hinh,
			TinhNang,
		}
		public enum TableHoaDon
		{
			SoHoaDon,
			MaNV,
			MaKH,
			NgayLap,
			TongTien,
		}
		public enum TableKhachHang
		{
			MaKH,
			TenKH,
			DiaChi,
			SDT,
			Mail,
		}
		public enum TableLoai
		{
			MaLoai,
			TenLoai,
		}
		public enum TableNhanVien
		{
			MaNV,
			TenNV,
			GioiTinh,
			NgaySinh,
			SDT,
			DiaChi,
			Mail,
			CMND,
			Hinh,
			TinhTrang,
			TenTaiKhoan,
		}
		public enum TableNhapHang
		{
			MaPhieuNhap,
			MaNV,
			TongSoLuong,
			NgayNhap,
			NhaCC,
			DienThoaiNCC,
			DiaChiNhaCC,
		}
		public enum TableTaiKhoan
		{
			TenTaiKhoan,
			MatKhau,
			ChucNang,
			Quyen,
		}
		public enum TableTraHang
		{
			MaPhieuTra,
			MaNV,
			TongSoLuong,
			NgayTra,
			NhaCC,
			DienThoaiNCC,
			DiaChiNhaCC,
		}
	}
}
