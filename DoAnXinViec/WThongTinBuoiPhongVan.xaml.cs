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
    /// Interaction logic for WThongTinBuoiPhongVan.xaml
    /// </summary>
    public partial class WThongTinBuoiPhongVan : Window
    {
        CV cv;
        public WThongTinBuoiPhongVan(CV cv,UngVien ungvien,PhongVan phongVan,Don don)
        {
            this.cv = cv;
            InitializeComponent();
            lblTenBuoiPhongvan.Content = phongVan.TenBuoiPV;
            lblTenUngVien.Content += ungvien.HoTen;
            lblVitriungtuyen.Content += don.TenCV;
            lblDiaDiem.Content += phongVan.DiaDiem;
            string thoiGian = $"{phongVan.ThoiGian.Hour} giờ {phongVan.ThoiGian.Minute} phút, ngày {phongVan.ThoiGian.Day} tháng {phongVan.ThoiGian.Month} năm {phongVan.ThoiGian.Year}";
            lblThoiGian.Content += thoiGian;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WCVChiTiet wCVChiTiet = new WCVChiTiet(cv);
            wCVChiTiet.ShowDialog();
        }
    }
}
