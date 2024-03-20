using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DoAnXinViec
{
    internal class HoSoDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }
        /*public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.IdCT");
            return Dbconnection.Load(sqlStr);
        }*/
        public void Them(HoSo hoSo)
        {
            string sqlStr = string.Format("INSERT INTO HoSo (IdCV, IdUV, LoaiHoSo, NgayNop, TrangThai) VALUES ('{0}','{1}', '{2}', '{3}', '{4}')", hoSo.IdCV, hoSo.IdUV, hoSo.LoaiHoSo, hoSo.NgayNop.ToShortDateString(), hoSo.TrangThai);
            Dbconnection.ThucThi(sqlStr);
        }
        public DataTable Show(string id)
        {
            string sqlStr = string.Format("SELECT * FROM UngVien, Don, HoSo WHERE HoSo.IdUV = UngVien.IdUV AND HoSo.IdCV = Don.IdCV and Don.IdCT = '{0}'", id);
            return Dbconnection.Load(sqlStr);
        }
    }
}
