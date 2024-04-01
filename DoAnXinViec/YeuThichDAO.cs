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
        public DataTable Load(CongTy congTy)
        {
            string sqlStr = string.Format("SELECT * FROM YeuThich WHERE IdCT = '{0}'", congTy.IdCT);
            return dbconnection.Load(sqlStr);
        }
        public bool Them(YeuThich yeuThich)
        {
            List<SqlParameter> parameters = Utility.GetParameters(yeuThich, new string[0]);
            string sqlStr = Utility.GenerateInsertSql("YeuThich", parameters);
            return (dbconnection.ThucThi(sqlStr, parameters));
        }
        public bool Xoa(YeuThich yeuThich)
        {
            List<SqlParameter> parameters = Utility.GetParameters(yeuThich, new string[0]);
            string sqlStr = Utility.GenerateDeleteSql("YeuThich", "IdCV = @IdCV AND IdCT = @IdCT");
            return (dbconnection.ThucThi(sqlStr, parameters));
        }
        
        public bool CheckExist(YeuThich yeuThich)
        {
            string sqlStr = string.Format("SELECT COUNT(*) AS SoLuong FROM YeuThich Where IdCV = '{0}' AND IdCT ='{1}'", yeuThich.IdCV, yeuThich.IdCT);
            return dbconnection.CheckExist(sqlStr);
        }
    }
}
