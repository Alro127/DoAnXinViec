using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
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
    /// Interaction logic for WTrangChinhCty.xaml
    /// </summary>
    public partial class WTrangChinhCty : Window
    {
        string id = "CT1";
        string tenCT = "tenCT";
        UCDangDon uCDangDon = new UCDangDon();
        UCDanhSachTin uCDanhSachTin = new UCDanhSachTin();
        UCHoSoUngTuyen uCHoSoUngTuyen = new UCHoSoUngTuyen();
        DonDAO donDAO = new DonDAO();
        HoSoDAO hoSoDAO = new HoSoDAO();
        public WTrangChinhCty()
        {
            InitializeComponent();
            uCHoSoUngTuyen.btnLuu.Click += new System.Windows.RoutedEventHandler(this.btnLuu_Click);
        }

        private void btnDanhSachTin_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCDanhSachTin);
            List<ThongTinDonTuyen> list = new List<ThongTinDonTuyen>();
            ThongTinDonTuyen a = new ThongTinDonTuyen() { Ten = "IT", Ngaydang = DateTime.Now, Toihan = DateTime.Now, Luotnop = 1, Luotxem = 10 };
            list.Add(a);
            uCDanhSachTin.lvDonTuyen.Items.Clear();
            uCDanhSachTin.lvDonTuyen.ItemsSource = list;

        }

        private void btnTaoTinDangTuyen_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCDangDon);
            uCDangDon.btnDang.Click += new System.Windows.RoutedEventHandler(this.btnDang_Click);
        }
       
        private void btnDang_Click(object sender, RoutedEventArgs e)
        {
            Don don = new Don(0,uCDangDon.tbTenCV.Text, tenCT, uCDangDon.cbDiaDiem.Text, int.Parse(uCDangDon.cbLuong.Text), "", new Image(), uCDangDon.tbMoTaCV.Text, uCDangDon.tbYeuCau.Text, uCDangDon.tbQuyenLoi.Text);
            donDAO.Them(don);
        }

        private void btnHoSoUngTuyen_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoUngTuyen);
            DataTable dt = hoSoDAO.Show(id);
            List <HoSo> listHoSo = new List <HoSo>();
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo((int)dr["IdCV"], (string)dr["IdUV"], (string)dr["HoTen"], (string)dr["TenCV"], (string)dr["LoaiHoSo"], DateTime.ParseExact((string)dr["NgayNop"], "dd/MM/yyyy", null).Date, (int)dr["TrangThai"]);
                listHoSo.Add(hoSo);
            }
            uCHoSoUngTuyen.lvHoSoUngTuyen.ItemsSource = listHoSo;
        }
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
              
        }
    } 
}
