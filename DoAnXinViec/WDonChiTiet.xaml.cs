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
        DonDAO donDAO = new DonDAO();
        string idUV;
        public WDonChiTiet()
        {
            InitializeComponent();
        }

        public WDonChiTiet(Don don, string idUV)
        {
            InitializeComponent();
            this.don = don;
            this.idUV = idUV;
        }

        public Don Don { get => don; set => don = value; }
        public string IdUV { get => idUV; set => idUV = value; }

        void Check()
        {
            if (hoSoDAO.CheckExist(Don, IdUV))
            {
                btnUngTuyenNgay.Content = "Đã gửi đơn ứng tuyển";
                btnUngTuyenNgay.IsEnabled = false;
            }
        }
        private void WDonChiTiet_Load(object sender, RoutedEventArgs e)
        {
            Check();
            this.DataContext = Don;
        }
        private void btnUngTuyenNgay_Click(object sender, RoutedEventArgs e)
        {
            HoSo hoSo = new HoSo(Don.IdCV,IdUV,"Online", DateTime.Now.Date,"Đợi");
            hoSoDAO.Them(hoSo);
            donDAO.TangLuotNop(Don);
            Check();
        }
    }
}
