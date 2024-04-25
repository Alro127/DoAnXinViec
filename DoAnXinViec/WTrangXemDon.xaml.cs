using MaterialDesignThemes.Wpf;
using System;
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
        CVDAO cVDAO = new CVDAO();
        YeuThichDAO yeuThichDAO = new YeuThichDAO();
        List<Don> donList = new List<Don>();
        List<CV> cvList = new List<CV> ();
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
        bool CheckTimKiem(Don don)
        {
            if (ucTrangTimViec.txtTimKiem.Text == "" || don.TenCV.ToLower().Contains(ucTrangTimViec.txtTimKiem.Text.ToLower()))
                return true;
            return false;
        }
        bool CheckDiaDiem(Don don)
        {
            if (ucTrangTimViec.cbDiaDiem.Text == "" || don.DiaDiem.Contains(ucTrangTimViec.cbDiaDiem.Text))
                return true;
            return false;
        }
        void GetMinMax(out int min, out int max, string t)
        {
            min = 0;
            max = int.MaxValue;
            if (t.Contains("Dưới"))
                max = int.Parse(Regex.Replace(t, "[^0-9]", ""));
            else if (t.Contains("Trên"))
                min = int.Parse(Regex.Replace(t, "[^0-9]", ""));
            else
            {
                string[] pair_t = t.Split('-');
                min = int.Parse(pair_t[0]);
                max = int.Parse(pair_t[1]);
            }
        }
        bool CheckLuong(Don don)
        {
            string t = ucTrangTimViec.cbLuong.Text;
            if (string.IsNullOrEmpty(t))
                return true;
            t = t.Replace("triệu", "");
            int min;
            int max;
            GetMinMax(out min, out max, t);
            string tDon = don.Luong;
            tDon = tDon.Replace("triệu", "");
            int minDon;
            int maxDon;
            GetMinMax(out minDon, out maxDon, tDon);
            if (maxDon > min && minDon < max) return true;
            return false;
        }
        bool CheckLinhVuc(Don don)
        {
            if (ucTrangTimViec.cbLinhVuc.Text == "" || don.LinhVuc.Contains(ucTrangTimViec.cbLinhVuc.Text))
                return true;
            return false;
        }
        bool CheckKinhNghiem(Don don)
        {
            string kn = ucTrangTimViec.cbKinhNghiem.Text;
            if (string.IsNullOrEmpty(kn) || kn == "Không yêu cầu") 
                return true;
            kn = kn.Replace("năm", "");
            int min, max;
            GetMinMax(out min, out max, kn);
            string knDon = don.KinhNghiem.Replace("năm", "");
            int knDonInt;
            if (string.IsNullOrEmpty(knDon) || knDon == "Không yêu cầu")
            {
                knDonInt = 0;
            }
            else if (knDon.Contains("Trên 5"))
            {
                knDonInt = int.Parse(knDon.Replace("Trên", ""));
            }
            else if (knDon.Contains("Dưới 1"))
            {
                knDonInt = int.Parse(knDon.Replace("Dưới", ""));
            }
            else knDonInt = int.Parse(knDon);
            if (min<=knDonInt && max>=knDonInt) return true;
            return false;

        }
        void DangUCDon()
        {
            ucTrangTimViec.wpDon.Children.Clear();
            foreach (Don don in donList)
            {
                if (CheckTimKiem(don) && CheckDiaDiem(don) && CheckLuong(don) && CheckKinhNghiem(don)&& CheckLinhVuc(don))
                {
                    YeuThich yeuThich = new YeuThich(don.IdDon, ungVien.Id);
                    UCDon uCDon = new UCDon(don, yeuThich);
                    ucTrangTimViec.wpDon.Children.Add(uCDon);
                    uCDon.btnXem.Click += new RoutedEventHandler(this.btnXem_Click);
                    uCDon.btnYeuThich.Click += new RoutedEventHandler(this.btnYeuThich_Click);
                }
            }

        }
        void Load()
        {
            donList.Clear();
            DataTable dtDon = donDAO.Load();
            cvList.Clear();
            DataTable dtCV = cVDAO.Load();
            foreach (DataRow dr in dtDon.Rows)
            {
                Don don = new Don(dr);
                donList.Add(don);
            }
            foreach (DataRow dr in dtCV.Rows)
            {
                CV cv = new CV(dr);
                cvList.Add(cv);
            }
            donList = donDAO.SapXepDonHienThiUuTienTheoLinhVuc(donList, cvList);
            DangUCDon();
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            Don don = (Don)(sender as Button).DataContext;
            WDonChiTiet wDonChiTiet = new WDonChiTiet(don, ungVien);
            donDAO.TangLuotXem(don);
            wDonChiTiet.ShowDialog();
            Load();            
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
            ucTrangTimViec.cbDiaDiem.SelectionChanged += new SelectionChangedEventHandler(this.cbDiaDiem_SelectionChanged);
            ucTrangTimViec.cbKinhNghiem.SelectionChanged += new SelectionChangedEventHandler(this.cbKinhNghiem_SelectionChanged);
            ucTrangTimViec.cbLuong.SelectionChanged += new SelectionChangedEventHandler(this.cbLuong_SelectionChanged);

            BitmapImage bitmapImg = MediaHandler.SetImage(ungVien.Anh, ungVien.Id);
            if (bitmapImg != null)
                ucTrangTimViec.imgAnh.ImageSource = bitmapImg;
            ucTrangTimViec.lblTen.Content = ungVien.HoTen;
            Load();
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            DangUCDon();
        }
        private void cbDiaDiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DangUCDon();
        }
        private void cbKinhNghiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DangUCDon();
        }
        private void cbLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
