using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns
{
    public static class ItemFactory
    {
        public static IItem CreateItem(string name, string desc, ItemType type)
        {
            IItem item;

            switch (type)
            {
                case ItemType.POTION:
                    item = new Potion();
                    break;

                case ItemType.EYEBALL:
                    item = new Eyeball();
                    break;

                case ItemType.KEY:
                    item = new Key();
                    break;

                default: throw new ArgumentException("Invalid Item");
            }

            item.Name = name;
            item.Description = desc;
            item.Type = type;

            return item;
        }

        public enum ItemType
        {
            POTION,
            EYEBALL,
            KEY
        }
    }
}
