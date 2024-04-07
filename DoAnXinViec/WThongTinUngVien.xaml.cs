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
    /// Interaction logic for WThongTinUngVien.xaml
    /// </summary>
    public partial class WThongTinUngVien : Window
    {
        UngVienDAO ungVienDAO = new UngVienDAO();
        UngVien ungVien = new UngVien();
        TaiKhoan taiKhoan;
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        public WThongTinUngVien()
        {
            InitializeComponent();
        }
        public WThongTinUngVien(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.TaiKhoan = taiKhoan;
            this.DataContext = UngVien;
        }

        public TaiKhoan TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public UngVien UngVien { get => ungVien; set => ungVien = value; }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            ungVien.Id = taiKhoan.Id;
            ungVien.Anh = "";
            ungVien.GT = "";
            if (ungVienDAO.Them(ungVien, "UngVien") == true && taiKhoanDAO.SignUp(taiKhoan) == true)
                MessageBox.Show("Thành công");
        }
    }
}