using System;

namespace NN_Backpropagation.Classes
{
    class Matrix
    {
        private double[][] values; // Значения матрицы
        public int cols, rows; // Кол-во строк и столбцов

        // Создание матрицы заданного размера и заполнение случайными числами из интервала (-0.5, 0.5)
        public Matrix(int cols, int rows, Random rand)
        {
            this.cols = cols;
            this.rows = rows;

            values = new double[cols][];
            for (int i = 0; i < cols; i++)
            {
                values[i] = new double[rows];
                for (int j = 0; j < rows; j++)
                {
                    values[i][j] = 2 * rand.NextDouble() - 1.0; // Заполняем случайными числами
                    // values[i][j] = rand.NextDouble() - 0.5; // Заполняем случайными числами
                    // values[i][j] = rand.NextDouble() * 0.05; // Заполняем случайными числами
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
