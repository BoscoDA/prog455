using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Character
    {
        protected int HP;
        protected int MP;
        protected int Stamina;

        public Dictionary<int, int> Map = new Dictionary<int, int>();   

        public virtual string Info()
        {
            return "There is nothing here!";
        }
    }
}
