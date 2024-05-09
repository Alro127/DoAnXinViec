using DoAnXinViec.DAO;
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
    /// Interaction logic for WHenLich.xaml
    /// </summary>
    public partial class WHenLich : Window
    {
        HoSo hoSo;
        HoSoDAO hoSoDAO = new HoSoDAO();
        PhongVan phongVan;
        PhongVanDAO phongVanDAO = new PhongVanDAO();
        public WHenLich()
        {
            InitializeComponent();
        }
        public WHenLich(Don don, PhongVan phongVan, UngVien ungVien, CongTy cty, HoSo hoSo)
        {
            InitializeComponent();
            this.hoSo = hoSo;
            this.phongVan = phongVan;
            lblViTriTuyenDung.Content += don.TenCV;
            string thoiGian = $"{phongVan.ThoiGian.Hour} giờ {phongVan.ThoiGian.Minute} phút, ngày {phongVan.ThoiGian.Day} tháng {phongVan.ThoiGian.Month} năm {phongVan.ThoiGian.Year}";
            lblThoiGian.Content += thoiGian;
            lblDiaDiem.Content += phongVan.DiaDiem;
            lblKinhGui.Content += ungVien.HoTen;
            tbLuuY.Text = phongVan.LuuY;
            lblSdt.Content += cty.SDT;
            lblEmail.Content += cty.Email;
            lblTenCty.Content = cty.TenCT;
            if (hoSo.TrangThai == "Chấp nhận")
            {
                btnTuChoi.Visibility = Visibility.Hidden;
                btnXacNhan.Visibility = Visibility.Hidden;
            }
        }

        private void btnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            btnXacNhan.Content = "Đã xác nhận";
            hoSo.TrangThai = "Chấp nhận";
            phongVan.XacNhan = "Đã xác nhận";
            btnXacNhan.IsEnabled = false;
            btnTuChoi.Visibility = Visibility.Hidden;
            hoSoDAO.CapNhat(hoSo);
        }

        private void btnTuChoi_Click(object sender, RoutedEventArgs e)
        {
            btnTuChoi.Content = "Đã từ chối";
            hoSo.TrangThai = "Từ chối";
            phongVan.XacNhan = "Đã xác nhận";
            btnXacNhan.IsEnabled = false;
            btnTuChoi.IsEnabled = false;
            hoSoDAO.CapNhat(hoSo);
            phongVanDAO.Xoa(phongVan);
        }
    }
}
