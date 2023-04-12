using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10DesignPatternII.Decorators;
using Week10DesignPatternII.Models.Items;
using Week10DesignPatternII.Utilities;
using RequiredAttribute = Week10DesignPatternII.Decorators.RequiredAttribute;

namespace Week10DesignPatternII.Models
{
    public class Character : ICharacter
    {
        [NameLength(Max = 10)]
        public string Name { get; set; }

        [InventorySize(MaxItems = 2)]
        public List<IItem> Inventory { get; set; }

        [Required]
        public ConsoleColor? UniformColor { get; set; }

        [GemType(ValidGems = "sapphire,ruby,emerald")]
        public string GemStone { get; set; }

        public int HP { get; set; }
        public int Weight { get; set; }
        public int DepthDived { get; set; }

        public Character()
        {
            Inventory = new List<IItem>();
            HP = 100;
            Weight = 100;
            DepthDived = 0;
        }

        public void Update(WaterPressure pressure)
        {
            HP -= pressure.actualWaterPressureDamage;
            HP = HP < 0 ? 0 : HP;

            Printer.Print($"\n{Name} took {pressure.actualWaterPressureDamage} damage from the pressure of the water.", ((ConsoleColor)UniformColor));
        }
    }
}
