using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10DesignPatternII.Utilities
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
            Console.ForegroundColor = color;

            Console.Write(output);

            Console.ResetColor();
        }

        /// <summary>
        /// Method for printing a message prompting a need for input to progress
        /// </summary>
        /// <param name="message"></param>
        public static void WaitForInput(string message)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write(message);

            Console.ReadKey();

            Console.ForegroundColor = previousColor;
        }
    }
}
