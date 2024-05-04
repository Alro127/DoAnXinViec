using System;
using System.Collections.Generic;
using System.Data;
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
        Don don = new Don();
        public UCDon()
        {
            InitializeComponent();
        }
        public UCDon(Don don, YeuThich? yeuThich = null)
        {
            InitializeComponent();
            this.DataContext = don;
            btnXem.DataContext = don;

            CongTyDAO congTyDAO = new CongTyDAO();
            DataTable dt = congTyDAO.Get(don.IdCT, "Cty");
            CongTy congTy = new CongTy(dt.Rows[0]);
            BitmapImage bitmapImg = MediaHandler.SetImage(congTy.Anh, congTy.Id);
            if (bitmapImg != null)
                imgAnh.Source = bitmapImg;

            YeuThichDAO yeuThichDAO = new YeuThichDAO();
            if (yeuThich != null)
            {
                if (yeuThichDAO.CheckExist(yeuThich))
                    btnYeuThich.IsChecked = true;
                else
                    btnYeuThich.IsChecked = false;
                btnYeuThich.Tag = don.IdDon;
            }
            lblthoigiandang.Content = Filter.tinhThoiGian(don.NgayDang);
        }
        public Don Don { get => don; set => don = value; }
    }
}