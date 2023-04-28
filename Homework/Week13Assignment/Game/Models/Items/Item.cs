using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10DesignPatternII.Models.Items
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatChange { get; set; }
        public string Type { get; set; }

        public Item(string name, string description, int statChange, string type)
        {
            Name = name;
            Description = description;
            StatChange = statChange;
            Type = type;
        }

        /// <summary>
        /// Returns a display string for the item
        /// </summary>
        /// <returns></returns>
        public string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\nName: {Name}\n");
            sb.Append($"\nDescription: {Description}\n");
            return sb.ToString();
        }
    }
}
