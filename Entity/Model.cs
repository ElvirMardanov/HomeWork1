using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    public class Model
    {
        public string Name { get; set; } = "Default";
        public int Age { get; set; }
        public int Weight { get; set; }

        /// <summary>
        /// Генерация возраста
        /// </summary>
        public void GenerateRandonAge()
        {
            Random random = new Random();
            Age = random.Next(0, 100);
        }

        /// <summary>
        /// Генерация веса
        /// </summary>
        public void GenerateRandomWeight()
        {
            Random random = new Random();
            Weight = random.Next(0, 100);
        }
    }
}
