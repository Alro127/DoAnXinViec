using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WTrangXemDon.xaml
    /// </summary>
    public partial class WTrangXemDon : Window
    {
        string id = "UV1";
        DonDAO donDAO = new DonDAO();
        public WTrangXemDon()
        {
            InitializeComponent();
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
        }
        void DangUCDon(DataRow dr)
        {
            Don don = new Don((int)dr["IdCV"], (string)dr["TenCV"], (string)dr["IdCT"], (string)dr["DiaDiem"], (int)dr["Luong"], DateTime.ParseExact((string)dr["NgayDang"], "dd/MM/yyyy", null), DateTime.ParseExact((string)dr["NgayToiHan"], "dd/MM/yyyy", null).Date,
                    (string)dr["Anh"], (string)dr["MoTaCV"], (string)dr["YeuCau"], (string)dr["QuyenLoi"], (int)dr["LuotXem"], (int)dr["LuotNop"]);
            UCDon uCDon = new UCDon();
            uCDon.grbTenCV.Header = don.TenCV;
            uCDon.lblTenCT.Content = (string)dr["TenCT"];
            uCDon.lblDiaDiem.Content = don.DiaDiem;
            uCDon.lblLuong.Content = don.Luong;
            uCDon.imgAnh.Source = new BitmapImage(new System.Uri(don.Anh));
            uCDon.btnXem.Tag = don;
            ucTrangTimViec.wpDon.Children.Add(uCDon);
            uCDon.btnXem.Click += new RoutedEventHandler(this.btnXem_Click);
        }
        void Load()
        {
            DataTable dt = donDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                DangUCDon(dr);
            }
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            WDonChiTiet wDonChiTiet = new WDonChiTiet();
            wDonChiTiet.Don = (Don)(sender as Button).Tag;
            wDonChiTiet.IdUV = id;
            donDAO.TangLuotXem(wDonChiTiet.Don);
            wDonChiTiet.ShowDialog();
        }
        private void btnQuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            WTrangChinhUngVien wTrangChinhUngVien = new WTrangChinhUngVien();
            this.Close();
            wTrangChinhUngVien.ShowDialog();
        }

        private void WTrangChinh_Load(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            ucTrangTimViec.wpDon.Children.Clear();
            DataTable dt = donDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                if (((string)dr["TenCV"]).Contains(ucTrangTimViec.txtTimKiem.Text))
                    DangUCDon(dr);
            }
        }
    }
}
