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
    class CVDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }
        public void Them(CV cv)
        {
            List<SqlParameter> parameters = Utility.GetParameters(cv, new string[1] {nameof(cv.UngVien)});
            string sqlStr = Utility.GenerateInsertSql("CV", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }
        public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM CV");
            return Dbconnection.Load(sqlStr);
        }
        public DataTable Get(string id)
        {
            string sqlStr = string.Format("SELECT * FROM CV WHERE Id = '{0}'", id);
            return dbconnection.Load(sqlStr);
        }
    }
}