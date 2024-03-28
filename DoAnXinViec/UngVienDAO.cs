using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace DoAnXinViec
{
    public class UngVienDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }

        public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM Cty");
            return Dbconnection.Load(sqlStr);
        }
        public void Them(UngVien ungVien)
        {
            List<SqlParameter> parameters = Utility.GetParameters(ungVien, new string[0]);
            string sqlStr = Utility.GenerateInsertSql("UngVien", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }

        public void CapNhat(UngVien ungVien)
        {
            List<SqlParameter> parameters = Utility.GetParameters(ungVien, new string[0]);
            string sqlStr = Utility.GenerateUpdateSql("UngVien", parameters, "IdUV = @IdUV");
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("ThanhCong");
        }

        public DataTable Get(string id)
        {
            string sqlStr = string.Format("SELECT * FROM UngVien WHERE IdUV = '{0}'", id);
            return dbconnection.Load(sqlStr);
        }
    }
}
