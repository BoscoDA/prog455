using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Counter
    {
        private static Counter? instance;
        private static int count;
        private Counter() { }

        private static Counter Instance()
        {
            if (instance == null)
            {
                instance = new Counter();
                count = 0;
            }

            return instance;
        }

        public int GetCount()
        {
            return count++;
        }

        public static Counter GetInstance => Instance();
    }
}
