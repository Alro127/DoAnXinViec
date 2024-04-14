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
    /// Interaction logic for UCCapNhapThongTinCty.xaml
    /// </summary>
    public partial class UCCapNhatThongTinCty : UserControl
    {
        CongTy congTy;
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
            this.thongtincty.DataContext = this.congTy;
            SetImage();
            Load();
        }
        void Load()
        {
            string[] DanhSachAnh = MediaHandler.GetImagesFromFolder(congTy.Id);
            for (int i = 0; i<DanhSachAnh.Length; i++)
            {
                Image anh = new Image() { Width = 100, Height = 100, Margin = new Thickness(10, 9, 0, 9) };
                anh.Source = MediaHandler.SetImage(DanhSachAnh[i], congTy.Id);
                wpAnh.Children.Add(anh);
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
            wpAnh.Children.Add(anh);
        }
    }
}