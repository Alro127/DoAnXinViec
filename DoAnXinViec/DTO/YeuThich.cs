using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    public class YeuThich
    {
        int idCV;
        string idCT;

        public YeuThich(int idCV, string idCT)
        {
            this.idCV = idCV;
            this.idCT = idCT;
        }
        public YeuThich() { }
        public int IdCV { get => idCV; set => idCV = value; }
        public string IdCT { get => idCT; set => idCT = value; }
    }
}
