using System;
using System.Collections.Generic;
using System.Data;
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

        public bool Checklogin(TaiKhoan taiKhoan)
        {
            string sqlStr = string.Format("SELECT Count(*) FROM TaiKhoan WHERE Id = '{0}' AND MatKhau = '{1}' AND Quyen = '{2}'  ", taiKhoan.Id, taiKhoan.MatKhau, taiKhoan.Quyen);
            return dbconnection.CheckExist(sqlStr);
        }
        public bool SignUp(TaiKhoan taiKhoan)
        {
            List<SqlParameter> parameters = Utility.GetParameters(taiKhoan);
            string sqlStr = Utility.GenerateInsertSql("TaiKhoan", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                return true;
            return false;
        }
        public DataTable Get(string id)
        {
            string sqlStr = string.Format("SELECT * FROM TaiKhoan WHERE Id = '{0}'", id);
            return dbconnection.Load(sqlStr);
        }
        public bool CheckSignUp(TaiKhoan taiKhoan)
        {
            string sqlStr = string.Format("SELECT Count(Id) FROM TaiKhoan WHERE Id = '{0}'", taiKhoan.Id);
            return dbconnection.CheckExist(sqlStr);
        }
        public bool CheckPassWord(TaiKhoan taiKhoan)
        {
            string sqlStr = string.Format("SELECT Count(Id) FROM TaiKhoan WHERE Id = '{0}' and MatKhau = '{1}'", taiKhoan.Id, taiKhoan.MatKhau);
            return dbconnection.CheckExist(sqlStr);
        }
        public void DoiMatKhau(TaiKhoan taiKhoan)
        {
            List<SqlParameter> parameters = Utility.GetParameters(taiKhoan);
            string sqlStr = Utility.GenerateUpdateSql("TaiKhoan", parameters, "Id = @Id");
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("ThanhCong");
        }
    }
}