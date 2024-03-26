using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnXinViec
{
    class CongTy
    {
        string idCT;
        string hoTen;
        string sdt;
        string email;
        string tenCT;
        string maSoThue;
        string gPKD;
        string lingVuc;
        int quyMoNhanSu;
        string tinhThanh;
        string diaChi;
        string link;
        string gTCT;
        string anh;

        public CongTy() { }
        public CongTy(string idCT, string hoTen, string sdt, string email, string tenCT, string maSoThue, string gPKD, string lingVuc, int quyMoNhanSu, string tinhThanh, string diaChi, string link, string gTCT, string anh)
        {
            this.idCT = idCT;
            this.hoTen = hoTen;
            this.sdt = sdt;
            this.email = email;
            this.tenCT = tenCT;
            this.maSoThue = maSoThue;
            this.gPKD = gPKD;
            this.lingVuc = lingVuc;
            this.quyMoNhanSu = quyMoNhanSu;
            this.tinhThanh = tinhThanh;
            this.diaChi = diaChi;
            this.link = link;
            this.gTCT = gTCT;
            this.anh = anh;
        }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string TenCT { get => tenCT; set => tenCT = value; }
        public string LingVuc { get => lingVuc; set => lingVuc = value; }
        public int QuyMoNhanSu { get => quyMoNhanSu; set => quyMoNhanSu = value; }
        public string TinhThanh { get => tinhThanh; set => tinhThanh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Link { get => link; set => link = value; }
        public string GTCT { get => gTCT; set => gTCT = value; }
        public string Anh { get => anh; set => anh = value; }
        public string MaSoThue { get => maSoThue; set => maSoThue = value; }
        public string GPKD { get => gPKD; set => gPKD = value; }
        public string IdCT { get => idCT; set => idCT = value; }
    }
}
