﻿namespace NN_Backpropagation.Classes
{
    public static class Global
    {
        public const string FilePath = @"C:\Users\Владик\Desktop\NewData2.xlsx";

        public const int NumMisscols = 2;        // Количество незначимых параметров у образа стоящих спереди
        public const int NumParams = 8;          // Количество значимых параметров у образа
        public const int InputSize = 8;          // Количество нейронов на входном слое
        public const int OutputSize = 6;         // Количество нейронов на выходном слое
        public const bool IsHeadDeleted = true;  // True - если в файле есть строка с заголовками

        public static double PartTrain = 1.0;    // Доля обучающей выборки [0, 1]
        public static int IndexActivation = 0;   // Индекс выбранной функции активации
        public static double Alpha = 0.5;        // Скорость обучения
        public static double Eps = 1e-7;         // Точность
        public static int Epochs = 150;          // Количество эпох
        public static bool IsShuffled = true;    // Перемешиваются вектора во время обучения или нет
    }
}
