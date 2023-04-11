using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public interface IPlayer
    {
        string Name { get; set; }
        
        int HP { get; set; }      

        int ATK { get; set; }

        int DEF { get; set; }

   
    }
}
