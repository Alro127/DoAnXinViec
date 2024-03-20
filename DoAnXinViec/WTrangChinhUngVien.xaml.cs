using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WTrangChinhCty.xaml
    /// </summary>
    public partial class WTrangChinhUngVien : Window
    {
        public WTrangChinhUngVien()
        {
            InitializeComponent();

        }

        private void btnHoSoCuaBan_Click(object sender, RoutedEventArgs e)
        {
            UCHoSoCuaBan uCHoSoCuaBan = new UCHoSoCuaBan(); 
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoCuaBan);
        }
    } 
}
