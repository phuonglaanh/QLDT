using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Loai
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }


        public Loai()
        {}
        public Loai(int maLoai, string tenLoai)
        {
            this.MaLoai = maLoai;
            this.TenLoai = tenLoai;
        }

    }
}
