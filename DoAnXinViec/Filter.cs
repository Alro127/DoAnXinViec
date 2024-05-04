using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    public class Filter
    {
        public static bool CheckNgay(DateTime time, string header, DateTime? selectedDate = null)
        {
            switch (header)
            {
                case "Tất cả":
                    return true;
                case "Hôm nay":
                    if (time.Date == DateTime.Today)
                        return true;
                    return false;
                case "Tuần này":
                    DateTime today = DateTime.Today;
                    DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
                    DateTime endOfWeek = startOfWeek.AddDays(6);

                    if (time.Date >= startOfWeek && time.Date <= endOfWeek)
                        return true;
                    return false;
                case "Tháng này":
                    today = DateTime.Today;
                    DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                    if (time.Date >= startOfMonth && time.Date <= endOfMonth)
                        return true;
                    return false;
                case "Năm này":
                    today = DateTime.Today;
                    DateTime startOfYear = new DateTime(today.Year, 1, 1);
                    DateTime endOfYear = new DateTime(today.Year, 12, 31);

                    if (time.Date >= startOfYear && time.Date <= endOfYear)
                        return true;
                    return false;
                default:
                    if (selectedDate!=null && time == selectedDate)
                        return true;
                    return false;
            }
        }
        public static string tinhThoiGian(DateTime ngayDang)
        {
            TimeSpan timeSincePosted = DateTime.Now - ngayDang;
            if (timeSincePosted.TotalMinutes < 1)
                return "Bây giờ";
            if (timeSincePosted.TotalHours < 1)
                return $"{(int)timeSincePosted.TotalMinutes} phút trước";
            if (timeSincePosted.TotalDays < 1)
                return $"{(int)timeSincePosted.TotalHours} giờ trước";
            return $"{(int)timeSincePosted.TotalDays} ngày trước";
        }
        public static void GetMinMax(out int min, out int max, string t)
        {
            min = 0;
            max = int.MaxValue;
            if (t.Contains("Dưới"))
                max = int.Parse(Regex.Replace(t, "[^0-9]", ""));
            else if (t.Contains("Trên"))
                min = int.Parse(Regex.Replace(t, "[^0-9]", ""));
            else
            {
                string[] pair_t = t.Split('-');
                min = int.Parse(pair_t[0]);
                max = int.Parse(pair_t[1]);
            }
        }
        public static List<Don> SapXepHienThiUuTienTheoLinhVuc(List<Don> list, List<string> listLinhVuc)
        {
            list.Sort((x, y) =>
            {
                if (listLinhVuc.Contains(x.LinhVuc) && !listLinhVuc.Contains(y.LinhVuc))
                    return -1;
                else if (!listLinhVuc.Contains(x.LinhVuc) && listLinhVuc.Contains(y.LinhVuc))
                    return 1;
                else
                    return 0;
            });

            return list;
        }
        public static List<CV> SapXepHienThiUuTienTheoLinhVuc(List<CV> list, List<string> listLinhVuc)
        {
            list.Sort((x, y) =>
            {
                if (listLinhVuc.Contains(x.LinhVuc) && !listLinhVuc.Contains(y.LinhVuc))
                    return -1;
                else if (!listLinhVuc.Contains(x.LinhVuc) && listLinhVuc.Contains(y.LinhVuc))
                    return 1;
                else
                    return 0;
            });

            return list;
        }
    }
}
