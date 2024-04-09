using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isabike
{
    public class Termekek
    {

        public string token { get; set; }
        public int termek_id { get;set;}

        public int termek_kateg { get;set;}

        public string kategoria_neve { get; set; }

        public string termek_nev { get; set;}

        public int gyarto_id { get; set;}

        public string gyarto_neve { get; set;}

        public string telefonszama { get; set;}

        public string webhely { get; set;}

        public int raktarondb { get; set;}

        public int tomeg_tulajdonsaga_id { get; set;}

        public string mertek_egysege { get; set;}

        public float tomeg_erteke { get; set;}

        public string szine { get; set;}

        public string leiras { get; set;}

        public int egyseg_ar { get; set;}

        public bool elerheto { get; set;}

        public string kep_helye { get; set;}
    }
}
