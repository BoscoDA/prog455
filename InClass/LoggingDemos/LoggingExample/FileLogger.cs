using NLog.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingExample
{
    internal class FileLogger : ILogger
    {
        private Logger _fileLogger;

        public FileLogger()
        {
            CreateLogger();
        }
        public void LogError(string message, Exception ex)
        {
            _fileLogger.Error(ex, message);
        }

        public void LogInfo(string message)
        {
            _fileLogger.Info(message);
        }

        public void LogWarning(string message)
        {
            _fileLogger.Warn(message);
        }

        private void CreateLogger()
        {
            var config = new LoggingConfiguration();
            var logfile = new FileTarget("logfile") { FileName = "log.txt"};
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            LogManager.Configuration = config;
            _fileLogger = LogManager.GetCurrentClassLogger();
        }
    }
}
