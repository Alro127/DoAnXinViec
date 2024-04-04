using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoAnXinViec
{
    public class User
    {
        string id;
        string hoTen;
        string tinhThanh;
        string diaChi;
        string sDT;
        string email;
        string gT;
        string anh;

        public User() { }

        public User(string id, string hoTen, string tinhThanh, string diaChi, string sDT, string email, string gT, string anh)
        {
            this.id = id;
            this.hoTen = hoTen;
            this.tinhThanh = tinhThanh;
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.email = email;
            this.gT = gT;
            this.anh = anh;
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
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
        public string GT
        {
            get { return gT; }
            set
            {
                if (gT != value)
                {
                    gT = value;
                    OnPropertyChanged(nameof(GT));
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
