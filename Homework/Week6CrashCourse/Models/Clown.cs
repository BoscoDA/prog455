using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6CrashCourse.Base;
using Week6CrashCourse.Interface;

namespace Week6CrashCourse.Models
{
    public class Clown : IMammal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Clown(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string GetInfo()
        {
            return $"{Name} the clown that is {Age} years old.";
        }

        public string PerformTrick()
        {
            return $"{Name} squirts water out of a flower into the Ringmasters face and makes the whole crowd laugh.";
        }
    }
}
