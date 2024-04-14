using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WTrangChuCTy.xaml
    /// </summary>
    public partial class WTrangChuCTy : Window
    {
        CongTy congTy;
        UngVien ungVien;
        DonDAO donDAO = new DonDAO();
        YeuThichDAO yeuThichDAO = new YeuThichDAO();
        List<Don> donList = new List<Don>();
        public WTrangChuCTy(CongTy congTy, UngVien ungVien)
        {
            InitializeComponent();
            this.congTy = congTy;
            this.ungVien = ungVien;
            this.DataContext = congTy;
            imgAnh.Source = MediaHandler.SetImage(congTy.Anh, congTy.Id);
            LoadDon();
            LoadAnh();
            lblSoLuongDon.Content = "Có " + donList.Count() + " công việc đang tuyển";
        }
        void DangUCDon()
        {
            stDon.Children.Clear();
            foreach (Don don in donList)
            {
                YeuThich yeuThich = new YeuThich(don.IdDon, ungVien.Id);
                UCDon uCDon = new UCDon(don, yeuThich);
                stDon.Children.Add(uCDon);
                uCDon.btnXem.Click += new RoutedEventHandler(this.btnXem_Click);
                uCDon.btnYeuThich.Click += new RoutedEventHandler(this.btnYeuThich_Click);
            }
        }
        void LoadDon()
        {
            DataTable dt = donDAO.LoadForCT(congTy);
            donList.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don(dr);
                donList.Add(don);
            }
            DangUCDon();
        }
        void LoadAnh()
        {
            string[] DanhSachAnh = MediaHandler.GetImagesFromFolder(congTy.Id);
            for (int i = 0; i < DanhSachAnh.Length; i++)
            {
                Image anh = new Image() { Width = 100, Height = 100, Margin = new Thickness(10, 9, 0, 9) };
                anh.Source = MediaHandler.SetImage(DanhSachAnh[i], congTy.Id);
                wpAnh.Children.Add(anh);
            }
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            Don don = (Don)(sender as Button).Tag;
            WDonChiTiet wDonChiTiet = new WDonChiTiet(don, ungVien);
            donDAO.TangLuotXem(don);
            wDonChiTiet.ShowDialog();
            LoadDon();
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
    }
}