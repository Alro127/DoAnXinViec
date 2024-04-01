using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        CV cv = new CV();
        CVDAO cvDAO = new CVDAO();
        UCHoSoCuaBan uCHoSoCuaBan = new UCHoSoCuaBan();
        public WTrangChinhUngVien()
        {
            InitializeComponent();
        }
        public WTrangChinhUngVien(UngVien ungVien)
        {
            InitializeComponent();
            this.UngVien = ungVien;
            this.DataContext = ungVien;
        }

        public UngVien UngVien { get => ungVien; set => ungVien = value; }
        public CV Cv { get => cv; set => cv = value; }

        private void btnHoSoCuaBan_Click(object sender, RoutedEventArgs e)
        {
            uCHoSoCuaBan.tbiThongTinCaNhan.DataContext = ungVien;
            uCHoSoCuaBan.tbiThongTinCV.DataContext = Cv;
            uCHoSoCuaBan.btnLuuVaDangHoSo.Click += new RoutedEventHandler(this.btnLuuVaDangHoSo_Click);
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoCuaBan);
        }
        private void btnLuuVaDangHoSo_Click(object sender, RoutedEventArgs e)
        {
            ungVienDAO.CapNhat(UngVien);
            Cv.NgayDang = DateTime.Now.Date;
            Cv.NgayToiHan = new DateTime(3000, 12, 31).Date;
            Cv.UngVien = UngVien;
            Cv.IdUV = UngVien.IdUV;
            cvDAO.Them(Cv);
        }
    } 
}
