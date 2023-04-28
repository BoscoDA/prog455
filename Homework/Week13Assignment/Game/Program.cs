using Week10DesignPatternII.Models;
using Week10DesignPatternII;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character();
            Character cpu = new Character();

            Game<Character, Character> game = new Game<Character, Character>();
            game.Start(player, cpu);
        }

        //Exception handler taken from here: https://stackoverflow.com/questions/3133199/net-global-exception-handler-in-console-application
        static void UnhandledExecptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}