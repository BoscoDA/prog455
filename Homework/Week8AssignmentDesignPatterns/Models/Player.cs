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

        public int Lives { get; private set; }
        public List<IItem> Inventory { get; private set; }

        private static object locker = new object();

        private Player()
        {
            Lives = 5;
            Inventory = new List<IItem>();
        }

        /// <summary>
        /// Returns the singleton instance of the player object
        /// </summary>
        /// <returns></returns>
        public static Player Instance()
        {
            if(instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Player();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Decrements the lives property by one
        /// </summary>
        public void LoseLife()
        {
            if (Lives > 0)
            {
                Lives--;
            }
        }

        /// <summary>
        /// Adds the item passed into the parameter to the player's inventory
        /// </summary>
        /// <param name="item"></param>
        public void PickUpItem(IItem item)
        {
            Inventory.Add(item);
        }
    }
}
