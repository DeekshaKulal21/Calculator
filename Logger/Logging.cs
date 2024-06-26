/********************************************************************************************
 * Project Name - Calculator
 * Description  - Logger for Logging the messages into a text file
 *  
 **************
 * Version Log
 **************
 * Version       Date           Modified By          Remarks          
 *********************************************************************************************
 *0 .0.0        26-Jul-2024     Deeksha Kulal        Created.
 **********************************************************************************************/
using System;
using System.IO;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Logger
{
    public class Logging
    {
        private readonly log4net.ILog logger;
        private static bool configured = false;

        /// <summary>
        /// Not used
        /// </summary>
        public enum LogLevel
        {
            /// <summary>
            /// DEBUG = The lowest level of logging - Basically debug message from the program
            /// </summary>   
            DEBUG,
            /// <summary>
            /// INFO = The 1st level of logging - Informational messages
            /// </summary>  
            INFO,
            /// <summary>
            /// WARN = The 2nd level of logging - Warning messages
            /// </summary>  
            WARN,
            /// <summary>
            /// ERROR = The 3rd level of logging - Error messages
            /// </summary>  
            ERROR,
            /// <summary>
            /// FATAL = The higher level of logging - Exceptions
            /// </summary>  
            FATAL
        }

        /// <summary>
        /// To specify our own appender
        /// </summary>        
        public Logging(Type methodName)
        {
            SetupLogger();
            logger = log4net.LogManager.GetLogger(methodName);
        }

        /// <summary>
        /// Logs the message at the debug level 
        /// </summary>        
        public void Debug(object message)
        {
            Console.WriteLine(message);
            logger.Debug(message);
        }

        /// <summary>
        /// Logs the message at the information level 
        /// </summary>        
        public void Info(object message)
        {
            Console.WriteLine(message);
            logger.Info(message);
        }

        /// <summary>
        /// Logs the message at the warning level 
        /// </summary> 
        public void Warn(object message)
        {
            Console.WriteLine(message);
            logger.Warn(message);
        }

        /// <summary>
        /// Logs the message at the error level with exception
        /// </summary> 
        public void Error(object message, Exception exception)
        {
            Console.WriteLine(message);
            logger.Error(message, exception);
        }

        /// <summary>
        /// Logs the message at the error level 
        /// </summary> 
        public void Error(object message)
        {
            Console.WriteLine(message);
            logger.Error(message);
        }

        /// <summary>
        /// Logs the message at the fatal level 
        /// </summary> 
        public void Fatal(object message)
        {
            Console.WriteLine(message);
            logger.Fatal(message);
        }

        /// <summary>
        /// SetupLogger
        /// </summary>
        private void SetupLogger()
        {
            if (configured == false)
            {
                string assemblyFolder = "";
                try
                {
                    assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }
                catch (Exception)
                {
                }
                string log4NetConfigFile = Path.Combine(assemblyFolder, "LoggerSettings.config");
                log4net.Config.XmlConfigurator.Configure(new FileInfo(log4NetConfigFile));
                configured = true;
            }
        }
    }
}
