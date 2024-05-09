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
    /// Interaction logic for WLargeImage.xaml
    /// </summary>
    public partial class WLargeImage : Window
    {
        int index;
        string[] DanhSachAnh;
        string idCongty;
        public WLargeImage(string idCongty,int viTri, string[] DanhSachAnh)
        {
            InitializeComponent();
            this.DanhSachAnh = DanhSachAnh;
            this.idCongty = idCongty;
            index = viTri;
            Load();
        }
        void Load()
        {
            BitmapImage bitmap = MediaHandler.SetImage(DanhSachAnh[index], idCongty);
            largeImageView.Source = bitmap;
            btnLeft.Foreground = new SolidColorBrush(Colors.Black);
            btnLeft.IsEnabled = true;
            btnRight.Foreground = new SolidColorBrush(Colors.Black);
            btnRight.IsEnabled = true;
            if (index == 0)
            {
                btnLeft.Foreground = new SolidColorBrush(Colors.DarkGray);
                btnLeft.IsEnabled = false;
            }
            if (index == DanhSachAnh.Length - 1)
            {
                btnRight.Foreground = new SolidColorBrush(Colors.DarkGray);
                btnRight.IsEnabled = false;
            }
        }
        private void btnRight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            index++;
            Load();
        }

        private void btnLeft_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            index--;
            Load();
        }
    }
}
