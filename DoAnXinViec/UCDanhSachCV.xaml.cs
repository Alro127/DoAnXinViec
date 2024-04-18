﻿using System;
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
        public UCDanhSachCV(UngVien ungVien)
        {
            InitializeComponent();
            this.ungVien = ungVien;
            Load();
        }
        private void Load()
        {
            CVDAO cvDAO = new CVDAO();
            DataTable dt = cvDAO.Get(ungVien);
            foreach (DataRow dr in dt.Rows)
            {
                CV cv = new CV(dr);
                cv.UngVien = ungVien;
                listCV.Add(cv);
            }
            lvDanhSachCV.ItemsSource = listCV;
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
            WChinhSuaCV wChinhSuaCV = new WChinhSuaCV(cv);
            wChinhSuaCV.ShowDialog();
        }
    }
}
