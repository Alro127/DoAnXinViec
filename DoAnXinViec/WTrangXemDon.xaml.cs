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
        List<Don> donList = new List<Don>();
        public WTrangXemDon(string id)
        {
            InitializeComponent();
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
            ucTrangTimViec.cbDiaDiem.SelectionChanged += new SelectionChangedEventHandler(this.cbDiaDiem_SelectionChanged);
            DataTable dt = ungVienDAO.Get(id, "UngVien");
            ungVien = new UngVien(dt.Rows[0]);
        }
        bool CheckTimKiem(Don don)
        {
            if (ucTrangTimViec.txtTimKiem.Text == "" || don.TenCV.Contains(ucTrangTimViec.txtTimKiem.Text))
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
        bool CheckKinhNghiem(Don don)
        {
            string kn = ucTrangTimViec.cbKinhNghiem.Text;
            if (string.IsNullOrEmpty(kn)) 
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
            foreach (Don don in donList)
            {
                if (CheckTimKiem(don)==true && CheckDiaDiem(don)==true && CheckLuong(don)==true)
                {
                    UCDon uCDon = new UCDon(don);
                    CongTyDAO congTyDAO = new CongTyDAO();
                    DataTable dt = congTyDAO.Get(don.IdCT, "Cty");
                    CongTy congTy = new CongTy(dt.Rows[0]);
                    BitmapImage bitmapImg = ImageHandler.SetImage(congTy.Anh,congTy.Id);
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
                Don don = new Don(dr);
                donList.Add(don);
            }
            DangUCDon();
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            Don don = (Don)(sender as Button).Tag;
            WDonChiTiet wDonChiTiet = new WDonChiTiet(don, ungVien);
            donDAO.TangLuotXem(don);
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
