using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for UCCongViecYeuThich.xaml
    /// </summary>
    public partial class UCCongViecYeuThich : UserControl
    {
        UngVien ungVien;
        DonDAO donDAO = new DonDAO();
        CongTyDAO congTyDAO = new CongTyDAO();

        YeuThichDAO yeuThichDAO = new YeuThichDAO();
        public UCCongViecYeuThich()
        {
            InitializeComponent();
        }
        public UCCongViecYeuThich(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            Load();
        }
        void DangUCDon(DataRow dr)
        {
            YeuThich yeuThich = new YeuThich(dr);
            DataTable dt = donDAO.Get(yeuThich.Id);
            if (dt.Rows.Count > 0)
            {
                Don don = new Don(dt.Rows[0]);
                UCDon ucDon= new UCDon(don);
                ucDon.btnXem.Click += new RoutedEventHandler(this.btnXem_Click);
                ucDon.btnYeuThich.Click += new RoutedEventHandler(this.btnYeuThich_Click);
                wpCVYeuThich.Children.Add(ucDon);
            }
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            Don don = (Don)(sender as Button).DataContext;
            WDonChiTiet wDonChiTiet = new WDonChiTiet(don, ungVien);
            donDAO.TangLuotXem(don);
            wDonChiTiet.ShowDialog();
        }
        void btnYeuThich_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            if (toggleButton.IsChecked == true)
            {
                YeuThich yeuThich = new YeuThich((int)(toggleButton).Tag, ungVien.Id);
                yeuThichDAO.Them(yeuThich);
            }
            else
            {
                YeuThich yeuThich = new YeuThich((int)(toggleButton).Tag, ungVien.Id);
                yeuThichDAO.Xoa(yeuThich);
            }
        }
        public void Load()
        {
            DataTable dt = yeuThichDAO.Load(ungVien);
            wpCVYeuThich.Children.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DangUCDon(dr);
            }
        }

    }
}
