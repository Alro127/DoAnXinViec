using System;
using System.Collections.Generic;
using System.Drawing;
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

        private void cbLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLuong.SelectedItem == wpKhoangLuong)
            {
                if ((txtMaxLuong.Text == "") || (txtMinLuong.Text == ""))
                {
                    cbLuong.SelectedItem = null;
                    return;
                }
                string temp = txtMinLuong.Text + " - " + txtMaxLuong.Text + " triệu";
                cbLuong.Items.Add(temp);
                cbLuong.SelectedItem = temp;
            }
        }

        private void cbKinhNghiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKinhNghiem.SelectedItem == wpKhoangKinhNghiem) 
            {
                if ((txtMaxNam.Text == "") || (txtMinNam.Text == ""))
                {
                    cbKinhNghiem.SelectedItem = null;
                    return;
                }
                string temp = txtMinNam.Text + " - " + txtMaxNam.Text + " năm";
                cbKinhNghiem.Items.Add(temp);
                cbKinhNghiem.SelectedItem = temp;
            }
        }
    }
}
