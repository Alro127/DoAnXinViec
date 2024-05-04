using DoAnXinViec.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for WLichPhongVan.xaml
    /// </summary>
    public partial class WLichPhongVan : Window
    {
        CongTy congTy;
        HoSoDAO  hsDAO = new HoSoDAO();
        PhongVanDAO phongVanDAO = new PhongVanDAO();
        List<HoSo> listHoSo = new List<HoSo>();
        List<PhongVan> listPhongVan = new List<PhongVan>();

        List<UCLich> listUCLich = new List<UCLich>();
        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public WLichPhongVan(CongTy congTy, HoSo? hoSo = null)
        {
            InitializeComponent();
            this.congTy = congTy;
            Load(startDate);
            LoadHoSo();
            if (hoSo != null)
            {
                for (int i = 0; i < listHoSo.Count; i++)
                {
                    if (listHoSo[i].IdDon == hoSo.IdDon && listHoSo[i].IdCV == hoSo.IdCV)
                    {
                        listHoSo[i] = hoSo;
                        cbHoSo.SelectedIndex = i;
                        break;
                    }    
                }
            }    
            cldLich.SelectedDate = DateTime.Now;
            tpThoiGian.SelectedTime = DateTime.Now;
        }
        void Load(DateTime startDate)
        {
            for (int i = 0; i < dateOfWeek.IndexOf(startDate.DayOfWeek.ToString()); i++)
            {
                UCLich ucl = new UCLich();
                ucl.IsEnabled = false;
                ucl.Opacity = 0.5;
                wpLich.Children.Add(ucl);
            }
            listUCLich.Clear();
            for (int i = 1; i<= DateTime.DaysInMonth(startDate.Year, startDate.Month); i++)
            {
                UCLich ucl = new UCLich();
                ucl.lblNgay.Content = i;
                listUCLich.Add(ucl);
                wpLich.Children.Add(ucl);
            }
            LoadPhongVan();
            ShowLichPhongVan();
        }
        private void cldLich_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            wpLich.Children.Clear();
            listUCLich.Clear();
            startDate = cldLich.DisplayDate;
            Load(startDate);
        }

        void LoadHoSo()
        {
            DataTable dt = hsDAO.LoadForCT(congTy);
            foreach (DataRow dr in dt.Rows)
            {
                HoSo hoSo = new HoSo(dr);
                listHoSo.Add(hoSo);
                cbHoSo.Items.Add(hoSo.IdDon + "/" + hoSo.IdCV + " - " + hoSo.TenHoSo + " - " + hoSo.ViTriUngTuyen);
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            HoSo hoSo = listHoSo[cbHoSo.SelectedIndex];
            DateTime ngay = cldLich.SelectedDate.Value.Date;
            DateTime gio = tpThoiGian.SelectedTime.Value;
            PhongVan phongVan = new PhongVan(hoSo.IdDon, hoSo.IdCV, tbTenBuoiPV.Text, new DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, gio.Second), tbDiaChi.Text, tbLuuY.Text);
            if (phongVanDAO.CheckExist(phongVan))
                phongVanDAO.CapNhat(phongVan);
            else phongVanDAO.Them(phongVan);
            hoSo.TrangThai = "Chấp nhận";
            HoSoDAO hoSoDAO = new HoSoDAO();
            hoSoDAO.CapNhat(hoSo);
        }

        void LoadPhongVan()
        {
            listPhongVan.Clear();
            DataTable dt = phongVanDAO.Load();
            foreach (DataRow dr in dt.Rows)
            {
                PhongVan pv = new PhongVan(dr);
                listPhongVan.Add(pv);
            }
        }

        void ShowLichPhongVan()
        {
            foreach (PhongVan pv in listPhongVan)
            {
                if (pv.ThoiGian.Month == startDate.Month && pv.ThoiGian.Year == startDate.Year)
                {
                    listUCLich[pv.ThoiGian.Day - 1].listLichPhongVan.Items.Add(pv);
                }
            }
        }

        private void cldLich_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cldLich.SelectedDate != null)
            {
                listUCLich[cldLich.SelectedDate.Value.Day-1].Background = Brushes.Aqua;
            }
        }

        private void cldLich_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cldLich.SelectedDate != null)
            {
                listUCLich[cldLich.SelectedDate.Value.Day - 1].Background = Brushes.White;
            }
        }
    }

}
