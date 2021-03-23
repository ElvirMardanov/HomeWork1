using System;
using System.Collections.Generic;

namespace HomeWork1
{
    /// <summary>
    /// Реализация логирования системы
    /// </summary>
    class Log : ILog
    {
        public void Debug(string message)
        {
            LogWriter.WriteLog(message, LogLevel.Debug);
        }

        public void Debug(string message, Exception e)
        {
            LogWriter.WriteLog(message, LogLevel.Debug, e);
        }

        public void DebugFormat(string message, params object[] args)
        {
            LogWriter.WriteLog(message, LogLevel.DebugFormat, args);
        }

        public void Error(string message)
        {
            LogWriter.WriteLog(message, LogLevel.Error);
        }

        public void Error(string message, Exception e)
        {
            LogWriter.WriteLog(message, LogLevel.Error, e);
        }

        public void Error(Exception ex)
        {
            LogWriter.WriteLog("ex", LogLevel.Error);
        }

        public void ErrorUnique(string message, Exception e)
        {
            LogWriter.WriteLogUnique(message, LogLevel.Error, e);
        }

        public void Fatal(string message)
        {
            LogWriter.WriteLog(message, LogLevel.Fatal);
        }

        public void Fatal(string message, Exception e)
        {
            LogWriter.WriteLog(message, LogLevel.Fatal, e);
        }

        public void Info(string message)
        {
            LogWriter.WriteLog(message, LogLevel.Info);
        }

        public void Info(string message, Exception e)
        {
            LogWriter.WriteLog(message, LogLevel.Info, e);
        }

        public void Info(string message, params object[] args)
        {
            LogWriter.WriteLog(message, LogLevel.Info, args);
        }

        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            LogWriter.WriteLog(message, LogLevel.Info, properties);
        }

        public void Warning(string message)
        {
            LogWriter.WriteLog(message, LogLevel.Warning);
        }

        public void Warning(string message, Exception e)
        {
            LogWriter.WriteLog(message, LogLevel.Warning, e);
        }

        public void WarningUnique(string message)
        {
            LogWriter.WriteLogUnique(message, LogLevel.Warning);
        }
    }
}
