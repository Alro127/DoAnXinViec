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
        public void Them(HoSo hoSo)
        {
            List<SqlParameter> parameters = Utility.GetParameters(hoSo, new string[3] {nameof(hoSo.TenCT), nameof(hoSo.ViTriUngTuyen), nameof(hoSo.TenHoSo)});
            string sqlStr = Utility.GenerateInsertSql("HoSo", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }
        public DataTable LoadForCT(CongTy congTy)
        {
            string sqlStr = string.Format("SELECT HoSo.IdCV, HoSo.IdUV, HoTen AS TenHoSo, TenCV AS ViTriUngTuyen, LoaiHoSo, NgayNop, TrangThai FROM UngVien, Don, HoSo WHERE HoSo.IdUV = UngVien.Id AND HoSo.IdCV = Don.IdCV and Don.IdCT = '{0}'", congTy.Id);
            return Dbconnection.Load(sqlStr);
        }
        public DataTable LoadTheoDon(CongTy congTy, Don don)
        {
            string sqlStr = string.Format("SELECT HoSo.IdCV, HoSo.IdUV, HoTen AS TenHoSo, LoaiHoSo, NgayNop, TrangThai FROM UngVien, Don, HoSo WHERE HoSo.IdUV = UngVien.Id AND HoSo.IdCV = '{1}' AND Don.IdCV = '{1}' AND Don.IdCT = '{0}'", congTy.Id, don.IdCV);
            return Dbconnection.Load(sqlStr);
        }
        public DataTable LoadForUV(UngVien ungVien)
        {
            string sqlStr = string.Format("SELECT HoSo.IdCV, HoSo.IdUV, TenCT, TenCV AS ViTriUngTuyen, LoaiHoSo, NgayNop, TrangThai FROM UngVien, CTy, HoSo, Don WHERE HoSo.IdUV = UngVien.Id AND HoSo.IdCV = Don.IdCV and Don.IdCT = CTy.Id and HoSo.IdUV = '{0}'", ungVien.Id);
            return Dbconnection.Load(sqlStr);
        }

        public bool CheckExist(Don don, string idUV)
        {
            string sqlStr = string.Format("SELECT COUNT(*) AS SoLuong FROM HoSo WHERE IdCV = '{0}' and IdUV = '{1}'", don.IdCV, idUV);
            return Dbconnection.CheckExist(sqlStr);
        }

    }
}
