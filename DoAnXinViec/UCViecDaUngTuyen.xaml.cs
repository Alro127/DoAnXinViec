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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for UCViecDaUngTuyen.xaml
    /// </summary>
    public partial class UCViecDaUngTuyen : UserControl
    {
        UngVien ungVien;
        List<HoSo> listHoSo = new List<HoSo>();
        List<HoSo> listHienThi = new List<HoSo>();
        HoSoDAO hoSoDAO = new HoSoDAO();
        string header = "Tất cả";
        public UCViecDaUngTuyen(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            Load();
        }

        public void Load()
        {
            DataTable dt = hoSoDAO.LoadForUV(ungVien);
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo(dr);
                listHoSo.Add(hoSo);
            }
            listHienThi.AddRange(listHoSo);
            lvHoSoUngTuyen.ItemsSource = listHoSo;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            foreach (HoSo hoSo in listHoSo)
            {
                if (hoSoDAO.CapNhat(hoSo)==false)
                {
                    MessageBox.Show("Lỗi");
                    return;
                }    
            }
            MessageBox.Show("Thành công");
        }
        private bool CheckNgay(HoSo hs)
        {
            switch (header)
            {
                case "Tất cả":
                    return true;
                case "Hôm nay":
                    if (hs.NgayNop == DateTime.Today)
                        return true;
                    return false;
                case "Tuần này":
                    DateTime today = DateTime.Today;
                    DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
                    DateTime endOfWeek = startOfWeek.AddDays(6);

                    if (hs.NgayNop.Date >= startOfWeek && hs.NgayNop.Date <= endOfWeek)
                        return true;
                    return false;
                case "Tháng này":
                    today = DateTime.Today;
                    DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                    if (hs.NgayNop.Date >= startOfMonth && hs.NgayNop.Date <= endOfMonth)
                        return true;
                    return false;
                case "Năm này":
                    today = DateTime.Today;
                    DateTime startOfYear = new DateTime(today.Year, 1, 1);
                    DateTime endOfYear = new DateTime(today.Year, 12, 31);

                    if (hs.NgayNop.Date >= startOfYear && hs.NgayNop.Date <= endOfYear)
                        return true;
                    return false;
                default:
                    if (hs.NgayNop == dtpNgayNop.SelectedDate)
                        return true;
                    return false;

            }

        }
        private void Loc()
        {
            listHienThi.Clear();
            foreach (HoSo hs in listHoSo)
            {
                if (CheckNgay(hs) == true && CheckTrangThai(hs) == true &&CheckBoLoc(hs) && CheckTimKiem(hs))
                    listHienThi.Add(hs);
            }
            lvHoSoUngTuyen.ItemsSource = listHienThi;
            lvHoSoUngTuyen.Items.Refresh();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Loc();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Loc();
        }
        bool CheckBoLoc(HoSo hoSo)
        {
            if (cbBoLoc.SelectedIndex <= 0) return true;
            if (cbBoLoc.SelectedIndex == 1)
                if (hoSo.TrangThai == "Chấp nhận")
                    return true;
            if (cbBoLoc.SelectedIndex == 2)
                if (hoSo.TrangThai == "Đợi")
                    return true;
            if (cbBoLoc.SelectedIndex == 3)
                if (hoSo.TrangThai == "Từ chối")
                    return true;
            return false;
        }
        private void cbBoLoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Loc();
        }
        bool CheckTimKiem(HoSo hs)
        {
            string vtut = hs.ViTriUngTuyen.ToLower();
            if (vtut.Contains(tbTimKiem.Text.ToLower()))
                return true;
            return false;
        }
        private void cbSapXep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSapXep.SelectedIndex == 0)
                listHienThi = listHienThi.OrderBy(hoSo => hoSo.TenCT).ToList();
            else if (cbSapXep.SelectedIndex == 1)
                listHienThi = listHienThi.OrderByDescending(hoSo => hoSo.TenCT).ToList();
            else if (cbSapXep.SelectedIndex == 2)
                listHienThi = listHienThi.OrderByDescending(hoSo => hoSo.NgayNop).ToList();
            else if (cbSapXep.SelectedIndex == 3)
                listHienThi = listHienThi.OrderBy(hoSo => hoSo.NgayNop).ToList();
            lvHoSoUngTuyen.ItemsSource = listHienThi;
            lvHoSoUngTuyen.Items.Refresh();
        }
        private void dtpNgayNop_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            header = null;
            Loc();
            mniThoiGianNop.Header = dtpNgayNop.SelectedDate.ToString();
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
        private bool CheckTrangThai(HoSo hs)
        {
            foreach (CheckBox item in mniTrangThai.Items)
                if (item.IsChecked == true && item.Content.ToString() == hs.TrangThai)
                    return true;
            return false;
        }

        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            HoSo hoSo = (sender as Button).Tag as HoSo;
            PhongVanDAO phongVanDAO = new PhongVanDAO();
            if ((hoSo.TrangThai == "Đợi") && (!phongVanDAO.CheckExist(hoSo.IdDon.ToString(), hoSo.IdCV.ToString())))
            {
                MessageBox.Show("Chưa có thông báo từ công ty");
                return;
            }
            if (hoSo.TrangThai == "Từ chối")
            {
                MessageBox.Show("Cảm ơn bạn đã tham gia ứng tuyển, hồ sơ của bạn chưa thuyết phục được nhà tuyển dụng");
                return;
            }
            DataTable dtPhongVan = phongVanDAO.Get(hoSo.IdDon, hoSo.IdCV);
            PhongVan phongVan = new PhongVan(dtPhongVan.Rows[0]);
            if ((hoSo.TrangThai == "Chấp nhận")||((hoSo.TrangThai == "Đợi")&&string.IsNullOrEmpty(phongVan.XacNhan)))
            {
                DonDAO donDAO = new DonDAO();
                DataTable dtDon = donDAO.Get(hoSo.IdDon);
                Don don = new Don(dtDon.Rows[0]);
                CongTyDAO congTyDAO = new CongTyDAO();
                DataTable dtCTy = congTyDAO.Get(don.IdCT, "CTy");
                CongTy congTy = new CongTy(dtCTy.Rows[0]);
                WHenLich wHenLich = new WHenLich(don, phongVan, ungVien, congTy,hoSo);
                wHenLich.ShowDialog();
            }

        }

        private void tbTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            Loc();
        }
    }
}
