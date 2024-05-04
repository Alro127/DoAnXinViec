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
        YeuThichDAO yeuThichDAO = new YeuThichDAO();
        List <CV> listCV = new List<CV>();
        public UCCVYeuThich(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            Load();
        }
        public void Load()
        {
            DataTable dt = yeuThichDAO.Load(congTy);
            wpCVYeuThich.Children.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                YeuThich yeuThich = new YeuThich(dr);
                DataTable dtDon = cvDAO.Get(yeuThich.Id);
                if (dtDon.Rows.Count > 0)
                {
                    CV cv = new CV(dt.Rows[0]);
                    listCV.Add(cv);
                    UCCV ucCV = new UCCV(cv, yeuThich);
                    wpCVYeuThich.Children.Add(ucCV);
                }
            }
        }

        private void tbTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            wpCVYeuThich.Children.Clear();
            foreach (CV cv in listCV)
            {
                string vtut = cv.ViTriUngTuyen.ToLower();
                string ten = cv.UngVien.HoTen.ToLower();
                if (vtut.Contains(tbTimKiem.Text.ToLower()) || ten.Contains(tbTimKiem.Text.ToLower()))
                {
                    DataTable dt = yeuThichDAO.Get(cv.Id, congTy.Id);
                    if (dt.Rows.Count > 0)
                    {
                        YeuThich yeuThich = new YeuThich(dt.Rows[0]);
                        UCCV ucCV = new UCCV(cv, yeuThich);
                        wpCVYeuThich.Children.Add(ucCV);
                    }
                }
            }    
        }
    }
}
