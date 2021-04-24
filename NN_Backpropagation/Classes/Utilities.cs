using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NN_Backpropagation.Classes
{
    static public class Utilities
    {
        /// <summary>
        ///   Нормализация одного значения
        /// </summary>
        /// <param name = "value">Значение для нормализации</param>
        /// <param name = "inputLow">Нижнее значение текущего интервала</param>
        /// <param name = "inputHigh">Верхнее значение текущего интервала</param>
        /// <param name = "outputLow">Нижнее значение ожидаемого интервала</param>
        /// <param name = "outputHigh">Верхнее значение ожидаемого интервала</param>
        public static double Normalize(double value, double inputLow, double inputHigh, double outputLow = 0.0, double outputHigh = 1.0)
        {
            return (value - inputLow) * (outputHigh - outputLow) / (inputHigh - inputLow) + outputLow;
        }

        /// <summary>
        ///   Нормализация массива значений
        /// </summary>
        /// <param name = "values">Массив для нормализации</param>
        /// <param name = "inputLow">Массив из нижних значений текущих интервалов</param>
        /// <param name = "inputHigh">Массив из верхних значение текущих интервалов</param>
        /// <param name = "outputLow">Нижнее значение ожидаемого интервала</param>
        /// <param name = "outputHigh">Верхнее значение ожидаемого интервала</param>
        public static double[] NormalizeArray(double[] values, double[] inputLow, double[] inputHigh, double outputLow = 0.0, double outputHigh = 1.0)
        {
            double[] arr = new double[values.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Normalize(values[i], inputLow[i], inputHigh[i], outputLow, outputHigh);
            }
            return arr;
        }

        /// <summary>
        ///   Денормализация одного значения
        /// </summary>
        /// <param name = "value">Значение для денормализации</param>
        /// <param name = "outputLow">Нижнее значение текущего интервала</param>
        /// <param name = "outputHigh">Верхнее значение текущего интервал</param>
        /// <param name = "inputLow">Нижнее значение ожидаемого интервала</param>
        /// <param name = "inputHigh">Верхнее значение ожидаемого интервала</param>
        public static double Denormalize(double value, double outputLow, double outputHigh, double inputLow = 0.0, double inputHigh = 1.0)
        {
            return ((outputLow - outputHigh) * value - inputHigh * outputLow + outputHigh * inputLow) / (inputLow - inputHigh);
        }

        /// <summary>
        ///   Денормализация массива значений
        /// </summary>
        /// <param name = "values">Массив для денормализации</param>
        /// <param name = "outputLow">Массив из нижних значений текущих интервалов</param>
        /// <param name = "outputHigh">Массив из верхних значений текущих интервалов</param>
        /// <param name = "inputLow">Нижнее значение ожидаемого интервала</param>
        /// <param name = "inputHigh">Верхнее значение ожидаемого интервала</param>
        public static double[] DenormalizeArray(double[] values, double[] outputLow, double[] outputHigh, double inputLow = 0.0, double inputHigh = 1.0)
        {
            double[] arr = new double[values.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Denormalize(values[i], outputLow[i], outputHigh[i], inputLow, inputHigh);
            }
            return arr;
        }

        /// <summary>
        ///   Поиск минимальных значений во всех колонках
        /// </summary>
        /// <param name = "data">Набор данных для поиска</param>
        /// <param name = "size">Количество столбцов</param>
        /// <param name = "from">Номер столбца, с которого начать поиск</param>
        public static double[] MinValuesArray(List<List<double>> data, int size, int from)
        {
            try
            {
                double[] minValues = new double[size];
                for (int i = 0; i < size; i++)
                {
                    minValues[i] = MinValueColumn(data, i + from);
                }
                return minValues;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        ///   Поиск максимальных значений во всех колонках
        /// </summary>
        /// <param name = "data">Набор данных для поиска</param>
        /// <param name = "size">Количество столбцов</param>
        /// <param name = "from">Номер столбца, с которого начать поиск</param>
        public static double[] MaxValuesArray(List<List<double>> data, int size, int from)
        {
            try
            {
                double[] maxValues = new double[size];
                for (int i = 0; i < size; i++)
                {
                    maxValues[i] = MaxValueColumn(data, i + from);
                }
                return maxValues;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        ///   Поиск минимального значения в i-ой колонке
        /// </summary>
        /// <param name = "data">Набор данных для поиска</param>
        /// <param name = "index">Номер столбца для поиска</param>
        private static double MinValueColumn(List<List<double>> data, int index)
        {
            try
            {
                double min = data[0][index];
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i][index] < min)
                    {
                        min = data[i][index];
                    }
                }
                return min;
            }
            catch (Exception error)
            {
                throw new Exception("Error: can't find min value!", error);
            }
        }

        /// <summary>
        ///   Поиск максимального значения в i-ой колонке
        /// </summary>
        /// <param name = "data">Набор данных для поиска</param>
        /// <param name = "index">Номер столбца для поиска</param>
        private static double MaxValueColumn(List<List<double>> data, int index)
        {
            try
            {
                double max = data[0][index];
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i][index] > max)
                    {
                        max = data[i][index];
                    }
                }
                return max;
            }
            catch (Exception error)
            {
                throw new Exception("Error: can't find max value!", error);
            }
        }

        /// <summary>
        ///   Форматирование данных
        /// </summary>
        /// <param name = "data">Набор данных для форматирования</param>
        /// <param name = "head">True, если имеется заголовок</param>
        /// <param name = "from">Номер позиции, с которой происходит удаление столбцов</param>
        /// <param name = "count">Количество для удаления столбцов</param>
        public static void FormatData(ref List<List<string>> data, bool head, int from = 0, int count = 0)
        {
            if (head)
            {
                data.RemoveAt(0);
            }

            if (count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    data[i].RemoveRange(from, count);
                }
            }
        }

        /// <summary>
        ///   Перевод набора данных из string в double
        /// </summary>
        /// <param name = "data">Набор данных для конвертирования</param>
        public static List<List<double>> DataStringToDouble(List<List<string>> data) {
            List<List<double>> doubleData = data.Select(x => x.Select(y => double.Parse(y)).ToList()).ToList();
            return doubleData;
        }

        /// <summary>
        ///   Создание массива с конфигурацией нейронной сети
        /// </summary>
        public static int[] CreateConfigArray()
        {
            int[] sizes = null;

            string[] words = Global.ConfigLayers.Split(' ');
            int sizeConfig = 2; // 2 - Входной и выходной слой
            if (Global.ConfigLayers != "")
            {
                sizeConfig += words.Length;
            }

            sizes = new int[sizeConfig];
            sizes[0] = Global.InputSize;
            if (Global.ConfigLayers != "")
            {
                for (int i = 0; i < words.Length; i++)
                {
                    sizes[i + 1] = int.Parse(words[i]);
                }
            }
            sizes[sizeConfig - 1] = Global.OutputSize;

            return sizes;
        }

        /// <summary>
        ///   Генерирует нормально распределённые числа
        /// </summary>
        /// <param name="rand"></param>
        /// <param name = "mu">Математическое ожидание</param>
        /// <param name = "sigma">Среднеквадратичное отклонение</param>
        public static double NextGaussian(this Random r, double mu = 0, double sigma = 1)
        {
            var a = 1.0 - r.NextDouble();
            var b = 1.0 - r.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(a)) *
                                Math.Sin(2.0 * Math.PI * b);

            var rand_normal = mu + sigma * rand_std_normal;

            return rand_normal;
        }
    }
}
