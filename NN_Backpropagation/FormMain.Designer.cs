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
            this.GB_Settings = new System.Windows.Forms.GroupBox();
            this.Check_IsShuffled = new System.Windows.Forms.CheckBox();
            this.TB_Epochs = new System.Windows.Forms.TextBox();
            this.Label_Epochs = new System.Windows.Forms.Label();
            this.TB_Eps = new System.Windows.Forms.TextBox();
            this.Label_Eps = new System.Windows.Forms.Label();
            this.TB_Alpha = new System.Windows.Forms.TextBox();
            this.Label_Alpha = new System.Windows.Forms.Label();
            this.Label_Activation = new System.Windows.Forms.Label();
            this.CB_Activation = new System.Windows.Forms.ComboBox();
            this.Btn_Test = new System.Windows.Forms.Button();
            this.Btn_Train = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.Rtb_Result = new System.Windows.Forms.RichTextBox();
            this.ControlPanel.SuspendLayout();
            this.GB_Settings.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.GB_Settings);
            this.ControlPanel.Controls.Add(this.Btn_Test);
            this.ControlPanel.Controls.Add(this.Btn_Train);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlPanel.Location = new System.Drawing.Point(524, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(301, 501);
            this.ControlPanel.TabIndex = 0;
            // 
            // GB_Settings
            // 
            this.GB_Settings.Controls.Add(this.Check_IsShuffled);
            this.GB_Settings.Controls.Add(this.TB_Epochs);
            this.GB_Settings.Controls.Add(this.Label_Epochs);
            this.GB_Settings.Controls.Add(this.TB_Eps);
            this.GB_Settings.Controls.Add(this.Label_Eps);
            this.GB_Settings.Controls.Add(this.TB_Alpha);
            this.GB_Settings.Controls.Add(this.Label_Alpha);
            this.GB_Settings.Controls.Add(this.Label_Activation);
            this.GB_Settings.Controls.Add(this.CB_Activation);
            this.GB_Settings.Location = new System.Drawing.Point(29, 21);
            this.GB_Settings.Name = "GB_Settings";
            this.GB_Settings.Size = new System.Drawing.Size(260, 303);
            this.GB_Settings.TabIndex = 5;
            this.GB_Settings.TabStop = false;
            this.GB_Settings.Text = "Настройки нейросети";
            // 
            // Check_IsShuffled
            // 
            this.Check_IsShuffled.AutoSize = true;
            this.Check_IsShuffled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Check_IsShuffled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Check_IsShuffled.Location = new System.Drawing.Point(18, 262);
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
            this.TB_Epochs.Location = new System.Drawing.Point(95, 223);
            this.TB_Epochs.Name = "TB_Epochs";
            this.TB_Epochs.Size = new System.Drawing.Size(159, 24);
            this.TB_Epochs.TabIndex = 7;
            this.TB_Epochs.Leave += new System.EventHandler(this.TB_Epochs_Leave);
            // 
            // Label_Epochs
            // 
            this.Label_Epochs.AutoSize = true;
            this.Label_Epochs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Epochs.Location = new System.Drawing.Point(15, 202);
            this.Label_Epochs.Name = "Label_Epochs";
            this.Label_Epochs.Size = new System.Drawing.Size(132, 18);
            this.Label_Epochs.TabIndex = 6;
            this.Label_Epochs.Text = "Количество эпох:";
            // 
            // TB_Eps
            // 
            this.TB_Eps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Eps.Location = new System.Drawing.Point(95, 166);
            this.TB_Eps.Name = "TB_Eps";
            this.TB_Eps.Size = new System.Drawing.Size(159, 24);
            this.TB_Eps.TabIndex = 5;
            this.TB_Eps.Leave += new System.EventHandler(this.TB_Eps_Leave);
            // 
            // Label_Eps
            // 
            this.Label_Eps.AutoSize = true;
            this.Label_Eps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Eps.Location = new System.Drawing.Point(15, 145);
            this.Label_Eps.Name = "Label_Eps";
            this.Label_Eps.Size = new System.Drawing.Size(78, 18);
            this.Label_Eps.TabIndex = 4;
            this.Label_Eps.Text = "Точность:";
            // 
            // TB_Alpha
            // 
            this.TB_Alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Alpha.Location = new System.Drawing.Point(95, 115);
            this.TB_Alpha.Name = "TB_Alpha";
            this.TB_Alpha.Size = new System.Drawing.Size(159, 24);
            this.TB_Alpha.TabIndex = 3;
            this.TB_Alpha.Leave += new System.EventHandler(this.TB_Alpha_Leave);
            // 
            // Label_Alpha
            // 
            this.Label_Alpha.AutoSize = true;
            this.Label_Alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Alpha.Location = new System.Drawing.Point(15, 90);
            this.Label_Alpha.Name = "Label_Alpha";
            this.Label_Alpha.Size = new System.Drawing.Size(149, 18);
            this.Label_Alpha.TabIndex = 2;
            this.Label_Alpha.Text = "Скорость обучения:";
            // 
            // Label_Activation
            // 
            this.Label_Activation.AutoSize = true;
            this.Label_Activation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Activation.Location = new System.Drawing.Point(15, 33);
            this.Label_Activation.Name = "Label_Activation";
            this.Label_Activation.Size = new System.Drawing.Size(147, 18);
            this.Label_Activation.TabIndex = 1;
            this.Label_Activation.Text = "Функция активации:";
            // 
            // CB_Activation
            // 
            this.CB_Activation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Activation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_Activation.FormattingEnabled = true;
            this.CB_Activation.Items.AddRange(new object[] {
            "Sigmoid",
            "TanH",
            "ReLU"});
            this.CB_Activation.Location = new System.Drawing.Point(95, 54);
            this.CB_Activation.Name = "CB_Activation";
            this.CB_Activation.Size = new System.Drawing.Size(159, 26);
            this.CB_Activation.TabIndex = 0;
            this.CB_Activation.SelectedIndexChanged += new System.EventHandler(this.CB_Activation_SelectedIndexChanged);
            // 
            // Btn_Test
            // 
            this.Btn_Test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Test.Location = new System.Drawing.Point(66, 420);
            this.Btn_Test.Name = "Btn_Test";
            this.Btn_Test.Size = new System.Drawing.Size(198, 42);
            this.Btn_Test.TabIndex = 4;
            this.Btn_Test.Text = "Тестирование сети";
            this.Btn_Test.UseVisualStyleBackColor = true;
            this.Btn_Test.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // Btn_Train
            // 
            this.Btn_Train.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Btn_Train.Location = new System.Drawing.Point(66, 355);
            this.Btn_Train.Name = "Btn_Train";
            this.Btn_Train.Size = new System.Drawing.Size(198, 42);
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
            this.InfoPanel.Size = new System.Drawing.Size(524, 501);
            this.InfoPanel.TabIndex = 1;
            // 
            // Rtb_Result
            // 
            this.Rtb_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rtb_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rtb_Result.Location = new System.Drawing.Point(0, 0);
            this.Rtb_Result.Name = "Rtb_Result";
            this.Rtb_Result.Size = new System.Drawing.Size(524, 501);
            this.Rtb_Result.TabIndex = 0;
            this.Rtb_Result.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 501);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.ControlPanel);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FormMain";
            this.Text = "Нейронная сеть - Обратное распространение ошибки";
            this.ControlPanel.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox CB_Activation;
        private System.Windows.Forms.Label Label_Activation;
        private System.Windows.Forms.TextBox TB_Alpha;
        private System.Windows.Forms.Label Label_Alpha;
        private System.Windows.Forms.Label Label_Eps;
        private System.Windows.Forms.TextBox TB_Eps;
        private System.Windows.Forms.TextBox TB_Epochs;
        private System.Windows.Forms.Label Label_Epochs;
        private System.Windows.Forms.CheckBox Check_IsShuffled;
    }
}

