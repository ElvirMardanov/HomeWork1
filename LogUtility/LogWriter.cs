using System;
using System.Configuration;
using System.IO;

namespace HomeWork1
{
    public class LogWriter
    {
        private static string generalPath = ConfigurationManager.AppSettings["LogFolderPath"]; 

        public static void WriteLog(string message, string levelName)
        {
            var path = GetActualPath();
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
            var path = GetActualPath();
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
        /// Получить путь папки
        /// </summary>
        private static string GetActualPath() => $@"{generalPath}/{DateTime.Now:yyyy-MM-dd}";

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
        /// 
        /// </summary>
        private static string GetLogText(string message, string level) =>
            $"{DateTime.Now} ({level}): {message}";
    }
}
