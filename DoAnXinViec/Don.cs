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
        DateTime ngayDang;
        DateTime ngayToiHan;
        string anh;
        string moTaCV;
        string yeuCau;
        string quyenLoi;
        int luotXem;
        int luotNop;
        public Don() { }

        public Don(int idCV, string tenCV, string idCT, string diaDiem, int luong, DateTime ngayDang, DateTime ngayToiHan, string anh, string moTaCV, string yeuCau, string quyenLoi, int luotXem, int luotNop)
        {
            this.idCV = idCV;
            this.tenCV = tenCV;
            this.idCT = idCT;
            this.diaDiem = diaDiem;
            this.luong = luong;
            this.NgayDang = ngayDang;
            this.ngayToiHan = ngayToiHan;
            this.anh = anh;
            this.moTaCV = moTaCV;
            this.yeuCau = yeuCau;
            this.quyenLoi = quyenLoi;
            this.LuotXem = luotXem;
            this.LuotNop = luotNop;
        }

        public string TenCV { get => tenCV; set => tenCV = value; }
        public string IdCT { get => idCT; set => idCT = value; }
        public string DiaDiem { get => diaDiem; set => diaDiem = value; }
        public int Luong { get => luong; set => luong = value; }
        public DateTime NgayToiHan { get => ngayToiHan; set => ngayToiHan = value; }
        public string Anh { get => anh; set => anh = value; }
        public string MoTaCV { get => moTaCV; set => moTaCV = value; }
        public string YeuCau { get => yeuCau; set => yeuCau = value; }
        public string QuyenLoi { get => quyenLoi; set => quyenLoi = value; }
        public int IdCV { get => idCV; set => idCV = value; }
        public int LuotXem { get => luotXem; set => luotXem = value; }
        public int LuotNop { get => luotNop; set => luotNop = value; }
        public DateTime NgayDang { get => ngayDang; set => ngayDang = value; }
    }
}
