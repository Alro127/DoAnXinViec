using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for WDangKy.xaml
    /// </summary>
    public partial class WDangKy : Window
    {
        DBConnection dBConnection = new DBConnection();
        public WDangKy()
        {
            InitializeComponent();
        }
        bool checkNull()
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống");
                txtTenDangNhap.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Password))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                txtMatKhau.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtXacNhanMatKhau.Password))
            {
                MessageBox.Show("Xác nhận mật khẩu không được bỏ trống");
                txtXacNhanMatKhau.Focus();
                return false;
            }
            if (txtMatKhau.Password != txtXacNhanMatKhau.Password)
            {
                MessageBox.Show("Mật khẩu không khớp");
                txtMatKhau.Focus();
                return false;
            }
            return true;
        }
        private void btnDangKyUngVien_Click(object sender, RoutedEventArgs e)
        {
            if (!checkNull())
                return;

            TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, "uv");

            if (!dBConnection.CheckSignUp(taiKhoan))
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                txtTenDangNhap.Focus();
                return;
            }

            WThongTinUngVien wthongTinUngVien = new WThongTinUngVien(taiKhoan);
            wthongTinUngVien.ShowDialog();
        }
        private void btnDangKyCongTy_Click(object sender, RoutedEventArgs e)
        {
            if (!checkNull())
                return;

            TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, "ct");

            if (!dBConnection.CheckSignUp(taiKhoan))
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }
            WThongTinCongTy wthongTinCongTy = new WThongTinCongTy(taiKhoan);
            wthongTinCongTy.ShowDialog();
        }
    }
}