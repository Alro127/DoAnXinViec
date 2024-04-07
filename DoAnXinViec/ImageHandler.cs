using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace DoAnXinViec
{
    public class ImageHandler
    {
        public static void SaveImage(string imageName, string id, byte[] imageData)
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagesDirectory = Path.Combine(projectDirectory, "Images/"+id);
            string imagePath = Path.Combine(imagesDirectory, imageName);

            if (!Directory.Exists(imagesDirectory))
            {
                Directory.CreateDirectory(imagesDirectory);
            }
            else
            {
                int counter = 1;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);
                string fileExtension = Path.GetExtension(imagePath);
                string uniqueFileName = fileNameWithoutExtension + "_" + counter + fileExtension;

                while (File.Exists(Path.Combine(imagesDirectory, uniqueFileName)))
                {
                    counter++;
                    uniqueFileName = fileNameWithoutExtension + "_" + counter + fileExtension;
                }

                imagePath = Path.Combine(imagesDirectory, uniqueFileName);
            }

            File.WriteAllBytes(imagePath, imageData);
        }

        public static byte[] GetImage(string imageName, string id)
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagesDirectory = Path.Combine(projectDirectory, "Images/" + id);
            string imagePath = Path.Combine(imagesDirectory, imageName);

            if (File.Exists(imagePath))
            {
                return File.ReadAllBytes(imagePath);
            }
            else
            {
                return null;
            }
        }

        public static BitmapImage SetImage(string imageName, string id)
        {
            byte[] imageData = ImageHandler.GetImage(imageName, id);

            if (imageData != null)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(imageData);
                bitmap.EndInit();
                return bitmap;
            }
            return null;
        }    
        public static string SelectImageAndSave(string id)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                string imageName = Path.GetFileName(imagePath);

                byte[] imageData = File.ReadAllBytes(imagePath);

                SaveImage(imageName, id, imageData);

                return imageName;
            }
            else
            {
                return null;
            }
        }
        public static string[] GetImagesFromFolder(string folderName)
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string folderPath = Path.Combine(projectDirectory, "Images/"+folderName);

            string[] imageExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".gif" };

            if (Directory.Exists(folderPath))
            {
                string[] imageFiles = Directory.GetFiles(folderPath)
                    .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()))
                    .ToArray();

                return imageFiles;
            }
            else
                return null;
        }
    }
}
