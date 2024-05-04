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
        CongTy congTy = new CongTy();
        DonDAO donDAO = new DonDAO();
        List<Don> listDon = new List<Don>();
        List<Don> listHienThi = new List<Don>();
        string header = "Tất cả";

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
            /*Don don = (Don)lvDonTuyen.SelectedItem;
            donDAO.Xoa(don);
            listDon.Remove(don);
            lvDonTuyen.ItemsSource = listDon;
            lvDonTuyen.Items.Refresh();*/
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
            listHienThi.Clear();
            listHienThi.AddRange(listDon);
            SapXep();
        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            Don don = (sender as Button).Tag as Don;
            WDanhSachUVTheoDon wDanhSachUVTheoDon = new WDanhSachUVTheoDon(congTy, don);
            wDanhSachUVTheoDon.ShowDialog();
        }
        bool CheckBoLoc(Don don)
        {
            if (cbBoLoc.SelectedIndex <= 0) return true;
            if (cbBoLoc.SelectedIndex == 1)
                if (don.NgayToiHan > DateTime.Now)
                    return true;
            if (cbBoLoc.SelectedIndex == 2)
                if (don.NgayToiHan < DateTime.Now)
                    return true;
            return false;
        }
        private void cbBoLoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Loc();
        }

        private void SapXep()
        {
            if (cbSapXep == null) return;
            if (cbSapXep.SelectedIndex == 0)
                listHienThi = listHienThi.OrderBy(don => don.TenCV).ToList();
            else if (cbSapXep.SelectedIndex == 1)
                listHienThi = listHienThi.OrderByDescending(don => don.TenCV).ToList();
            else if (cbSapXep.SelectedIndex == 2)
                listHienThi = listHienThi.OrderByDescending(don => don.NgayDang).ToList();
            else if (cbSapXep.SelectedIndex == 3)
                listHienThi = listHienThi.OrderBy(don => don.NgayDang).ToList();
            lvDonTuyen.ItemsSource = listHienThi;
            lvDonTuyen.Items.Refresh();
        }
        private void cbSapXep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SapXep();
        }

        bool CheckTimKiem(Don don)
        {
            if (tbTimKiem.Text == "") return true;
            string str = don.TenCV.ToLower();
            if (str.Contains(tbTimKiem.Text.ToLower()))
                return true;
            return false;
        }
        private void tbTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            Loc();
        }
        private void Loc()
        {
            listHienThi.Clear();
            foreach (Don don in listDon)
            {
                if (Filter.CheckNgay(don.NgayDang,header,dtpNgayDang.SelectedDate) && CheckBoLoc(don) && CheckTimKiem(don))
                    listHienThi.Add(don);
            }
            SapXep();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            if (menuItem != null)
            {
                header = menuItem.Header.ToString();
                Loc();
                mniThoiGianDang.Header = header;
            }
        }

        private void dtpNgayDang_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            header = "";
            Loc();
            mniThoiGianDang.Header = dtpNgayDang.SelectedDate.ToString();
        }

        private void LuotNop_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            if (menuItem != null)
                header = menuItem.Header.ToString();
            if (header == "Cao nhất - Thấp nhất")
                listHienThi = listHienThi.OrderByDescending(don => don.LuotNop).ToList();
            else
                listHienThi = listHienThi.OrderBy(don => don.LuotNop).ToList();
            lvDonTuyen.ItemsSource = listHienThi;
            lvDonTuyen.Items.Refresh();
        }

        private void LuotXem_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            if (menuItem != null)
                header = menuItem.Header.ToString();
            if (header == "Cao nhất - Thấp nhất")
                listHienThi = listHienThi.OrderByDescending(don => don.LuotXem).ToList();
            else
                listHienThi = listHienThi.OrderBy(don => don.LuotXem).ToList();
            lvDonTuyen.ItemsSource = listHienThi;
            lvDonTuyen.Items.Refresh();
        }
    }
}
