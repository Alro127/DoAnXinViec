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
    /// Interaction logic for WDangNhap.xaml
    /// </summary>
    public partial class WDangNhap : Window
    {
        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, "ct");

            if (rdoUngVien.IsChecked == true)
            {
                taiKhoan.Quyen = "uv";
            }

            string getuser = taiKhoanDAO.Checklogin(taiKhoan);
            if (getuser == "Tài khoản hoặc mật khẩu không đúng!")
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                return;
            }

            MessageBox.Show("Xin chúc mừng bạn đã đăng nhập thành công");

            if (taiKhoan.Quyen == "uv")
            {
                WTrangXemDon wTrangXemDon = new WTrangXemDon(taiKhoan.Id);
                wTrangXemDon.ShowDialog();
            }
            else
            {
                WTrangChinhCty wTrangChinhCty = new WTrangChinhCty(taiKhoan.Id);
                wTrangChinhCty.ShowDialog();
            }
        }

        private void lblDangKy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WDangKy wDangKy = new WDangKy();
            this.Close();
            wDangKy.ShowDialog();
        }
    }
}
