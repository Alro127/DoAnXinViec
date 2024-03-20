using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    class HoSo
    {
        int idCV;
        string idUV;
        string tenHoSo;
        string viTriUngTuyen;
        string loaiHoSo;
        DateTime ngayNop;
        int trangThai;

        public HoSo(int idCV, string idUV, string loaiHoSo, DateTime ngayNop, int trangThai)
        {
            this.idCV = idCV;
            this.idUV = idUV;
            this.loaiHoSo = loaiHoSo;
            this.ngayNop = ngayNop;
            this.trangThai = trangThai;
        }

        public HoSo(int idCV, string idUV, string tenHoSo, string viTriUngTuyen, string loaiHoSo, DateTime ngayNop, int trangThai)
        {
            this.idCV = idCV;
            this.idUV = idUV;
            this.tenHoSo = tenHoSo;
            this.viTriUngTuyen = viTriUngTuyen;
            this.loaiHoSo = loaiHoSo;
            this.ngayNop = ngayNop;
            this.trangThai = trangThai;
        }

        public int IdCV { get => idCV; set => idCV = value; }
        public string IdUV { get => idUV; set => idUV = value; }
        public string TenHoSo { get => tenHoSo; set => tenHoSo = value; }
        public string ViTriUngTuyen { get => viTriUngTuyen; set => viTriUngTuyen = value; }
        public string LoaiHoSo { get => loaiHoSo; set => loaiHoSo = value; }
        public DateTime NgayNop { get => ngayNop; set => ngayNop = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
