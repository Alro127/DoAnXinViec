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
            List<SqlParameter> parameters = Utility.GetParameters(cv, cv.UnecessaryProperty2());
            string sqlStr = Utility.GenerateInsertSql("CV", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }
        public void CapNhat(CV cv)
        {
            List<SqlParameter> valueParameters = Utility.GetParameters(cv, cv.UnecessaryProperty2());
            List<SqlParameter> parameters = Utility.GetParameters(cv, cv.UnecessaryProperty1());
            string sqlStr = Utility.GenerateUpdateSql("CV", valueParameters, "Id = @Id");
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("ThanhCong");
        }
        public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM CV");
            return Dbconnection.Load(sqlStr);
        }
        public DataTable Get(UngVien ungVien)
        {
            string sqlStr = string.Format("SELECT * FROM CV WHERE IdUV = '{0}'", ungVien.Id);
            return dbconnection.Load(sqlStr);
        }

        public DataTable Get(int id)
        {
            string sqlStr = string.Format("SELECT * FROM CV WHERE Id = '{0}'", id);
            return dbconnection.Load(sqlStr);
        }
    }
}