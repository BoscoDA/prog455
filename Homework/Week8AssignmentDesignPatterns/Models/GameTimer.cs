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

        /// <summary>
        /// Returns the singleton instance of the object
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void StartTimer()
        {
            timer.Start();
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void StopTimer()
        {
            timer.Stop();
        }

        /// <summary>
        /// Returns the elapsed time as a timespan
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTime()
        {
            return timer.Elapsed;
        }
    }
}
