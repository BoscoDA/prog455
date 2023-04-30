using Week10DesignPatternII.Decorators;
using Week10DesignPatternII.Models.Items;

namespace Week10DesignPatternII.Models
{
    public interface ICharacter
    {
        Guid Id { get; set; }
        string Name { get; set; }

        List<IItem> Inventory { get; set; }

        ConsoleColor? UniformColor { get; set; }

        string GemStone { get; set; }

        int HP { get; set; }
        int Weight { get; set; }
        int DepthDived { get; set; }

        void Update(WaterPressure pressure);
    }
}