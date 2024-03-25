using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace DoAnXinViec
{
    public class MyValueToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Kiểm tra xem giá trị có phù hợp không
            if (value != null)
            {
                switch (value)
                {
                    case "Từ chối":
                        return Brushes.IndianRed;
                    case "Đợi":
                        return Brushes.Orange;
                    default:
                        return Brushes.LightGreen;
                }
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
