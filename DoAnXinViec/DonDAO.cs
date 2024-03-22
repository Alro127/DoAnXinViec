using System;
using System.Collections.Generic;
using System.Data;
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
            string sqlStr = string.Format("SELECT*FROM Don INNER JOIN Cty ON Don.IdCT = Cty.IdCT");
            return Dbconnection.Load(sqlStr);
        }
        public void Them(Don don)
        {
            string sqlStr = string.Format("INSERT INTO Don (TenCV, IdCT, DiaDiem, Luong, Anh, NgayDang, NgayToiHan, MoTaCV, YeuCau, QuyenLoi, LuotXem, LuotNop) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}', N'{8}', N'{9}', N'{10}', N'{11}')", don.TenCV, don.IdCT, don.DiaDiem, don.Luong, don.Anh, don.NgayDang.ToString("dd/MM/yyyy"), don.NgayToiHan.ToString("dd/MM/yyyy"), don.MoTaCV, don.YeuCau, don.QuyenLoi, don.LuotXem, don.LuotNop);
            if (Dbconnection.ThucThi(sqlStr))
                MessageBox.Show("Thanh Cong");
        }

        public void CapNhat(Don don)
        {
            string sqlStr = string.Format("UPDATE Don SET TenCV = N'{0}', IdCT = N'{1}', DiaDiem = N'{2}', Luong = N'{3}', Anh = N'{4}', NgayDang = N'{5}', NgayToiHan = N'{6}', MoTaCV = N'{7}', YeuCau = N'{8}', QuyenLoi = N'{9}', LuotXem = N'{10}', LuotNop = N'{11}' WHERE IdCV = N'{12}'" ,don.TenCV, don.IdCT, don.DiaDiem, don.Luong, don.Anh, don.NgayDang.ToString("dd/MM/yyyy"), don.NgayToiHan.ToString("dd/MM/yyyy"), don.MoTaCV, don.YeuCau, don.QuyenLoi, don.LuotXem, don.LuotNop, don.IdCV);
            if (Dbconnection.ThucThi(sqlStr))
                MessageBox.Show("Thanh Cong");
        }

        public void TangLuotXem(Don don)
        {
            string sqlStr = string.Format("UPDATE Don SET LuotXem = LuotXem + 1 WHERE IdCV = '{0}'", don.IdCV);
            if (Dbconnection.ThucThi(sqlStr)==false)
                MessageBox.Show("Co Loi");
        }
        public void TangLuotNop(Don don)
        {
            string sqlStr = string.Format("UPDATE Don SET LuotNop = LuotNop + 1 WHERE IdCV = '{0}'", don.IdCV);
            if (Dbconnection.ThucThi(sqlStr) == false)
                MessageBox.Show("Co Loi");
        }
    }
}