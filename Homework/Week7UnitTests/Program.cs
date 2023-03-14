using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7UnitTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilities util = new Utilities();
            var temp = util.IsPrime(0);

            Console.ReadKey();
        }
    }
}
