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
        UngVien ungVien = new UngVien();
        UngVienDAO ungVienDAO = new UngVienDAO();
        DonDAO donDAO = new DonDAO();
        List <Don> donList = new List<Don>();
        public WTrangXemDon(string id)
        {
            InitializeComponent();
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
            DataTable dt = ungVienDAO.Get(id, "UngVien");
            if (dt.Rows.Count > 0)
            {
                Utility.SetItemFromRow(ungVien, dt.Rows[0]);
            }
            else MessageBox.Show("Lỗi");
        }
        public WTrangXemDon(UngVien ungVien)
        {
            this.ungVien = ungVien;
            InitializeComponent();
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
            ucTrangTimViec.cbDiaDiem.SelectionChanged += new SelectionChangedEventHandler(this.cbDiaDiem_SelectionChanged);
        }
        void DangUCDon()
        {
            foreach (Don don in donList)
            {
                if ((ucTrangTimViec.txtTimKiem.Text == "" || don.TenCV.Contains(ucTrangTimViec.txtTimKiem.Text))
                    && (ucTrangTimViec.cbDiaDiem.Text == "" || don.DiaDiem.Contains(ucTrangTimViec.cbDiaDiem.Text))
                    && (ucTrangTimViec.cbLuong.Text == ""))
                {
                    UCDon uCDon = new UCDon(don);
                    BitmapImage bitmapImg = ImageHandler.SetImage(don.Anh);
                    if (bitmapImg != null)
                        uCDon.imgAnh.Source = bitmapImg;
                    ucTrangTimViec.wpDon.Children.Add(uCDon);
                    uCDon.btnXem.Click += new RoutedEventHandler(this.btnXem_Click);
                }
            }
        }
        void Load()
        {
            DataTable dt = donDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don();
                Utility.SetItemFromRow(don, dr);
                donList.Add(don);
            }
            DangUCDon();
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            WDonChiTiet wDonChiTiet = new WDonChiTiet((Don)(sender as Button).Tag, ungVien.Id);
            donDAO.TangLuotXem(wDonChiTiet.Don);
            wDonChiTiet.ShowDialog();
        }
        private void btnQuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            WTrangChinhUngVien wTrangChinhUngVien = new WTrangChinhUngVien(ungVien);
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
            DangUCDon();
        }
        private void cbDiaDiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucTrangTimViec.wpDon.Children.Clear();
            DangUCDon();
        }
    }
}
