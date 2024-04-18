using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    public class TaiKhoan
    {
        string id;
        string matKhau;
        string quyen;
        
        public TaiKhoan() { }
        public TaiKhoan(string id, string matKhau, string quyen)
        {
            Id = id;
            MatKhau = matKhau;
            Quyen = quyen;
        }
        public TaiKhoan(DataRow dr)
        {
            Utility.SetItemFromRow(this, dr);
        }

        public string Id { get => id; set => id = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}