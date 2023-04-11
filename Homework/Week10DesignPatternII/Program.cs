namespace Week10DesignPatternII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character();
            Character cpu = new Character();

            Game<Character, Character> game = new Game<Character, Character>();
            game.Start(player, cpu);

            Console.ReadKey();
        }
    }
}