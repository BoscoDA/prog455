using Week10DesignPatternII.Decorators;

namespace Week10DesignPatternII
{
    public interface ICharacter
    {
        string Name { get; set; }

        List<IItem> Inventory { get; set; }

        ConsoleColor? UniformColor { get; set; }

        Gem? GemStone { get; set; }
    }
}