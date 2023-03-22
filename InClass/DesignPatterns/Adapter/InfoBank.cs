using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    //Simulating a database
    internal class InfoBank
    {
        public int GetHP(string type)
        {
            switch (type)
            {
                case "Orc":
                    return 900;
                case "Dwarf":
                    return 750;
                default:
                    return 0;

            }
        }

        public int GetMP(string type)
        {
            switch (type)
            {
                case "Orc":
                    return 10;
                case "Dwarf":
                    return 105;
                default:
                    return 0;

            }
        }

        public int GetStamina(string type)
        {
            switch (type)
            {
                case "Orc":
                    return 150;
                case "Dwarf":
                    return 60;
                default:
                    return 0;

            }
        }
    }
}
