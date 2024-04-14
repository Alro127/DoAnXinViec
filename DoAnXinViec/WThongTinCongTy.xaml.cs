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
    /// Interaction logic for WThongTinCongTy.xaml
    /// </summary>
    public partial class WThongTinCongTy : Window
    {
        CongTy congTy = new CongTy();
        CongTyDAO congTyDAO = new CongTyDAO();
        TaiKhoan taiKhoan;
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();

        public WThongTinCongTy(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
            this.DataContext = congTy;
        }
        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            congTy.Id = taiKhoan.Id;
            congTy.Anh = "";
            if (congTyDAO.Them(congTy, "Cty") == true)
            {
                taiKhoanDAO.SignUp(taiKhoan);
                MediaHandler.CreateDirectory(congTy.Id);
                MessageBox.Show("Thành công");
                this.Close();
                WTrangChinhCty wTrangChinhCty = new WTrangChinhCty(congTy);
                wTrangChinhCty.ShowDialog();
            }
        }
    }
}