using System;
using NLog;

namespace Logger
{
    public class ErrorLogger
    {
        private static NLog.Logger logger;

        static ErrorLogger()
        {
            logger = LogManager.GetLogger("dblogger");
        }

        public static void Error(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Debug(Exception ex, string message)
        {
            logger.Debug(ex,message);
        }
    }
}
