namespace FractalDimension
{
    partial class MainForm
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
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.BCAnswerText = new System.Windows.Forms.TextBox();
            this.BCCalculateButton = new System.Windows.Forms.Button();
            this.CDPanel = new System.Windows.Forms.Panel();
            this.BlackBoundaryInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SetBlackBoundaryButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MDPanel = new System.Windows.Forms.Panel();
            this.MDRelaionButton = new System.Windows.Forms.Button();
            this.MDAnswerText = new System.Windows.Forms.TextBox();
            this.MDCalculateButton = new System.Windows.Forms.Button();
            this.CellSizeInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.SRPanel = new System.Windows.Forms.Panel();
            this.SRCalculateButton = new System.Windows.Forms.Button();
            this.QMaxInput = new System.Windows.Forms.NumericUpDown();
            this.QMinInput = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MFPanel = new System.Windows.Forms.Panel();
            this.EpsilonInput = new System.Windows.Forms.NumericUpDown();
            this.MFPrecalculateButton = new System.Windows.Forms.Button();
            this.alphaMaxText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.alphaMinText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.MFCalculateButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CDPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackBoundaryInput)).BeginInit();
            this.MDPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellSizeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SRPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QMaxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QMinInput)).BeginInit();
            this.MFPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EpsilonInput)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(3, 2);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(342, 28);
            this.LoadImageButton.TabIndex = 0;
            this.LoadImageButton.Text = "Выбрать изображение";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // BCAnswerText
            // 
            this.BCAnswerText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BCAnswerText.Location = new System.Drawing.Point(140, 138);
            this.BCAnswerText.Name = "BCAnswerText";
            this.BCAnswerText.ReadOnly = true;
            this.BCAnswerText.Size = new System.Drawing.Size(197, 22);
            this.BCAnswerText.TabIndex = 1;
            this.BCAnswerText.Text = "Ответ";
            // 
            // BCCalculateButton
            // 
            this.BCCalculateButton.Location = new System.Drawing.Point(3, 133);
            this.BCCalculateButton.Name = "BCCalculateButton";
            this.BCCalculateButton.Size = new System.Drawing.Size(131, 33);
            this.BCCalculateButton.TabIndex = 2;
            this.BCCalculateButton.Text = "Рассчитать";
            this.BCCalculateButton.UseVisualStyleBackColor = true;
            this.BCCalculateButton.Click += new System.EventHandler(this.BCCalculateButton_Click);
            // 
            // CDPanel
            // 
            this.CDPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CDPanel.Controls.Add(this.BlackBoundaryInput);
            this.CDPanel.Controls.Add(this.label2);
            this.CDPanel.Controls.Add(this.SetBlackBoundaryButton);
            this.CDPanel.Controls.Add(this.label1);
            this.CDPanel.Controls.Add(this.BCCalculateButton);
            this.CDPanel.Controls.Add(this.BCAnswerText);
            this.CDPanel.Location = new System.Drawing.Point(3, 36);
            this.CDPanel.Name = "CDPanel";
            this.CDPanel.Size = new System.Drawing.Size(342, 172);
            this.CDPanel.TabIndex = 3;
            // 
            // BlackBoundaryInput
            // 
            this.BlackBoundaryInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlackBoundaryInput.Location = new System.Drawing.Point(158, 61);
            this.BlackBoundaryInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlackBoundaryInput.Name = "BlackBoundaryInput";
            this.BlackBoundaryInput.Size = new System.Drawing.Size(179, 22);
            this.BlackBoundaryInput.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 51);
            this.label2.TabIndex = 3;
            this.label2.Text = "Емкостная размерность с использованием ме-\r\nтода наименьших квадратов для ч/б \r\nи" +
    "зображений\r\n";
            // 
            // SetBlackBoundaryButton
            // 
            this.SetBlackBoundaryButton.Location = new System.Drawing.Point(3, 89);
            this.SetBlackBoundaryButton.Name = "SetBlackBoundaryButton";
            this.SetBlackBoundaryButton.Size = new System.Drawing.Size(334, 33);
            this.SetBlackBoundaryButton.TabIndex = 7;
            this.SetBlackBoundaryButton.Text = "Применить порог";
            this.SetBlackBoundaryButton.UseVisualStyleBackColor = true;
            this.SetBlackBoundaryButton.Click += new System.EventHandler(this.SetBlackBoundaryButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Порог черного цвета";
            // 
            // MDPanel
            // 
            this.MDPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MDPanel.Controls.Add(this.MDRelaionButton);
            this.MDPanel.Controls.Add(this.MDAnswerText);
            this.MDPanel.Controls.Add(this.MDCalculateButton);
            this.MDPanel.Controls.Add(this.CellSizeInput);
            this.MDPanel.Controls.Add(this.label4);
            this.MDPanel.Controls.Add(this.label3);
            this.MDPanel.Location = new System.Drawing.Point(3, 214);
            this.MDPanel.Name = "MDPanel";
            this.MDPanel.Size = new System.Drawing.Size(342, 158);
            this.MDPanel.TabIndex = 4;
            // 
            // MDRelaionButton
            // 
            this.MDRelaionButton.Location = new System.Drawing.Point(3, 119);
            this.MDRelaionButton.Name = "MDRelaionButton";
            this.MDRelaionButton.Size = new System.Drawing.Size(334, 33);
            this.MDRelaionButton.TabIndex = 6;
            this.MDRelaionButton.Text = "Зависимость A delta от размера ячейки";
            this.MDRelaionButton.UseVisualStyleBackColor = true;
            this.MDRelaionButton.Click += new System.EventHandler(this.MDRelaionButton_Click);
            // 
            // MDAnswerText
            // 
            this.MDAnswerText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MDAnswerText.Location = new System.Drawing.Point(140, 83);
            this.MDAnswerText.Name = "MDAnswerText";
            this.MDAnswerText.ReadOnly = true;
            this.MDAnswerText.Size = new System.Drawing.Size(197, 22);
            this.MDAnswerText.TabIndex = 8;
            this.MDAnswerText.Text = "Ответ";
            // 
            // MDCalculateButton
            // 
            this.MDCalculateButton.Location = new System.Drawing.Point(3, 78);
            this.MDCalculateButton.Name = "MDCalculateButton";
            this.MDCalculateButton.Size = new System.Drawing.Size(131, 33);
            this.MDCalculateButton.TabIndex = 6;
            this.MDCalculateButton.Text = "Рассчитать";
            this.MDCalculateButton.UseVisualStyleBackColor = true;
            this.MDCalculateButton.Click += new System.EventHandler(this.MDCalculateButton_Click);
            // 
            // CellSizeInput
            // 
            this.CellSizeInput.Enabled = false;
            this.CellSizeInput.Location = new System.Drawing.Point(158, 43);
            this.CellSizeInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CellSizeInput.Name = "CellSizeInput";
            this.CellSizeInput.Size = new System.Drawing.Size(179, 22);
            this.CellSizeInput.TabIndex = 6;
            this.CellSizeInput.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "N, размер ячейки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 34);
            this.label3.TabIndex = 8;
            this.label3.Text = "Рассчет размерности Минковского для полуто-\r\nновых изображений";
            // 
            // ImageBox
            // 
            this.ImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ImageBox.Location = new System.Drawing.Point(348, 2);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(605, 694);
            this.ImageBox.TabIndex = 5;
            this.ImageBox.TabStop = false;
            // 
            // SRPanel
            // 
            this.SRPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SRPanel.Controls.Add(this.SRCalculateButton);
            this.SRPanel.Controls.Add(this.QMaxInput);
            this.SRPanel.Controls.Add(this.QMinInput);
            this.SRPanel.Controls.Add(this.label7);
            this.SRPanel.Controls.Add(this.label6);
            this.SRPanel.Controls.Add(this.label5);
            this.SRPanel.Location = new System.Drawing.Point(3, 378);
            this.SRPanel.Name = "SRPanel";
            this.SRPanel.Size = new System.Drawing.Size(342, 116);
            this.SRPanel.TabIndex = 6;
            // 
            // SRCalculateButton
            // 
            this.SRCalculateButton.Location = new System.Drawing.Point(3, 77);
            this.SRCalculateButton.Name = "SRCalculateButton";
            this.SRCalculateButton.Size = new System.Drawing.Size(334, 33);
            this.SRCalculateButton.TabIndex = 7;
            this.SRCalculateButton.Text = "Рассчитать";
            this.SRCalculateButton.UseVisualStyleBackColor = true;
            this.SRCalculateButton.Click += new System.EventHandler(this.SRCalculateButton_Click);
            // 
            // QMaxInput
            // 
            this.QMaxInput.Location = new System.Drawing.Point(229, 43);
            this.QMaxInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.QMaxInput.Name = "QMaxInput";
            this.QMaxInput.Size = new System.Drawing.Size(108, 22);
            this.QMaxInput.TabIndex = 7;
            this.QMaxInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.QMaxInput.ValueChanged += new System.EventHandler(this.QMaxInput_ValueChanged);
            // 
            // QMinInput
            // 
            this.QMinInput.Location = new System.Drawing.Point(51, 43);
            this.QMinInput.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.QMinInput.Name = "QMinInput";
            this.QMinInput.Size = new System.Drawing.Size(108, 22);
            this.QMinInput.TabIndex = 7;
            this.QMinInput.ValueChanged += new System.EventHandler(this.QMinInput_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "q max";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "q min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 34);
            this.label5.TabIndex = 7;
            this.label5.Text = "Зависимость спектра Реньи для полутоновых\r\nизображений от параметра q";
            // 
            // MFPanel
            // 
            this.MFPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MFPanel.Controls.Add(this.EpsilonInput);
            this.MFPanel.Controls.Add(this.MFPrecalculateButton);
            this.MFPanel.Controls.Add(this.alphaMaxText);
            this.MFPanel.Controls.Add(this.label11);
            this.MFPanel.Controls.Add(this.alphaMinText);
            this.MFPanel.Controls.Add(this.label10);
            this.MFPanel.Controls.Add(this.MFCalculateButton);
            this.MFPanel.Controls.Add(this.label9);
            this.MFPanel.Controls.Add(this.label8);
            this.MFPanel.Location = new System.Drawing.Point(3, 500);
            this.MFPanel.Name = "MFPanel";
            this.MFPanel.Size = new System.Drawing.Size(342, 196);
            this.MFPanel.TabIndex = 7;
            // 
            // EpsilonInput
            // 
            this.EpsilonInput.DecimalPlaces = 6;
            this.EpsilonInput.Enabled = false;
            this.EpsilonInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.EpsilonInput.Location = new System.Drawing.Point(116, 123);
            this.EpsilonInput.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EpsilonInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.EpsilonInput.Name = "EpsilonInput";
            this.EpsilonInput.Size = new System.Drawing.Size(221, 22);
            this.EpsilonInput.TabIndex = 8;
            this.EpsilonInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            // 
            // MFPrecalculateButton
            // 
            this.MFPrecalculateButton.Location = new System.Drawing.Point(3, 76);
            this.MFPrecalculateButton.Name = "MFPrecalculateButton";
            this.MFPrecalculateButton.Size = new System.Drawing.Size(334, 33);
            this.MFPrecalculateButton.TabIndex = 10;
            this.MFPrecalculateButton.Text = "Рассчитать границы [alphaMin; alphaMax]";
            this.MFPrecalculateButton.UseVisualStyleBackColor = true;
            this.MFPrecalculateButton.Click += new System.EventHandler(this.MFPrecalculateButton_Click);
            // 
            // alphaMaxText
            // 
            this.alphaMaxText.Location = new System.Drawing.Point(204, 41);
            this.alphaMaxText.Name = "alphaMaxText";
            this.alphaMaxText.ReadOnly = true;
            this.alphaMaxText.Size = new System.Drawing.Size(133, 22);
            this.alphaMaxText.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Max";
            // 
            // alphaMinText
            // 
            this.alphaMinText.Location = new System.Drawing.Point(30, 41);
            this.alphaMinText.Name = "alphaMinText";
            this.alphaMinText.ReadOnly = true;
            this.alphaMinText.Size = new System.Drawing.Size(129, 22);
            this.alphaMinText.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Min";
            // 
            // MFCalculateButton
            // 
            this.MFCalculateButton.Enabled = false;
            this.MFCalculateButton.Location = new System.Drawing.Point(3, 158);
            this.MFCalculateButton.Name = "MFCalculateButton";
            this.MFCalculateButton.Size = new System.Drawing.Size(334, 33);
            this.MFCalculateButton.TabIndex = 8;
            this.MFCalculateButton.Text = "Рассчитать";
            this.MFCalculateButton.UseVisualStyleBackColor = true;
            this.MFCalculateButton.Click += new System.EventHandler(this.MFCalculateButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Шаг разбиения";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(313, 34);
            this.label8.TabIndex = 8;
            this.label8.Text = "Мультифрактальный спектр, получаемый при\r\nпомощью локальной \"функции плотности\"";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 708);
            this.Controls.Add(this.MFPanel);
            this.Controls.Add(this.SRPanel);
            this.Controls.Add(this.LoadImageButton);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.MDPanel);
            this.Controls.Add(this.CDPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(974, 755);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рассчет фрактальной размерности";
            this.CDPanel.ResumeLayout(false);
            this.CDPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackBoundaryInput)).EndInit();
            this.MDPanel.ResumeLayout(false);
            this.MDPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellSizeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.SRPanel.ResumeLayout(false);
            this.SRPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QMaxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QMinInput)).EndInit();
            this.MFPanel.ResumeLayout(false);
            this.MFPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EpsilonInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.TextBox BCAnswerText;
        private System.Windows.Forms.Button BCCalculateButton;
        private System.Windows.Forms.Panel CDPanel;
        private System.Windows.Forms.Panel MDPanel;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown BlackBoundaryInput;
        private System.Windows.Forms.Button SetBlackBoundaryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown CellSizeInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button MDCalculateButton;
        private System.Windows.Forms.TextBox MDAnswerText;
        private System.Windows.Forms.Button MDRelaionButton;
        private System.Windows.Forms.Panel SRPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown QMaxInput;
        private System.Windows.Forms.NumericUpDown QMinInput;
        private System.Windows.Forms.Button SRCalculateButton;
        private System.Windows.Forms.Panel MFPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button MFCalculateButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox alphaMinText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox alphaMaxText;
        private System.Windows.Forms.Button MFPrecalculateButton;
        private System.Windows.Forms.NumericUpDown EpsilonInput;
    }
}

