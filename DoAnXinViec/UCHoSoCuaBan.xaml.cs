using System;
using System.Collections.Generic;
using System.Drawing;
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
        CV cv = new CV();

        public UngVien TempUngVien { get => tempUngVien; set => tempUngVien = value; }
        public CV Cv { get => cv; set => cv = value; }

        private void SetImage(string imageName)
        {
            BitmapImage bitmapImg = MediaHandler.SetImage(imageName, TempUngVien.Id);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }    
        public UCHoSoCuaBan(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            this.TempUngVien = new UngVien(ungVien);
            this.tbiThongTinCaNhan.DataContext = TempUngVien;
            this.tbcHoSoCuaBan.DataContext = Cv;
            SetImage(TempUngVien.Anh);
        }
        public UCHoSoCuaBan(CV cv)
        {
            InitializeComponent();
            this.Cv = cv;
            this.TempUngVien = this.Cv.UngVien;
            this.tbiThongTinCaNhan.DataContext = this.Cv.UngVien;
            this.tbcHoSoCuaBan.DataContext = this.Cv;
            SetImage(this.Cv.UngVien.Anh);
        }

        private void btnXemTruoc_Click(object sender, RoutedEventArgs e)
        {
            Cv.NgayDang = DateTime.Now.Date;
            Cv.NgayToiHan = new DateTime(3000, 12, 31).Date;
            Cv.UngVien = TempUngVien;
            Cv.IdUV = TempUngVien.Id;
            WCVChiTiet wCVChiTiet = new WCVChiTiet(Cv);
            wCVChiTiet.ShowDialog();
        }

        private void btnTaiAnhLen_Click(object sender, RoutedEventArgs e)
        {
            Cv.Anh = MediaHandler.SelectImageAndSave(ungVien.Id);
            SetImage(Cv.Anh);
        }
    }
}
