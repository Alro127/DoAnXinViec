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
        public UCCV()
        {
            InitializeComponent();
        }
        public UCCV(CV cv)
        {
            InitializeComponent();
            this.Cv = cv;
            grbTenUngVien.Header = Cv.UngVien.HoTen;
            lblNoiLamViec.Content = Cv.UngVien.TinhThanh;
            lblLuong.Content = Cv.Luong;
        }
        public CV Cv { get => this.cv; set => this.cv = value; }

        private void grbTenUngVien_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}