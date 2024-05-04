using System;
using System.Collections.Generic;
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
    /// Interaction logic for UCTrangTimViec.xaml
    /// </summary>
    public partial class UCTrangTimViec : UserControl
    {
        public UCTrangTimViec()
        {
            InitializeComponent();
        }

        private void cbLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLuong.SelectedItem == wpKhoangLuong)
            {
                if ((txtMaxLuong.Text == "") || (txtMinLuong.Text == ""))
                {
                    cbLuong.SelectedItem = null;
                    return;
                }
                string temp = txtMinLuong.Text + " - " + txtMaxLuong.Text + " triệu";
                cbLuong.Items.Add(temp);
                cbLuong.SelectedItem = temp;
            }
        }
        private void cbKinhNghiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKinhNghiem.SelectedItem == wpKhoangKinhNghiem) 
            {
                if ((txtMaxNam.Text == "") || (txtMinNam.Text == ""))
                {
                    cbKinhNghiem.SelectedItem = null;
                    return;
                }
                string temp = txtMinNam.Text + " - " + txtMaxNam.Text + " năm";
                cbKinhNghiem.Items.Add(temp);
                cbKinhNghiem.SelectedItem = temp;
            }
        }

        public bool CheckTimKiem(string s)
        {
            if (txtTimKiem.Text == "" || s.ToLower().Contains(txtTimKiem.Text.ToLower()))
                return true;
            return false;
        }
        public bool CheckDiaDiem(string s)
        {
            if (cbDiaDiem.SelectedItem == null || ((cbDiaDiem.SelectedItem as Label).Content as string).Contains(s))
                return true;
            return false;
        }
        public bool CheckLinhVuc(string s)
        {
            if (cbLinhVuc.SelectedItem == null || ((cbLinhVuc.SelectedItem as Label).Content as string).Contains(s))
                return true;
            return false;
        }

        public bool CheckLuong(string s)
        {
            if (cbLuong.SelectedItem == null)
                return true;
            string t = (cbLuong.SelectedItem as Label).Content as string;
            if (t == "Thỏa thuận")
                return true;
            t = t.Replace("triệu", "");
            int min;
            int max;
            Filter.GetMinMax(out min, out max, t);
            string tDon = s;
            tDon = tDon.Replace("triệu", "");
            int minDon;
            int maxDon;
            Filter.GetMinMax(out minDon, out maxDon, tDon);
            if (maxDon > min && minDon < max) return true;
            return false;
        }
        public bool CheckKinhNghiem(string s)
        {
            if (cbKinhNghiem.SelectedItem == null)
                return true;
            string kn = (cbKinhNghiem.SelectedItem as Label).Content as string;
            if (string.IsNullOrEmpty(kn) || kn == "Không yêu cầu")
                return true;
            kn = kn.Replace("năm", "");
            int min, max;
            Filter.GetMinMax(out min, out max, kn);
            string knDon = s.Replace("năm", "");
            int knDonInt;
            if (string.IsNullOrEmpty(knDon) || knDon == "Không yêu cầu")
            {
                knDonInt = 0;
            }
            else if (knDon.Contains("Trên 5"))
            {
                knDonInt = int.Parse(knDon.Replace("Trên", ""));
            }
            else if (knDon.Contains("Dưới 1"))
            {
                knDonInt = int.Parse(knDon.Replace("Dưới", ""));
            }
            else knDonInt = int.Parse(knDon);
            if (min <= knDonInt && max >= knDonInt) return true;
            return false;
        }

    }
}
