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
        string hoTen;
        string sdt;
        string email;
        string tenCty;
        string lingVuc;
        int quyMoNhanSu;
        string tinhThanh;
        string diaChi;
        string link;
        string gTCT;
        Image anh;

        public CongTy(string hoTen, string sdt, string email, string tenCty, string lingVuc, int quyMoNhanSu, string tinhThanh, string diaChi, string link, string gTCT, Image anh)
        {
            this.hoTen = hoTen;
            this.sdt = sdt;
            this.email = email;
            this.tenCty = tenCty;
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
        public string TenCty { get => tenCty; set => tenCty = value; }
        public string LingVuc { get => lingVuc; set => lingVuc = value; }
        public int QuyMoNhanSu { get => quyMoNhanSu; set => quyMoNhanSu = value; }
        public string TinhThanh { get => tinhThanh; set => tinhThanh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Link { get => link; set => link = value; }
        public string GTCT { get => gTCT; set => gTCT = value; }
        public Image Anh { get => anh; set => anh = value; }
    }
}
