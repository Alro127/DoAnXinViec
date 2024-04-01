using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnXinViec
{
    public class CongTy : INotifyPropertyChanged
    {
        string idCT;
        string hoTen;
        string sdt;
        string email;
        string tenCT;
        string maSoThue;
        string gPKD;
        string lingVuc;
        int quyMoNhanSu;
        string tinhThanh;
        string diaChi;
        string link;
        string gTCT;
        string anh;

        public CongTy() { }
        public CongTy(string idCT, string hoTen, string sdt, string email, string tenCT, string maSoThue, string gPKD, string lingVuc, int quyMoNhanSu, string tinhThanh, string diaChi, string link, string gTCT, string anh)
        {
            this.idCT = idCT;
            this.hoTen = hoTen;
            this.sdt = sdt;
            this.email = email;
            this.tenCT = tenCT;
            this.maSoThue = maSoThue;
            this.gPKD = gPKD;
            this.lingVuc = lingVuc;
            this.quyMoNhanSu = quyMoNhanSu;
            this.tinhThanh = tinhThanh;
            this.diaChi = diaChi;
            this.link = link;
            this.gTCT = gTCT;
            this.anh = anh;
        }

        public string HoTen
        {
            get { return hoTen; }
            set
            {    
                if (hoTen != value)
                {
                    hoTen = value;
                    OnPropertyChanged(nameof(HoTen));
                }
            }
        }

        public string Sdt
        {
            get { return sdt; }
            set
            {
                if (sdt != value)
                {
                    sdt = value;
                    OnPropertyChanged(nameof(Sdt));
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
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

        public string LingVuc
        {
            get { return lingVuc; }
            set
            {
                if (lingVuc != value)
                {
                    lingVuc = value;
                    OnPropertyChanged(nameof(LingVuc));
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

        public string TinhThanh
        {
            get { return tinhThanh; }
            set
            {
                if (tinhThanh != value)
                {
                    tinhThanh = value;
                    OnPropertyChanged(nameof(TinhThanh));
                }
            }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set
            {
                if (diaChi != value)
                {
                    diaChi = value;
                    OnPropertyChanged(nameof(DiaChi));
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

        public string GTCT
        {
            get { return gTCT; }
            set
            {
                if (gTCT != value)
                {
                    gTCT = value;
                    OnPropertyChanged(nameof(GTCT));
                }
            }
        }

        public string Anh
        {
            get { return anh; }
            set
            {
                if (anh != value)
                {
                    anh = value;
                    OnPropertyChanged(nameof(Anh));
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

        public string IdCT
        {
            get { return idCT; }
            set
            {
                if (idCT != value)
                {
                    idCT = value;
                    OnPropertyChanged(nameof(IdCT));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
