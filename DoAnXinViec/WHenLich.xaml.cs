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
        public WHenLich()
        {
            InitializeComponent();
        }
        public WHenLich(Don don, PhongVan phongVan,UngVien ungVien,CongTy cty)
        {
            InitializeComponent();
            lblViTriTuyenDung.Content += don.TenCV;
            string thoiGian = $"{phongVan.ThoiGian.Hour} giờ {phongVan.ThoiGian.Minute} phút, ngày {phongVan.ThoiGian.Day} tháng {phongVan.ThoiGian.Month} năm {phongVan.ThoiGian.Year}";
            lblThoiGian.Content += thoiGian;
            lblDiaDiem.Content += phongVan.DiaDiem;
            lblKinhGui.Content += ungVien.HoTen;
            tbLuuY.Text = phongVan.LuuY;
            lblSdt.Content += cty.SDT;
            lblEmail.Content += cty.Email;
            lblTenCty.Content = cty.TenCT;
        }
    }
}
