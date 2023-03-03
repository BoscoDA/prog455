using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6CrashCourse.Interface;

namespace Week6CrashCourse.Base
{
    public abstract class AnimalBase : IMammal
    {
        // atleast one method 
        // atleast one constructor

        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }


        public AnimalBase(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
        }

        public virtual string GetInfo()
        {
            return $"{Name} the {Species} who is {Age} years old.";
        }

        public virtual string PerformTrick()
        {
            return $"{Name} does a trick!";
        }
    }
}
