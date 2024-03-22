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
using Microsoft.Win32;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for UCDangDon.xaml
    /// </summary>
    public partial class UCDangDon : UserControl
    {
        public UCDangDon()
        {
            InitializeComponent();
            ucDon.lblTenCT.Content = "TenCT";
        }

        private void txtTenCV_KeyUp(object sender, KeyEventArgs e)
        {
            ucDon.grbTenCV.Header = txtTenCV.Text;
        }

        private void cbLuong_KeyUp(object sender, KeyEventArgs e)
        {
            ucDon.lblLuong.Content = cbLuong.Text;
        }

        private void cbDiaDiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucDon.lblDiaDiem.Content =((Label)cbDiaDiem.SelectedValue).Content;
        }

        private void cbLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucDon.lblLuong.Content = ((Label)cbLuong.SelectedValue).Content;
        }

        private void imgAnh_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    imgAnh.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
        }
    }
}
