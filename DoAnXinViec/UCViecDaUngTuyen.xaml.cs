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
    /// Interaction logic for UCViecDaUngTuyen.xaml
    /// </summary>
    public partial class UCViecDaUngTuyen : UserControl
    {
        UngVien ungVien;
        List<HoSo> listHoSo;
        HoSoDAO hoSoDAO = new HoSoDAO();
        public UCViecDaUngTuyen(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            Load();
        }

        public void Load()
        {
            DataTable dt = hoSoDAO.LoadForUV(ungVien);
            listHoSo = new List<HoSo>();
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo(dr);
                listHoSo.Add(hoSo);
            }
            lvHoSoUngTuyen.ItemsSource = listHoSo;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            foreach (HoSo hoSo in listHoSo)
            {
                if (hoSoDAO.CapNhat(hoSo)==false)
                {
                    MessageBox.Show("Lỗi");
                    return;
                }    
            }
            MessageBox.Show("Thành công");
        }
    }
}
