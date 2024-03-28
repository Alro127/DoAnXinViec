using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
    /// Interaction logic for WTimUngVien.xaml
    /// </summary>
    public partial class WTimUngVien : Window
    {
        CVDAO cvDAO = new CVDAO();
        CongTy congTy = new CongTy();
        public WTimUngVien()
        {
            InitializeComponent();
        }
        public WTimUngVien(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
        }
        void DangUCCV(DataRow dr)
        {
            CV cv = new CV();
            Utility.SetItemFromRow(cv, dr);
            UCCV ucCV = new UCCV(cv);
            ucCV.Tag = cv;
            ucCV.MouseDoubleClick += new MouseButtonEventHandler(this.UCCV_Click);
            ucTrangTimViec.wpDon.Children.Add(ucCV);
        }

        void UCCV_Click(object sender, MouseButtonEventArgs e)
        {
            WCVChiTiet wCVChiTiet = new WCVChiTiet((CV)(sender as UCCV).Tag);
            wCVChiTiet.ShowDialog();
        }
        void Load()
        {
            DataTable dt = cvDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                DangUCCV(dr);
            }
        }
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            ucTrangTimViec.wpDon.Children.Clear();
            DataTable dt = cvDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                if (((string)dr["LinhVuc"]).Contains(ucTrangTimViec.txtTimKiem.Text))
                    DangUCCV(dr);
            }
        }

        private void WTimUngVien_Load(object sender, RoutedEventArgs e)
        {
            Load();
            ucTrangTimViec.btnTimKiem.Click += new RoutedEventHandler(this.btnTimKiem_Click);
        }
        private void btnQuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            WTrangChinhCty wTrangChinhCty = new WTrangChinhCty(congTy);
            this.Close();
            wTrangChinhCty.ShowDialog();
        }
    }
}