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
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        public WDangKy()
        {
            InitializeComponent();
        }
        private void btnDangKyUngVien_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMatKhau.Password != txtXacNhanMatKhau.Password)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp");
                    return;
                }
                TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, "uv");
                if (taiKhoanDAO.CheckSignUp(taiKhoan))
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                    txtTenDangNhap.Focus();
                    return;
                }

                WThongTinUngVien wthongTinUngVien = new WThongTinUngVien(taiKhoan);
                wthongTinUngVien.ShowDialog();
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        private void btnDangKyCongTy_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtMatKhau.Password != txtXacNhanMatKhau.Password)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp");
                    return;
                }
                TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, "ct");

                if (taiKhoanDAO.CheckSignUp(taiKhoan))
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                    txtTenDangNhap.Focus();
                    return;
                }
                WThongTinCongTy wthongTinCongTy = new WThongTinCongTy(taiKhoan);
                wthongTinCongTy.ShowDialog();
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}