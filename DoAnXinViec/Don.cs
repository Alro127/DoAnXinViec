using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnXinViec
{
    class Don
    {
        int idCV;
        string tenCV;
        string idCT;
        string diaDiem;
        int luong;
        string ngayToiHan;
        Image anh;
        string moTaCV;
        string yeuCau;
        string quyenLoi;
        public Don() { }

        public Don(int idCV, string tenCV, string idCT, string diaDiem, int luong, string ngayToiHan, Image anh, string moTaCV, string yeuCau, string quyenLoi)
        {
            this.idCV = idCV;
            this.tenCV = tenCV;
            this.idCT = idCT;
            this.diaDiem = diaDiem;
            this.luong = luong;
            this.ngayToiHan = ngayToiHan;
            this.anh = anh;
            this.moTaCV = moTaCV;
            this.yeuCau = yeuCau;
            this.quyenLoi = quyenLoi;
        }

        public string TenCV { get => tenCV; set => tenCV = value; }
        public string IdCT { get => idCT; set => idCT = value; }
        public string DiaDiem { get => diaDiem; set => diaDiem = value; }
        public int Luong { get => luong; set => luong = value; }
        public string NgayToiHan { get => ngayToiHan; set => ngayToiHan = value; }
        public Image Anh { get => anh; set => anh = value; }
        public string MoTaCV { get => moTaCV; set => moTaCV = value; }
        public string YeuCau { get => yeuCau; set => yeuCau = value; }
        public string QuyenLoi { get => quyenLoi; set => quyenLoi = value; }
        public int IdCV { get => idCV; set => idCV = value; }
    }
}
