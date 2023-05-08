using Logger.Chain_of_Responsibility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Code taken from example provided in PROG 455 Spring 2023
 * All code was based off of code created by Leo Hazou
 */
namespace Logger
{
    public class DBLogger
    {
        private static DBLogger _instance;
        private static InfoLogger info = new InfoLogger();
        private static ErrorLogger error = new ErrorLogger();
        private static WarningLogger warning = new WarningLogger();

        /// <summary>
        /// Gets singleton instance of the class
        /// </summary>
        /// <returns></returns>
        public static DBLogger Instance() 
        {
            if(_instance == null)
            {
                _instance = new DBLogger();
                info = new InfoLogger();
                error = new ErrorLogger();
                warning = new WarningLogger();
                info.SetNextLogger(warning);
                warning.SetNextLogger(error);
            }
            return _instance;
        }

        /// <summary>
        /// Initiates the chain of responsiblity for logging to the database
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void Log(string level, string message, Exception? ex = null)
        {
            info.Log(level, message, ex);
        }
    }
}
