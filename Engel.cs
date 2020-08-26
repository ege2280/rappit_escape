using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavsanKac
{
    public class Engel
    {
    
        public string EngelAdi { get; set; }
        public EngelDurum EngelDurum { get; set; }
        public Konum EngelKonum { get; set; }
       public Engel()
        {
            EngelKonum = new Konum();

        }

    }
}
