using System.Data;

namespace DataAccess
{
	public class QLPhanQuyen
	{
		KetNois qltk = new KetNois();
		public DataTable PhanQuyenChucNang_Get()
		{
			return qltk.LayDuLieu("PhanQuyen_GetAll");
		}

		public DataTable MenuPhanQuyen()
		{
			return qltk.LayDuLieu("MenuPQ_GetAll");
		}
		//TaiKhoanUser
		public DataTable TenTaiKhoan()
		{
			return qltk.LayDuLieu("TaiKhoanUser");
		}
	}
}
