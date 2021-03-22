using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {     
        static void Main(string[] args)
        {
            var defaultModel = new Model();
            var logger = new Log();

            defaultModel.GenerateRandonAge();
            logger.Info($"Автогенерация возраста = {defaultModel.Age}");

            defaultModel.GenerateRandomWeight();
            logger.Info($"Автогенерация веса = {defaultModel.Weight}");

            try
            {
                var test = defaultModel.Age / defaultModel.Weight;
            }
            catch (Exception e)
            {
                logger.Error("Масса не может быть = 0", e);
            }
        }
    }
}
