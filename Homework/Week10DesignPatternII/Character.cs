using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10DesignPatternII.Decorators;
using RequiredAttribute = Week10DesignPatternII.Decorators.RequiredAttribute;

namespace Week10DesignPatternII
{
    public class Character : ICharacter
    {
        [NameLength(Max = 10)]
        public string Name { get; set; }

        [InventorySize(MaxItems = 2)]
        public List<IItem> Inventory { get; set; }

        [Required]
        public ConsoleColor? UniformColor { get; set; }

        //Custom Decorator
        public Gem? GemStone { get; set; }

        public Character() 
        {
            Inventory = new List<IItem>();
        }
    }



    public enum Gem
    {
        SAPPHIRE,
        RUBY,
        EMERALD
    }
}
