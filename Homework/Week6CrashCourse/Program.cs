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
            List<IMammal> performers = new List<IMammal>()
            {
                new BigCats("Leo", 6, "Lion"),
                new Bear("Jerry", 10, "Black Bear"),
                new Clown("Stan", 25),

                new BigCats("Jasper", 4, "Leopard"),
                new Bear("Chris", 6, "Brown Bear"),
                new Clown("Jim", 35),

                new BigCats("Gary", 8, "Tiger"),
                new Bear("Phil", 10, "Polar Bear"),
                new Clown("Sharon", 27)
            };

            foreach (var performer in performers)
            {
                Console.WriteLine("Introducing...");
                if (performer.GetType().BaseType == typeof(AnimalBase))
                {
                    Console.WriteLine(((AnimalBase)performer).GetInfo());
                    Console.WriteLine(performer.PerformTrick() + "\n");
                }
                else if (performer.GetType() == typeof(Clown))
                {
                    Console.WriteLine(((Clown)performer).GetInfo());
                    Console.WriteLine(performer.PerformTrick() + "\n");
                }

            }

            List<IMammal> performera2 = performers.Where(a => a.GetType().BaseType != typeof(AnimalBase)).ToList();
            foreach (var performer in performera2)
            {
                Console.WriteLine(performer.GetType().ToString());
            }

            Console.ReadKey();
        }
    }
}