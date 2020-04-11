using NN_Backpropagation.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN_Backpropagation
{
    public partial class FormMain : Form
    {
        int TrainSize; // Размер обучающей выборки

        List<List<string>> DataFromFile = new List<List<string>>();    // Данные считанные из файла
        List<List<double>> ConvertedData = new List<List<double>>();   // Данные конвертированные в числа

        double[] MaxValues = null;
        double[] MinValues = null;

        Vector[] X_train = null;
        Vector[] Y_train = null;
        Vector[] X_test = null;
        Vector[] Y_test = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            FileExcel.Open();
            DataFromFile = await Task.Run(() => FileExcel.ReadFile());
            FileExcel.Close();

            Utilities.FormatData(ref DataFromFile, Const.IsHeadDeleted, Const.NumMisscols);
            ConvertedData = Utilities.DataStringToDouble(DataFromFile);

            Activate();
            Rtb_Result.AppendText("Данные считаны успешно!" + Environment.NewLine);

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Только после прочтения данных
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Нахождение минимальных и максимальных значений для нормализации данных
            MinValues = new double[Const.NumParams];
            MaxValues = new double[Const.NumParams];

            MinValues = Utilities.MinValuesArray(ConvertedData, Const.NumParams);
            MaxValues = Utilities.MaxValuesArray(ConvertedData, Const.NumParams);

            TrainSize = (int)(Const.PartTrain * ConvertedData.Count);

            X_train = new Vector[TrainSize];
            Y_train = new Vector[TrainSize];
            X_test = new Vector[ConvertedData.Count - TrainSize];
            Y_test = new Vector[ConvertedData.Count - TrainSize];

            double[] buf = new double[Const.NumParams];

            // Создание обучающей выборки и её нормализация
            for (int i = 0; i < TrainSize; i++)
            {
                for (int j = 0; j < Const.NumParams; j++)
                {
                    buf[j] = ConvertedData[i][j];
                }
                X_train[i] = new Vector(Utilities.NormalizeArray(buf, MinValues, MaxValues));
                Y_train[i] = new Vector(ConvertedData[i][Const.NumParams]);
            }

            // Создание тестовой выборки и её нормализация
            for (int i = TrainSize; i < ConvertedData.Count; i++)
            {
                for (int j = 0; j < Const.NumParams; j++)
                {
                    buf[j] = ConvertedData[i][j];
                }
                X_test[i - TrainSize] = new Vector(Utilities.NormalizeArray(buf, MinValues, MaxValues));
                Y_test[i - TrainSize] = new Vector(ConvertedData[i][Const.NumParams]);
            }

        }
    }
}
