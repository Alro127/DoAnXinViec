using System;
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
        int idDon;
        string tenCV;
        string idCT;
        string diaDiem;
        string luong;
        string kinhNghiem;
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

        public Don(DataRow dr)
        {
            Utility.SetItemFromRow(this, dr);

        }

        public Don(int idDon, string tenCV, string idCT, string diaDiem, string luong, string kinhNghiem, DateTime ngayDang, DateTime ngayToiHan, string moTaCV, string yeuCau, string quyenLoi, int luotXem, int luotNop)
        {
            this.idDon = idDon;
            this.tenCV = tenCV;
            this.idCT = idCT;
            this.diaDiem = diaDiem;
            this.luong = luong;
            this.kinhNghiem = kinhNghiem;
            this.NgayDang = ngayDang;
            this.ngayToiHan = ngayToiHan;
            this.moTaCV = moTaCV;
            this.yeuCau = yeuCau;
            this.quyenLoi = quyenLoi;
            this.LuotXem = luotXem;
            this.LuotNop = luotNop;
        }
        public string[] UnecessaryProperty()
        {
            return new string[3] { nameof(IdDon), nameof(TenCT), nameof(Anh) };
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

        public string Luong
        {
            get => luong;
            set => luong = value;
        }
        public string KinhNghiem
        {
            get => kinhNghiem;
            set => kinhNghiem = value;
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

        public int IdDon
        {
            get => idDon;
            set => idDon = value;
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
