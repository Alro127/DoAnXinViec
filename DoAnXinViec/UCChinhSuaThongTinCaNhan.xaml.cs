using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
    public partial class UCChinhSuaThongTinCaNhan :System.Windows.Controls.UserControl
    {
        UngVien ungVien;
        string newImagePath;
        public UCChinhSuaThongTinCaNhan()
        {
            InitializeComponent();
        }
        public UCChinhSuaThongTinCaNhan(UngVien ungVien)
        {
            InitializeComponent();
            this.UngVien = new UngVien(ungVien);
            this.DataContext = this.UngVien;
        }

        public UngVien UngVien { get => ungVien; set => ungVien = value; }
        public string NewImagePath { get => newImagePath; set => newImagePath = value; }

        private void btnTaiAnhLen_Click(object sender, RoutedEventArgs e)
        {
            string folderName = UngVien.Id.ToString();

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = System.IO.Path.Combine(basePath, folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\"; 
            openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                newImagePath = System.IO.Path.Combine(folderPath, System.IO.Path.GetFileName(imagePath));
                UngVien.Anh = imagePath;
                this.imgAnh.ImageSource = new BitmapImage(new Uri(imagePath));
            }
        }

    }
}
