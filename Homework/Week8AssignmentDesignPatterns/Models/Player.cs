using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns
{
    public class Player
    {
        private static Player instance;

        public string Name { get; private set; }
        public int Lives { get; private set; }
        public List<IItem> Inventory { get; private set; }

        private static object locker = new object();

        private Player(string name)
        {
            Name = name;
            Lives = 5;
            Inventory = new List<IItem>();
        }

        public static Player Instance(string name)
        {
            if(instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Player(name);
                    }
                }
            }

            return instance;
        }

        public void LoseLife()
        {
            Lives--;
        }

        public void PickUpItem(IItem item)
        {
            Inventory.Add(item);
        }
    }
}
