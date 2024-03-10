﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
    /// Interaction logic for WTrangChinh.xaml
    /// </summary>
    public partial class WTrangChinh : Window
    {
        public WTrangChinh()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            WDangKy wDangKy = new WDangKy();
            wDangKy.ShowDialog();
        }
    }
}
