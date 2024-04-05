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
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WDanhSachUVTheoDon.xaml
    /// </summary>
    public partial class WDanhSachUVTheoDon : Window
    {
        CongTy congTy;
        Don don;
        List<HoSo> listHoSo = new List<HoSo>();
        List<HoSo> listHoSoChapNhan = new List<HoSo>();
        List<HoSo> listHoSoDoi = new List<HoSo>();
        List<HoSo> listHoSoTuChoi = new List<HoSo>();


        public WDanhSachUVTheoDon(CongTy congTy, Don don)
        {
            InitializeComponent();
            this.congTy = congTy;
            this.don = don;
            Load();
        }
        public void Load()
        {
            HoSoDAO hoSoDAO = new HoSoDAO();
            DataTable dt = hoSoDAO.LoadTheoDon(congTy, don);
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo();
                Utility.SetItemFromRow(hoSo, dr);
                listHoSo.Add(hoSo);
                if (hoSo.TrangThai=="Chấp nhận")
                    listHoSoChapNhan.Add(hoSo);
                else if (hoSo.TrangThai=="Đợi")
                    listHoSoDoi.Add(hoSo);
                else
                    listHoSoTuChoi.Add(hoSo);
            }
            lvHoSo.ItemsSource = listHoSo;
            lvHoSoChapNhan.ItemsSource = listHoSoChapNhan;
            lvHoSoDoi.ItemsSource = listHoSoDoi;
            lvHoSoTuChoi.ItemsSource = listHoSoTuChoi;
        }

    }
}
