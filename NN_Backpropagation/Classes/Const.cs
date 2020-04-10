namespace NN_Backpropagation.Classes
{
    public static class Const
    {
        public static readonly string FilePath = @"C:\Users\Владик\Desktop\NewData.xlsx";

        public static readonly int NumMisscols = 2; // Количество незначимых параметров у образа стоящих спереди
        public static readonly int NumParams = 8; // Количество значимых параметров у образа
        public static readonly int IndexOutput = 10; // Индекс в C# для метки образа - для выхода
    }
}
