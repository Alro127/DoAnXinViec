using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DoAnXinViec
{
    class DonDAO
    {
        DBConnection dbconnection = new DBConnection();
        internal DBConnection Dbconnection { get => dbconnection; set => dbconnection = value; }
        public DataTable Load()
        {
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.IdCT");
            return Dbconnection.Load(sqlStr);
        }
        public void Them(Don don)
        {
            string sqlStr = string.Format("INSERT INTO Don (TenCV, IdCT, DiaDiem, Luong, Anh, NgayToiHan, MoTaCV, YeuCau, QuyenLoi) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}', '{8}')", don.TenCV, don.IdCT, don.DiaDiem, don.Luong, don.Anh, don.NgayToiHan, don.MoTaCV, don.YeuCau, don.QuyenLoi);
            Dbconnection.ThucThi(sqlStr);
        }
    }
}