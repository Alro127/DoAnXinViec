using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DoAnXinViec
{
    public class CongTyDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }

        public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM Cty");
            return Dbconnection.Load(sqlStr);
        }
        public void Them(CongTy congty)
        {
            List<SqlParameter> parameters = Utility.GetParameters(congty, new string[0]);
            string sqlStr = Utility.GenerateInsertSql("Cty", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }

        public void CapNhat(CongTy congty)
        {
            List<SqlParameter> parameters = Utility.GetParameters(congty, new string[0]);
            string sqlStr = Utility.GenerateUpdateSql("Cty", parameters, "Id = @Id");
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("ThanhCong");
        }

        public DataTable Get(string id)
        {
            string sqlStr = string.Format("SELECT * FROM Cty WHERE IdCT = '{0}'",id);
            return dbconnection.Load(sqlStr);
        }
    }
}
