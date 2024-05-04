using DoAnXinViec.DAO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for UCHoSoUngTuyen.xaml
    /// </summary>
    public partial class UCHoSoUngTuyen : UserControl
    {
        CongTy congTy;
        HoSoDAO hoSoDAO = new HoSoDAO();
        List<HoSo> listHoSo = new List<HoSo>();
        List<HoSo> listHienThi = new List<HoSo>();
        string header = "Tất cả";
        public UCHoSoUngTuyen(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            Load();
            LoadBoLoc();
            DataContext = this;
        }
        public void Load()
        {
            DataTable dt = hoSoDAO.LoadForCT(congTy);
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo(dr);
                listHoSo.Add(hoSo);
            }
            listHienThi.AddRange(listHoSo);
            lvHoSoUngTuyen.ItemsSource = listHoSo;
        }
        private void Loc()
        {
            listHienThi.Clear();
            foreach (HoSo hs in listHoSo)
            {
                if (Filter.CheckNgay(hs.NgayNop,header,dtpNgayNop.SelectedDate) && CheckTrangThai(hs) && CheckBoLoc(hs) &&  CheckTimKiem(hs))
                    listHienThi.Add(hs);
            }
            SapXep();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Loc();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Loc();
        }
        private bool CheckTrangThai(HoSo hs)
        {
            foreach (CheckBox item in mniTrangThai.Items)
                if (item.IsChecked == true && item.Content.ToString() == hs.TrangThai)
                    return true;
            return false;
        }
        void LoadBoLoc()
        {
            List <string> listVTUT = new List<string>() { "Tất cả"};
            listVTUT.AddRange(listHoSo.Select(hs => hs.ViTriUngTuyen).Distinct().ToList());
            cbBoLoc.ItemsSource = listVTUT;
        }
        bool CheckBoLoc(HoSo hs)
        {
            if (cbBoLoc.SelectedIndex <= 0) return true;
            if (hs.ViTriUngTuyen == cbBoLoc.SelectedItem.ToString()) return true;
            return false;
        }
        private void cbBoLoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Loc();
        }
        void SapXep()
        {
            if (cbSapXep == null) return;
            if (cbSapXep.SelectedIndex == 0)
                listHienThi = listHienThi.OrderBy(hoSo => hoSo.TenHoSo).ToList();
            else if (cbSapXep.SelectedIndex == 1)
                listHienThi = listHienThi.OrderByDescending(hoSo => hoSo.TenHoSo).ToList();
            else if (cbSapXep.SelectedIndex == 2)
                listHienThi = listHienThi.OrderByDescending(hoSo => hoSo.NgayNop).ToList();
            else if (cbSapXep.SelectedIndex == 3)
                listHienThi = listHienThi.OrderBy(hoSo => hoSo.NgayNop).ToList();
            lvHoSoUngTuyen.ItemsSource = listHienThi;
            lvHoSoUngTuyen.Items.Refresh();
        }
        private void cbSapXep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SapXep();
        }

        private void cbSetTrangThai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedIndex == 0)
                    comboBox.Foreground = Brushes.Orange;
                else if (comboBox.SelectedIndex == 1)
                    comboBox.Foreground = Brushes.Green;
                else comboBox.Foreground = Brushes.Red;
            }
        }

        private void btnXem_Click(object sender, RoutedEventArgs e)
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
            lvHoSoUngTuyen.Items.Refresh();
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
            lvHoSoUngTuyen.Items.Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            if (menuItem != null)
            {
                header = menuItem.Header.ToString();
                Loc();
                mniThoiGianNop.Header = header;
            }
        }

        private void dtpNgayNop_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            header = null;
            Loc();
            mniThoiGianNop.Header = dtpNgayNop.SelectedDate.ToString();
        }

        bool CheckTimKiem(HoSo hs)
        {
            string vtut = hs.ViTriUngTuyen.ToLower();
            string ths = hs.TenHoSo.ToLower();
            if (vtut.Contains(tbTimKiem.Text.ToLower()) || ths.Contains(tbTimKiem.Text.ToLower()))
                return true;
            return false;
        }
        private void tbTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            Loc();
        }
    }
}
