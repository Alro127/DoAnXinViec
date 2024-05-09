using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnXinViec.DAO
{
    public class PhongVanDAO
    {
        DBConnection dbconnection = new DBConnection();
        public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM PhongVan");
            return dbconnection.Load(sqlStr);
        }
        public bool CheckExist(string idDon,string idCV)
        {
            string sqlStr = string.Format("SELECT COUNT(*) FROM PhongVan WHERE IdDon = '{0}' AND IdCV = '{1}'", idDon, idCV);
            return dbconnection.CheckExist(sqlStr);
        }
        public void Them(PhongVan phongVan)
        {
            List<SqlParameter> parameters = Utility.GetParameters(phongVan);
            string sqlStr = Utility.GenerateInsertSql("PhongVan", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }

        public void CapNhat(PhongVan phongVan)
        {
            List<SqlParameter> parameters = Utility.GetParameters(phongVan);
            string sqlStr = Utility.GenerateUpdateSql("PhongVan", parameters, "IdDon = @IdDon and IdCV = @IdCV");
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }
        public DataTable Get(int idDon, int idCV)
        {
            string sqlStr = string.Format("SELECT * FROM PhongVan WHERE IdDon = '{0}' and IdCV = '{1}'", idDon, idCV);
            return dbconnection.Load(sqlStr);
        }
        public bool Xoa(PhongVan phongVan)
        {
            List<SqlParameter> parameters = Utility.GetParameters(phongVan);
            string sqlStr = Utility.GenerateDeleteSql("PhongVan", "IdDon = @IdDon AND IdCV = @IdCV");
            return (dbconnection.ThucThi(sqlStr, parameters));
        }
    }
}
