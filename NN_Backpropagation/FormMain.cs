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

        Network network = null;

        public FormMain()
        {
            InitializeComponent();
            Btn_Test.Enabled = false;
        }

        private void ReadAndFormatData()
        {
            FileExcel.Open();
            DataFromFile = FileExcel.ReadFile();
            FileExcel.Close();

            Utilities.FormatData(ref DataFromFile, Const.IsHeadDeleted, Const.NumMisscols);
            ConvertedData = Utilities.DataStringToDouble(DataFromFile);
        }

        private void NormalizeData()
        {
            // Нахождение минимальных и максимальных значений для нормализации данных
            MinValues = new double[Const.NumParams];
            MaxValues = new double[Const.NumParams];

            MinValues = Utilities.MinValuesArray(ConvertedData, Const.NumParams);
            MaxValues = Utilities.MaxValuesArray(ConvertedData, Const.NumParams);

            TrainSize = (int)(Const.PartTrain * ConvertedData.Count);
        }

        private void CreateTrainSet()
        {
            X_train = new Vector[TrainSize];
            Y_train = new Vector[TrainSize];

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
        }

        private void CreateTestSet()
        {
            X_test = new Vector[ConvertedData.Count - TrainSize];
            Y_test = new Vector[ConvertedData.Count - TrainSize];

            double[] buf = new double[Const.NumParams];

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

        private void InitNetwork()
        {
            network = new Network(new int[] { 8, 3, 2, 1 });
        }

        private void TrainNetwork()
        {
            if (network != null)
            {
                network.Train(X_train, Y_train, 0.5, 1e-7, 1000);
            }
        }

        private void TestNetwork(Vector[] X, Vector[] Y)
        {
            if (network != null)
            {
                int CorrectAnswers = 0;
                for (int i = 0; i < X.Length; i++)
                {
                    Vector output = network.Forward(X[i]);
                    if (Math.Round(output[0]) == Y[i][0])
                    {
                        CorrectAnswers++;
                    }
                    Rtb_Result.AppendText(i + ")  Label Y = " + Y[i][0] + "    Out = " + output[0] + Environment.NewLine);
                }
                Rtb_Result.AppendText("Total accuracy = " + (double)CorrectAnswers / X.Length + Environment.NewLine);
            }
        }

        private async void Btn_Train_Click(object sender, EventArgs e)
        {
            Btn_Train.Enabled = false;

            await Task.Run(() => ReadAndFormatData());

            NormalizeData();
            CreateTrainSet();
            CreateTestSet();

            InitNetwork();
            TrainNetwork();

            Btn_Train.Enabled = true;
            if (network != null)
            {
                Btn_Test.Enabled = true;
            }
        }

        private void Btn_Test_Click(object sender, EventArgs e)
        {
            TestNetwork(X_train, Y_train);
        }
    }
}
