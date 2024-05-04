using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        UngVien ungVien;
        UngVienDAO ungVienDAO = new UngVienDAO();
        DonDAO donDAO = new DonDAO();
        YeuThichDAO yeuThichDAO = new YeuThichDAO();
        CVDAO cvDAO = new CVDAO();
        List<Don> donList = new List<Don>();
        List<CV> cvList = new List<CV>();
        public WTrangXemDon(string id)
        {
            InitializeComponent();
            DataTable dt = ungVienDAO.Get(id, "UngVien");
            ungVien = new UngVien(dt.Rows[0]);
        }
        public WTrangXemDon(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
        }
        void DangUCDon()
        {
            ucTrangTimViec.wpDon.Children.Clear();
            foreach (Don don in donList)
            {
                if (ucTrangTimViec.CheckTimKiem(don.TenCV) && ucTrangTimViec.CheckDiaDiem(don.DiaDiem) && ucTrangTimViec.CheckLuong(don.Luong) && ucTrangTimViec.CheckKinhNghiem(don.KinhNghiem) && ucTrangTimViec.CheckLinhVuc(don.LinhVuc))
                {
                    YeuThich yeuThich = new YeuThich(don.IdDon, ungVien.Id);
                    UCDon uCDon = new UCDon(don, yeuThich);
                    ucTrangTimViec.wpDon.Children.Add(uCDon);
                    uCDon.btnXem.Click += new RoutedEventHandler(this.btnXem_Click);
                    uCDon.btnYeuThich.Click += new RoutedEventHandler(this.btnYeuThich_Click);
                }
            }

        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            Don don = (Don)(sender as Button).DataContext;
            WDonChiTiet wDonChiTiet = new WDonChiTiet(don, ungVien);
            donDAO.TangLuotXem(don);
            wDonChiTiet.ShowDialog();
        }
        void btnYeuThich_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            if (toggleButton.IsChecked == true)
            {
                YeuThich yeuThich = new YeuThich((int)(toggleButton).Tag, ungVien.Id);
                yeuThichDAO.Them(yeuThich);
            }
            else
            {
                YeuThich yeuThich = new YeuThich((int)(toggleButton).Tag, ungVien.Id);
                yeuThichDAO.Xoa(yeuThich);
            }
        }
        private void WTrangChinh_Load(object sender, RoutedEventArgs e)
        {
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
            ucTrangTimViec.btnQuanLyTaiKhoan.Click += new RoutedEventHandler(this.btnQuanLyTaiKhoan_Click);
            ucTrangTimViec.cbDiaDiem.SelectionChanged += new SelectionChangedEventHandler(this.SelectionChanged);
            ucTrangTimViec.cbKinhNghiem.SelectionChanged += new SelectionChangedEventHandler(this.SelectionChanged);
            ucTrangTimViec.cbLinhVuc.SelectionChanged += new SelectionChangedEventHandler(this.SelectionChanged);
            ucTrangTimViec.cbLuong.SelectionChanged += new SelectionChangedEventHandler(this.SelectionChanged);

            BitmapImage bitmapImg = MediaHandler.SetImage(ungVien.Anh, ungVien.Id);
            if (bitmapImg != null)
                ucTrangTimViec.imgAnh.ImageSource = bitmapImg;
            ucTrangTimViec.lblTen.Content = ungVien.HoTen;

            donList.Clear();
            DataTable dt = donDAO.Load();
            cvList.Clear();
            DataTable dtCV = cvDAO.Get(ungVien);
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don(dr);
                donList.Add(don);
            }
            foreach (DataRow dr in dtCV.Rows)
            {
                CV cv = new CV(dr);
                cvList.Add(cv);
            }
            var listLinhVuc = cvList.Select(u => u.LinhVuc).ToList();
            donList = Filter.SapXepHienThiUuTienTheoLinhVuc(donList, listLinhVuc);
            DangUCDon();
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            DangUCDon();
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DangUCDon();
        }
        private void btnQuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            WTrangChinhUngVien wTrangChinhUngVien = new WTrangChinhUngVien(ungVien);
            this.Close();
            wTrangChinhUngVien.ShowDialog();
        }
    }
}
