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
            List<SqlParameter> parameters = Utility.GetParameters(hoSo, hoSo.UnecessaryProperty());
            string sqlStr = Utility.GenerateInsertSql("HoSo", parameters);
            if (dbconnection.ThucThi(sqlStr, parameters))
                MessageBox.Show("Thanh Cong");
        }
        public bool CapNhat(HoSo hoSo)
        {
            List<SqlParameter> parameters = Utility.GetParameters(hoSo, hoSo.UnecessaryProperty());
            string sqlStr = Utility.GenerateUpdateSql("HoSo", parameters, "IdDon = @IdDon AND IdCV = @IdCV");
            return dbconnection.ThucThi(sqlStr, parameters);
        }
        public DataTable LoadForCT(CongTy congTy)
        {
            string sqlStr = string.Format("SELECT HoSo.IdDon, HoSo.IdCV, HoTen AS TenHoSo, TenCV AS ViTriUngTuyen, LoaiHoSo, NgayNop, TrangThai " +
                                          "FROM UngVien, Don, HoSo, CV " +
                                          "WHERE HoSo.IdCV = CV.Id AND HoSo.IdDon = Don.IdDon AND UngVien.Id = CV.IdUV AND Don.IdCT = '{0}'", congTy.Id);
            return Dbconnection.Load(sqlStr);
        }
        public DataTable LoadTheoDon(CongTy congTy, Don don)
        {
            string sqlStr = string.Format("SELECT HoSo.IdDon, HoSo.IdCV, HoTen AS TenHoSo, LoaiHoSo, NgayNop, TrangThai " +
                                          "FROM UngVien, Don, HoSo, CV " +
                                          "WHERE HoSo.IdCV = CV.Id AND HoSo.IdDon = Don.IdDon AND UngVien.Id = CV.IdUV AND Don.IdDon = '{1}' AND Don.IdCT = '{0}'", congTy.Id, don.IdDon);
            return Dbconnection.Load(sqlStr);
        }
        public DataTable LoadForUV(UngVien ungVien)
        {
            string sqlStr = string.Format("SELECT HoSo.IdDon, HoSo.IdCV, TenCT, TenCV AS ViTriUngTuyen, LoaiHoSo, NgayNop, TrangThai " +
                                          "FROM CV, CTy, HoSo, Don " +
                                          "WHERE HoSo.IdCV = CV.Id AND HoSo.IdDon = Don.IdDon AND Don.IdCT = CTy.Id AND CV.IdUV = '{0}'", ungVien.Id);
            return Dbconnection.Load(sqlStr);
        }

        public bool CheckExist(Don don, string idUV)
        {
            string sqlStr = string.Format("SELECT COUNT(*) FROM CV  " +
                                          "WHERE CV.Id IN (SELECT IdCV AS SoLuong FROM HoSo WHERE IdDon = '{0}') AND CV.IdUV = '{1}'", don.IdDon, idUV);
            return Dbconnection.CheckExist(sqlStr);
        }

    }
}
