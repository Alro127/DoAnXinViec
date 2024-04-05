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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for UCLichSuDangDon.xaml
    /// </summary>
    public partial class UCLichSuDangDon : UserControl
    {
        DonDAO donDAO = new DonDAO();
        CongTy congTy = new CongTy();
        public UCLichSuDangDon()
        {
            InitializeComponent();
        }
        public UCLichSuDangDon(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            Load();
        }

        public void Load()
        {
            DataTable dt = donDAO.LoadLichSu(congTy);
            List<Don> listDon = new List<Don>();

            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don();
                Utility.SetItemFromRow(don, dr);
                listDon.Add(don);
            }
            DateTime temp = DateTime.MinValue.Date;
            Expander expander;
            StackPanel stackPanel = new StackPanel();
            foreach (Don don in listDon)
            {
                if (don.NgayDang.Date != temp)
                {
                    expander = new Expander() { Header = don.NgayDang.Date, IsExpanded = true };
                    stackPanel = new StackPanel();
                    expander.Content = stackPanel;
                    stLichSuDangDon.Children.Add(expander);
                    temp = don.NgayDang.Date;
                }
                stackPanel.Children.Add(
                    new Label()
                    {
                        Content = don.TenCV,
                        Background = Brushes.White,
                        BorderBrush = Brushes.LightGray,
                        BorderThickness = new Thickness(0, 0, 0, 1),
                        Height = 40,
                        FontSize = 12,
                        Foreground = Brushes.Black,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Effect = new DropShadowEffect { ShadowDepth = 0, Color = Colors.Transparent }
                    });
            }
        }
    }
}
