using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HoaDon
	{
		public int SoHoaDon {get;set ;}
		public int MaNV {get;set ;}
		public int MaKH {get;set ;}
		public string NgayLap {get;set ;}
		public float TongTien {get;set ;}

		public HoaDon()
		{
		}
		public HoaDon(int soHoaDon, int maNV, int maKH, string ngayLap, float tongTien)
		{
			SoHoaDon = soHoaDon;
		}
	}
}
