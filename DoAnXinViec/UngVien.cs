using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnXinViec
{
    class UngVien
    {
        string hoTen;
        string gioiTinh;
        DateTime ngaySinh;
        string tinhThanh;
        string diaChi;
        string sdt;
        string email;
        Image anh;

        public UngVien(string hoTen, string gioiTinh, DateTime ngaySinh, string tinhThanh, string diaChi, string sdt, string email, Image anh)
        {
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.tinhThanh = tinhThanh;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.email = email;
            this.anh = anh;
        }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string TinhThanh { get => tinhThanh; set => tinhThanh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public Image Anh { get => anh; set => anh = value; }
    }
}
