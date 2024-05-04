using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for WChonCV.xaml
    /// </summary>
    public partial class WChonCV : Window
    {
        UngVien ungVien = new UngVien();
        List<CV> listCV = new List<CV>();
        CV cv;

        public CV Cv { get => cv; set => cv = value; }

        public WChonCV(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            Load();
        }
        private void Load()
        {
            CVDAO cvDAO = new CVDAO();
            DataTable dt = cvDAO.Get(ungVien);
            listCV.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                CV cv = new CV(dr);
                cv.UngVien = ungVien;
                listCV.Add(cv);
            }
            lvDanhSachCV.ItemsSource = listCV;
        }

        private void btnChon_Click(object sender, RoutedEventArgs e)
        {
            Cv = (CV)lvDanhSachCV.SelectedItem;
            this.Close();
        }
        private void tbTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            List<CV> listHienThi = new List<CV>();
            foreach (CV cv in listCV)
            {
                string vtut = cv.ViTriUngTuyen.ToLower();
                if (vtut.ToLower().Contains(tbTimKiem.Text))
                {
                    listHienThi.Add(cv);
                }    
            } 
            lvDanhSachCV.ItemsSource = listHienThi;
        }

        private void btnTaoCVMoi_Click(object sender, RoutedEventArgs e)
        {
            WTaoCV wTaoCV = new WTaoCV(ungVien);
            wTaoCV.ShowDialog();
        }

        private void btnReLoad_Click(object sender, RoutedEventArgs e)
        {
            Load();
            lvDanhSachCV.Items.Refresh();
        }
    }
}
