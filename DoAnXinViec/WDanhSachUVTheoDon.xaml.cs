using DoAnXinViec.DAO;
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
    /// Interaction logic for WDanhSachUVTheoDon.xaml
    /// </summary>
    public partial class WDanhSachUVTheoDon : Window
    {
        CongTy congTy;
        Don don;
        HoSoDAO hoSoDAO = new HoSoDAO();
        List<HoSo> listHoSo = new List<HoSo>();
        List<HoSo> listHienThi = new List<HoSo>();

        public WDanhSachUVTheoDon(CongTy congTy, Don don)
        {
            InitializeComponent();
            this.congTy = congTy;
            this.don = don;
            Load();
        }
        public void Load()
        {
            HoSoDAO hoSoDAO = new HoSoDAO();
            DataTable dt = hoSoDAO.LoadTheoDon(congTy, don);
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo(dr);
                listHoSo.Add(hoSo);
            }
        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            HoSo hoSo = (sender as Button).Tag as HoSo;
            CVDAO cvDAO = new CVDAO();
            DataTable dt = cvDAO.Get(hoSo.IdCV);
            CV cv = new CV(dt.Rows[0]);
            WCVChiTiet wCVChiTiet = new WCVChiTiet(cv);
            wCVChiTiet.ShowDialog();
        }
        private void mniHen_Click(object sender, RoutedEventArgs e)
        {
            HoSo hoSo = (sender as MenuItem).Tag as HoSo;
            WLichPhongVan wLichPhongVan = new WLichPhongVan(congTy, hoSo);
            wLichPhongVan.ShowDialog();
            lvHoSo.Items.Refresh();
            lvHoSoChapNhan.Items.Refresh();
            lvHoSoDoi.Items.Refresh();
            lvHoSoTuChoi.Items.Refresh();
        }
        private void mniTuChoi_Click(object sender, RoutedEventArgs e)
        {
            HoSo hoSo = (sender as MenuItem).Tag as HoSo;
            if (hoSo.TrangThai == "Chấp nhận")
            {
                PhongVanDAO phongVanDAO = new PhongVanDAO();
                DataTable dt = phongVanDAO.Get(hoSo.IdDon, hoSo.IdCV);
                PhongVan phongVan = new PhongVan(dt.Rows[0]);
                phongVanDAO.Xoa(phongVan);
            }
            hoSo.TrangThai = "Từ chối";
            hoSoDAO.CapNhat(hoSo);
            lvHoSo.Items.Refresh();
            lvHoSoChapNhan.Items.Refresh();
            lvHoSoDoi.Items.Refresh();
            lvHoSoTuChoi.Items.Refresh();
        }

        private void tabChapNhan_Loaded(object sender, RoutedEventArgs e)
        {
            listHienThi.Clear();
            foreach (HoSo hs in listHoSo)
            {
                if (hs.TrangThai == "Chấp nhận")
                    listHienThi.Add(hs);
            }
            lvHoSoChapNhan.ItemsSource = listHienThi;
            lvHoSoChapNhan.Items.Refresh();
        }

        private void tabDanhSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listHienThi.Clear();
            if (tabDanhSach.SelectedItem == tabTatCa) 
            {
                listHienThi.AddRange(listHoSo);
                lvHoSo.ItemsSource = listHienThi;
                lvHoSo.Items.Refresh();
                return;
            }
            string trangthai = ((TabItem)tabDanhSach.SelectedItem).Header as string;
            foreach (HoSo hs in listHoSo)
            {
                if (hs.TrangThai == trangthai)
                    listHienThi.Add(hs);
            }
            if (tabDanhSach.SelectedItem == tabChapNhan)
            {
                lvHoSoChapNhan.ItemsSource = listHienThi;
                lvHoSoChapNhan.Items.Refresh();
                return;
            }
            if (tabDanhSach.SelectedItem == tabDoi)
            {
                lvHoSoDoi.ItemsSource = listHienThi;
                lvHoSoDoi.Items.Refresh();
                return;
            }
            if (tabDanhSach.SelectedItem == tabTuChoi)
            {
                lvHoSoTuChoi.ItemsSource = listHienThi;
                lvHoSoTuChoi.Items.Refresh();
                return;
            }
        }
    }
}
