using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

        // Нормализация массива значений
        public static double[] NormalizeArray(double[] values, double[] inputLow, double[] inputHigh, double outputLow = 0.0, double outputHigh = 1.0)
        {
            double[] arr = new double[values.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Normalize(values[i], inputLow[i], inputHigh[i], outputLow, outputHigh);
            }
            return arr;
        }

        // Денормализация одного значения
        public static double Denormalize(double value, double outputLow, double outputHigh, double inputLow = 0.0, double inputHigh = 1.0)
        {
            return ((outputLow - outputHigh) * value - inputHigh * outputLow + outputHigh * inputLow) / (inputLow - inputHigh);
        }

        // Денормализация массива значений
        public static double[] DenormalizeArray(double[] values, double[] outputLow, double[] outputHigh, double inputLow = 0.0, double inputHigh = 1.0)
        {
            double[] arr = new double[values.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Denormalize(values[i], outputLow[i], outputHigh[i], inputLow, inputHigh);
            }
            return arr;
        }

        // Поиск минимальных значений во всех колонках
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

        // Поиск максимальных значений во всех колонках
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

        // Поиск минимального значения в i-ой колонке
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

        // Поиск максимального значения в i-ой колонке
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

        // Форматирование данных с удалением столбцов с указанной позиции и возможностью удаления заголовка
        public static void FormatData(ref List<List<string>> data, bool head, int from, int count)
        {
            if (head)
            {
                data.RemoveAt(0);
            }

            for (int i = 0; i < data.Count; i++)
            {
                data[i].RemoveRange(from, count);
            }
        }

        // Перевод набора данных из string в double
        public static List<List<double>> DataStringToDouble(List<List<string>> data) {
            List<List<double>> doubleData = data.Select(x => x.Select(y => double.Parse(y)).ToList()).ToList();
            return doubleData;
        }

        // Перетасовка векторов
        public static void ShuffleVectors(Vector[] x, Vector[] y)
        {
            int j = 0;
            Random random = new Random(DateTime.Now.Millisecond);
            Vector buf = null;

            for (int i = x.Length - 1; i >= 1; i--)
            {
                j = random.Next(i + 1);

                buf = x[i];
                x[i] = x[j];
                x[j] = buf;

                buf = y[i];
                y[i] = y[j];
                y[j] = buf;
            }
        }

        // Создание массива с конфигурацией нейронной сети
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
    }
}
