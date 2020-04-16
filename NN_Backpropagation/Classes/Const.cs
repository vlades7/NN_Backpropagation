namespace NN_Backpropagation.Classes
{
    public static class Const
    {
        public const string FilePath = @"C:\Users\Владик\Desktop\NewData2.xlsx";

        public const int NumMisscols = 2; // Количество незначимых параметров у образа стоящих спереди
        public const int NumParams = 8; // Количество значимых параметров у образа

        public const bool IsHeadDeleted = true; // True - если в файле есть строка с заголовками

        public static double PartTrain = 1.0; // Доля обучающей выборки (0..1)
    }
}
