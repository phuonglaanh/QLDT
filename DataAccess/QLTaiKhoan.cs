using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
	public class QLTaiKhoan
	{
		string[] name;
		object[] value;
		KetNois qltt = new KetNois();
		public DataTable DangNhap(String TenTK, String MK)
		{
			name = new string[2];
			value = new object[2];
			name[0] = "@TenTaiKhoan"; value[0] = TenTK;
			name[1] = "@MatKhau"; value[1] = MK;
			return qltt.LayDuLieuCoDieuKien("DangNhap_Select", name, value, 2);
		}

	}
}
