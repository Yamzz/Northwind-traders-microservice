using NLog;
using Northwind.Traders.Employees.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Traders.Employees.Api.Logging
{
    public class NLogManager : INLogManager
    {
        private ILogger logger;

        public NLogManager()
        {
            StackTrace trace = new StackTrace();

            if (trace.FrameCount > 1)
            {
                logger = LogManager.GetLogger(trace.GetFrame(1).GetMethod().ReflectedType.FullName);
            }
            else //This would go back to the stated problem
            {
                logger = LogManager.GetCurrentClassLogger();
            }
        }

        public void Debug(string message, params object[] args)
        {
            if (logger.IsDebugEnabled)
            {
                Write(LogLevel.Debug, message, args);
            }
        }

        public void Info(string message, params object[] args)
        {
            if (logger.IsInfoEnabled)
            {
                Write(LogLevel.Info, message, args);
            }
        }

        public void Warn(string message, params object[] args)
        {
            if (logger.IsWarnEnabled)
            {
                Write(LogLevel.Warn, message);
            }
        }

        public void Warn(string message, Exception exception, params object[] args)
        {
            if (logger.IsWarnEnabled)
            {
                WriteWithEx(LogLevel.Warn, message, exception);
            }
        }

        public void Error(string message)
        {
            if (logger.IsErrorEnabled)
            {
                Write(LogLevel.Error, message);
            }
        }

        public void Error(string message, Exception exception, params object[] args)
        {
            if (logger.IsErrorEnabled)
            {
                WriteWithEx(LogLevel.Error, message, exception);
            }
        }

        public void Fatal(string message)
        {
            if (logger.IsFatalEnabled)
            {
                Write(LogLevel.Fatal, message);
            }
        }

        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (logger.IsFatalEnabled)
            {
                WriteWithEx(LogLevel.Fatal, message, exception);
            }
        }

  
        /// <summary>
        /// These two method are used to retain the ${callsite} for all the Nlog method  
        /// </summary>
        /// <param name="level">LogLevel.</param>
        ///  <param name="format">Passed message.</param>
        ///  <param name="ex">Exception.</param>
        private void Write(LogLevel level, string message, params object[] args)
        {
            LogEventInfo le = new LogEventInfo(level, logger.Name, null, message, args);
            logger.Log(typeof(NLogManager), le);
        }

        private void WriteWithEx(LogLevel level, string message, Exception ex, params object[] args)
        {
            LogEventInfo le = new LogEventInfo(level, logger.Name, null, message, args);
            le.Exception = ex;
            logger.Log(typeof(NLogManager), le);
        }
    }
}
