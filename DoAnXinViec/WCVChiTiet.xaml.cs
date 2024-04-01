using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for WCVChiTiet.xaml
    /// </summary>
    public partial class WCVChiTiet : Window
    {
        CV cv;
        public WCVChiTiet()
        {
            InitializeComponent();
        }
        public WCVChiTiet(CV cv)
        {
            InitializeComponent();
            this.Cv = cv;
            this.DataContext = Cv;
            //lblGioiTinh.Content = Cv.UngVien.GioiTinh;
            //lblNgaySinh.Content = Cv.UngVien.NgaySinh.Date.ToString("dd/MM/yyyy");
            /*lblDiaChi.Content = Cv.UngVien.DiaChi;
            lblEmail.Content = Cv.UngVien.Email;
            lblSDT.Content = Cv.UngVien.SDT;
            elpAnh.DataContext = Cv.UngVien;*/
        }

        public CV Cv { get => cv; set => cv = value; }
    }
}
