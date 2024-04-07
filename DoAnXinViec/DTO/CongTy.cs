using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            this.tenCT = tenCT;
            this.maSoThue = maSoThue;
            this.gPKD = gPKD;
            this.linhVuc = linhVuc;
            this.quyMoNhanSu = quyMoNhanSu;
            this.link = link;
        }

        public string TenCT
        {
            get { return tenCT; }
            set
            {
                if (tenCT != value)
                {
                    tenCT = value;
                    OnPropertyChanged(nameof(TenCT));
                }
            }
        }

        public string LinhVuc
        {
            get { return linhVuc; }
            set
            {
                if (linhVuc != value)
                {
                    linhVuc = value;
                    OnPropertyChanged(nameof(LinhVuc));
                }
            }
        }

        public int QuyMoNhanSu
        {
            get { return quyMoNhanSu; }
            set
            {
                if (quyMoNhanSu != value)
                {
                    quyMoNhanSu = value;
                    OnPropertyChanged(nameof(QuyMoNhanSu));
                }
            }
        }

        public string Link
        {
            get { return link; }
            set
            {
                if (link != value)
                {
                    link = value;
                    OnPropertyChanged(nameof(Link));
                }
            }
        }

        public string MaSoThue
        {
            get { return maSoThue; }
            set
            {
                if (maSoThue != value)
                {
                    maSoThue = value;
                    OnPropertyChanged(nameof(MaSoThue));
                }
            }
        }

        public string GPKD
        {
            get { return gPKD; }
            set
            {
                if (gPKD != value)
                {
                    gPKD = value;
                    OnPropertyChanged(nameof(GPKD));
                }
            }
        }
    }
}
