using System;
using System.Collections.Generic;
using System.IO;

namespace NN_Backpropagation.Classes
{
    class FileRR
    {
        public string Name { get; set; }  // Имя файла
        public int Id { get; set; }       // Id, который связывает ребенка и файл
        public int Length { get; set; }   // Количество значений

        public int MinCount { get; set; }      // Минимальное возможное кол-во вхождений в диапозон
        public int MaxCount { get; set; }      // Максимальное возможное кол-во вхождений в диапозон
        public int MinValue { get; set; }      // Минимальное значение
        public int MaxValue { get; set; }      // Максимальное значение

        public int[] values = null;                         // Интервалы между сокращениями (мс)
        public int[] ranges = new int[Global.CountRanges];  // Количество вхождений в каждый диапазон

        public FileRR(string filePath, bool isFirstReaded = false)
        {
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                FileInfo fileInfo = new FileInfo(filePath);

                Name = fileInfo.Name;
                Id = int.Parse(fileInfo.Name.Remove(Name.IndexOf(".")));
                Length = File.ReadAllLines(filePath).Length - Convert.ToInt32(!isFirstReaded);

                values = new int[Length];

                MinCount = 0;
                MaxCount = Length;

                if (!isFirstReaded)
                {
                    sr.ReadLine();
                }
                for (int i = 0; i < Length; i++)
                {
                    values[i] = int.Parse(sr.ReadLine());
                }
            }
        }

        // Поиск макс. и мин. значения внутри файла
        private void FindMinMaxValue()
        {
            MinValue = MaxValue = values[0];
            for (int i = 0; i < Length; i++)
            {
                if (MinValue > values[i])
                {
                    MinValue = values[i];
                }
                if (MaxValue < values[i])
                {
                    MaxValue = values[i];
                }
            }
        }

        // Заполняет массив вхождениями в диапазоны
        public void CreateRanges()
        {
            int index = 0;
            FindMinMaxValue();
            for (int i = 0; i < Length; i++)
            {
                index = (int)Math.Floor(((double)values[i] - MinValue) * Global.CountRanges / (MaxValue - MinValue));
                if (index == Global.CountRanges)
                {
                    index--;
                }
                ranges[index]++;
            }
        }
    }
}
