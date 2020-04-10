using NN_Backpropagation.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN_Backpropagation
{
    public partial class FormMain : Form
    {
        List<List<string>> DataSetFromFile = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSetFromFile = new List<List<string>>();

            FileExcel.Open();
            DataSetFromFile = FileExcel.ReadFile();
            FileExcel.Close();

            Utilities.FormatData(ref DataSetFromFile, true, Const.NumMisscols);

            Activate();
            Rtb_Result.AppendText("Данные считаны успешно!" + Environment.NewLine);
        }
    }
}
