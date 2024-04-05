using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
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
        UngVienDAO ungVienDAO = new UngVienDAO();
        YeuThichDAO yeuThichDAO = new YeuThichDAO();
        CongTy congTy = new CongTy();
        public WTimUngVien()
        {
            InitializeComponent();
        }
        public WTimUngVien(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
        }
        void DangUCCV(DataRow dr)
        {
            CV cv = new CV();
            UngVien ungVien = new UngVien();
            Utility.SetItemFromRow(cv, dr);
            DataTable dt = ungVienDAO.Get(cv.IdUV, "UngVien");
            Utility.SetItemFromRow(ungVien, dt.Rows[0]);
            cv.UngVien = ungVien;
            UCCV ucCV = new UCCV(cv);
            ucCV.DataContext = cv;
            ucCV.MouseDoubleClick += new MouseButtonEventHandler(this.UCCV_Click);
            ucCV.btnYeuThich.Click += new RoutedEventHandler(this.btnYeuThich_Click);
            ucCV.btnYeuThich.Tag = cv.Id;
            YeuThich yeuThich = new YeuThich(cv.Id, congTy.Id);
            if (yeuThichDAO.CheckExist(yeuThich)) 
                ucCV.btnYeuThich.IsChecked = true;
            else
                ucCV.btnYeuThich.IsChecked= false;

            BitmapImage bitmapImg = ImageHandler.SetImage(cv.UngVien.Anh);
            if (bitmapImg != null)
                ucCV.imgAnh.Source = bitmapImg;
            ucTrangTimViec.wpDon.Children.Add(ucCV);
        }

        void UCCV_Click(object sender, MouseButtonEventArgs e)
        {
            WCVChiTiet wCVChiTiet = new WCVChiTiet((CV)(sender as UCCV).DataContext);
            wCVChiTiet.ShowDialog();
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
                DangUCCV(dr);
            }
        }
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            ucTrangTimViec.wpDon.Children.Clear();
            DataTable dt = cvDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                if (((string)dr["LinhVuc"]).Contains(ucTrangTimViec.txtTimKiem.Text))
                    DangUCCV(dr);
            }
        }

        private void WTimUngVien_Load(object sender, RoutedEventArgs e)
        {
            Load();
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
        }
        private void btnQuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            WTrangChinhCty wTrangChinhCty = new WTrangChinhCty(congTy);
            this.Close();
            wTrangChinhCty.ShowDialog();
        }
    }
}