using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns
{
    public class GameTimer
    {
        private static GameTimer instance;
        private static Stopwatch timer;
        private static object locker = new object();

        private static GameTimer Instance()
        {
            if(instance == null)
            {
                lock (locker)
                {
                    if(instance == null)
                    {
                        instance = new GameTimer();
                        timer = new Stopwatch();
                    }
                }
                
            }

            return instance;
        }

        public static GameTimer GetInstance => Instance();

        public void StartTimer()
        {
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        public TimeSpan GetTime()
        {
            return timer.Elapsed;
        }
    }
}
