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
    /// Interaction logic for UCChinhSuaCV.xaml
    /// </summary>
    public partial class UCChinhSuaCV : UserControl
    {
        UngVien ungVien;
        UngVien tempUngVien;
        UngVienDAO ungVienDAO = new UngVienDAO();
        CV cv;
        CV tempcv;
        CVDAO cvDAO = new CVDAO();
        private void SetImage(string imageName)
        {
            BitmapImage bitmapImg = MediaHandler.SetImage(imageName, ungVien.Id);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }
        public UCChinhSuaCV(UngVien ungVien,CV cV)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            this.tempUngVien = new UngVien(ungVien);
            this.tbiThongTinCaNhan.DataContext = tempUngVien;
            this.cv = cV;
            this.tempcv= new CV(cV);
            this.tbiThongTinCV.DataContext = tempcv;
            SetImage(ungVien.Anh);
        }
        private void btnLuuVaDangHoSo_Click(object sender, RoutedEventArgs e)
        {
            this.ungVien = new UngVien(tempUngVien);
            ungVienDAO.CapNhat(ungVien, "UngVien");
            cvDAO.CapNhat(cv);
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

        private void btnTaiAnhLen_Click(object sender, RoutedEventArgs e)
        {
            cv.Anh = MediaHandler.SelectImageAndSave(ungVien.Id);
            SetImage(cv.Anh);
        }
        public UCChinhSuaCV()
        {
            InitializeComponent();
        }
    }
}
