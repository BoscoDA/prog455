using LoggingExample;

//DB notes: can use id and use newid() to generate the id, use getdate() to get the date


//List to hold my loggers
List<ILogger> loggers;
LoggerDemo logDemo;

//Log to the database using custom implementation
ILogger dBlogger = new DbLogger();
loggers = new List<ILogger>();
loggers.Add(dBlogger);
logDemo = new LoggerDemo(loggers);
logDemo.SimulateLogging();



//Log to a file using NLog implementation
ILogger fileLogger = new FileLogger();
loggers = new List<ILogger>();
loggers.Add(fileLogger);
logDemo = new LoggerDemo(loggers);
logDemo.SimulateLogging();


//Log to both at the same time
loggers = new List<ILogger>();
loggers.Add(dBlogger);
loggers.Add(fileLogger);
logDemo = new LoggerDemo(loggers);
logDemo.SimulateLogging();


