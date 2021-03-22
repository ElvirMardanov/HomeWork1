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
            throw new NotImplementedException();
        }

        public void Debug(string message, Exception e)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(string message, params object[] args)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void ErrorUnique(string message, Exception e)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            LogWriter.WriteLog(message, LogLevel.Fatal);
        }

        public void Fatal(string message, Exception e)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            LogWriter.WriteLog(message, LogLevel.Info);
        }

        public void Info(string message, Exception e)
        {
            throw new NotImplementedException();
        }

        public void Info(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message, Exception e)
        {
            throw new NotImplementedException();
        }

        public void WarningUnique(string message)
        {
            throw new NotImplementedException();
        }
    }
}
