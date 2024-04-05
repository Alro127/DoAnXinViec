﻿using MaterialDesignThemes.Wpf;
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
        List<HoSo> listHoSo = new List<HoSo>();
        List<HoSo> listHienThi = new List<HoSo>();


        public UCHoSoUngTuyen(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            Load();
        }

        public void Load()
        {
            HoSoDAO hoSoDAO = new HoSoDAO();
            DataTable dt = hoSoDAO.LoadForCT(congTy);
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo();
                Utility.SetItemFromRow(hoSo, dr);
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
                if (CheckNgay(hs)==true && CheckTrangThai(hs)==true)
                    listHienThi.Add(hs);
            }
            lvHoSoUngTuyen.ItemsSource = listHienThi;
            lvHoSoUngTuyen.Items.Refresh(); 
        }

        private bool CheckNgay(HoSo hs)
        {
            if (cbThoiGianNop.SelectedValue == null)
                return true;
            if (cbThoiGianNop.SelectedValue == lblTatCa)
                    return true;

            if (cbThoiGianNop.SelectedValue == lblHomNay)
                  if (hs.NgayNop == DateTime.Today)
                    return true;
            if (cbThoiGianNop.SelectedValue == lblTuanNay)
            {
                DateTime today = DateTime.Today;
                DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
                DateTime endOfWeek = startOfWeek.AddDays(6);

                if (hs.NgayNop.Date >= startOfWeek && hs.NgayNop.Date <= endOfWeek)
                    return true;
            }
            if (cbThoiGianNop.SelectedValue == lblThangNay)
            {
                DateTime today = DateTime.Today;
                DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                if (hs.NgayNop.Date >= startOfMonth && hs.NgayNop.Date <= endOfMonth)
                    return true;
            }
            if (cbThoiGianNop.SelectedValue == lblNamNay)
            {
                DateTime today = DateTime.Today;
                DateTime startOfYear = new DateTime(today.Year, 1, 1);
                DateTime endOfYear = new DateTime(today.Year, 12, 31);

                if (hs.NgayNop.Date >= startOfYear && hs.NgayNop.Date <= endOfYear)
                    return true;
            }
            if (cbThoiGianNop.SelectedValue == dtpNgayNop)
                if (hs.NgayNop == dtpNgayNop.SelectedDate)
                    return true;
            return false;
        }
        private void cbThoiGianNop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Loc();
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
            foreach (CheckBox item in cbTrangThai.Items)
                if (item.IsChecked == true && item.Content.ToString() == hs.TrangThai)
                    return true;
            return false;
        }

        private void cbTrangThai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbTrangThai.Text = "Trạng Thái";
        }
    }
}
