using System;
using System.Collections.Generic;
using System.Reflection;
using Common.Logging;

namespace SchedulerService.Service.Log
{
    public class LogInfo
    {
        public LogLevel LogLevel = LogLevel.Error;
        public string ModuleName;
        public string MethodName;
        public string FileName;
        public int? LineNumber;
        public string Message;
        public int? TraceID;
        public int? ApplicationID;
        public int? ChannelID;
        public LogInfo(LogLevel logLevel)
        {
            this.LogLevel = logLevel;
        }
        public List<LogProperty> Values()
        {
            List<LogProperty> list = new List<LogProperty>();
            Type type = base.GetType();
            FieldInfo[] fields = type.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo fieldInfo = fields[i];
                LogProperty logProperty = new LogProperty();
                logProperty.Name = fieldInfo.Name;
                logProperty.Value = fieldInfo.GetValue(this);
                object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(Serialize), false);
                if (customAttributes.Length > 0)
                {
                    logProperty.Serialize = true;
                }
                else
                {
                    logProperty.Serialize = false;
                }
                list.Add(logProperty);
            }
            return list;
        }
    }
}