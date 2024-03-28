using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
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
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WTrangChinhCty.xaml
    /// </summary>
    public partial class WTrangChinhCty : Window
    {
        UCDangDon uCDangDon = new UCDangDon();
        UCDanhSachTin uCDanhSachTin = new UCDanhSachTin();
        UCLichSuDangDon uCLichSuDangDon = new UCLichSuDangDon();
        UCHoSoUngTuyen uCHoSoUngTuyen = new UCHoSoUngTuyen();
        CongTy congTy = new CongTy();
        CongTyDAO congTyDAO = new CongTyDAO();
        DonDAO donDAO = new DonDAO();
        HoSoDAO hoSoDAO = new HoSoDAO();
        public WTrangChinhCty()
        {
            InitializeComponent();
            uCDanhSachTin.btnLichSu.Click += new RoutedEventHandler(this.btnLichSu_Click);
        }
        public WTrangChinhCty(string id)
        {
            InitializeComponent();
            DataTable dt = congTyDAO.Get(id);
            if (dt.Rows.Count > 0)
            {
                Utility.SetItemFromRow(congTy, dt.Rows[0]);
            }
            else MessageBox.Show("Lỗi");
            uCDanhSachTin.btnLichSu.Click += new RoutedEventHandler(this.btnLichSu_Click);
        }
        public WTrangChinhCty(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            uCDanhSachTin.btnLichSu.Click += new RoutedEventHandler(this.btnLichSu_Click);
        }

        private void btnDanhSachTin_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCDanhSachTin);
            DataTable dt = donDAO.Load();
            List<Don> listDon = new List<Don>();
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don();
                Utility.SetItemFromRow(don,dr);             
                listDon.Add(don);
            }
            uCDanhSachTin.lvDonTuyen.ItemsSource = listDon;
        }

        private void btnTaoTinDangTuyen_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCDangDon);
            uCDangDon.btnDang.Click += new System.Windows.RoutedEventHandler(this.btnDang_Click);
        }
        private void btnDang_Click(object sender, RoutedEventArgs e)
        {
            
            Don don = new Don(0,uCDangDon.txtTenCV.Text, congTy.IdCT, uCDangDon.cbDiaDiem.Text, int.Parse(uCDangDon.cbLuong.Text), DateTime.Now.Date, DateTime.ParseExact(uCDangDon.dtpNgayToiHan.Text, "dd/MM/yyyy", null).Date, uCDangDon.txtMoTaCV.Text, uCDangDon.txtYeuCau.Text, uCDangDon.txtQuyenLoi.Text,0,0);
            donDAO.Them(don);
        }

        private void btnHoSoUngTuyen_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoUngTuyen);
            DataTable dt = hoSoDAO.LoadForCT(congTy.IdCT);
            List <HoSo> listHoSo = new List <HoSo>();
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo();
                Utility.SetItemFromRow(hoSo, dr);
                listHoSo.Add(hoSo);
            }
            uCHoSoUngTuyen.lvHoSoUngTuyen.ItemsSource = listHoSo;
        }
        private void btnLichSu_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCLichSuDangDon);
            DataTable dt = donDAO.LoadLichSu();
            List<Don> listDon = new List<Don>();
            
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don();
                Utility.SetItemFromRow(don, dr);
                listDon.Add(don);
            }
            DateTime temp = DateTime.MinValue.Date;
            Expander expander;
            StackPanel stackPanel = new StackPanel();
            foreach (Don don in  listDon)
            {
                if (don.NgayDang.Date != temp)
                {
                    expander = new Expander() { Header = don.NgayDang.Date, IsExpanded = true};
                    stackPanel = new StackPanel();
                    expander.Content = stackPanel;
                    uCLichSuDangDon.stLichSuDangDon.Children.Add(expander);
                    temp = don.NgayDang.Date;
                }
                stackPanel.Children.Add(
                    new Label() { 
                        Content = don.TenCV, 
                        Background = Brushes.White, 
                        BorderBrush = Brushes.LightGray, 
                        BorderThickness = new Thickness(0,0,0,1), 
                        Height = 40, FontSize = 12, 
                        Foreground = Brushes.Black, 
                        HorizontalContentAlignment = HorizontalAlignment.Left, 
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Effect = new DropShadowEffect { ShadowDepth = 0, Color = Colors.Transparent } });
            }
        }

        private void WTrangChinhCTy_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = congTyDAO.Get(congTy.IdCT);
            if (dt != null)
                Utility.SetItemFromRow(congTy, dt.Rows[0]);
            this.DataContext = congTy;
        }

        private void btnTimKiemUngVien_Click(object sender, RoutedEventArgs e)
        {
            WTimUngVien wTimUngVien = new WTimUngVien(congTy);
            wTimUngVien.ShowDialog();
        }
    } 
}
