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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for UCHoSoCuaBan.xaml
    /// </summary>
    public partial class UCHoSoCuaBan : UserControl
    {
        UngVien ungVien;
        UngVien tempUngVien;
        UngVienDAO ungVienDAO = new UngVienDAO();
        CV cv = new CV();
        CVDAO cvDAO = new CVDAO();
        public UCHoSoCuaBan()
        {
            InitializeComponent();
        }
        public UCHoSoCuaBan(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            this.tempUngVien = new UngVien(ungVien);
            this.tbiThongTinCaNhan.DataContext = tempUngVien;
            this.tbcHoSoCuaBan.DataContext = cv;
        }
        private void btnLuuVaDangHoSo_Click(object sender, RoutedEventArgs e)
        {
            this.ungVien = new UngVien(tempUngVien);
            ungVienDAO.CapNhat(ungVien, "UngVien");
            cv.NgayDang = DateTime.Now.Date;
            cv.NgayToiHan = new DateTime(3000, 12, 31).Date;
            cv.UngVien = ungVien;
            cv.IdUV = ungVien.Id;
            cvDAO.Them(cv);
        }

        private void btnXemTruoc_Click(object sender, RoutedEventArgs e)
        {
            cv.NgayDang = DateTime.Now.Date;
            cv.NgayToiHan = new DateTime(3000, 12, 31).Date;
            cv.UngVien = tempUngVien;
            cv.IdUV = tempUngVien.Id;
            WCVChiTiet wCVChiTiet = new WCVChiTiet(cv);
            wCVChiTiet.ShowDialog();
        }
    }
}
