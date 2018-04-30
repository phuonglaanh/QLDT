using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TaiKhoan
    {
		public string TenTaiKhoan { get; set; }
		public string MatKhau { get; set; }
		string[] name;
		object[] value;

		public TaiKhoan()
		{ }
		public TaiKhoan(string tenTK, string matKhau)
		{
			this.TenTaiKhoan = tenTK;
			this.MatKhau = matKhau;
		}

		QLTaiKhoan tk = new QLTaiKhoan();
		public DataTable DangNhap(String TK, String MK)
		{
			return tk.DangNhap(TK, MK);
		}
	}
}
