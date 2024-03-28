using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnXinViec
{
    public class UngVien: INotifyPropertyChanged
    {
        string idUV;
        string hoTen;
        string gioiTinh;
        DateTime ngaySinh;
        string tinhThanh;
        string diaChi;
        string sDT;
        string email;
        string anh;

        public UngVien() { }

        public UngVien(string idUV, string hoTen, string gioiTinh, DateTime ngaySinh, string tinhThanh, string diaChi, string sDT, string email, string anh)
        {
            this.idUV = idUV;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.tinhThanh = tinhThanh;
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.email = email;
            this.anh = anh;
        }

        public string IdUV
        {
            get { return idUV; }
            set
            {
                if (idUV != value)
                {
                    idUV = value;
                    OnPropertyChanged(nameof(IdUV));
                }
            }
        }

        public string HoTen
        {
            get { return hoTen; }
            set
            {
                if (hoTen != value)
                {
                    hoTen = value;
                    OnPropertyChanged(nameof(HoTen));
                }
            }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set
            {
                if (gioiTinh != value)
                {
                    gioiTinh = value;
                    OnPropertyChanged(nameof(GioiTinh));
                }
            }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set
            {
                if (ngaySinh != value)
                {
                    ngaySinh = value;
                    OnPropertyChanged(nameof(NgaySinh));
                }
            }
        }

        public string TinhThanh
        {
            get { return tinhThanh; }
            set
            {
                if (tinhThanh != value)
                {
                    tinhThanh = value;
                    OnPropertyChanged(nameof(TinhThanh));
                }
            }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set
            {
                if (diaChi != value)
                {
                    diaChi = value;
                    OnPropertyChanged(nameof(DiaChi));
                }
            }
        }

        public string SDT
        {
            get { return sDT; }
            set
            {
                if (sDT != value)
                {
                    sDT = value;
                    OnPropertyChanged(nameof(SDT));
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Anh
        {
            get { return anh; }
            set
            {
                if (anh != value)
                {
                    anh = value;
                    OnPropertyChanged(nameof(Anh));
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
