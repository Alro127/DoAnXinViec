using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for UCDanhSachTin.xaml
    /// </summary>
    public partial class UCDanhSachTin : UserControl
    {
        DonDAO donDAO = new DonDAO();
        List<Don> listDon = new List<Don>();

        public UCDanhSachTin()
        {
            InitializeComponent();
        }

        internal DonDAO DonDAO { get => donDAO; set => donDAO = value; }
        public List<Don> ListDon { get => listDon; set => listDon = value; }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Don don = (Don)lvDonTuyen.SelectedItem;
            donDAO.Xoa(don);
            listDon.Remove(don);
            lvDonTuyen.ItemsSource = ListDon;
            lvDonTuyen.Items.Refresh();
        }
    }
}
