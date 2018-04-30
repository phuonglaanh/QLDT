using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BangGia
    {
        public int SoBangGia { get; set; }
        public int MaHH { get; set; }
        public int GiaBan { get; set; }
        public DateTime NgayApDung { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int GiamGia { get; set; }

        public BangGia()
        {

        }
        public BangGia(int soBangGia, int maHH, int giaBan, DateTime ngayApDung, DateTime ngayKetThuc, int giamGia)
        {
            SoBangGia = soBangGia;
            MaHH = maHH;
            GiaBan = giaBan;
            NgayApDung = ngayApDung;
            NgayKetThuc = ngayKetThuc;
            GiamGia = giamGia;
        }
       


    }
}
