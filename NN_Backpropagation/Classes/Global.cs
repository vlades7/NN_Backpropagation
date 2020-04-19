namespace NN_Backpropagation.Classes
{
    public static class Global
    {
        public const string FilePath = @"C:\Users\Владик\Desktop\NewData3.xlsx";  // Путь к файлу с данными
        public const string DirPath = @"C:\Users\Владик\Desktop\RR";              // Путь к файлам с ритмами

        public const int CountRanges = 10;                          // Количество диапазонов
        public const int NumInfoCols = 1;                           // Количество информационных параметров у образа
        public const int NumMissCols = 1;                           // Количество незначимых параметров у образа стоящих спереди
        public const int NumParamsExcel = 8;                        // Количество значимых параметров у образа из Excel
        public const int InputSize = CountRanges + NumParamsExcel;  // Количество нейронов на входном слое
        public const int OutputSize = 6;                            // Количество нейронов на выходном слое

        public const bool IsHeadDeleted = true;                     // True - если в файле есть строка с заголовками
        public const bool DeleteFirstStr = true;                    // True - если не считывать первую строку файла
        public const bool PrintLogs = false;                        // True - если нужно печатать дополнительный вывод

        public static string ConfigLayers = "9 3";                  // Конфигурация нейронной сети (скрытые слои)
        public static double PartTrain = 1.0;                       // Доля обучающей выборки [0, 1]
        public static int IndexActivation = 0;                      // Индекс выбранной функции активации
        public static double Alpha = 0.5;                           // Скорость обучения
        public static double Eps = 1e-7;                            // Точность
        public static int Epochs = 150;                             // Количество эпох
        public static bool IsShuffled = true;                       // True - если перемешивать вектора во время обучения
    }
}
