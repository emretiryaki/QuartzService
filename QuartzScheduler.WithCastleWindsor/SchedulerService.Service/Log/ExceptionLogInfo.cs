using System;
using Common.Logging;

namespace SchedulerService.Service.Log
{
    public class ExceptionLogInfo : LogInfo
    {
        public Exception Exception;
        public ExceptionLogInfo(LogLevel logLevel = LogLevel.Error)
            : base(logLevel)
        {
        }
    }

    public enum LogLevel
    {
        Debug,
        Trace,
        Warning,
        Error
    }
}