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
        UCChinhSuaThongTinCaNhan uCChinhSuaThongTinCaNhan;
        public WTrangChinhUngVien()
        {
            InitializeComponent();
        }
        public WTrangChinhUngVien(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            this.DataContext = ungVien;
        }
        //Tạm để đợi tìm cách làm bên xaml
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            ungVien = uCChinhSuaThongTinCaNhan.UngVien;
            if (!File.Exists(uCChinhSuaThongTinCaNhan.NewImagePath))
            {
                File.Copy(ungVien.Anh,uCChinhSuaThongTinCaNhan.NewImagePath);
            }
            UngVienDAO ungVienDAO = new UngVienDAO();
            if (ungVienDAO.CapNhat(ungVien, "UngVien") == true)
                System.Windows.MessageBox.Show("ThanhCong");
            this.imgAnh.ImageSource = new BitmapImage(new Uri(ungVien.Anh));
        }
        private void btnChinhSuaThongTinCaNhan_Click(object sender, RoutedEventArgs e)
        {
            uCChinhSuaThongTinCaNhan = new UCChinhSuaThongTinCaNhan(ungVien);
            uCChinhSuaThongTinCaNhan.btnLuu.Click += new RoutedEventHandler(this.btnLuu_Click);
            stMain.Children.Clear();
            stMain.Children.Add(uCChinhSuaThongTinCaNhan);
        }
        private void btnHoSoCuaBan_Click(object sender, RoutedEventArgs e)
        {
            UCHoSoCuaBan uCHoSoCuaBan = new UCHoSoCuaBan(ungVien);
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoCuaBan);
        }
        private void btnChinhSuaCV_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnViecDaUngTuyen_Click(object sender, RoutedEventArgs e)
        {
            UCViecDaUngTuyen uCViecDaUngTuyen = new UCViecDaUngTuyen(ungVien);
            stMain.Children.Clear();
            stMain.Children.Add(uCViecDaUngTuyen);
        }
    } 
}
