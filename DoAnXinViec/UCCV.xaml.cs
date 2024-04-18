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
        public UCCV(CV cv, YeuThich? yeuThich=null)
        {
            InitializeComponent();
            this.cv = cv;
            ucCV.DataContext = cv;
            btnYeuThich.Tag = cv.Id;
            if (yeuThich != null )
            {
                YeuThichDAO yeuThichDAO = new YeuThichDAO();
                if (yeuThichDAO.CheckExist(yeuThich))
                    btnYeuThich.IsChecked = true;
                else
                    btnYeuThich.IsChecked = false;
            }

            BitmapImage bitmapImg = MediaHandler.SetImage(cv.Anh, cv.UngVien.Id);
            if (bitmapImg != null)
                imgAnh.Source = bitmapImg;

            grbViTriUngTuyen.Header = Cv.UngVien.HoTen;
            lblTenUngVien.Content = Cv.ViTriUngTuyen;
            lblNoiLamViec.Content ="Địa điểm: " + Cv.UngVien.TinhThanh;
            lblLuong.Content = Cv.Luong;
            lblKinhNghiem.Content = "Kinh nghiệm: " + Cv.NamKinhNghiem;
            lblthoigiandang.Content = tinhThoiGian(Cv.NgayDang);
        }
        public string tinhThoiGian(DateTime ngayDang)
        {
            TimeSpan timeSincePosted = DateTime.Now - ngayDang;
            if (timeSincePosted.TotalMinutes < 1)
                return "Bây giờ";
            if (timeSincePosted.TotalHours < 1)
                return $"{(int)timeSincePosted.TotalMinutes} phút trước";
            if (timeSincePosted.TotalDays < 1)
                return $"{(int)timeSincePosted.TotalHours} giờ trước";
            return $"{(int)timeSincePosted.TotalDays} ngày trước";
        }
        public CV Cv { get => this.cv; set => this.cv = value; }


        private void ucCV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WCVChiTiet wCVChiTiet = new WCVChiTiet(Cv);
            wCVChiTiet.ShowDialog();
        }
    }
}