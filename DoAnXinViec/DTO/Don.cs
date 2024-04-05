﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnXinViec
{
    public class Don
    {
        int idCV;
        string tenCV;
        string idCT;
        string diaDiem;
        int luong;
        DateTime ngayDang;
        DateTime ngayToiHan;
        string moTaCV;
        string yeuCau;
        string quyenLoi;
        int luotXem;
        int luotNop;
        string tenCT;
        string anh;
        public Don() 
        { 
            this.ngayDang = DateTime.Now;
            this.luotXem = 0;
            this.luotNop = 0;
        }

        public Don(int idCV, string tenCV, string idCT, string diaDiem, int luong, DateTime ngayDang, DateTime ngayToiHan, string moTaCV, string yeuCau, string quyenLoi, int luotXem, int luotNop)
        {
            this.idCV = idCV;
            this.tenCV = tenCV;
            this.idCT = idCT;
            this.diaDiem = diaDiem;
            this.luong = luong;
            this.NgayDang = ngayDang;
            this.ngayToiHan = ngayToiHan;
            this.moTaCV = moTaCV;
            this.yeuCau = yeuCau;
            this.quyenLoi = quyenLoi;
            this.LuotXem = luotXem;
            this.LuotNop = luotNop;
        }

        public Don(int idCV, string tenCV, string idCT, string diaDiem, int luong, DateTime ngayDang, DateTime ngayToiHan, string moTaCV, string yeuCau, string quyenLoi, int luotXem, int luotNop, string tenCT, string anh)
        {
            this.idCV = idCV;
            this.tenCV = tenCV;
            this.idCT = idCT;
            this.diaDiem = diaDiem;
            this.luong = luong;
            this.ngayDang = ngayDang;
            this.ngayToiHan = ngayToiHan;
            this.moTaCV = moTaCV;
            this.yeuCau = yeuCau;
            this.quyenLoi = quyenLoi;
            this.luotXem = luotXem;
            this.luotNop = luotNop;
            this.tenCT = tenCT;
            this.anh = anh;
        }

        public string TenCV
        {
            get => tenCV;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                tenCV = value;
            }
        }
        public string IdCT
        {
            get => idCT;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                idCT = value;
            }
        }

        public string DiaDiem
        {
            get => diaDiem;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                diaDiem = value;
            }
        }

        public int Luong
        {
            get => luong;
            set => luong = value;
        }

        public DateTime NgayToiHan
        {
            get => ngayToiHan;
            set => ngayToiHan = value;
        }

        public string MoTaCV
        {
            get => moTaCV;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                moTaCV = value;
            }
        }

        public string YeuCau
        {
            get => yeuCau;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                yeuCau = value;
            }
        }

        public string QuyenLoi
        {
            get => quyenLoi;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                quyenLoi = value;
            }
        }

        public int IdCV
        {
            get => idCV;
            set => idCV = value;
        }

        public int LuotXem
        {
            get => luotXem;
            set => luotXem = value;
        }

        public int LuotNop
        {
            get => luotNop;
            set => luotNop = value;
        }

        public DateTime NgayDang
        {
            get => ngayDang;
            set => ngayDang = value;
        }

        public string TenCT
        {
            get => tenCT;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                tenCT = value;
            }
        }

        public string Anh
        {
            get => anh;
            set => anh = value;
        }

    }
}
