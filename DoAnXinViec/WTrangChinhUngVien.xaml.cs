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
    public partial class WTrangChinhUngVien : Window
    {
        UngVien ungVien;
        UngVienDAO ungVienDAO = new UngVienDAO();
        CV cv;
        CVDAO cvDAO = new CVDAO();
        UCHoSoCuaBan uCHoSoCuaBan = new UCHoSoCuaBan();
        public WTrangChinhUngVien()
        {
            InitializeComponent();
        }
        public WTrangChinhUngVien(UngVien ungVien)
        {
            InitializeComponent();
            this.UngVien = ungVien;
            this.DataContext = ungVien;
        }

        public UngVien UngVien { get => ungVien; set => ungVien = value; }

        private void btnHoSoCuaBan_Click(object sender, RoutedEventArgs e)
        {
            stMain.Children.Clear();
            stMain.Children.Add(uCHoSoCuaBan);
            DataTable dt = cvDAO.Get(UngVien.IdUV);
            if (dt.Rows.Count > 0 )
            {
                Utility.SetItemFromRow(cv, dt.Rows[0]);
                cv.NgayDang = DateTime.Now.Date;
                cv.NgayHetHan = DateTime.MaxValue;
                cv.UngVien = UngVien;
            }
            uCHoSoCuaBan.tbiThongTinCaNhan.DataContext = ungVien;
            uCHoSoCuaBan.tbiThongTinCV.DataContext = cv;
            uCHoSoCuaBan.btnLuuVaDangHoSo.Click += new RoutedEventHandler(this.btnLuuVaDangHoSo_Click);
        }
        private void btnLuuVaDangHoSo_Click(object sender, RoutedEventArgs e)
        {
            ungVienDAO.CapNhat(UngVien);
            cvDAO.Them(cv);
        }
    } 
}
