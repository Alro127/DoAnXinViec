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
        }

        void Load()
        {
            DataTable dt = donDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don((int)dr["IdCV"] ,(string)dr["TenCV"], (string)dr["IdCT"], (string)dr["DiaDiem"], (int)dr["Luong"], "", new Image(), (string)dr["MoTaCV"], (string)dr["YeuCau"], (string)dr["QuyenLoi"]);
                UCDon uCDon = new UCDon();
                uCDon.grbTenCV.Header = don.TenCV;
                uCDon.lblTenCT.Content = (string)dr["TenCT"];
                uCDon.lblDiaDiem.Content = don.DiaDiem;
                uCDon.lblLuong.Content = don.Luong;
                uCDon.btnXem.Tag = don;
                ucTrangTimViec.wpDon.Children.Add(uCDon);
                uCDon.btnXem.Click += new System.Windows.RoutedEventHandler(this.btnXem_Click);
            }
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            WDonChiTiet wDonChiTiet = new WDonChiTiet();
            wDonChiTiet.Don = (Don)(sender as Button).Tag;
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
    }
}
