﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    public class CV:INotifyPropertyChanged
    {
        string id;
        UngVien ungVien;
        string viTriUngTuyen;
        string linhVuc;
        string trinhDo;
        int luong;
        int namKinhNghiem;
        string mucTieu;
        string kyNang;
        string chungChi;
        string hocVan;
        string kinhNghiem;
        DateTime ngayDang;
        DateTime ngayHetHan;

        public CV() { }

        public CV(string id, UngVien ungVien, string viTriUngTuyen, string linhVuc, string trinhDo, int luong, int namKinhNghiem, string mucTieu, string kyNang, string chungChi, string hocVan, string kinhNghiem, DateTime ngayDang, DateTime ngayHetHan)
        {
            this.id = id;
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
            this.ngayHetHan = ngayHetHan;
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
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
        public int Luong
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
        public int NamKinhNghiem
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

        public DateTime NgayHetHan
        {
            get { return ngayHetHan; }
            set
            {
                if (ngayHetHan != value)
                {
                    ngayHetHan = value;
                    OnPropertyChanged(nameof(NgayHetHan));
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