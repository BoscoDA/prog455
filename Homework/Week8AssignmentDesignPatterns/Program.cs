using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models;

namespace Week8AssignmentDesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExecptionTrapper;
            Game game = new Game();
            game.Start();
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
