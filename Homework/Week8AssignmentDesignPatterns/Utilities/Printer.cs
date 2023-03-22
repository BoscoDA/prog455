using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns.Utilities
{
    public static class Printer
    {
        /// <summary>
        /// Method for printing all information to the console.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="color"></param>
        public static void Print(string output, ConsoleColor color)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(output);

            Console.ForegroundColor = previousColor;
        }

        public static void WaitForInput(string message)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write(message);

            Console.ReadKey();

            Console.ForegroundColor = previousColor;
        }
    }
}
