using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoAnXinViec
{
    /// <summary>
    /// Interaction logic for WTrangChuCTy.xaml
    /// </summary>
    public partial class WTrangChuCTy : Window
    {
        CongTy congTy;
        DonDAO donDAO = new DonDAO();
        List<Don> donList = new List<Don>();
        public WTrangChuCTy(CongTy congTy)
        {
            InitializeComponent();
            this.congTy = congTy;
            this.DataContext = congTy;
            imgAnh.Source = ImageHandler.SetImage(congTy.Anh, congTy.Id);
            LoadDon();
            LoadAnh();
        }
        void DangUCDon()
        {
            foreach (Don don in donList)
            {
                UCDon uCDon = new UCDon(don);
                BitmapImage bitmapImg = ImageHandler.SetImage(congTy.Anh, congTy.Id);
                if (bitmapImg != null)
                    uCDon.imgAnh.Source = bitmapImg;
                stDon.Children.Add(uCDon);
            }
        }
        void LoadDon()
        {
            DataTable dt = donDAO.LoadForCT(congTy);
            foreach (DataRow dr in dt.Rows)
            {
                Don don = new Don(dr);
                donList.Add(don);
            }
            DangUCDon();
        }
        void LoadAnh()
        {
            string[] DanhSachAnh = ImageHandler.GetImagesFromFolder(congTy.Id);
            for (int i = 0; i < DanhSachAnh.Length; i++)
            {
                Image anh = new Image() { Width = 100, Height = 100, Margin = new Thickness(10, 9, 0, 9) };
                anh.Source = ImageHandler.SetImage(DanhSachAnh[i], congTy.Id);
                wpAnh.Children.Add(anh);
            }
        }
    }
}