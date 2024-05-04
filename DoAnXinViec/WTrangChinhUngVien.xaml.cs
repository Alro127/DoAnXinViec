using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for WTrangChinhCty.xaml
    /// </summary>
    public partial class WTrangChinhUngVien : Window
    {
        UngVien ungVien;
        UngVienDAO ungVienDAO = new UngVienDAO();
        UCChinhSuaThongTinCaNhan uCChinhSuaThongTinCaNhan;
        public WTrangChinhUngVien(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            this.DataContext = ungVien;
            imgAnh.ImageSource = MediaHandler.SetImage(ungVien.Anh, ungVien.Id);
        }
        private void SetImage()
        {
            BitmapImage bitmapImg = MediaHandler.SetImage(ungVien.Anh, ungVien.Id);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            ungVien = uCChinhSuaThongTinCaNhan.UngVien;
            SetImage();
            if (ungVienDAO.CapNhat(ungVien, "UngVien") == true)
                System.Windows.MessageBox.Show("ThanhCong");
        }
        private void btnChinhSuaThongTinCaNhan_Click(object sender, RoutedEventArgs e)
        {
            uCChinhSuaThongTinCaNhan = new UCChinhSuaThongTinCaNhan(ungVien);
            uCChinhSuaThongTinCaNhan.btnLuu.Click += new RoutedEventHandler(this.btnLuu_Click);
            stMain.Children.Clear();
            stMain.Children.Add(uCChinhSuaThongTinCaNhan);
        }
        private void btnDanhSachCV_Click(object sender, RoutedEventArgs e)
        {
            UCDanhSachCV uCDanhSachCV = new UCDanhSachCV(ungVien);
            stMain.Children.Clear();
            stMain.Children.Add(uCDanhSachCV);
        }
        private void btnViecDaUngTuyen_Click(object sender, RoutedEventArgs e)
        {
            UCViecDaUngTuyen uCViecDaUngTuyen = new UCViecDaUngTuyen(ungVien);
            stMain.Children.Clear();
            stMain.Children.Add(uCViecDaUngTuyen);
        }

        private void btnCongViecYeuThich_Click(object sender, RoutedEventArgs e)
        {
            UCCongViecYeuThich uCCongViecYeuThich = new UCCongViecYeuThich(ungVien);
            stMain.Children.Clear();
            stMain.Children.Add(uCCongViecYeuThich);
        }

        private void btnTimKiemCongViec_Click(object sender, RoutedEventArgs e)
        {
            WTrangXemDon wTrangXemDon = new WTrangXemDon(ungVien);
            wTrangXemDon.ShowDialog();
        }
    } 
}
