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
        CongTy congTy = new CongTy();
        CongTyDAO congTyDAO = new CongTyDAO();
        UCCapNhatThongTinCty uCCapNhatThongTinCty;

        private void SetImage()
        {
            BitmapImage bitmapImg = ImageHandler.SetImage(congTy.Anh, congTy.Id);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }
        public WTrangChinhCty(string id)
        {
            InitializeComponent();
            DataTable dt = congTyDAO.Get(id, "Cty");
            if (dt.Rows.Count > 0)
            {
                Utility.SetItemFromRow(congTy, dt.Rows[0]);
            }
            else MessageBox.Show("Lỗi");
            SetImage();
        }
        public WTrangChinhCty(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            SetImage();
        }
        private void WTrangChinhCTy_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = congTyDAO.Get(congTy.Id, "Cty");
            if (dt != null)
                Utility.SetItemFromRow(congTy, dt.Rows[0]);
            this.DataContext = congTy;
        }
        private void btnDanhSachTin_Click(object sender, RoutedEventArgs e)
        {            
            UCDanhSachTin uCDanhSachTin = new UCDanhSachTin(congTy);
            uCDanhSachTin.btnLichSu.Click += new RoutedEventHandler(this.btnLichSu_Click);
            stMain.Children.Clear();
            stMain.Children.Add(uCDanhSachTin);
        }
        private void btnLichSu_Click(object sender, RoutedEventArgs e)
        {
            UCLichSuDangDon uCLichSuDangDon = new UCLichSuDangDon(congTy);
            stMain.Children.Clear();
            stMain.Children.Add(uCLichSuDangDon);
        }
        private void btnTaoTinDangTuyen_Click(object sender, RoutedEventArgs e)
        {
            UCDangDon uCDangDon = new UCDangDon(congTy);
            stMain.Children.Clear();
            stMain.Children.Add(uCDangDon);
        }
        private void btnHoSoUngTuyen_Click(object sender, RoutedEventArgs e)
        {
            UCHoSoUngTuyen uCHoSoUngTuyen = new UCHoSoUngTuyen(congTy);
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoUngTuyen);
        }
        private void btnTimKiemUngVien_Click(object sender, RoutedEventArgs e)
        {
            WTimUngVien wTimUngVien = new WTimUngVien(congTy);
            wTimUngVien.ShowDialog();
        }
        private void btnHoSoDaThich_Click(object sender, RoutedEventArgs e)
        {
            UCCVYeuThich uCCVYeuThich = new UCCVYeuThich(congTy);
            
            stMain.Children.Clear();
            stMain.Children.Add(uCCVYeuThich);
        }

        private void btnCapNhatThongTin_Click(object sender, RoutedEventArgs e)
        {
            uCCapNhatThongTinCty = new UCCapNhatThongTinCty(congTy);
            uCCapNhatThongTinCty.btnLuu.Click += new RoutedEventHandler(this.btnLuu_Click);
            stMain.Children.Clear();
            stMain.Children.Add(uCCapNhatThongTinCty);
        }
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            congTy = uCCapNhatThongTinCty.CongTy;
            SetImage();
            if (congTyDAO.CapNhat(congTy, "CTy") == true)
                System.Windows.MessageBox.Show("ThanhCong");
        }
    } 
}
