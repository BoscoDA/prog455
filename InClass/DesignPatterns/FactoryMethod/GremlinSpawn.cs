using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class GremlinSpawn : Spawn
    {
        public override Player FactoryMethdod()
        {
            return new Gremlin();
        }
    }
}
