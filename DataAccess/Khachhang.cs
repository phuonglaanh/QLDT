using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class Khachhang
	{
		public int MaKH     { get; set; }
		public string TenKH {get; set; }
		public string DiaChi{get; set; }
		public string SDT   {get; set; }
		public string Mail  {get; set; }

		public Khachhang()
		{
		}
		public Khachhang(int maKH, string tenKH, string diaChi, string sDT, string mail)
		{
			MaKH = maKH;
			TenKH = tenKH;
			DiaChi = diaChi;
			SDT = sDT;
			Mail = mail;
		}
		public override string ToString()
		{
			return this.TenKH;
		}
	}
}
