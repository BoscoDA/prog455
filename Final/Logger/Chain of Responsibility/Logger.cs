using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Chain_of_Responsibility
{
    public abstract class Logger
    {
        protected string _sqlConnString = string.Empty;
        protected DatabaseConnectionSingleton? connectionSingleton;

        protected Logger? nextLogger { get; set; }
        /// <summary>
        /// Processes requests specific type and passes anyother request to the next receiver.
        /// </summary>
        /// <param name="level"></param>
        public abstract void Log(string level, string message, Exception? ex);

        /// <summary>
        /// Sets the what the next receiver in the chain will be.
        /// </summary>
        /// <param name="receiver"></param>
        public void SetNextLogger(Logger logger)
        {
            this.nextLogger = logger;
        }
    }
}
