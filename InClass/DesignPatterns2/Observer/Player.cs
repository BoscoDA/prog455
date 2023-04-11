using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public  class Player
    {
        public int HP { get; set; }
        public string Name { get; set; }
        public bool Alive { get; set; } = true;

        public void Update(Poison poison)
        {
            this.HP -= poison.DamageActual;

            if (HP <= 0)
            {
                Alive = false;
                HP = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{this.Name} sustained { poison.DamageActual } damage. Player defeated.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{this.Name} sustained { poison.DamageActual } damage. {HP} remaining.");
                Console.ForegroundColor= ConsoleColor.White;
            }

        }
    }
}
