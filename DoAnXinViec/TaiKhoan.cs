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

        public TaiKhoan(string tenTK, string matKhau)
        {
            this.TenTK = tenTK;
            this.MatKhau = matKhau;
        }

        public string TenTK { get => tenTK; set => tenTK = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
