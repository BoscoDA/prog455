using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week8AssignmentDesignPatterns.ItemFactory;

namespace Week8AssignmentDesignPatterns
{
    public abstract class ItemBase : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
    }
}
