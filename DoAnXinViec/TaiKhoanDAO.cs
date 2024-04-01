using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public void SignUp(TaiKhoan taiKhoan)
        {
            List<SqlParameter> parameters = Utility.GetParameters(taiKhoan, new string[0]);
            string sqlStr = Utility.GenerateInsertSql("TaiKhoan", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");

        }
    }
}