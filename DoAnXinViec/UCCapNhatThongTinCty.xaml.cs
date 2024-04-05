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
        CongTy tempCongTy;
        CongTyDAO congTyDAO = new CongTyDAO();

        public CongTy CongTy { get => congTy; set => congTy = value; }

        private void SetImage()
        {
            BitmapImage bitmapImg = ImageHandler.SetImage(CongTy.Anh);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }
        public UCCapNhatThongTinCty(CongTy congTy)
        {
            InitializeComponent();
            this.CongTy = congTy;
            this.tempCongTy = new CongTy(congTy);
            this.thongtincty.DataContext = tempCongTy;
            SetImage();
        }

        private void btnTaiAnhLen_Click(object sender, RoutedEventArgs e)
        {
            CongTy.Anh = ImageHandler.SelectImageAndSave();
            SetImage();
        }
    }
}