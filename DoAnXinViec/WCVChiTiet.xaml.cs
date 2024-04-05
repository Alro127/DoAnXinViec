﻿using System;
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
    /// Interaction logic for WCVChiTiet.xaml
    /// </summary>
    public partial class WCVChiTiet : Window
    {
        CV cv;
        public WCVChiTiet(CV cv)
        {
            InitializeComponent();
            this.Cv = cv;
            this.DataContext = Cv;
            BitmapImage bitmapImg = ImageHandler.SetImage(Cv.UngVien.Anh);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }

        public CV Cv { get => cv; set => cv = value; }
    }
}
