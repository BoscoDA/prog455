using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6CrashCourse.Base;
using Week6CrashCourse.Interface;

namespace Week6CrashCourse.Models
{
    public class Bear : AnimalBase, IMammal
    {
        public Bear(string name, int age, string species) : base(name, age, species)
        {

        }

        public override string PerformTrick()
        {
            return $"{Name} rides a tricycle around the stage!";
        }
    }
}
