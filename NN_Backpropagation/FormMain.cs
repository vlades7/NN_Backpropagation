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
            try
            {
                FileExcel.Open();
                DataFromFile = FileExcel.ReadFile();
                FileExcel.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            double[] bufX = new double[Const.NumParams];
            double[] bufY = new double[ConvertedData[0].Count - Const.NumParams];

            // Создание обучающей выборки и её нормализация
            for (int i = 0; i < TrainSize; i++)
            {
                for (int j = 0; j < Const.NumParams; j++)
                {
                    bufX[j] = ConvertedData[i][j];
                }
                X_train[i] = new Vector(Utilities.NormalizeArray(bufX, MinValues, MaxValues));

                for (int j = Const.NumParams; j < ConvertedData[i].Count; j++)
                {
                    bufY[j - Const.NumParams] = ConvertedData[i][j];
                }
                Y_train[i] = new Vector(bufY);
            }
        }

        private void CreateTestSet()
        {
            X_test = new Vector[ConvertedData.Count - TrainSize];
            Y_test = new Vector[ConvertedData.Count - TrainSize];

            double[] bufX = new double[Const.NumParams];
            double[] bufY = new double[ConvertedData[0].Count - Const.NumParams];

            // Создание тестовой выборки и её нормализация
            for (int i = TrainSize; i < ConvertedData.Count; i++)
            {
                for (int j = 0; j < Const.NumParams; j++)
                {
                    bufX[j] = ConvertedData[i][j];
                }
                X_test[i - TrainSize] = new Vector(Utilities.NormalizeArray(bufX, MinValues, MaxValues));

                for (int j = Const.NumParams; j < ConvertedData[i].Count; j++)
                {
                    bufY[j - Const.NumParams] = ConvertedData[i][j];
                }
                Y_test[i - TrainSize] = new Vector(bufY);
            }
        }

        private void InitNetwork()
        {
            network = new Network(new int[] { 8, 4, 3, 6 });
        }

        private void TrainNetwork()
        {
            if (network != null)
            {
                network.Train(X_train, Y_train, 0.5, 1e-7, 100);
            }
        }

        private void TestNetwork(Vector[] X, Vector[] Y)
        {
            if (network != null)
            {
                double Accuracy = 0;
                int NumberEqualities = 0;
                for (int i = 0; i < X.Length; i++)
                {
                    Vector output = network.Forward(X[i]);
                    for (int j = 0; j < output.length; j++)
                    {
                        if (Math.Round(output[j]) == Y[i][j])
                        {
                            NumberEqualities++;
                        }
                    }
                    Accuracy += (double)NumberEqualities / output.length;
                    NumberEqualities = 0;
                    Rtb_Result.AppendText("#" + (i + 1) + Environment.NewLine + 
                        "Out:  " + output.VectorToStr() + Environment.NewLine + 
                        "Y_out:" + Y[i].VectorToStr() + Environment.NewLine);
                }
                Rtb_Result.AppendText("Total accuracy = " + Accuracy / X.Length + Environment.NewLine);
            }
        }

        private async void Btn_Train_Click(object sender, EventArgs e)
        {
            Btn_Train.Enabled = false;

            await Task.Run(() => ReadAndFormatData());

            if (ConvertedData.Count == 0)
            {
                Btn_Train.Enabled = true;
                return;
            }

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
            if (Const.PartTrain == 1)
            {
                TestNetwork(X_train, Y_train);
            }
            else
            {
                TestNetwork(X_test, Y_test);
            }
        }
    }
}
