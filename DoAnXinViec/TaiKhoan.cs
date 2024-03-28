using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    internal class TaiKhoan
    {
        string tenTK;
        string matKhau;
        string quyen;
        public TaiKhoan(string tenTK, string matKhau, string quyen)
        {
            this.TenTK = tenTK;
            this.MatKhau = matKhau;
            this.Quyen = quyen;
        }

        public string TenTK { get => tenTK; set => tenTK = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}