using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class HumanSpawn : Spawn
    {
        public override Player FactoryMethdod()
        {
            return new Human();
        }
    }
}
