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
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.Id WHERE Don.NgayToiHan > GETDATE()");
            return Dbconnection.Load(sqlStr);
        }
        public DataTable LoadForCT(CongTy congTy)
        {
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.Id WHERE Don.NgayToiHan > GETDATE() AND Cty.Id = '{0}'", congTy.Id);
            return Dbconnection.Load(sqlStr);
        }
        public DataTable LoadLichSu(CongTy congTy)
        {
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.Id WHERE Cty.Id = '{0}' ORDER BY Don.NgayDang ASC", congTy.Id);
            return Dbconnection.Load(sqlStr);
        }
        public void Them(Don don)
        {
            List<SqlParameter> parameters = Utility.GetParameters(don, don.UnecessaryProperty());
            string sqlStr = Utility.GenerateInsertSql("Don", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }
        public void CapNhat(Don don)
        {
            List<SqlParameter> parameters = Utility.GetParameters(don);
            string sqlStr = Utility.GenerateUpdateSql("Don", parameters, "IdCV = @IdCV");
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("ThanhCong");
        }
        public void Xoa(Don don)
        {
            string sqlStr = string.Format("UPDATE Don SET NgayToiHan = @NOW WHERE IdCV = @IdCV");
            List<SqlParameter> parameters = new List<SqlParameter>() { new SqlParameter("@NOW", DateTime.Now), new SqlParameter("@IdDon", don.IdDon) };
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("ThanhCong");
        }
        public void TangLuotXem(Don don)
        {
            string sqlStr = string.Format("UPDATE Don SET LuotXem = LuotXem + 1 WHERE IdDon = @IdDon");
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdDon", don.IdDon));
            if (Dbconnection.ThucThi(sqlStr,parameters)==false)
                MessageBox.Show("Co Loi");
        }
        public void TangLuotNop(Don don)
        {
            string sqlStr = string.Format("UPDATE Don SET LuotNop = LuotNop + 1 WHERE IdDon = @IdDon");
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdDon", don.IdDon));
            if (Dbconnection.ThucThi(sqlStr, parameters) == false)
                MessageBox.Show("Co Loi");
        }
    }
}