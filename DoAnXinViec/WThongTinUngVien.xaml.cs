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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WThongTinUngVien.xaml
    /// </summary>
    public partial class WThongTinUngVien : Window
    {
        UngVienDAO ungVienDAO = new UngVienDAO();
        TaiKhoan taiKhoan;
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        public WThongTinUngVien(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                UngVien ungVien = new UngVien(taiKhoan.Id, txtHoten.Text, cbGioitinh.Text, dtpNgaysinh.SelectedDate.Value.Date, cbTinhThanh.Text, txtDiachi.Text, txtSdt.Text, txtEmail.Text, " ", " ");
                if (ungVienDAO.Them(ungVien, "UngVien") == true)
                {
                    taiKhoanDAO.SignUp(taiKhoan);
                    MediaHandler.CreateDirectory(ungVien.Id);
                    MessageBox.Show("Thành công");
                    this.Close();

                    WTrangChinhUngVien wTrangChinhUngVien = new WTrangChinhUngVien(ungVien);
                    wTrangChinhUngVien.Close();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}