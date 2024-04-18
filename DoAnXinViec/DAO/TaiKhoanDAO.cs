﻿using System;
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

        public string Checklogin(TaiKhoan taiKhoan)
        {
            string info = dbconnection.CheckLogin(taiKhoan);
            return info;
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
    }
}