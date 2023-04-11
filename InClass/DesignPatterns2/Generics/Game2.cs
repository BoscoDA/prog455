using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Game2<T> where T: List<IPlayer>
    {

        Random rand = new Random();

        public void Fight(T players)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();

            while (players.Where(x => x.HP > 0).Count() > 1)
            {
                var active = players.Where(x => x.HP > 0).ToList();
                var attacker = rand.Next(0, active.Count());
                var defender = rand.Next(0, active.Count());
                int counter = 0;

                while (attacker == defender)
                {
                    counter++;
                    attacker = rand.Next(0, active.Count());
                    defender = rand.Next(0, active.Count());
                }

                Console.WriteLine("Counter = " + counter);

                if (!frequency.ContainsKey(counter))
                {
                    frequency.Add(counter, 0);
                }

                frequency[counter]++;

                Action(active[attacker], active[defender]);

                if (CleanUpHP(active[defender]) == 0)
                {
                    Console.WriteLine($"{active[defender].Name} has been defeated");
                }
            }

            var winner = players.Where(x => x.HP > 0).FirstOrDefault();
            if (winner != null)
            {
                Console.WriteLine($"{winner.Name} has won the game!");
            }

            var frequency2 = frequency.OrderBy(x => x.Key);

            foreach (var key in frequency2)
            {
                Console.WriteLine($"{key.Key}: {key.Value}");
            }
        }

        private void Action(IPlayer attacker, IPlayer defender)
        {

            var damage = rand.Next(attacker.ATK / (defender.DEF * 2), attacker.ATK / defender.DEF);
            Console.WriteLine($"{attacker.Name} is attacking {defender.Name}");

            defender.HP -= damage;

            Console.WriteLine($"{attacker.Name} does {damage} Damage to {defender.Name}");


        }

        private int CleanUpHP(IPlayer attackedPlayer)
        {
            return attackedPlayer.HP > 0 ? attackedPlayer.HP : 0;
        }
    }
}
