using NN_Backpropagation.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN_Backpropagation
{
    public partial class FormMain : Form
    {
        int TrainSize; // Размер обучающей выборки

        List<List<string>> DataFromFile = new List<List<string>>();    // Данные считанные из файла
        List<List<double>> ConvertedData = new List<List<double>>();   // Данные конвертированные в числа
        List<FileRR> filesRR = new List<FileRR>();                     // Файлы с RR-интервалами

        Vector[] X_train = null;
        Vector[] Y_train = null;
        Vector[] X_test = null;
        Vector[] Y_test = null;

        Network network = null;

        public FormMain()
        {
            InitializeComponent();

            CB_Activation.SelectedIndex = 0;
            TB_Config.Text = Global.ConfigLayers;
            TB_Alpha.Text = Global.Alpha.ToString();
            TB_Eps.Text = Global.Eps.ToString();
            TB_Epochs.Text = Global.Epochs.ToString();
            TB_PartTrain.Text = Global.PartTrain.ToString();
            Check_IsShuffled.Checked = Global.IsShuffled;

            Btn_Test.Enabled = false;
        }

        // Считывание и форматирование данных из Excel
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

            Utilities.FormatData(ref DataFromFile, Global.IsHeadDeleted, Global.NumInfoCols, Global.NumMissCols);
            ConvertedData = Utilities.DataStringToDouble(DataFromFile);
        }

        // Нормализация данных из Excel
        private void NormalizeData()
        {
            double[] MaxValues = null;
            double[] MinValues = null;

            // Нахождение минимальных и максимальных значений для нормализации данных
            MinValues = new double[Global.NumParamsExcel];
            MaxValues = new double[Global.NumParamsExcel];

            MinValues = Utilities.MinValuesArray(ConvertedData, Global.NumParamsExcel, Global.NumInfoCols);
            MaxValues = Utilities.MaxValuesArray(ConvertedData, Global.NumParamsExcel, Global.NumInfoCols);

            for (int i = 0; i < ConvertedData.Count; i++)
            {
                for (int j = 0; j < Global.NumParamsExcel; j++)
                {
                    ConvertedData[i][j + Global.NumInfoCols] = Utilities.Normalize(ConvertedData[i][j + Global.NumInfoCols],
                        MinValues[j], MaxValues[j]);
                }
            }

            TrainSize = (int)(Global.PartTrain * ConvertedData.Count);
        }

        // Считывание файлов RR-интервалов
        private void ReadFilesRR()
        {
            DirectoryInfo dir = new DirectoryInfo(Global.DirPath);
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    filesRR.Add(new FileRR(file.FullName));
                }
                catch { }
            }

            filesRR.Sort((a, b) => a.Id >= b.Id ? 1 : -1);

            foreach (FileRR f in filesRR)
            {
                f.CreateRanges();
            }
        }

        // Вставка нормализированных диапазонов вхождений в общие данные
        private void NormRangesToData()
        {
            double[] normRanges = new double[Global.CountRanges];
            for (int i = 0; i < ConvertedData.Count; i++)
            {
                for (int j = 0; j < Global.CountRanges; j++)
                {
                    normRanges[j] = Utilities.Normalize(filesRR[i].ranges[j], filesRR[i].MinCount, filesRR[i].MaxCount);
                }
                ConvertedData[i].InsertRange(Global.NumInfoCols, normRanges);
            }
        }

        // Создание набора данных для обучения
        private void CreateTrainSet()
        {
            X_train = new Vector[TrainSize];
            Y_train = new Vector[TrainSize];

            double[] bufX = new double[Global.InputSize];
            double[] bufY = new double[Global.OutputSize];

            // Создание обучающей выборки и её нормализация
            for (int i = 0; i < TrainSize; i++)
            {
                for (int j = 0; j < Global.InputSize; j++)
                {
                    bufX[j] = ConvertedData[i][j + Global.NumInfoCols];
                }
                X_train[i] = new Vector(bufX);

                for (int j = Global.InputSize + Global.NumInfoCols; j < ConvertedData[i].Count; j++)
                {
                    bufY[j - Global.InputSize - Global.NumInfoCols] = ConvertedData[i][j];
                }
                Y_train[i] = new Vector(bufY);
            }
        }

        // Создание набора данных для тестирования
        private void CreateTestSet()
        {
            X_test = new Vector[ConvertedData.Count - TrainSize];
            Y_test = new Vector[ConvertedData.Count - TrainSize];

            double[] bufX = new double[Global.InputSize];
            double[] bufY = new double[Global.OutputSize];

            // Создание тестовой выборки и её нормализация
            for (int i = TrainSize; i < ConvertedData.Count; i++)
            {
                for (int j = 0; j < Global.InputSize; j++)
                {
                    bufX[j] = ConvertedData[i][j + Global.NumInfoCols];
                }
                X_test[i - TrainSize] = new Vector(bufX);

                for (int j = Global.InputSize + Global.NumInfoCols; j < ConvertedData[i].Count; j++)
                {
                    bufY[j - Global.InputSize - Global.NumInfoCols] = ConvertedData[i][j];
                }
                Y_test[i - TrainSize] = new Vector(bufY);
            }
        }

        // Инициализация нейронной сети
        private void InitNetwork()
        {
            int[] sizes = Utilities.CreateConfigArray();
            network = new Network(sizes);
        }

        // Обучение нейронной сети
        private async void TrainNetwork()
        {
            if (network != null)
            {
                string str = "Обучение начато..." + Environment.NewLine;
                str += "Параметры нейросети:" + Environment.NewLine;
                str += "\tКонфигурация нейросети:" + Environment.NewLine;
                str += string.Format("\t\t{0} {1} {2}\n", Global.InputSize, Global.ConfigLayers, Global.OutputSize);
                switch (Global.IndexActivation)
                {
                    case 0:
                        str += "\tФункция активации: сигмоидальная функция" + Environment.NewLine;
                        break;
                    case 1:
                        str += "\tФункция активации: гиперболический тангенс" + Environment.NewLine;
                        break;
                    case 2:
                        str += "\tФункция активации: ReLU" + Environment.NewLine;
                        break;
                    default:
                        str += "\tФункция активации: сигмоидальная функция" + Environment.NewLine; ;
                        break;
                }
                str += "\tСкорость обучения: " + Global.Alpha + Environment.NewLine;
                str += "\tТочность нейросети: " + Global.Eps + Environment.NewLine;
                str += "\tКоличество эпох: " + Global.Epochs + Environment.NewLine;
                str += "\tДоля выборки: " + Global.PartTrain + Environment.NewLine;
                if (Global.IsShuffled)
                {
                    str += "\tПеретасовка векторов выбрана" + Environment.NewLine;
                }
                else
                {
                    str += "\tПеретасовка векторов не выбрана" + Environment.NewLine;
                }
                Rtb_Result.AppendText(str);

                await Task.Run(() => network.Train(X_train, Y_train, Global.Alpha, Global.Eps, Global.Epochs, Global.IsShuffled));

                str = "Обучение завершено!" + Environment.NewLine + Environment.NewLine;
                Rtb_Result.AppendText(str);
            }
        }

        // Тестирование нейронной сети
        private void TestNetwork(Vector[] X, Vector[] Y)
        {
            if (network != null)
            {
                double TotalAccuracy = 0;                              // Общая точность нейросети
                double[] Accuracy = new double[Global.OutputSize];     // Точность нейросети для каждого нейрона
                int[] NumberEqualities = new int[Global.OutputSize];   // Количество совпадений на нейронах

                for (int i = 0; i < X.Length; i++)
                {
                    Vector output = network.Forward(X[i]);
                    for (int j = 0; j < Global.OutputSize; j++)
                    {
                        if (Math.Round(output[j]) == Y[i][j])
                        {
                            NumberEqualities[j]++;
                        }
                    }

                    if (Global.PrintLogs)
                    {
                        Rtb_Result.AppendText("#" + (i + 1) + Environment.NewLine +
                            "Calc_Out:" + output.VectorToStr() + Environment.NewLine +
                            "Real_out:" + Y[i].VectorToStr() + Environment.NewLine + Environment.NewLine);
                    }
                }

                for (int i = 0; i < Global.OutputSize; i++)
                {
                    Accuracy[i] = (double)NumberEqualities[i] / X.Length;
                }

                Accuracy.Sum(x => TotalAccuracy += x);
                TotalAccuracy /= Global.OutputSize;

                string strOutput = "";
                strOutput += string.Format("Точность - жизнеспособность: {0}\n", Math.Round(Accuracy[0], 6) * 100);
                strOutput += string.Format("Точность - физическое развитие: {0}\n", Math.Round(Accuracy[1], 6) * 100);
                strOutput += string.Format("Точность - норма НПР: {0}\n", Math.Round(Accuracy[2], 6) * 100);
                strOutput += string.Format("Точность - моторика: {0}\n", Math.Round(Accuracy[3], 6) * 100);
                strOutput += string.Format("Точность - речь: {0}\n", Math.Round(Accuracy[4], 6) * 100);
                strOutput += string.Format("Точность - моторика и речь: {0}\n\n", Math.Round(Accuracy[5], 6) * 100);
                strOutput += string.Format("Общая точность: {0}\n", Math.Round(TotalAccuracy, 6) * 100);
                Rtb_Result.AppendText(strOutput);
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
            ReadFilesRR();
            NormRangesToData();
            
            CreateTrainSet();
            if (Global.PartTrain != 1)
            {
                CreateTestSet();
            }

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

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Rtb_Result.Clear();
            Rtb_Result.ScrollToCaret();
        }

        #region Настройки нейросети и валидация данных
        private void CB_Activation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.IndexActivation = CB_Activation.SelectedIndex;
        }

        private void TB_Config_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] words = TB_Config.Text.Split(new char[] { ' ', ',', '.', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (int.Parse(words[i]) == 0)
                    {
                        words[i] = "1";
                    }
                }
                Global.ConfigLayers = string.Join(" ", words);
                TB_Config.Text = Global.ConfigLayers.ToString();
            }
            catch
            {
                TB_Config.Text = "9 3";
                Global.ConfigLayers = TB_Config.Text;
            }
        }

        private void TB_Config_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(32))
            {
                e.Handled = true;
            }
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

        private void TB_PartTrain_Leave(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(TB_PartTrain.Text) <= 0.3 || double.Parse(TB_PartTrain.Text) > 1.0)
                {
                    TB_PartTrain.Text = "1,0";
                }
                Global.PartTrain = double.Parse(TB_PartTrain.Text);
                TB_PartTrain.Text = Global.PartTrain.ToString();
            }
            catch
            {
                TB_PartTrain.Text = "1,0";
                Global.PartTrain = double.Parse(TB_PartTrain.Text);
            }
        }

        private void Check_IsShuffled_CheckedChanged(object sender, EventArgs e)
        {
            Global.IsShuffled = Check_IsShuffled.Checked;
        }

        private void Rtb_Result_TextChanged(object sender, EventArgs e)
        {
            Rtb_Result.ScrollToCaret();
        }
        #endregion
    }
}
