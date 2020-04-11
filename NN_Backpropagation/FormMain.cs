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
        List<List<string>> DataFromFile = new List<List<string>>();
        List<List<double>> ConvertedData = new List<List<double>>();

        double[] MaxValues = null;
        double[] MinValues = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            FileExcel.Open();
            DataFromFile = FileExcel.ReadFile();
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
            MinValues = new double[Const.NumParams];
            MaxValues = new double[Const.NumParams];

            MinValues = Utilities.MinValuesArray(ConvertedData, Const.NumParams);
            MaxValues = Utilities.MaxValuesArray(ConvertedData, Const.NumParams);
        }

        private async void TEST_Click(object sender, EventArgs e)
        {
            TEST.Enabled = false;
            FileExcel.Open();
            DataFromFile = await Task.Run(() => FileExcel.ReadFile());
            FileExcel.Close();
            //Thread.Sleep(1000);
            TEST.Enabled = true;

            Rtb_Result.AppendText("SUCCESS" + Environment.NewLine);
        }
    }
}
