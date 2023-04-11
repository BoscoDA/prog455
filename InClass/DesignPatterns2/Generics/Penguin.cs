using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Penguin : IPlayer
    {
       
        public string Name { get; set; }
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }

    }
}
