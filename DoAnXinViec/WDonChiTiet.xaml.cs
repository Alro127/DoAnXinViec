using System;
using System.Collections.Generic;
using System.Data;
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
        UngVien ungVien;

        CongTy congTy;
        CongTyDAO congTyDAO = new CongTyDAO();
        public WDonChiTiet(Don don, UngVien ungVien)
        {
            InitializeComponent();
            this.don = don;
            this.ungVien = ungVien;
        }
        void Check()
        {
            if (hoSoDAO.CheckExist(don, ungVien.Id))
            {
                btnUngTuyenNgay.Content = "Đã gửi đơn ứng tuyển";
                btnUngTuyenNgay.IsEnabled = false;
            }
        }
        private void WDonChiTiet_Load(object sender, RoutedEventArgs e)
        {
            Check();
            this.DataContext = don;

            DataTable dt = congTyDAO.Get(don.IdCT, "Cty");
            congTy = new CongTy(dt.Rows[0]);
            imgAnh.ImageSource = ImageHandler.SetImage(congTy.Anh, congTy.Id);
        }
        private void btnUngTuyenNgay_Click(object sender, RoutedEventArgs e)
        {
            WChonCV wChonCV = new WChonCV(ungVien);
            wChonCV.ShowDialog();
            if (wChonCV.Cv != null)
            {
                HoSo hoSo = new HoSo(don.IdDon, wChonCV.Cv.Id, "Online", DateTime.Now.Date, "Đợi");
                hoSoDAO.Them(hoSo);
                donDAO.TangLuotNop(don);
                Check();
            }    
            
        }

        private void btnXemCongTy_Click(object sender, RoutedEventArgs e)
        {
            WTrangChuCTy wTrangChuCTy = new WTrangChuCTy(congTy);
            wTrangChuCTy.ShowDialog();
        }
    }
}
