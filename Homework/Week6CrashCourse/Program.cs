using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Week6CrashCourse.Base;
using Week6CrashCourse.Interface;
using Week6CrashCourse.Models;

namespace Week6CrashCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circus circus = new Circus();

            circus.CircusShow();
            circus.PrintPerformersWithoutAnimalBase();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}