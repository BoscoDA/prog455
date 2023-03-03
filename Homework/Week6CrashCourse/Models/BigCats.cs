using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6CrashCourse.Base;

namespace Week6CrashCourse.Models
{
    public class BigCats : AnimalBase
    {
        public BigCats(string name, int age, string species) : base(name, age, species)
        {

        }

        public override string PerformTrick()
        {
            return $"{Name} jumps through a hoop and wows the crowd!";
        }
    }
}
