using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class Item
    {
        public Item(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public int Quantity { get; set; }
        public string Name { get; set; } = "";
    }
}
