using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6CrashCourse.Base;
using Week6CrashCourse.Interface;

namespace Week6CrashCourse.Models
{
    internal class Circus
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

        public void CircusShow()
        {
            Console.WriteLine("Welcome to the circus, the show will now start...\n");

            foreach (var performer in performers)
            {
                Console.WriteLine("Introducing...\n");
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

                Console.WriteLine("Press any key for next performer...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        public void PrintPerformersWithoutAnimalBase()
        {
            Console.WriteLine("Here are the types of the performers that do not implement the AnimalBase Class");
            List<IMammal> performera2 = performers.Where(a => a.GetType().BaseType != typeof(AnimalBase)).ToList();
            foreach (var performer in performera2)
            {
                Console.WriteLine(performer.GetType().ToString());
            }
        }
    }
}
