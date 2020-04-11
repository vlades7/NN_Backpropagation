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
            this.Btn_Test = new System.Windows.Forms.Button();
            this.Btn_Train = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.Rtb_Result = new System.Windows.Forms.RichTextBox();
            this.ControlPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.Btn_Test);
            this.ControlPanel.Controls.Add(this.Btn_Train);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlPanel.Location = new System.Drawing.Point(525, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(275, 450);
            this.ControlPanel.TabIndex = 0;
            // 
            // Btn_Test
            // 
            this.Btn_Test.Location = new System.Drawing.Point(53, 84);
            this.Btn_Test.Name = "Btn_Test";
            this.Btn_Test.Size = new System.Drawing.Size(167, 42);
            this.Btn_Test.TabIndex = 4;
            this.Btn_Test.Text = "Тестирование сети";
            this.Btn_Test.UseVisualStyleBackColor = true;
            this.Btn_Test.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // Btn_Train
            // 
            this.Btn_Train.Location = new System.Drawing.Point(53, 27);
            this.Btn_Train.Name = "Btn_Train";
            this.Btn_Train.Size = new System.Drawing.Size(167, 42);
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
            this.InfoPanel.Size = new System.Drawing.Size(525, 450);
            this.InfoPanel.TabIndex = 1;
            // 
            // Rtb_Result
            // 
            this.Rtb_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rtb_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rtb_Result.Location = new System.Drawing.Point(0, 0);
            this.Rtb_Result.Name = "Rtb_Result";
            this.Rtb_Result.Size = new System.Drawing.Size(525, 450);
            this.Rtb_Result.TabIndex = 0;
            this.Rtb_Result.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.ControlPanel);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FormMain";
            this.Text = "Нейронная сеть - Обратное распространение ошибки";
            this.ControlPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.RichTextBox Rtb_Result;
        private System.Windows.Forms.Button Btn_Train;
        private System.Windows.Forms.Button Btn_Test;
    }
}

