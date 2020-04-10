using System;
using System.Collections.Generic;

namespace NN_Backpropagation.Classes
{
    static public class Utilities
    {
        // Преобразование строки Дня Рождения в формат DateTime
        public static DateTime UserStringToDateTime(string userString)
        {
            string[] args = userString.Split('.');
            if (args.Length == 3)
            {
                return new DateTime(Convert.ToInt32(args[2]), Convert.ToInt32(args[1]), Convert.ToInt32(args[0]));
            }
            return DateTime.MinValue;
        }

        // Нормализация одного значения
        public static double Normalize(double value, double inputLow, double inputHigh, double outputLow = 0.0, double outputHigh = 1.0)
        {
            return (value - inputLow) * (outputHigh - outputLow) / (inputHigh - inputLow) + outputLow;
        }

        // Денормализация одного значения
        public static double Denormalize(double value, double outputLow, double outputHigh, double inputLow = 0.0, double inputHigh = 1.0)
        {
            return ((outputLow - outputHigh) * value - inputHigh * outputLow + outputHigh * inputLow) / (inputLow - inputHigh);
        }
        
        // Форматирование данных с удалением первых столбцов и возможностью удаления заголовка
        public static void FormatData(ref List<List<string>> data, bool head, int deleteFirstCols)
        {
            if (head)
            {
                data.RemoveAt(0);
            }

            for (int i = 0; i < data.Count; i++)
            {
                data[i].RemoveRange(0, deleteFirstCols);
            }
        }
    }
}
