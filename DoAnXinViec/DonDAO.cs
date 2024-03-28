using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DoAnXinViec
{
    class DonDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }
        public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.IdCT WHERE Don.NgayToiHan >= GETDATE()");
            return Dbconnection.Load(sqlStr);
        }

        public DataTable LoadLichSu()
        {
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.IdCT ORDER BY Don.NgayDang ASC");
            return Dbconnection.Load(sqlStr);
        }
        public void Them(Don don)
        {
            List<SqlParameter> parameters = Utility.GetParameters(don, new string[3] {nameof(don.IdCV), nameof(don.TenCT), nameof(don.Anh)});
            string sqlStr = Utility.GenerateInsertSql("Don", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }
        public void CapNhat(Don don)
        {
            List<SqlParameter> parameters = Utility.GetParameters(don, new string[0]);
            string sqlStr = Utility.GenerateUpdateSql("Don", parameters, "Id = @Id");
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("ThanhCong");
        }
        public void TangLuotXem(Don don)
        {
            string sqlStr = string.Format("UPDATE Don SET LuotXem = LuotXem + 1 WHERE IdCV = @IdCV");
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdCV", don.IdCV));
            if (Dbconnection.ThucThi(sqlStr,parameters)==false)
                MessageBox.Show("Co Loi");
        }
        public void TangLuotNop(Don don)
        {
            string sqlStr = string.Format("UPDATE Don SET LuotNop = LuotNop + 1 WHERE IdCV = @IdCV");
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdCV", don.IdCV));
            if (Dbconnection.ThucThi(sqlStr, parameters) == false)
                MessageBox.Show("Co Loi");
        }
    }
}