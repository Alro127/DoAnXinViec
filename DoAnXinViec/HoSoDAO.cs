using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace DoAnXinViec
{
    internal class HoSoDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }
        public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.IdCT");
            return Dbconnection.Load(sqlStr);
        }
        public void Them(HoSo hoSo)
        {
            List<SqlParameter> parameters = Utility.GetParameters(hoSo, new string[2] {nameof(hoSo.ViTriUngTuyen), nameof(hoSo.TenHoSo)});
            string sqlStr = Utility.GenerateInsertSql("HoSo", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }
        public DataTable LoadForCT(string id)
        {
            string sqlStr = string.Format("SELECT HoSo.IdCV, HoSo.IdUV, HoTen AS TenHoSo, TenCV AS ViTriUngTuyen, LoaiHoSo, NgayNop, TrangThai FROM UngVien, Don, HoSo WHERE HoSo.IdUV = UngVien.IdUV AND HoSo.IdCV = Don.IdCV and Don.IdCT = '{0}'", id);
            return Dbconnection.Load(sqlStr);
        }

        public bool CheckExist(Don don, string idUV)
        {
            string sqlStr = string.Format("SELECT COUNT(*) AS SoLuong FROM HoSo WHERE IdCV = '{0}' and IdUV = '{1}'", don.IdCV, idUV);
            return Dbconnection.CheckExist(sqlStr);
        }

    }
}
