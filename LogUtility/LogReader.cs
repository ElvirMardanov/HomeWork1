using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    public class LogReader
    {
        /// <summary>
        /// Проверка уникальности лога по файлу лога
        /// </summary>
        public static bool isUniqueLog(string path, string message)
        {
            if (!File.Exists(path))
            {
                return !File.ReadLines(path)
                    .Any(line => line.Contains(message));
            }

            return true;
        }
    }
}
