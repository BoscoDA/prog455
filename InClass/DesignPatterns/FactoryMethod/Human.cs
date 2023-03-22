using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Human : Player
    {
        public override string Name => $"I am a Human";
    }
}
