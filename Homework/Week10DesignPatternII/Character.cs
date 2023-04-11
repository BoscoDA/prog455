using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10DesignPatternII.Decorators;

namespace Week10DesignPatternII
{
    public class Character
    {
        [StringLength(10)] //MUST REPLACE WITH CUSTOM DECORATOR
        public string Name { get; set; }

        [InventorySize(MaxItems = 2)]
        public List<IItem> Inventory { get; set; }

        [Required] //MUST REPLACE WITH CUSTOM DECORATOR
        public ConsoleColor UniformColor { get; set; }

        //Custom Decorator
        public Gem GemStone { get; set; }
    }

    public enum Gem
    {
        SAPPHIRE,
        RUBY,
        EMERALD
    }
}
