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
    /// Interaction logic for UCCVYeuThich.xaml
    /// </summary>
    public partial class UCCVYeuThich : UserControl
    {
        CongTy congTy;
        CVDAO cvDAO = new CVDAO();
        UngVienDAO ungVienDAO = new UngVienDAO();
        YeuThichDAO yeuThichDAO = new YeuThichDAO();
        public UCCVYeuThich()
        {
            InitializeComponent();
        }
        public UCCVYeuThich(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            Load();
        }
        void DangUCCV(DataRow dr)
        {
            CV cv = new CV();
            UngVien ungVien = new UngVien();
            YeuThich yeuThich = new YeuThich();

            Utility.SetItemFromRow(yeuThich, dr);
            DataTable dt = cvDAO.Get(yeuThich.IdCV);

            Utility.SetItemFromRow(cv, dt.Rows[0]);
            dt = ungVienDAO.Get(cv.IdUV, "UngVien");

            Utility.SetItemFromRow(ungVien, dt.Rows[0]);
            cv.UngVien = ungVien;

            UCCV ucCV = new UCCV(cv);
            ucCV.Tag = cv;
            ucCV.btnYeuThich.IsEnabled = false;
            wpCVYeuThich.Children.Add(ucCV);
        }
        public void Load()
        {
            DataTable dt = yeuThichDAO.Load(congTy);
            wpCVYeuThich.Children.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DangUCCV(dr);
            }
        }
    }
}
