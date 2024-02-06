using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isabike
{
    public class gyarto
    {
        public int id { get; set;}
        public string name { get; set;}
        public string tel { get; set;}
        public string webpage { get; set;}

        public override string ToString() => name;

    }

    public class gyartoList {
        public gyarto[] gyartok { get; set;}   
    }
}
