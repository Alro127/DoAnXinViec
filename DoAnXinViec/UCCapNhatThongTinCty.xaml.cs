using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for UCCapNhapThongTinCty.xaml
    /// </summary>
    public partial class UCCapNhatThongTinCty : UserControl
    {
        CongTy congTy;
        TaiKhoan taiKhoan;
        Dictionary<Image, string> imagePaths = new Dictionary<Image, string>();
        string[] DanhSachAnh;
        public CongTy CongTy { get => congTy; set => congTy = value; }

        private void SetImage()
        {
            BitmapImage bitmapImg = MediaHandler.SetImage(congTy.Anh, CongTy.Id);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }
        public UCCapNhatThongTinCty(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = new CongTy(congTy);
            this.DataContext = this.congTy;
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            DataTable dt = taiKhoanDAO.Get(congTy.Id);
            taiKhoan = new TaiKhoan(dt.Rows[0]);
            pwMatKhau.Password = taiKhoan.MatKhau;
            SetImage();
            Load();
        }
        void Load()
        {
            DanhSachAnh = MediaHandler.GetImagesFromFolder(congTy.Id);
            for (int i = 0; i<DanhSachAnh.Length; i++)
            {
                Image anh = new Image() { Width = 100, Height = 100, Margin = new Thickness(10, 9, 0, 9) };
                BitmapImage bitmap = MediaHandler.SetImage(DanhSachAnh[i], congTy.Id);
                imagePaths.Add(anh, DanhSachAnh[i]);
                anh.Source = bitmap;
                anh.MouseLeftButtonDown += Image_MouseLeftButtonDown;
                stAnh.Children.Add(anh);
            }
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image clickedImage)
            {
                BitmapImage bitmap = clickedImage.Source as BitmapImage;
                if (bitmap != null)
                {
                    string imagePath = imagePaths[clickedImage];
                    int viTri = Array.IndexOf(DanhSachAnh, imagePath);
                    WLargeImage largeImage = new WLargeImage(congTy.Id, viTri, DanhSachAnh);
                    largeImage.ShowDialog();
                }
            }
        }
        private void btnTaiAnhLen_Click(object sender, RoutedEventArgs e)
        {
            congTy.Anh = MediaHandler.SelectImageAndSave(congTy.Id);
            SetImage();
        }

        private void btnThemAnh_Click(object sender, RoutedEventArgs e)
        {
            string anhStr = MediaHandler.SelectImageAndSave(congTy.Id);
            if (anhStr == null) return;
            Image anh = new Image() {Width = 100, Height = 100, Margin = new Thickness(10,9,0,9) };
            anh.Source = MediaHandler.SetImage(anhStr, congTy.Id);
            stAnh.Children.Add(anh);
        }

        private void btnDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            WDoiMatKhau wDoiMatKhau = new WDoiMatKhau(taiKhoan);
            wDoiMatKhau.ShowDialog();
        }
    }
}