using System;
using System.Configuration;

namespace HomeWork1.LogUtility
{
    public class LogService
    {
        /// <summary>
        /// Путь общей папки для хранения логов
        /// </summary>
        public static string generalPath = ConfigurationManager.AppSettings["LogFolderPath"];

        /// <summary>
        /// Получить путь папки
        /// </summary>
        public static string GetActualPath() => $@"{generalPath}/{DateTime.Now:yyyy-MM-dd}";
    }
}
