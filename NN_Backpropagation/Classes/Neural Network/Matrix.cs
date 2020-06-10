using System;

namespace NN_Backpropagation.Classes
{
    class Matrix
    {
        private double[][] values; // Значения матрицы
        public int rows, cols; // Кол-во строк и столбцов

        // Создание матрицы заданного размера и заполнение по методу Ксавье
        public Matrix(int rows, int cols, Random rand)
        {
            this.rows = rows;
            this.cols = cols;

            values = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                values[i] = new double[cols];
                for (int j = 0; j < cols; j++)
                {
                    values[i][j] = rand.NextGaussian() * Math.Sqrt(2.0 / (rows + cols)); // Заполняем случайными числами
                }
            }
        }

        // Обращение по индексу
        public double this[int i, int j]
        {
            get => values[i][j];  // Получение значения
            set => values[i][j] = value;  // Изменение значения
        }
    }
}
