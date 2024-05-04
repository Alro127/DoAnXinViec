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
    /// Interaction logic for WDoiMatKhau.xaml
    /// </summary>
    public partial class WDoiMatKhau : Window
    {
        TaiKhoan taiKhoan;
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        public WDoiMatKhau()
        {
            InitializeComponent();
        }
        public WDoiMatKhau(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;

        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            taiKhoan.MatKhau = txtMatKhauCu.Password;
            if (!taiKhoanDAO.CheckPassWord(taiKhoan))
            {
                MessageBox.Show("Mật khẩu cũ không trùng khớp");
                return;
            }
            if (txtMatKhauMoi.Password != txtXacNhanMatKhau.Password)
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp");
                return;
            }
            taiKhoan.MatKhau = txtMatKhauMoi.Password;
            taiKhoanDAO.DoiMatKhau(taiKhoan);
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}