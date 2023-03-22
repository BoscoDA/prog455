using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
