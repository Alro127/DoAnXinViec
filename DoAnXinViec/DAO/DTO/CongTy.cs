using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;

namespace DoAnXinViec
{
    public class CongTy: User
    { 
        string tenCT;
        string maSoThue;
        string gPKD;
        string linhVuc;
        int quyMoNhanSu;
        string link;


        public CongTy() { }

        public CongTy(DataRow dr)
        {
            Utility.SetItemFromRow(this, dr);
        }
        public CongTy(CongTy congTy)
        {
            var properties = typeof(CongTy).GetProperties();

            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(congTy));
                }
            }
        }
        public CongTy(string id, string hoTen, string sDT, string email, string tenCT, string maSoThue, string gPKD, string linhVuc, int quyMoNhanSu, string tinhThanh, string diaChi, string link, string gT, string anh): base(id, hoTen, tinhThanh, diaChi, sDT, email, gT, anh)
        {
            
            try
            {
                TenCT = tenCT;
                MaSoThue = maSoThue;
                GPKD = gPKD;
                LinhVuc = linhVuc;
                QuyMoNhanSu = quyMoNhanSu;
                Link = link;
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public string TenCT
        {
            get { return tenCT; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống tên công ty");
                }
                tenCT = value;
                OnPropertyChanged(nameof(TenCT));
            }
        }

        public string LinhVuc
        {
            get { return linhVuc; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống tên lĩnh vực");
                }
                linhVuc = value;
                OnPropertyChanged(nameof(LinhVuc));
            }
        }

        public int QuyMoNhanSu
        {
            get { return quyMoNhanSu; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentNullException("Quy mô nhân sự phải là 1 con số lớn hơn 0");
                }
                quyMoNhanSu = value;
                OnPropertyChanged(nameof(QuyMoNhanSu));
            }
        }

        public string Link
        {
            get { return link; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống tên đường link");
                }
                link = value;
                OnPropertyChanged(nameof(Link));
            }
        }

        public string MaSoThue
        {
            get { return maSoThue; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống mã số thuế");
                }
                maSoThue = value;
                OnPropertyChanged(nameof(MaSoThue));
            }
        }

        public string GPKD
        {
            get { return gPKD; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống giấy phép kinh doanh");
                }
                gPKD = value;
                OnPropertyChanged(nameof(GPKD));
            }
        }
    }
}
