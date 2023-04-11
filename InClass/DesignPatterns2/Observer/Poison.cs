using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Poison
    {
        private List<Player> Players = new List<Player>();
        private int DamageInterval;
        private int MinDamage;
        private int MaxDamage;
        public int DamageActual;

        public Poison()
        {
            
        }

        public void ActivatePoisonBarrier(int minDamage =1, int maxDamage =15, int damageInterval = 7 )
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            DamageInterval = damageInterval;
           
            Notify();
        }

        public void Notify()
        {
            var turn = 1;
            while (DamageInterval > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Turn #{turn}");
                Console.ForegroundColor= ConsoleColor.White;
                foreach (Player p in Players)
                {
                    DamageActual = new Random().Next(MinDamage, MaxDamage);
                    if (p.Alive)
                    {
                        p.Update(this);
                    }
                }
                DamageInterval--;
                turn++; 

            }
        }

        public void Attach(Player player)
        {
            Players.Add(player);
        }

        public void remove(Player player)
        {
            Players.Remove(player);
        }

    }
}
