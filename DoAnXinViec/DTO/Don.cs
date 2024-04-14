using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            try
            {
                IdDon = idDon;
                TenCV = tenCV;
                IdCT = idCT;
                DiaDiem = diaDiem;
                Luong = luong;
                KinhNghiem = kinhNghiem;
                NgayDang = ngayDang;
                NgayToiHan = ngayToiHan;
                MoTaCV = moTaCV;
                YeuCau = yeuCau;
                QuyenLoi = quyenLoi;
                LuotXem = luotXem;
                LuotNop = luotNop;
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
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
                    throw new ArgumentNullException("Không được bỏ trống tên công việc");
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
                    throw new ArgumentNullException("Không được bỏ trống id CT");
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
                    throw new ArgumentNullException("Không được bỏ trống địa điểm");
                }
                diaDiem = value;
            }
        }

        public string Luong
        {
            get => luong;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống lương");
                }
                luong = value;
            }
        }
        public string KinhNghiem
        {
            get => kinhNghiem;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống kinh nghiệm");
                }
                kinhNghiem = value;
            }
        }

        public DateTime NgayToiHan
        {
            get => ngayToiHan;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Không được bỏ trống ngày tới hạn");
                }
                ngayToiHan = value;
            }
        }

        public string MoTaCV
        {
            get => moTaCV;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống mô tả công việc");
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
                    throw new ArgumentNullException("Không được bỏ trống yêu cầu");
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
                    throw new ArgumentNullException("Không được bỏ trống quyền lợi");
                }
                quyenLoi = value;
            }
        }

        public int IdDon
        {
            get => idDon;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Không được bỏ trống id đơn");
                }
                idDon = value;
            }
        }

        public int LuotXem
        {
            get => luotXem;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Không được bỏ trống lượt xem");
                }
                luotXem = value;
            }
        }

        public int LuotNop
        {
            get => luotNop;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Không được bỏ trống lượt nộp");
                }
                luotNop = value;
            }
        }

        public DateTime NgayDang
        {
            get => ngayDang;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Không được bỏ trống ngày đăng");
                }
                ngayDang = value;
            }
        }

        public string TenCT
        {
            get => tenCT;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Không được bỏ trống tên công ty");
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
