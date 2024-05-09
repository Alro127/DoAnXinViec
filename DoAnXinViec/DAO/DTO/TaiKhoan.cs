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
            try
            {
                Id = id;
                MatKhau = matKhau;
                Quyen = quyen;
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public TaiKhoan(DataRow dr)
        {
            Utility.SetItemFromRow(this, dr);
        }

        public string Quyen { get => quyen; set => quyen = value; }
        public string Id
        {
            get => id;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống id");
                }
                id = value;
            }
        }
        public string MatKhau
        {
            get => matKhau;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống mật khẩu");
                }
                matKhau = value;
            }
        }
    }
}