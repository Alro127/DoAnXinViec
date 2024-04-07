using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for UCChinhSuaThongTin.xaml
    /// </summary>
    public partial class UCChinhSuaThongTinCaNhan :UserControl
    {
        UngVien ungVien;
        private void SetImage()
        {
            BitmapImage bitmapImg = ImageHandler.SetImage(ungVien.Anh, ungVien.Id);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }
        public UCChinhSuaThongTinCaNhan(UngVien ungVien)
        {
            InitializeComponent();
            this.UngVien = new UngVien(ungVien);
            this.DataContext = this.UngVien;
            SetImage();
        }

        public UngVien UngVien { get => ungVien; set => ungVien = value; }

        private void btnTaiAnhLen_Click(object sender, RoutedEventArgs e)
        {
            ungVien.Anh = ImageHandler.SelectImageAndSave(ungVien.Id);
            SetImage();
        }

    }
}
