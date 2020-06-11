namespace NN_Backpropagation
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.TB_IdPatient = new System.Windows.Forms.TextBox();
            this.Label_IdPatient = new System.Windows.Forms.Label();
            this.Btn_TestOne = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.GB_Settings = new System.Windows.Forms.GroupBox();
            this.TB_Config = new System.Windows.Forms.TextBox();
            this.Label_Config = new System.Windows.Forms.Label();
            this.TB_PartTrain = new System.Windows.Forms.TextBox();
            this.Label_PartTrain = new System.Windows.Forms.Label();
            this.Check_IsShuffled = new System.Windows.Forms.CheckBox();
            this.TB_Epochs = new System.Windows.Forms.TextBox();
            this.Label_Epochs = new System.Windows.Forms.Label();
            this.TB_Eps = new System.Windows.Forms.TextBox();
            this.Label_Eps = new System.Windows.Forms.Label();
            this.TB_Alpha = new System.Windows.Forms.TextBox();
            this.Label_Alpha = new System.Windows.Forms.Label();
            this.Btn_Test = new System.Windows.Forms.Button();
            this.Btn_Train = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.Rtb_Result = new System.Windows.Forms.RichTextBox();
            this.Check_IsParallel = new System.Windows.Forms.CheckBox();
            this.ControlPanel.SuspendLayout();
            this.GB_Settings.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.TB_IdPatient);
            this.ControlPanel.Controls.Add(this.Label_IdPatient);
            this.ControlPanel.Controls.Add(this.Btn_TestOne);
            this.ControlPanel.Controls.Add(this.Btn_Clear);
            this.ControlPanel.Controls.Add(this.GB_Settings);
            this.ControlPanel.Controls.Add(this.Btn_Test);
            this.ControlPanel.Controls.Add(this.Btn_Train);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlPanel.Location = new System.Drawing.Point(689, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(557, 470);
            this.ControlPanel.TabIndex = 0;
            // 
            // TB_IdPatient
            // 
            this.TB_IdPatient.Location = new System.Drawing.Point(209, 359);
            this.TB_IdPatient.Name = "TB_IdPatient";
            this.TB_IdPatient.Size = new System.Drawing.Size(144, 22);
            this.TB_IdPatient.TabIndex = 9;
            this.TB_IdPatient.Leave += new System.EventHandler(this.TB_IdPatient_Leave);
            // 
            // Label_IdPatient
            // 
            this.Label_IdPatient.AutoSize = true;
            this.Label_IdPatient.Location = new System.Drawing.Point(206, 339);
            this.Label_IdPatient.Name = "Label_IdPatient";
            this.Label_IdPatient.Size = new System.Drawing.Size(122, 17);
            this.Label_IdPatient.TabIndex = 8;
            this.Label_IdPatient.Text = "Номер пациента:";
            // 
            // Btn_TestOne
            // 
            this.Btn_TestOne.Location = new System.Drawing.Point(209, 403);
            this.Btn_TestOne.Name = "Btn_TestOne";
            this.Btn_TestOne.Size = new System.Drawing.Size(144, 55);
            this.Btn_TestOne.TabIndex = 7;
            this.Btn_TestOne.Text = "Прогноз";
            this.Btn_TestOne.UseVisualStyleBackColor = true;
            this.Btn_TestOne.Click += new System.EventHandler(this.Btn_TestOne_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(372, 403);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(144, 55);
            this.Btn_Clear.TabIndex = 6;
            this.Btn_Clear.Text = "Очистить вывод";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // GB_Settings
            // 
            this.GB_Settings.Controls.Add(this.Check_IsParallel);
            this.GB_Settings.Controls.Add(this.TB_Config);
            this.GB_Settings.Controls.Add(this.Label_Config);
            this.GB_Settings.Controls.Add(this.TB_PartTrain);
            this.GB_Settings.Controls.Add(this.Label_PartTrain);
            this.GB_Settings.Controls.Add(this.Check_IsShuffled);
            this.GB_Settings.Controls.Add(this.TB_Epochs);
            this.GB_Settings.Controls.Add(this.Label_Epochs);
            this.GB_Settings.Controls.Add(this.TB_Eps);
            this.GB_Settings.Controls.Add(this.Label_Eps);
            this.GB_Settings.Controls.Add(this.TB_Alpha);
            this.GB_Settings.Controls.Add(this.Label_Alpha);
            this.GB_Settings.Location = new System.Drawing.Point(29, 21);
            this.GB_Settings.Name = "GB_Settings";
            this.GB_Settings.Size = new System.Drawing.Size(505, 261);
            this.GB_Settings.TabIndex = 5;
            this.GB_Settings.TabStop = false;
            this.GB_Settings.Text = "Настройки нейросети";
            // 
            // TB_Config
            // 
            this.TB_Config.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Config.Location = new System.Drawing.Point(340, 59);
            this.TB_Config.Name = "TB_Config";
            this.TB_Config.Size = new System.Drawing.Size(159, 24);
            this.TB_Config.TabIndex = 13;
            this.TB_Config.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Config_KeyPress);
            this.TB_Config.Leave += new System.EventHandler(this.TB_Config_Leave);
            // 
            // Label_Config
            // 
            this.Label_Config.AutoSize = true;
            this.Label_Config.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Config.Location = new System.Drawing.Point(298, 34);
            this.Label_Config.Name = "Label_Config";
            this.Label_Config.Size = new System.Drawing.Size(113, 18);
            this.Label_Config.TabIndex = 12;
            this.Label_Config.Text = "Конфигурация:";
            // 
            // TB_PartTrain
            // 
            this.TB_PartTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_PartTrain.Location = new System.Drawing.Point(340, 110);
            this.TB_PartTrain.Name = "TB_PartTrain";
            this.TB_PartTrain.Size = new System.Drawing.Size(159, 24);
            this.TB_PartTrain.TabIndex = 11;
            this.TB_PartTrain.Leave += new System.EventHandler(this.TB_PartTrain_Leave);
            // 
            // Label_PartTrain
            // 
            this.Label_PartTrain.AutoSize = true;
            this.Label_PartTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_PartTrain.Location = new System.Drawing.Point(298, 89);
            this.Label_PartTrain.Name = "Label_PartTrain";
            this.Label_PartTrain.Size = new System.Drawing.Size(115, 18);
            this.Label_PartTrain.TabIndex = 10;
            this.Label_PartTrain.Text = "Доля выборки:";
            // 
            // Check_IsShuffled
            // 
            this.Check_IsShuffled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Check_IsShuffled.AutoSize = true;
            this.Check_IsShuffled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Check_IsShuffled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Check_IsShuffled.Location = new System.Drawing.Point(301, 146);
            this.Check_IsShuffled.Name = "Check_IsShuffled";
            this.Check_IsShuffled.Size = new System.Drawing.Size(198, 22);
            this.Check_IsShuffled.TabIndex = 9;
            this.Check_IsShuffled.Text = "Перемешивать вектора:";
            this.Check_IsShuffled.UseVisualStyleBackColor = true;
            this.Check_IsShuffled.CheckedChanged += new System.EventHandler(this.Check_IsShuffled_CheckedChanged);
            // 
            // TB_Epochs
            // 
            this.TB_Epochs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Epochs.Location = new System.Drawing.Point(95, 167);
            this.TB_Epochs.Name = "TB_Epochs";
            this.TB_Epochs.Size = new System.Drawing.Size(159, 24);
            this.TB_Epochs.TabIndex = 7;
            this.TB_Epochs.Leave += new System.EventHandler(this.TB_Epochs_Leave);
            // 
            // Label_Epochs
            // 
            this.Label_Epochs.AutoSize = true;
            this.Label_Epochs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Epochs.Location = new System.Drawing.Point(15, 146);
            this.Label_Epochs.Name = "Label_Epochs";
            this.Label_Epochs.Size = new System.Drawing.Size(132, 18);
            this.Label_Epochs.TabIndex = 6;
            this.Label_Epochs.Text = "Количество эпох:";
            // 
            // TB_Eps
            // 
            this.TB_Eps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Eps.Location = new System.Drawing.Point(95, 110);
            this.TB_Eps.Name = "TB_Eps";
            this.TB_Eps.Size = new System.Drawing.Size(159, 24);
            this.TB_Eps.TabIndex = 5;
            this.TB_Eps.Leave += new System.EventHandler(this.TB_Eps_Leave);
            // 
            // Label_Eps
            // 
            this.Label_Eps.AutoSize = true;
            this.Label_Eps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Eps.Location = new System.Drawing.Point(15, 89);
            this.Label_Eps.Name = "Label_Eps";
            this.Label_Eps.Size = new System.Drawing.Size(78, 18);
            this.Label_Eps.TabIndex = 4;
            this.Label_Eps.Text = "Точность:";
            // 
            // TB_Alpha
            // 
            this.TB_Alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Alpha.Location = new System.Drawing.Point(95, 59);
            this.TB_Alpha.Name = "TB_Alpha";
            this.TB_Alpha.Size = new System.Drawing.Size(159, 24);
            this.TB_Alpha.TabIndex = 3;
            this.TB_Alpha.Leave += new System.EventHandler(this.TB_Alpha_Leave);
            // 
            // Label_Alpha
            // 
            this.Label_Alpha.AutoSize = true;
            this.Label_Alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Alpha.Location = new System.Drawing.Point(15, 34);
            this.Label_Alpha.Name = "Label_Alpha";
            this.Label_Alpha.Size = new System.Drawing.Size(149, 18);
            this.Label_Alpha.TabIndex = 2;
            this.Label_Alpha.Text = "Скорость обучения:";
            // 
            // Btn_Test
            // 
            this.Btn_Test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Test.Location = new System.Drawing.Point(47, 403);
            this.Btn_Test.Name = "Btn_Test";
            this.Btn_Test.Size = new System.Drawing.Size(144, 55);
            this.Btn_Test.TabIndex = 4;
            this.Btn_Test.Text = "Тестирование сети";
            this.Btn_Test.UseVisualStyleBackColor = true;
            this.Btn_Test.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // Btn_Train
            // 
            this.Btn_Train.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Train.Location = new System.Drawing.Point(47, 339);
            this.Btn_Train.Name = "Btn_Train";
            this.Btn_Train.Size = new System.Drawing.Size(144, 55);
            this.Btn_Train.TabIndex = 3;
            this.Btn_Train.Text = "Обучить нейросеть";
            this.Btn_Train.UseVisualStyleBackColor = true;
            this.Btn_Train.Click += new System.EventHandler(this.Btn_Train_Click);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.Rtb_Result);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoPanel.Location = new System.Drawing.Point(0, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(689, 470);
            this.InfoPanel.TabIndex = 1;
            // 
            // Rtb_Result
            // 
            this.Rtb_Result.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Rtb_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rtb_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rtb_Result.Location = new System.Drawing.Point(0, 0);
            this.Rtb_Result.Name = "Rtb_Result";
            this.Rtb_Result.ReadOnly = true;
            this.Rtb_Result.Size = new System.Drawing.Size(689, 470);
            this.Rtb_Result.TabIndex = 0;
            this.Rtb_Result.Text = "";
            this.Rtb_Result.TextChanged += new System.EventHandler(this.Rtb_Result_TextChanged);
            // 
            // Check_IsParallel
            // 
            this.Check_IsParallel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Check_IsParallel.AutoSize = true;
            this.Check_IsParallel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Check_IsParallel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Check_IsParallel.Location = new System.Drawing.Point(310, 174);
            this.Check_IsParallel.Name = "Check_IsParallel";
            this.Check_IsParallel.Size = new System.Drawing.Size(189, 22);
            this.Check_IsParallel.TabIndex = 14;
            this.Check_IsParallel.Text = "Параллельный режим:";
            this.Check_IsParallel.UseVisualStyleBackColor = true;
            this.Check_IsParallel.CheckedChanged += new System.EventHandler(this.Check_IsParallel_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 470);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.ControlPanel);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нейронная сеть - Обратное распространение ошибки";
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.GB_Settings.ResumeLayout(false);
            this.GB_Settings.PerformLayout();
            this.InfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.RichTextBox Rtb_Result;
        private System.Windows.Forms.Button Btn_Train;
        private System.Windows.Forms.Button Btn_Test;
        private System.Windows.Forms.GroupBox GB_Settings;
        private System.Windows.Forms.TextBox TB_Alpha;
        private System.Windows.Forms.Label Label_Alpha;
        private System.Windows.Forms.Label Label_Eps;
        private System.Windows.Forms.TextBox TB_Eps;
        private System.Windows.Forms.TextBox TB_Epochs;
        private System.Windows.Forms.Label Label_Epochs;
        private System.Windows.Forms.CheckBox Check_IsShuffled;
        private System.Windows.Forms.Label Label_PartTrain;
        private System.Windows.Forms.TextBox TB_PartTrain;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.TextBox TB_Config;
        private System.Windows.Forms.Label Label_Config;
        private System.Windows.Forms.TextBox TB_IdPatient;
        private System.Windows.Forms.Label Label_IdPatient;
        private System.Windows.Forms.Button Btn_TestOne;
        private System.Windows.Forms.CheckBox Check_IsParallel;
    }
}

