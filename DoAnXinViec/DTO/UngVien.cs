using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnXinViec
{
    public class UngVien: User
    {
        string gioiTinh;
        DateTime ngaySinh;

        public UngVien() { }

        public UngVien(DataRow dr)
        {
            Utility.SetItemFromRow(this, dr);
        }

        public UngVien(UngVien ungvien)
        {
            var properties = typeof(UngVien).GetProperties();

            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(ungvien));
                }
            }
        }

        public UngVien(string id, string hoTen, string gioiTinh, DateTime ngaySinh, string tinhThanh, string diaChi, string sDT, string email, string gT, string anh):base(id, hoTen, tinhThanh, diaChi, sDT, email, gT, anh)
        {
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
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
    }
}
