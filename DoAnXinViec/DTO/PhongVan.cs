using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    public class PhongVan
    {
        int idDon;
        int idCV;
        string tenBuoiPV;
        DateTime thoiGian;
        string diaDiem;
        string luuY;
        
        public PhongVan()
        { }
        
        
        public PhongVan(DataRow dr) 
        {
            Utility.SetItemFromRow(this, dr);
        }

        public PhongVan(int idDon, int idCV, string tenBuoiPV, DateTime thoiGian, string diaDiem, string luuY)
        {
            this.idDon = idDon;
            this.idCV = idCV;
            this.tenBuoiPV = tenBuoiPV;
            this.thoiGian = thoiGian;
            this.diaDiem = diaDiem;
            this.luuY = luuY;
        }

        public int IdDon { get => idDon; set => idDon = value; }
        public int IdCV { get => idCV; set => idCV = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }
        public string DiaDiem { get => diaDiem; set => diaDiem = value; }
        public string LuuY { get => luuY; set => luuY = value; }
        public string TenBuoiPV { get => tenBuoiPV; set => tenBuoiPV = value; }
    }
}
