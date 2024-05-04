﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoAnXinViec
{
    public class HoSo: INotifyPropertyChanged
    {
        int idDon;
        int idCV;
        string tenHoSo;
        string tenCT;
        string viTriUngTuyen;
        string loaiHoSo;
        DateTime ngayNop;
        string trangThai;

        public HoSo() { }
        public HoSo(DataRow dr)
        {
            Utility.SetItemFromRow(this, dr);
        }
        public HoSo(int idDon, int idCV, string loaiHoSo, DateTime ngayNop, string trangThai)
        {
            this.idDon = idDon;
            this.idCV = idCV;
            this.loaiHoSo = loaiHoSo;
            this.ngayNop = ngayNop;
            this.trangThai = trangThai;
        }

        public HoSo(int idDon, int idCV, string tenHoSo, string tenCT, string viTriUngTuyen, string loaiHoSo, DateTime ngayNop, string trangThai)
        {
            this.idDon= idDon;
            this.idCV = idCV;
            this.tenHoSo = tenHoSo;
            this.TenCT = tenCT;
            this.viTriUngTuyen = viTriUngTuyen;
            this.loaiHoSo = loaiHoSo;
            this.ngayNop = ngayNop;
            this.trangThai = trangThai;
        }

        public int IdCV { get => idCV; set => idCV = value; }
        public int IdDon { get => idDon; set => idDon = value; }
        public string TenHoSo { get => tenHoSo; set => tenHoSo = value; }
        public string TenCT { get => tenCT; set => tenCT = value; }
        public string ViTriUngTuyen { get => viTriUngTuyen; set => viTriUngTuyen = value; }
        public string LoaiHoSo { get => loaiHoSo; set => loaiHoSo = value; }
        public DateTime NgayNop { get => ngayNop; set => ngayNop = value; }
        public string TrangThai
        {
            get => trangThai;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                trangThai = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string[] UnecessaryProperty()
        {
            return new string[3] { nameof(TenCT), nameof(ViTriUngTuyen), nameof(TenHoSo) };
        }
    }
}
