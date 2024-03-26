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
            Don don = new Don();
            Utility.SetItemFromRow(don, dr);
            UCDon uCDon = new UCDon(don);
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
            WDonChiTiet wDonChiTiet = new WDonChiTiet((Don)(sender as Button).Tag, id);
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
            Don don;
            foreach (DataRow dr in dt.Rows)
            {
                if (((string)dr[nameof(don.TenCV)]).Contains(ucTrangTimViec.txtTimKiem.Text))
                    DangUCDon(dr);
            }
        }
    }
}
