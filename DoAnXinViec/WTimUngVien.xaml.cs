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
        void DangUCCV()
        {
            ucTrangTimViec.wpDon.Children.Clear();
            foreach (CV cv in cvList)
            {
                if (ucTrangTimViec.CheckTimKiem(cv.ViTriUngTuyen) && ucTrangTimViec.CheckDiaDiem(cv.UngVien.TinhThanh) && ucTrangTimViec.CheckLuong(cv.Luong) && ucTrangTimViec.CheckKinhNghiem(cv.KinhNghiem) && ucTrangTimViec.CheckLinhVuc(cv.LinhVuc))
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
        private void WTimUngVien_Load(object sender, RoutedEventArgs e)
        {
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
            ucTrangTimViec.btnQuanLyTaiKhoan.Click += new RoutedEventHandler(this.btnQuanLyTaiKhoan_Click);
            ucTrangTimViec.cbDiaDiem.SelectionChanged += new SelectionChangedEventHandler(this.SelectionChanged);
            ucTrangTimViec.cbKinhNghiem.SelectionChanged += new SelectionChangedEventHandler(this.SelectionChanged);
            ucTrangTimViec.cbLinhVuc.SelectionChanged += new SelectionChangedEventHandler(this.SelectionChanged);
            ucTrangTimViec.cbLuong.SelectionChanged += new SelectionChangedEventHandler(this.SelectionChanged);

            BitmapImage bitmapImg = MediaHandler.SetImage(congTy.Anh, congTy.Id);
            if (bitmapImg != null)
                ucTrangTimViec.imgAnh.ImageSource = bitmapImg;
            ucTrangTimViec.lblTen.Content = congTy.HoTen;
            DataTable dt = cvDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                CV cv = new CV(dr);
                cvList.Add(cv);
            }
            cvList = Filter.SapXepHienThiUuTienTheoLinhVuc(cvList, new List<string>() { congTy.LinhVuc });
            DangUCCV();
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
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DangUCCV();
        }
    }
}