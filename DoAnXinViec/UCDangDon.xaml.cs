using System;
using System.Collections.Generic;
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
using Microsoft.Win32;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for UCDangDon.xaml
    /// </summary>
    public partial class UCDangDon : UserControl
    {
        CongTy congTy;
        DonDAO donDAO = new DonDAO();
        public UCDangDon()
        {
            InitializeComponent();
            ucDon.lblTenCT.Content = ((CongTy)(this.Tag)).TenCT;
        }
        public UCDangDon(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            ucDon.lblTenCT.Content = congTy.TenCT;
        }

        private void txtTenCV_KeyUp(object sender, KeyEventArgs e)
        {
            ucDon.grbTenCV.Header = txtTenCV.Text;
        }

        private void cbLuong_KeyUp(object sender, KeyEventArgs e)
        {
            ucDon.lblLuong.Content = cbLuong.Text;
        }

        private void cbDiaDiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucDon.lblDiaDiem.Content =((Label)cbDiaDiem.SelectedValue).Content;
        }

        private void cbLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLuong.SelectedItem == null) return;
            if (cbLuong.SelectedItem == wpKhoangLuong)
            {
                if ((txtMaxLuong.Text == "") || (txtMinLuong.Text == ""))
                {
                    cbLuong.SelectedItem = null;
                    return;
                }
                string temp = txtMinLuong.Text + " - " + txtMaxLuong.Text + " triệu";
                
                if (!cbLuong.Items.Contains(temp))
                {
                    cbLuong.Items.Add(temp);
                }
                cbLuong.SelectedItem = temp;
            }
            ucDon.lblLuong.Content = cbLuong.Text;
        }

        private void btnDang_Click(object sender, RoutedEventArgs e)
        {
            Don don = new Don(0, txtTenCV.Text, congTy.Id, cbDiaDiem.Text, cbLuong.Text, cbKinhNghiem.Text, DateTime.Now.Date, dtpNgayToiHan.SelectedDate.Value, txtMoTaCV.Text, txtYeuCau.Text, txtQuyenLoi.Text, 0, 0);
            donDAO.Them(don);
        }
    }
}
