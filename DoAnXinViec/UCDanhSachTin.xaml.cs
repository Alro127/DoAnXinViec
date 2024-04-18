using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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
using System.Windows.Media.Effects;
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
        CongTy congTy;
        DonDAO donDAO = new DonDAO();
        List<Don> listDon = new List<Don>();
        public UCDanhSachTin()
        {
            InitializeComponent();
        }
        public UCDanhSachTin(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            Load();
        }
        internal DonDAO DonDAO { get => donDAO; set => donDAO = value; }
        private void SuaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void XoaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Don don = (Don)lvDonTuyen.SelectedItem;
            donDAO.Xoa(don);
            listDon.Remove(don);
            lvDonTuyen.ItemsSource = listDon;
            lvDonTuyen.Items.Refresh();
        }
        private void ChonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ok");
        }
        public void Load()
        {
            DataTable dt = donDAO.LoadForCT(congTy);
            listDon.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don(dr);
                listDon.Add(don);
            }
            lvDonTuyen.ItemsSource = listDon;
        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            Don don = (sender as Button).Tag as Don;
            WDanhSachUVTheoDon wDanhSachUVTheoDon = new WDanhSachUVTheoDon(congTy, don);
            wDanhSachUVTheoDon.ShowDialog();
        }
    }
}
