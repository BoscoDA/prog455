using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week8AssignmentDesignPatterns.ItemFactory;

namespace Week8AssignmentDesignPatterns
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        ItemType Type { get; set; }
    }
}
