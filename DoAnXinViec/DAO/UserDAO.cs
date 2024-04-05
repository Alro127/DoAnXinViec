using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace DoAnXinViec
{
    public class UserDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }

        public DataTable Load(string table)
        {
            string sqlStr = string.Format("SELECT*FROM " + table);
            return Dbconnection.Load(sqlStr);
        }
        public bool Them <T>(T user, string table) where T : User
        {
            List<SqlParameter> parameters = Utility.GetParameters(user, new string[0]);
            string sqlStr = Utility.GenerateInsertSql(table, parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                return true;
            return false;
        }

        public bool CapNhat <T>(T user, string table) where T : User
        {
            List<SqlParameter> parameters = Utility.GetParameters(user, new string[0]);
            string sqlStr = Utility.GenerateUpdateSql(table, parameters, "Id = @Id");
            if (dbconnection.ThucThi(sqlStr, parameters))
                return true;
            return false;
        }

        public DataTable Get(string id, string table)
        {
            string sqlStr = string.Format("SELECT * FROM " + table +" WHERE Id = '{0}'", id);
            return dbconnection.Load(sqlStr);
        }
    }
}
