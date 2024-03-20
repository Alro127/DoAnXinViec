using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    class ThongTinHoSoUngTuyen
    {
        string tenHoSo;
        string viTriUngTuyen;
        string loaiHoSo;
        DateTime ngayNop;
        string trangThai;

        public ThongTinHoSoUngTuyen(string tenHoSo, string viTriUngTuyen, string loaiHoSo, DateTime ngayNop, string trangThai)
        {
            this.tenHoSo = tenHoSo;
            this.viTriUngTuyen = viTriUngTuyen;
            this.loaiHoSo = loaiHoSo;
            this.ngayNop = ngayNop;
            this.trangThai = trangThai;
        }

        public string TenHoSo { get => tenHoSo; set => tenHoSo = value; }
        public string ViTriUngTuyen { get => viTriUngTuyen; set => viTriUngTuyen = value; }
        public string LoaiHoSo { get => loaiHoSo; set => loaiHoSo = value; }
        public DateTime NgayNop { get => ngayNop; set => ngayNop = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
