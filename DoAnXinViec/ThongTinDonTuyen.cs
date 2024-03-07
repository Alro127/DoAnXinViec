using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    class ThongTinDonTuyen
    {
        string ten;
        DateTime ngaydang;
        DateTime toihan;
        int luotnop;
        int luotxem;
        public ThongTinDonTuyen()
        { }
        public ThongTinDonTuyen(string ten, DateTime ngaydang, DateTime toihan, int luotnop, int luotxem)
        {
            this.Ten = ten;
            this.Ngaydang = ngaydang;
            this.Toihan = toihan;
            this.Luotnop = luotnop;
            this.Luotxem = luotxem;
        }

        public string Ten { get => ten; set => ten = value; }
        public DateTime Ngaydang { get => ngaydang; set => ngaydang = value; }
        public DateTime Toihan { get => toihan; set => toihan = value; }
        public int Luotnop { get => luotnop; set => luotnop = value; }
        public int Luotxem { get => luotxem; set => luotxem = value; }
    }
}
