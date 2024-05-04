using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoAnXinViec
{
    public class YeuThichDAO
    {
        DBConnection dbconnection = new DBConnection();
        public DataTable Load<T>(T user) where T : User
        {
            string sqlStr = string.Format("SELECT * FROM YeuThich WHERE IdUser = '{0}'", user.Id);
            return dbconnection.Load(sqlStr);
        }
        public bool Them(YeuThich yeuThich)
        {
            List<SqlParameter> parameters = Utility.GetParameters(yeuThich);
            string sqlStr = Utility.GenerateInsertSql("YeuThich", parameters);
            return (dbconnection.ThucThi(sqlStr, parameters));
        }
        public bool Xoa(YeuThich yeuThich)
        {
            List<SqlParameter> parameters = Utility.GetParameters(yeuThich);
            string sqlStr = Utility.GenerateDeleteSql("YeuThich", "Id = @Id AND IdUser = @IdUser");
            return (dbconnection.ThucThi(sqlStr, parameters));
        }
        
        public bool CheckExist(YeuThich yeuThich)
        {
            string sqlStr = string.Format("SELECT COUNT(*) AS SoLuong FROM YeuThich Where Id = '{0}' AND IdUser ='{1}'", yeuThich.Id, yeuThich.IdUser);
            return dbconnection.CheckExist(sqlStr);
        }

        public DataTable Get(int id, string idUser)
        {
            string sqlStr = string.Format("SELECT * FROM YeuThich WHERE Id = '{0}' and IdUser", id, idUser);
            return dbconnection.Load(sqlStr);
        }
    }
}
