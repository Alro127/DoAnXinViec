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
    /// Interaction logic for UCLich.xaml
    /// </summary>
    public partial class UCLich : UserControl
    {
        public UCLich()
        {
            InitializeComponent();
        }

        private void lblPV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PhongVan phongVan = (sender as Label).Tag as PhongVan;
            DonDAO donDAO = new DonDAO();
            DataTable dtDon = donDAO.Get(phongVan.IdDon);
            Don don = new Don(dtDon.Rows[0]);
            CVDAO cVDAO = new CVDAO();
            DataTable dtCV = cVDAO.Get(phongVan.IdCV);
            CV cv = new CV(dtCV.Rows[0]);
            UngVienDAO ungVienDAO = new UngVienDAO();
            DataTable dtUngVien = ungVienDAO.Get(cv.IdUV, "UngVien");
            UngVien ungVien = new UngVien(dtUngVien.Rows[0]);
            WThongTinBuoiPhongVan wThongTinBuoiPhongVan = new WThongTinBuoiPhongVan(cv,ungVien,phongVan,don);
            wThongTinBuoiPhongVan.ShowDialog();
        }
    }
}
