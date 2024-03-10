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
    /// Interaction logic for WDangKy.xaml
    /// </summary>
    public partial class WDangKy : Window
    {
        public WDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKyUngVien_Click(object sender, RoutedEventArgs e)
        {
            WThongTinUngVien wThongTinUngVien = new WThongTinUngVien();
            wThongTinUngVien.ShowDialog();
        }

        private void btnDangKyCongTy_Click(object sender, RoutedEventArgs e)
        {
            WThongTinCongTy wThongTinCongTy = new WThongTinCongTy();
            wThongTinCongTy.ShowDialog();
        }
    }
}
