using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace DoAnXinViec
{
    internal class TaiKhoanDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }

        public string Checklogin(TaiKhoan taiKhoan)
        {
            string info = dbconnection.CheckLogin(taiKhoan);
            return info;
        }
        /*public void SignUp(TaiKhoan taiKhoan)
        {   
            string sqlStr = string.Format("INSERT INTO TaiKhoan (Id, Matkhau, Quyen) VALUES('{0}','{1}','{2}')",taiKhoan.TenTK, taiKhoan.MatKhau, taiKhoan.Quyen);
            if(Dbconnection.ThucThi(sqlStr))
            {
                MessageBox.Show("Thanhf coong");
                return;
            }

        }*/
    }
}