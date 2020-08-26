using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavsanKac
{
   public class YildizOrmani
    {
        public Konum Konum { get; set; }
        public Engel Engel { get; set; }
        public YildizOrmani()
        {
            Konum = new Konum();
            Engel = new Engel();
        }

    }
}
