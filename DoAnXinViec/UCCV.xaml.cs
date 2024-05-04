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
    /// Interaction logic for UCUngVien.xaml
    /// </summary>
    public partial class UCCV : UserControl
    {
        CV cv;
        public UCCV(CV cv, YeuThich yeuThich)
        {
            InitializeComponent();
            this.cv = cv;
            ucCV.DataContext = cv;
            btnYeuThich.Tag = cv.Id;

            YeuThichDAO yeuThichDAO = new YeuThichDAO();
            if (yeuThichDAO.CheckExist(yeuThich))
                btnYeuThich.IsChecked = true;
            else
                btnYeuThich.IsChecked = false;

            BitmapImage bitmapImg = MediaHandler.SetImage(cv.Anh, cv.UngVien.Id);
            if (bitmapImg != null)
                imgAnh.Source = bitmapImg;

            grbViTriUngTuyen.Header = Cv.ViTriUngTuyen;
            lblTenUngVien.Content = Cv.UngVien.HoTen;
            lblNoiLamViec.Content = "Địa điểm: " + Cv.UngVien.TinhThanh;
            lblLuong.Content = Cv.Luong;
            lblKinhNghiem.Content = "Kinh nghiệm: " + Cv.NamKinhNghiem;
            lblthoigiandang.Content = Filter.tinhThoiGian(Cv.NgayDang);
        }
        
        public CV Cv { get => this.cv; set => this.cv = value; }


        private void ucCV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WCVChiTiet wCVChiTiet = new WCVChiTiet(Cv);
            wCVChiTiet.ShowDialog();
        }
    }
}