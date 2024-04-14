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
        public UCCVYeuThich(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            Load();
        }
        void DangUCCV(DataRow dr)
        {
            YeuThich yeuThich = new YeuThich(dr);
            DataTable dt = cvDAO.Get(yeuThich.Id);
            if (dt.Rows.Count>0)
            {
                CV cv = new CV(dt.Rows[0]);
                UCCV ucCV = new UCCV(cv,yeuThich);
                wpCVYeuThich.Children.Add(ucCV);
            }
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
