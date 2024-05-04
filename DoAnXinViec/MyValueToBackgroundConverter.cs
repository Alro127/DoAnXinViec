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
                switch (value)
                {
                    case "Từ chối":
                        return Brushes.Red;
                    case "Đợi":
                        return Brushes.Orange;
                    case "Chấp nhận":
                        return Brushes.Green;
                    default:
                        return Brushes.White;
                }
        }
        public object ConvertBorder(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((DateTime)value > DateTime.Now)
                return Brushes.Orange;
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
