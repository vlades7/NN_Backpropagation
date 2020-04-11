namespace NN_Backpropagation.Classes
{
    public static class Const
    {
        public const string FilePath = @"C:\Users\Владик\Desktop\NewData.xlsx";

        public const int NumMisscols = 2; // Количество незначимых параметров у образа стоящих спереди
        public const int NumParams = 8; // Количество значимых параметров у образа

        public const double PartTrain = 1; // Доля обучающей выборки

        public const bool IsHeadDeleted = true; // True - если в файле есть строка с заголовками
    }
}
