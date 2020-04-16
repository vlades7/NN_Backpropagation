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

            CB_Activation.SelectedIndex = 0;
            TB_Alpha.Text = Global.Alpha.ToString();
            TB_Eps.Text = Global.Eps.ToString();
            TB_Epochs.Text = Global.Epochs.ToString();
            Check_IsShuffled.Checked = Global.IsShuffled;

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

            Utilities.FormatData(ref DataFromFile, Global.IsHeadDeleted, Global.NumMisscols);
            ConvertedData = Utilities.DataStringToDouble(DataFromFile);
        }

        private void NormalizeData()
        {
            // Нахождение минимальных и максимальных значений для нормализации данных
            MinValues = new double[Global.NumParams];
            MaxValues = new double[Global.NumParams];

            MinValues = Utilities.MinValuesArray(ConvertedData, Global.NumParams);
            MaxValues = Utilities.MaxValuesArray(ConvertedData, Global.NumParams);

            TrainSize = (int)(Global.PartTrain * ConvertedData.Count);
        }

        private void CreateTrainSet()
        {
            X_train = new Vector[TrainSize];
            Y_train = new Vector[TrainSize];

            double[] bufX = new double[Global.NumParams];
            double[] bufY = new double[ConvertedData[0].Count - Global.NumParams];

            // Создание обучающей выборки и её нормализация
            for (int i = 0; i < TrainSize; i++)
            {
                for (int j = 0; j < Global.NumParams; j++)
                {
                    bufX[j] = ConvertedData[i][j];
                }
                X_train[i] = new Vector(Utilities.NormalizeArray(bufX, MinValues, MaxValues));

                for (int j = Global.NumParams; j < ConvertedData[i].Count; j++)
                {
                    bufY[j - Global.NumParams] = ConvertedData[i][j];
                }
                Y_train[i] = new Vector(bufY);
            }
        }

        private void CreateTestSet()
        {
            X_test = new Vector[ConvertedData.Count - TrainSize];
            Y_test = new Vector[ConvertedData.Count - TrainSize];

            double[] bufX = new double[Global.NumParams];
            double[] bufY = new double[ConvertedData[0].Count - Global.NumParams];

            // Создание тестовой выборки и её нормализация
            for (int i = TrainSize; i < ConvertedData.Count; i++)
            {
                for (int j = 0; j < Global.NumParams; j++)
                {
                    bufX[j] = ConvertedData[i][j];
                }
                X_test[i - TrainSize] = new Vector(Utilities.NormalizeArray(bufX, MinValues, MaxValues));

                for (int j = Global.NumParams; j < ConvertedData[i].Count; j++)
                {
                    bufY[j - Global.NumParams] = ConvertedData[i][j];
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
                string str = "Обучение начато..." + Environment.NewLine +
                    "Параметры нейросети:" + Environment.NewLine;
                str += "\tСкорость обучения: " + Global.Alpha + Environment.NewLine;
                str += "\tТочность нейросети: " + Global.Eps + Environment.NewLine;
                str += "\tКоличество эпох: " + Global.Epochs + Environment.NewLine;
                if (Global.IsShuffled)
                {
                    str += "\tПеретасовка векторов выбрана" + Environment.NewLine;
                }
                else
                {
                    str += "\tПеретасовка векторов не выбрана" + Environment.NewLine;
                }
                Rtb_Result.AppendText(str);

                network.Train(X_train, Y_train, Global.Alpha, Global.Eps, Global.Epochs, Global.IsShuffled);

                str = "Обучение завершено!" + Environment.NewLine;
                Rtb_Result.AppendText(str);
            }
        }

        private void TestNetwork(Vector[] X, Vector[] Y)
        {
            if (network != null)
            {
                double Accuracy = 0; // Точность нейросети
                int NumberEqualities = 0; // Количество совпадений на нейронах

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
                        "Y_out:" + Y[i].VectorToStr() + Environment.NewLine + Environment.NewLine);
                }

                Rtb_Result.AppendText("Total accuracy = " + Math.Round(Accuracy / X.Length, 6) + Environment.NewLine + Environment.NewLine);
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
            if (Global.PartTrain == 1)
            {
                TestNetwork(X_train, Y_train);
            }
            else
            {
                TestNetwork(X_test, Y_test);
            }
        }

        #region Настройки нейросети и валидация данных
        private void CB_Activation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.IndexActivation = CB_Activation.SelectedIndex;
        }

        private void TB_Alpha_Leave(object sender, EventArgs e)
        {
            try
            {
                Global.Alpha = double.Parse(TB_Alpha.Text);
                TB_Alpha.Text = Global.Alpha.ToString();
            }
            catch
            {
                TB_Alpha.Text = "0,5";
                Global.Alpha = double.Parse(TB_Alpha.Text);
            }
        }

        private void TB_Eps_Leave(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(TB_Eps.Text) <= 0)
                {
                    TB_Eps.Text = "0,0001";
                }
                Global.Eps = double.Parse(TB_Eps.Text);
                TB_Eps.Text = Global.Eps.ToString();
            }
            catch
            {
                TB_Eps.Text = "0,0001";
                Global.Eps = double.Parse(TB_Eps.Text);
            }
        }

        private void TB_Epochs_Leave(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(TB_Epochs.Text) <= 0)
                {
                    TB_Epochs.Text = "100";
                }
                Global.Epochs = int.Parse(TB_Epochs.Text);
                TB_Epochs.Text = Global.Epochs.ToString();
            }
            catch
            {
                TB_Epochs.Text = "100";
                Global.Epochs = int.Parse(TB_Epochs.Text);
            }
        }

        private void Check_IsShuffled_CheckedChanged(object sender, EventArgs e)
        {
            Global.IsShuffled = Check_IsShuffled.Checked;
        }
        #endregion
    }
}
