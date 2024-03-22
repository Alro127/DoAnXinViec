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
        public bool Them(HoSo hoSo)
        {
            string sqlStr = string.Format("INSERT INTO HoSo (IdCV, IdUV, LoaiHoSo, NgayNop, TrangThai) VALUES ('{0}','{1}', N'{2}', '{3}', N'{4}')", hoSo.IdCV, hoSo.IdUV, hoSo.LoaiHoSo, hoSo.NgayNop.ToShortDateString(), hoSo.TrangThai);
            return Dbconnection.ThucThi(sqlStr);
        }
        public DataTable LoadForCT(string id)
        {
            string sqlStr = string.Format("SELECT * FROM UngVien, Don, HoSo WHERE HoSo.IdUV = UngVien.IdUV AND HoSo.IdCV = Don.IdCV and Don.IdCT = '{0}'", id);
            return Dbconnection.Load(sqlStr);
        }

        public bool CheckExist(Don don, string idUV)
        {
            string sqlStr = string.Format("SELECT COUNT(*) AS SoLuong FROM HoSo WHERE IdCV = '{0}' and IdUV = '{1}'", don.IdCV, idUV);
            return Dbconnection.CheckExist(sqlStr);
        }

    }
}
