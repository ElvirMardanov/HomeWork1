using HomeWork1.LogUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace HomeWork1
{
    public class LogWriter
    {
        public static void WriteLog(string message, string levelName)
        {
            var path = LogService.GetActualPath();
            CreateFolder(path);

            string filePath = Path.Combine(path, GetFileExtensionName(levelName));
            CreateFile(filePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append: true))
                {                
                    sw.WriteLine(GetLogText(message, levelName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteLog(string message, string levelName, Exception e)
        {
            var path = LogService.GetActualPath();
            CreateFolder(path);

            string filePath = Path.Combine(path, GetFileExtensionName(levelName));
            CreateFile(filePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append: true))
                {
                    sw.WriteLine(GetLogText(message, levelName));
                    sw.WriteLine(e.Message);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteLog(string message, string levelName, params object[] args)
        {
            var path = LogService.GetActualPath();
            CreateFolder(path);

            string filePath = Path.Combine(path, GetFileExtensionName(levelName));
            CreateFile(filePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append: true))
                {
                    sw.WriteLine(GetLogText(message, levelName));
                    sw.WriteLine("Log args: " + string.Join(", ", args));
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteLog(string message, string levelName, Dictionary<object, object> properties)
        {
            var path = LogService.GetActualPath();
            CreateFolder(path);

            string filePath = Path.Combine(path, GetFileExtensionName(levelName));
            CreateFile(filePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append: true))
                {
                    sw.WriteLine(GetLogText(message, levelName));
                    sw.WriteLine("Log properties: " + string.Join(", ", properties.Select(pair => $"{pair.Value}")));
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteLogUnique(string message, string levelName)
        {
            var path = LogService.GetActualPath();
            CreateFolder(path);

            string filePath = Path.Combine(path, GetFileExtensionName(levelName));
            var fullMessage = GetLogText(message, levelName);

            if (LogReader.isUniqueLog(filePath, fullMessage))
            {
                CreateFile(filePath);
                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath, append: true))
                    {
                        sw.WriteLine(fullMessage);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void WriteLogUnique(string message, string levelName, Exception e)
        {
            var path = LogService.GetActualPath();
            CreateFolder(path);

            string filePath = Path.Combine(path, GetFileExtensionName(levelName));
            var fullMessage = GetLogText(message, levelName);

            if (LogReader.isUniqueLog(filePath, fullMessage))
            {
                CreateFile(filePath);
                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath, append: true))
                    {
                        sw.WriteLine(fullMessage);
                        sw.WriteLine(e.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Создать конечную папку
        /// </summary>
        /// <returns></returns>
        private static void CreateFolder(string path)
        {       
            DirectoryInfo dirInfoDate = new DirectoryInfo(path);

            if (!dirInfoDate.Exists)
            {
                dirInfoDate.Create();
            }

        }

        /// <summary>
        /// Создать файл логов
        /// </summary>
        private static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        /// <summary>
        /// Получить название файла с расширением
        /// </summary>
        private static string GetFileExtensionName(string levelName) =>
            levelName + ConfigurationManager.AppSettings["LogExtension"];

        /// <summary>
        /// Получить текст для записи в лог
        /// </summary>
        private static string GetLogText(string message, string level) =>
            $"{DateTime.Now} ({level}): {message}";
    }
}
