using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WTrangChinhCty.xaml
    /// </summary>
    public partial class WTrangChinhCty : Window
    {
        string id = "CT1";
        string tenCT = "tenCT";
        UCDangDon uCDangDon = new UCDangDon();
        UCDanhSachTin uCDanhSachTin = new UCDanhSachTin();
        UCHoSoUngTuyen uCHoSoUngTuyen = new UCHoSoUngTuyen();
        DonDAO donDAO = new DonDAO();
        HoSoDAO hoSoDAO = new HoSoDAO();
        public WTrangChinhCty()
        {
            InitializeComponent();
            uCHoSoUngTuyen.btnLuu.Click += new RoutedEventHandler(this.btnLuu_Click);
        }

        private void btnDanhSachTin_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCDanhSachTin);
            DataTable dt = donDAO.Load();
            List<Don> listDon = new List<Don>();
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don((int)dr["IdCV"], (string)dr["TenCV"], (string)dr["IdCT"], (string)dr["DiaDiem"], (int)dr["Luong"], DateTime.ParseExact((string)dr["NgayDang"], "dd/MM/yyyy", null).Date, 
                    DateTime.ParseExact((string)dr["NgayToiHan"], "dd/MM/yyyy", null).Date, (string)dr["Anh"], (string)dr["MoTaCV"], (string)dr["YeuCau"], (string)dr["QuyenLoi"], (int)dr["LuotXem"], (int)dr["LuotNop"]);                
                listDon.Add(don);
            }
            uCDanhSachTin.lvDonTuyen.ItemsSource = listDon;
        }

        private void btnTaoTinDangTuyen_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCDangDon);
            uCDangDon.btnDang.Click += new System.Windows.RoutedEventHandler(this.btnDang_Click);
        }
        private void btnDang_Click(object sender, RoutedEventArgs e)
        {
            
            Don don = new Don(0,uCDangDon.txtTenCV.Text, id, uCDangDon.cbDiaDiem.Text, int.Parse(uCDangDon.cbLuong.Text), DateTime.Now.Date, DateTime.ParseExact(uCDangDon.dtpNgayToiHan.Text, "dd/MM/yyyy", null).Date, uCDangDon.imgAnh.Source.ToString(), uCDangDon.txtMoTaCV.Text, uCDangDon.txtYeuCau.Text, uCDangDon.txtQuyenLoi.Text,0,0);
            donDAO.Them(don);
        }

        private void btnHoSoUngTuyen_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoUngTuyen);
            DataTable dt = hoSoDAO.LoadForCT(id);
            List <HoSo> listHoSo = new List <HoSo>();
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo((int)dr["IdCV"], (string)dr["IdUV"], (string)dr["HoTen"], (string)dr["TenCV"], (string)dr["LoaiHoSo"], DateTime.ParseExact((string)dr["NgayNop"], "dd/MM/yyyy", null).Date, (string)dr["TrangThai"]);
                listHoSo.Add(hoSo);
            }
            uCHoSoUngTuyen.lvHoSoUngTuyen.ItemsSource = listHoSo;
        }
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
              
        }
    } 
}
