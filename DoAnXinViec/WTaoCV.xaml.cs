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
    /// Interaction logic for WTaoCV.xaml
    /// </summary>
    public partial class WTaoCV : Window
    {
        UngVien ungVien = new UngVien();
        UCHoSoCuaBan uCHoSoCuaBan;
        UngVienDAO ungVienDAO = new UngVienDAO();
        public WTaoCV(UngVien ungVien)
        {
            InitializeComponent();
            uCHoSoCuaBan = new UCHoSoCuaBan(ungVien);
            uCHoSoCuaBan.btnLuuVaDangHoSo.Click += new RoutedEventHandler(btnLuuVaDangHoSo_Click);
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoCuaBan);
        }
        private void btnLuuVaDangHoSo_Click(object sender, RoutedEventArgs e)
        {
            this.ungVien = new UngVien(uCHoSoCuaBan.TempUngVien);
            ungVienDAO.CapNhat(ungVien, "UngVien");
            uCHoSoCuaBan.Cv.NgayDang = DateTime.Now.Date;
            uCHoSoCuaBan.Cv.NgayToiHan = new DateTime(3000, 12, 31).Date;
            uCHoSoCuaBan.Cv.UngVien = ungVien;
            uCHoSoCuaBan.Cv.IdUV = ungVien.Id;
            CVDAO cvDAO = new CVDAO();
            cvDAO.Them(uCHoSoCuaBan.Cv);
        }
    }
}
