using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
            
            try
            {
                Id = id;
                HoTen = hoTen;
                TinhThanh = tinhThanh;
                DiaChi = diaChi;
                SDT = sDT;
                Email = email;
                GT = gT;
                Anh = anh;
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống Id");
                }
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string HoTen
        {
            get { return hoTen; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống họ tên");
                }
                hoTen = value;
                OnPropertyChanged(nameof(HoTen));
            }
        }

        public string TinhThanh
        {
            get { return tinhThanh; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống tỉnh thành");
                }
                tinhThanh = value;
                OnPropertyChanged(nameof(TinhThanh));
            }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống địa chỉ");
                }
                diaChi = value;
                OnPropertyChanged(nameof(DiaChi));
            }
        }

        public string SDT
        {
            get { return sDT; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống số điện thoại");
                }
                sDT = value;
                OnPropertyChanged(nameof(SDT));
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống địa chỉ email");
                }
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string GT
        {
            get { return gT; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống phần giới thiệu");
                }
                gT = value;
                OnPropertyChanged(nameof(GT));
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
