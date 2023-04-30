﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingExample
{
    internal class LoggerLevel
    {
        public sealed class ErrorLevel
        {
            public const string Error = "Error";
            public const string Warning = "Warning";
            //compile time (favor this)
            public const string Information = "Info";
            // difference between public const string and static readonly string is public const string will not communicate well between different assemblies, static readonly string will

            //run time
            //static readonly string Test = "";
        }
    }
}