using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingExample
{
    internal class LoggerDemo
    {
        private List<ILogger> _loggers;
        public LoggerDemo(List<ILogger> loggers)
        {
            _loggers = loggers;   
        }

        public void SimulateLogging()
        {
            _loggers.ForEach(l => l.LogInfo($"Started executing of Logger Simulator"));

            try
            {
                int i = 1;
                int j = 1;
                while (true)
                {
                    Console.WriteLine($"{i / j--}");
                    _loggers.ForEach(l => l.LogWarning("Possibility of Division by zero"));
                }
            }
            catch (Exception ex)
            {
                //at lower levels throw the execption back up to this point
                _loggers.ForEach(l => l.LogError("Error occured in method SimulateError().", ex));
            }

            _loggers.ForEach(l => l.LogInfo("Ended execution of Logger Simulator"));
        }
    }
}
