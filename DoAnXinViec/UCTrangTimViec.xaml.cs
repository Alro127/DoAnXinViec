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
    /// Interaction logic for UCTrangTimViec.xaml
    /// </summary>
    public partial class UCTrangTimViec : UserControl
    {
        public UCTrangTimViec()
        {
            InitializeComponent();
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            WDonChiTiet wDonChiTiet = new WDonChiTiet();
            wDonChiTiet.ShowDialog();
        }
    }
}
