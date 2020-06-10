using System;

namespace NN_Backpropagation.Classes
{
    class Network
    {
        struct LayerT
        {
            public Vector x; // Вход слоя
            public Vector z; // Активированный выход слоя
            public Vector df; // Производная функции активации слоя
        }

        private Matrix[] weights; // Матрицы весов слоя
        private LayerT[] L; // Значения на каждом слое
        private Vector[] deltas; // Дельты ошибки на каждом слое

        private int layersN; // Число слоёв

        // Создание сети из массива количества нейронов в каждом слое
        public Network(int[] sizes)
        {
            Random random = new Random(DateTime.Now.Millisecond); // Создаём генератор случайных чисел

            layersN = sizes.Length - 1; // Запоминаем число слоёв

            weights = new Matrix[layersN]; // Создаём массив матриц весовых коэффициентов
            L = new LayerT[layersN]; // Создаём массив значений на каждом слое
            deltas = new Vector[layersN]; // Создаём массив для дельт

            // Для каждого слоя создаём матрицы весовых коэффициентов
            for (int k = 1; k < sizes.Length; k++)
            {
                weights[k - 1] = new Matrix(sizes[k], sizes[k - 1], random);

                L[k - 1].x = new Vector(sizes[k - 1]); // Создаём вектор для входа слоя
                L[k - 1].z = new Vector(sizes[k]); // Создаём вектор для выхода слоя
                L[k - 1].df = new Vector(sizes[k]); // Создаём вектор для производной слоя

                deltas[k - 1] = new Vector(sizes[k]); // Создаём вектор для дельт
            }
        }

        // Получение выхода сети (прямое распространение)
        public Vector Forward(Vector input)
        {
            for (int k = 0; k < layersN; k++)
            {
                if (k == 0)
                {
                    for (int i = 0; i < input.length; i++)
                    {
                        L[k].x[i] = input[i];
                    }
                }
                else
                {
                    for (int i = 0; i < L[k - 1].z.length; i++)
                    {
                        L[k].x[i] = L[k - 1].z[i];
                    }
                }

                for (int i = 0; i < weights[k].rows; i++)
                {
                    double y = 0; // Неактивированный выход нейрона

                    for (int j = 0; j < weights[k].cols; j++)
                    {
                        y += weights[k][i, j] * L[k].x[j];
                    }

                    // Сигмоидальная функция
                    L[k].z[i] = 1 / (1 + Math.Exp(-y));
                    L[k].df[i] = L[k].z[i] * (1 - L[k].z[i]);
                }
            }

            return L[layersN - 1].z;
        }

        // Обратное распространение
        void Backward(Vector output, ref double error)
        {
            int last = layersN - 1;

            error = 0; // Обнуляем ошибку

            for (int i = 0; i < output.length; i++)
            {
                double e = L[last].z[i] - output[i]; // Находим разность значений векторов

                deltas[last][i] = e * L[last].df[i]; // Запоминаем дельту

                error += e * e; // Расчет ошибки по MSE (Mean Squared Error)
            }
            error /= output.length;

            // Вычисляем каждую предыдущую дельту на основе текущей с помощью умножения на транспонированную матрицу
            for (int k = last; k > 0; k--)
            {
                for (int i = 0; i < weights[k].cols; i++)
                {
                    deltas[k - 1][i] = 0;
                    for (int j = 0; j < weights[k].rows; j++)
                    {
                        deltas[k - 1][i] += weights[k][j, i] * deltas[k][j];
                    }
                    deltas[k - 1][i] *= L[k - 1].df[i]; // Умножаем получаемое значение на производную предыдущего слоя
                }
            }
        }

        // Обновление весовых коэффициентов, alpha - скорость обучения
        void UpdateWeights(double alpha)
        {
            for (int k = 0; k < layersN; k++)
            {
                for (int i = 0; i < weights[k].rows; i++)
                {
                    for (int j = 0; j < weights[k].cols; j++)
                    {
                        weights[k][i, j] -= alpha * deltas[k][i] * L[k].x[j];
                    }
                }
            }
        }

        // Обучение сети
        public void Train(Vector[] X, Vector[] Y, double alpha, double eps, int epochs, bool isShuffled)
        {
            int epoch = 1; // Номер эпохи
            double error; // Ошибка эпохи
            do
            {
                error = 0; // Обнуляем ошибку
                // Проходимся по всем элементам обучающего множества
                for (int i = 0; i < X.Length; i++)
                {
                    Forward(X[i]); // Прямое распространение сигнала
                    Backward(Y[i], ref error); // Обратное распространение ошибки
                    UpdateWeights(alpha); // Обновление весовых коэффициентов
                }

                // Перемешивание векторов
                if (isShuffled)
                {
                    Utilities.ShuffleVectors(X, Y);
                }

                Console.WriteLine("Epoch: {0}, error: {1}", epoch, error); // Выводим в консоль номер эпохи и величину ошибку
                epoch++;
            } while (epoch <= epochs && error > eps);
        }
    }
}
