﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for UCChinhSuaThongTin.xaml
    /// </summary>
    public partial class UCChinhSuaThongTinCaNhan :UserControl
    {
        UngVien ungVien;
        TaiKhoan taiKhoan;
        private void SetImage()
        {
            BitmapImage bitmapImg = MediaHandler.SetImage(ungVien.Anh, ungVien.Id);
            if (bitmapImg != null)
                imgAnh.ImageSource = bitmapImg;
        }
        public UCChinhSuaThongTinCaNhan(UngVien ungVien)
        {
            InitializeComponent();
            this.UngVien = new UngVien(ungVien);
            this.DataContext = this.UngVien;
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            DataTable dt = taiKhoanDAO.Get(ungVien.Id);
            taiKhoan = new TaiKhoan(dt.Rows[0]);
            pwMatKhau.Password = taiKhoan.MatKhau;
            SetImage();
        }

        public UngVien UngVien { get => ungVien; set => ungVien = value; }

        private void btnTaiAnhLen_Click(object sender, RoutedEventArgs e)
        {
            ungVien.Anh = MediaHandler.SelectImageAndSave(ungVien.Id);
            SetImage();
        }

        private void btnDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            WDoiMatKhau wDoiMatKhau = new WDoiMatKhau(taiKhoan);
            wDoiMatKhau.ShowDialog();
        }
    }
}
