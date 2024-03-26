using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;

namespace DoAnXinViec
{
    class HoSo: INotifyPropertyChanged
    {
        int idCV;
        string idUV;
        string tenHoSo;
        string viTriUngTuyen;
        string loaiHoSo;
        DateTime ngayNop;
        string trangThai;

        public HoSo() { }
        public HoSo(int idCV, string idUV, string loaiHoSo, DateTime ngayNop, string trangThai)
        {
            this.idCV = idCV;
            this.idUV = idUV;
            this.loaiHoSo = loaiHoSo;
            this.ngayNop = ngayNop;
            this.trangThai = trangThai;
        }

        public HoSo(int idCV, string idUV, string tenHoSo, string viTriUngTuyen, string loaiHoSo, DateTime ngayNop, string trangThai)
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
        public string TrangThai
        {
            get => trangThai;
            set
            {
                if (trangThai != value)
                {
                    trangThai = value;
                    OnPropertyChanged("TrangThai");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
