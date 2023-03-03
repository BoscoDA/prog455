using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6CrashCourse.Interface
{
    internal interface IMammal
    {
        //2 Properties
        //PerformTrick Method
        string Name { get; set; }
        int Age { get; set; }

        string PerformTrick();
    }
}
