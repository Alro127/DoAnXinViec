using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for UCDon.xaml
    /// </summary>
    public partial class UCDon : UserControl
    {
        Don don;
        CongTy congty;
        public UCDon()
        {
            InitializeComponent();
        }
        public UCDon(Don don)
        {
            InitializeComponent();
            this.Don = don;
            grbTenCV.Header = don.TenCV;
            lblTenCT.Content = don.IdCT; //cho sua thanh ten cong ty
            lblDiaDiem.Content = don.DiaDiem;
            lblLuong.Content = don.Luong;
            btnXem.Tag = don;
        }

        public Don Don { get => don; set => don = value; }
    }
}
