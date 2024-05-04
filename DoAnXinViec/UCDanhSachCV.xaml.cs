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
    /// Interaction logic for UCDanhSachCV.xaml
    /// </summary>
    public partial class UCDanhSachCV : UserControl
    {
        UngVien ungVien;
        List <CV> listCV = new List <CV> ();
        List <CV> listHienThi = new List<CV> ();
        public UCDanhSachCV(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            Load();
            LoadBoLoc();
        }
        private void Load()
        {
            CVDAO cvDAO = new CVDAO();
            DataTable dt = cvDAO.Get(ungVien);
            listCV.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                CV cv = new CV(dr);
                cv.UngVien = ungVien;
                listCV.Add(cv);
            }
            listHienThi.AddRange(listCV);
            lvDanhSachCV.ItemsSource = listHienThi;
        }
        void LoadBoLoc()
        {
            List<string> listLinhVuc = new List<string>() { "Tất cả"};
            listLinhVuc.AddRange(listCV.Select(cv => cv.LinhVuc).Distinct().ToList());
            cbBoLoc.ItemsSource = listLinhVuc;
        }
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            CV cv = (sender as Button).Tag as CV;
            WCVChiTiet wCVChiTiet = new WCVChiTiet(cv);
            wCVChiTiet.ShowDialog();
        }

        private void btnChinhSua_Click(object sender, RoutedEventArgs e)
        {
            CV cv = (sender as Button).Tag as CV;
            listCV.Remove(cv);
            WChinhSuaCV wChinhSuaCV = new WChinhSuaCV(cv);
            wChinhSuaCV.ShowDialog();
            listCV.Add(cv);
            listHienThi.Clear();
            listHienThi.AddRange(listCV);
            lvDanhSachCV.ItemsSource=listHienThi;
            lvDanhSachCV.Items.Refresh();
        }
        private void cbBoLoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Loc();
        }
        private void SapXep()
        {
            if (cbSapXep.SelectedIndex == 0)
                listHienThi = listHienThi.OrderBy(cv => cv.ViTriUngTuyen).ToList();
            else if (cbSapXep.SelectedIndex == 1)
                listHienThi = listHienThi.OrderByDescending(cv => cv.ViTriUngTuyen).ToList();
            else if (cbSapXep.SelectedIndex == 2)
                listHienThi = listHienThi.OrderByDescending(cv => cv.ViTriUngTuyen).ToList();
            else if (cbSapXep.SelectedIndex == 3)
                listHienThi = listHienThi.OrderBy(cv => cv.ViTriUngTuyen).ToList();
            lvDanhSachCV.ItemsSource = listHienThi;
            lvDanhSachCV.Items.Refresh();
        }
        private void cbSapXep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SapXep();
        }
        bool CheckTimKiem(CV cv)
        {
            if (tbTimKiem.Text == "") return true;
            string str = cv.ViTriUngTuyen.ToLower();
            if (str.Contains(tbTimKiem.Text.ToLower()))
                return true;
            return false;
        }
        private void Loc()
        {
            listHienThi.Clear();
            foreach (CV cv in listCV)
            {
                if (CheckBoLoc(cv) && CheckTimKiem(cv))
                    listHienThi.Add(cv);
            }
            SapXep();
        }
        bool CheckBoLoc(CV cv)
        {
            if (cbBoLoc.SelectedIndex <= 0) return true;
            if (cv.LinhVuc == cbBoLoc.SelectedItem.ToString()) return true;
            return false;
        }
        private void tbTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            Loc();
        }

        private void btnThemCV_Click(object sender, RoutedEventArgs e)
        {
            WTaoCV wTaoCV = new WTaoCV(ungVien);
            wTaoCV.ShowDialog();
        }

        private void btnReLoad_Click(object sender, RoutedEventArgs e)
        {
            Load();
            lvDanhSachCV.Items.Refresh();
        }
    }
}
