using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for WDonChiTiet.xaml
    /// </summary>
    public partial class WDonChiTiet : Window
    {
        HoSoDAO hoSoDAO= new HoSoDAO();
        Don don = new Don();
        string idUV = "UV1";
        public WDonChiTiet()
        {
            InitializeComponent();
        }

        internal Don Don { get => don; set => don = value; }

        private void WDonChiTiet_Load(object sender, RoutedEventArgs e)
        {
            tbMoTaCV.Text = Don.MoTaCV;
            tbQuyenLoi.Text = Don.QuyenLoi;
            tbYeuCau.Text = Don.YeuCau;
        }
        private void btnUngTuyenNgay_Click(object sender, RoutedEventArgs e)
        {
            HoSo hoSo = new HoSo(Don.IdCV,idUV,"Online", DateTime.Now.Date,1);
            hoSoDAO.Them(hoSo);
        }
    }
}
