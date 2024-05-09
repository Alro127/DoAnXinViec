using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoAnXinViec
{
    public class CV:INotifyPropertyChanged
    {
        int id;
        string idUV;
        UngVien ungVien;
        string viTriUngTuyen;
        string linhVuc;
        string trinhDo;
        string luong;
        string namKinhNghiem;
        string mucTieu;
        string kyNang;
        string chungChi;
        string hocVan;
        string kinhNghiem;
        DateTime ngayDang;
        DateTime ngayToiHan;
        string anh;

        public CV() { }

        public CV(DataRow dr)
        {
            Utility.SetItemFromRow(this,dr);
            UngVienDAO ungVienDAO = new UngVienDAO();
            DataTable dtuv = ungVienDAO.Get(IdUV, "UngVien");
            UngVien ungVien = new UngVien(dtuv.Rows[0]);
            UngVien = ungVien;
        }
        public CV(CV cV)
        {
            var properties = typeof(CV).GetProperties();

            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(cV));
                }
            }
        }
        public CV(int id, string idUV, UngVien ungVien, string viTriUngTuyen, string linhVuc, string trinhDo, string luong, string namKinhNghiem, string mucTieu, string kyNang, string chungChi, string hocVan, string kinhNghiem, DateTime ngayDang, DateTime ngayToiHan, string anh)
        {
            this.id = id;
            this.idUV = idUV;
            this.ungVien = ungVien;
            this.viTriUngTuyen = viTriUngTuyen;
            this.linhVuc = linhVuc;
            this.trinhDo = trinhDo;
            this.luong = luong;
            this.namKinhNghiem = namKinhNghiem;
            this.mucTieu = mucTieu;
            this.kyNang = kyNang;
            this.chungChi = chungChi;
            this.hocVan = hocVan;
            this.kinhNghiem = kinhNghiem;
            this.ngayDang = ngayDang;
            this.ngayToiHan = ngayToiHan;
            this.anh = anh;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string IdUV
        {
            get { return idUV; }
            set
            {
                if (idUV != value)
                {
                    idUV = value;
                    OnPropertyChanged(nameof(IdUV));
                }
            }
        }

        public UngVien UngVien
        {
            get { return ungVien; }
            set
            {
                if (ungVien != value)
                {
                    ungVien = value;
                    OnPropertyChanged(nameof(UngVien));
                }
            }
        }

        public string ViTriUngTuyen
        {
            get { return viTriUngTuyen; }
            set
            {
                if (viTriUngTuyen != value)
                {
                    viTriUngTuyen = value;
                    OnPropertyChanged(nameof(ViTriUngTuyen));
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

        public string TrinhDo
        {
            get { return trinhDo; }
            set
            {
                if (trinhDo != value)
                {
                    trinhDo = value;
                    OnPropertyChanged(nameof(TrinhDo));
                }
            }
        }
        public string Luong
        {
            get { return luong; }
            set
            {
                if (luong != value)
                {
                    luong = value;
                    OnPropertyChanged(nameof(Luong));
                }
            }
        }
        public string NamKinhNghiem
        {
            get { return namKinhNghiem; }
            set
            {
                if (namKinhNghiem != value)
                {
                    namKinhNghiem = value;
                    OnPropertyChanged(nameof(namKinhNghiem));
                }
            }
        }
        public string MucTieu
        {
            get { return mucTieu; }
            set
            {
                if (mucTieu != value)
                {
                    mucTieu = value;
                    OnPropertyChanged(nameof(MucTieu));
                }
            }
        }
        public string KyNang
        {
            get { return kyNang; }
            set
            {
                if (kyNang != value)
                {
                    kyNang = value;
                    OnPropertyChanged(nameof(KyNang));
                }
            }
        }

        public string ChungChi
        {
            get { return chungChi; }
            set
            {
                if (chungChi != value)
                {
                    chungChi = value;
                    OnPropertyChanged(nameof(ChungChi));
                }
            }
        }
        public string HocVan
        {
            get { return hocVan; }
            set
            {
                if (hocVan != value)
                {
                    hocVan = value;
                    OnPropertyChanged(nameof(HocVan));
                }
            }
        }
        public string KinhNghiem
        {
            get { return kinhNghiem; }
            set
            {
                if (kinhNghiem != value)
                {
                    kinhNghiem = value;
                    OnPropertyChanged(nameof(KinhNghiem));
                }
            }
        }
        public DateTime NgayDang
        {
            get { return ngayDang; }
            set
            {
                if (ngayDang != value)
                {
                    ngayDang = value;
                    OnPropertyChanged(nameof(NgayDang));
                }
            }
        }

        public DateTime NgayToiHan
        {
            get { return ngayToiHan; }
            set
            {
                if (ngayToiHan != value)
                {
                    ngayToiHan = value;
                    OnPropertyChanged(nameof(NgayToiHan));
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string[] UnecessaryProperty1()
        {
            return new string[1] { nameof(UngVien) };
        }
        public string[] UnecessaryProperty2()
        {
            return new string[2] { nameof(Id), nameof(UngVien) };
        }
    }
}