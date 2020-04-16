using System;

namespace NN_Backpropagation.Classes
{
    public class Vector
    {
        public double[] values; // Значения вектора
        public int length; // Длина вектора

        // Создание вектора по длине
        public Vector(int length)
        {
            this.length = length;
            values = new double[length];
        }

        // Создание вектора из вещественных значений
        public Vector(params double[] _values)
        {
            length = _values.Length;
            values = new double[length];

            for (int i = 0; i < length; i++)
            {
                values[i] = _values[i];
            }
        }

        // Значения вектора в строку
        public string VectorToStr(int round = 0, string separator = " ")
        {
            string str = "";
            for (int i = 0; i < length - 1; i++)
            {
                str += Math.Round(this[i], round) + separator;
            }
            str += Math.Round(this[length - 1], round);
            return str;
        }

        // Обращение по индексу
        public double this[int i]
        {
            get => values[i];
            set => values[i] = value;
        }
    }
}
