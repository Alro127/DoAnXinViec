using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for WTimUngVien.xaml
    /// </summary>
    public partial class WTimUngVien : Window
    {
        CVDAO cvDAO = new CVDAO();
        YeuThichDAO yeuThichDAO = new YeuThichDAO();
        CongTy congTy = new CongTy();
        List<CV> cvList = new List<CV>();

        public WTimUngVien(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            BitmapImage bitmapImg = MediaHandler.SetImage(congTy.Anh, congTy.Id);
            if (bitmapImg != null)
                ucTrangTimViec.imgAnh.ImageSource = bitmapImg;
            ucTrangTimViec.lblTen.Content = congTy.TenCT;
        }
        bool CheckTimKiem(CV cv)
        {
            if (ucTrangTimViec.txtTimKiem.Text == "" || cv.ViTriUngTuyen.Contains(ucTrangTimViec.txtTimKiem.Text))
                return true;
            return false;
        }
        bool CheckDiaDiem(CV cv)
        {
            if (ucTrangTimViec.cbDiaDiem.Text == "" || cv.UngVien.TinhThanh.Contains(ucTrangTimViec.cbDiaDiem.Text))
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
        bool CheckLuong(CV cv)
        {
            string t = ucTrangTimViec.cbLuong.Text;
            if (string.IsNullOrEmpty(t))
                return true;
            t = t.Replace("triệu", "");
            int min;
            int max;
            GetMinMax(out min, out max, t);
            string tCV = cv.Luong;
            tCV = tCV.Replace("triệu", "");
            int minDon;
            int maxDon;
            GetMinMax(out minDon, out maxDon, tCV);
            if (maxDon > min && minDon < max) return true;
            return false;
        }
        bool CheckKinhNghiem(CV cv)
        {
            string kn = ucTrangTimViec.cbKinhNghiem.Text;
            if (string.IsNullOrEmpty(kn))
                return true;
            kn = kn.Replace("năm", "");
            int min, max;
            GetMinMax(out min, out max, kn);
            string knCV = cv.NamKinhNghiem.Replace("năm", "");
            int knCVInt;
            if (string.IsNullOrEmpty(knCV) || knCV == "Không yêu cầu")
            {
                knCVInt = 0;
            }
            else if (knCV.Contains("Trên 5"))
            {
                knCVInt = int.Parse(knCV.Replace("Trên", ""));
            }
            else if (knCV.Contains("Dưới 1"))
            {
                knCVInt = int.Parse(knCV.Replace("Dưới", ""));
            }
            else knCVInt = int.Parse(knCV);
            if (min <= knCVInt && max >= knCVInt) return true;
            return false;

        }
        void DangUCCV()
        {
            ucTrangTimViec.wpDon.Children.Clear();
            foreach (CV cv in cvList)
            {
                if (CheckTimKiem(cv) && CheckDiaDiem(cv) && CheckLuong(cv) && CheckKinhNghiem(cv))
                {
                    YeuThich yeuThich = new YeuThich(cv.Id, congTy.Id);
                    UCCV ucCV = new UCCV(cv, yeuThich);
                    ucCV.btnYeuThich.Click += new RoutedEventHandler(this.btnYeuThich_Click);
                    ucTrangTimViec.wpDon.Children.Add(ucCV);
                }
            }
            
        }

        
        void btnYeuThich_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            if (toggleButton.IsChecked == true)
            {
                YeuThich yeuThich = new YeuThich((int)(toggleButton).Tag, congTy.Id);
                yeuThichDAO.Them(yeuThich);
            }
            else
            {
                YeuThich yeuThich = new YeuThich((int)(toggleButton).Tag, congTy.Id);
                yeuThichDAO.Xoa(yeuThich);
            }
        }
        void Load()
        {
            DataTable dt = cvDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                CV cv = new CV(dr);
                cvList.Add(cv);
            }
            DangUCCV();
        }

        private void WTimUngVien_Load(object sender, RoutedEventArgs e)
        {
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
            ucTrangTimViec.btnQuanLyTaiKhoan.Click += new RoutedEventHandler(this.btnQuanLyTaiKhoan_Click);
            ucTrangTimViec.cbDiaDiem.SelectionChanged += new SelectionChangedEventHandler(this.cbDiaDiem_SelectionChanged);
            ucTrangTimViec.cbKinhNghiem.SelectionChanged += new SelectionChangedEventHandler(this.cbKinhNghiem_SelectionChanged);
            ucTrangTimViec.cbLuong.SelectionChanged += new SelectionChangedEventHandler(this.cbLuong_SelectionChanged);

            BitmapImage bitmapImg = MediaHandler.SetImage(congTy.Anh, congTy.Id);
            if (bitmapImg != null)
                ucTrangTimViec.imgAnh.ImageSource = bitmapImg;
            ucTrangTimViec.lblTen.Content = congTy.HoTen;
            Load();
        }
        private void btnQuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            WTrangChinhCty wTrangChinhCty = new WTrangChinhCty(congTy);
            this.Close();
            wTrangChinhCty.ShowDialog();
        }
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            DangUCCV();
        }
        private void cbDiaDiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DangUCCV();
        }
        private void cbKinhNghiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DangUCCV();
        }
        private void cbLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DangUCCV();
        }
    }
}