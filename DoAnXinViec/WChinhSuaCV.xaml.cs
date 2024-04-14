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
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WChinhSuaCV.xaml
    /// </summary>
    public partial class WChinhSuaCV : Window
    {
        UCHoSoCuaBan uCHoSoCuaBan;
        CV cv;
        CV tempCV;
        CVDAO cvDAO = new CVDAO();
        public WChinhSuaCV(CV cv)
        {
            InitializeComponent();
            this.cv = cv;
            this.tempCV = new CV(cv);
            uCHoSoCuaBan = new UCHoSoCuaBan(tempCV);
            uCHoSoCuaBan.btnLuuVaDangHoSo.Click += new RoutedEventHandler(btnLuuVaDangHoSo_Click);
            stMain.Children.Add(uCHoSoCuaBan);
        }
        private void btnLuuVaDangHoSo_Click(object sender, RoutedEventArgs e)
        {
            cv = new CV(tempCV);
            UngVienDAO ungVienDAO= new UngVienDAO();
            ungVienDAO.CapNhat(cv.UngVien, "UngVien");
            cv.NgayDang = DateTime.Now.Date;
            cv.NgayToiHan = new DateTime(3000, 12, 31).Date;
            cvDAO.CapNhat(cv);
        }
    }
}
