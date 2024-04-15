using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isabike
{
    internal class Privilege
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Privilege(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
