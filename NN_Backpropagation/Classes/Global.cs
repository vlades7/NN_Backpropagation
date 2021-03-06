﻿using System;
using System.IO;

namespace NN_Backpropagation.Classes
{
    public static class Global
    {
        // Путь к файлу с данными
        public static string FilePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Children.xlsx"));
        // Путь к файлам с ритмами
        public static string DirPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\RR_intervals"));
        #region Для установки
        //public static string FilePath = Path.GetFullPath(@"data\Children.xlsx");
        //public static string DirPath = Path.GetFullPath(@"data\RR_intervals");
        #endregion

        public const int CountRanges = 10;                          // Количество диапазонов
        public const int NumInfoCols = 1;                           // Количество информационных параметров у образа
        public const int NumMissCols = 1;                           // Количество незначимых параметров у образа стоящих спереди
        public const int NumParamsExcel = 9;                        // Количество значимых параметров у образа из Excel
        public const int InputSize = CountRanges + NumParamsExcel;  // Количество нейронов на входном слое
        public const int OutputSize = 6;                            // Количество нейронов на выходном слое

        public const bool IsHeadDeleted = true;                     // True - если в файле есть строка с заголовками

        public static string ConfigLayers = "8 4";                  // Конфигурация нейронной сети (скрытые слои)
        public static double PartTrain = 1.0;                       // Доля обучающей выборки [0, 1]
        public static double Alpha = 0.5;                           // Скорость обучения
        public static double Eps = 1e-7;                            // Точность
        public static int Epochs = 150;                             // Количество эпох
        public static int IdPatient = 41;                           // Номер пациента
        public static bool IsShuffled = false;                      // True - если перемешивать вектора во время обучения
        public static bool IsParallel = false;                      // True - если вычислять в параллельном режиме
    }
}
