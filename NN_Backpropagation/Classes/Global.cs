using System;
using System.IO;

namespace NN_Backpropagation.Classes
{
    public static class Global
    {
        // Путь к файлу с данными
        public static string FilePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Children.xlsx"));

        public const int NumInfoCols = 1;                           // Количество информационных параметров у образа
        public const int NumParamsExcel = 10;                       // Количество значимых параметров у образа из Excel
        public const int InputSize = NumParamsExcel;                // Количество нейронов на входном слое
        public const int OutputSize = 1;                            // Количество нейронов на выходном слое

        public const bool IsHeadDeleted = true;                     // True - если в файле есть строка с заголовками

        public static bool IsRPROP = true;                          // True - метод RPROP, False - наискорейший спуск с моментом
        public static string ConfigLayers = "6";                    // Конфигурация нейронной сети (скрытые слои)

        public static double Mu = 0.9;                              // Коэффициент "Мю" для наискорейшего спуска с моментом
        public static double nu1 = 1.2;                             // Коэффициент "Ню плюс" для RPROP
        public static double nu2 = 0.5;                             // Коэффициент "Ню минус" для RPROP

        public static double PartTrain = 1.0;                       // Доля обучающей выборки [0, 1]
        public static double Alpha = 0.5;                           // Скорость обучения
        public static double Eps = 1e-7;                            // Точность
        public static int Epochs = 150;                             // Количество эпох
        public static int IdPatient = 25;                           // Номер пациента
    }
}
