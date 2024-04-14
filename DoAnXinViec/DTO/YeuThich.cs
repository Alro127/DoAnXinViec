using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnXinViec
{
    public class YeuThich
    {
        int id;
        string idUser;

        public YeuThich(int id, string idUser)
        {
            this.id = id;
            this.idUser = idUser;
        }

        public YeuThich(DataRow dr)
        {
            Utility.SetItemFromRow(this, dr);
        }
        public YeuThich() { }
        public int Id { get => id; set => id = value; }
        public string IdUser { get => idUser; set => idUser = value; }
    }
}
