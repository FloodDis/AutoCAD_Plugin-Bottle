namespace AutoCAD_Plugin_Bottle.View
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.LengthLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.MainHeightLabel = new System.Windows.Forms.Label();
            this.NeckHeightLabel = new System.Windows.Forms.Label();
            this.NeckRadiusLabel = new System.Windows.Forms.Label();
            this.MainLengthTextBox = new System.Windows.Forms.TextBox();
            this.MainWidthTextBox = new System.Windows.Forms.TextBox();
            this.MainHeightTextBox = new System.Windows.Forms.TextBox();
            this.NeckHeightTextBox = new System.Windows.Forms.TextBox();
            this.NeckRadiusTextBox = new System.Windows.Forms.TextBox();
            this.LengthRangeLabel = new System.Windows.Forms.Label();
            this.WidthRangeLabel = new System.Windows.Forms.Label();
            this.MainHeightRangeLabel = new System.Windows.Forms.Label();
            this.NeckHeightRangeLabel = new System.Windows.Forms.Label();
            this.NeckRadiusRangeLabel = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.NeckLengthLablel = new System.Windows.Forms.Label();
            this.NeckLengthTextBox = new System.Windows.Forms.TextBox();
            this.NeckWidthLabel = new System.Windows.Forms.Label();
            this.NeckWidthTextBox = new System.Windows.Forms.TextBox();
            this.MainRadiusLabel = new System.Windows.Forms.Label();
            this.MainRadiusTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RoundMainRadioButton = new System.Windows.Forms.RadioButton();
            this.MainPartFormGroupBox = new System.Windows.Forms.GroupBox();
            this.RectangleMainRadioButton = new System.Windows.Forms.RadioButton();
            this.NeckFormGroupBox = new System.Windows.Forms.GroupBox();
            this.RectangleNeckRadioButton = new System.Windows.Forms.RadioButton();
            this.RoundNeckRadioButton = new System.Windows.Forms.RadioButton();
            this.MainPartFormGroupBox.SuspendLayout();
            this.NeckFormGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(29, 29);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(40, 13);
            this.LengthLabel.TabIndex = 0;
            this.LengthLabel.Text = "Длина";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(29, 62);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(46, 13);
            this.WidthLabel.TabIndex = 1;
            this.WidthLabel.Text = "Ширина";
            // 
            // MainHeightLabel
            // 
            this.MainHeightLabel.AutoSize = true;
            this.MainHeightLabel.Location = new System.Drawing.Point(29, 96);
            this.MainHeightLabel.Name = "MainHeightLabel";
            this.MainHeightLabel.Size = new System.Drawing.Size(127, 13);
            this.MainHeightLabel.TabIndex = 2;
            this.MainHeightLabel.Text = "Высота основной части";
            // 
            // NeckHeightLabel
            // 
            this.NeckHeightLabel.AutoSize = true;
            this.NeckHeightLabel.Location = new System.Drawing.Point(29, 129);
            this.NeckHeightLabel.Name = "NeckHeightLabel";
            this.NeckHeightLabel.Size = new System.Drawing.Size(99, 13);
            this.NeckHeightLabel.TabIndex = 3;
            this.NeckHeightLabel.Text = "Высота горлышка";
            // 
            // NeckRadiusLabel
            // 
            this.NeckRadiusLabel.AutoSize = true;
            this.NeckRadiusLabel.Location = new System.Drawing.Point(29, 164);
            this.NeckRadiusLabel.Name = "NeckRadiusLabel";
            this.NeckRadiusLabel.Size = new System.Drawing.Size(97, 13);
            this.NeckRadiusLabel.TabIndex = 4;
            this.NeckRadiusLabel.Text = "Радиус горлышка";
            // 
            // MainLengthTextBox
            // 
            this.MainLengthTextBox.BackColor = System.Drawing.Color.White;
            this.MainLengthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLengthTextBox.Location = new System.Drawing.Point(175, 26);
            this.MainLengthTextBox.Name = "MainLengthTextBox";
            this.MainLengthTextBox.Size = new System.Drawing.Size(72, 20);
            this.MainLengthTextBox.TabIndex = 5;
            this.MainLengthTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.MainLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // MainWidthTextBox
            // 
            this.MainWidthTextBox.BackColor = System.Drawing.Color.White;
            this.MainWidthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainWidthTextBox.Location = new System.Drawing.Point(175, 59);
            this.MainWidthTextBox.Name = "MainWidthTextBox";
            this.MainWidthTextBox.Size = new System.Drawing.Size(72, 20);
            this.MainWidthTextBox.TabIndex = 6;
            this.MainWidthTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.MainWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // MainHeightTextBox
            // 
            this.MainHeightTextBox.BackColor = System.Drawing.Color.White;
            this.MainHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainHeightTextBox.Location = new System.Drawing.Point(175, 93);
            this.MainHeightTextBox.Name = "MainHeightTextBox";
            this.MainHeightTextBox.Size = new System.Drawing.Size(72, 20);
            this.MainHeightTextBox.TabIndex = 7;
            this.MainHeightTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.MainHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // NeckHeightTextBox
            // 
            this.NeckHeightTextBox.BackColor = System.Drawing.Color.White;
            this.NeckHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NeckHeightTextBox.Location = new System.Drawing.Point(175, 126);
            this.NeckHeightTextBox.Name = "NeckHeightTextBox";
            this.NeckHeightTextBox.Size = new System.Drawing.Size(72, 20);
            this.NeckHeightTextBox.TabIndex = 8;
            this.NeckHeightTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.NeckHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // NeckRadiusTextBox
            // 
            this.NeckRadiusTextBox.BackColor = System.Drawing.Color.White;
            this.NeckRadiusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NeckRadiusTextBox.Location = new System.Drawing.Point(175, 164);
            this.NeckRadiusTextBox.Name = "NeckRadiusTextBox";
            this.NeckRadiusTextBox.Size = new System.Drawing.Size(72, 20);
            this.NeckRadiusTextBox.TabIndex = 9;
            this.NeckRadiusTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.NeckRadiusTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // LengthRangeLabel
            // 
            this.LengthRangeLabel.AutoSize = true;
            this.LengthRangeLabel.Location = new System.Drawing.Point(271, 29);
            this.LengthRangeLabel.Name = "LengthRangeLabel";
            this.LengthRangeLabel.Size = new System.Drawing.Size(59, 13);
            this.LengthRangeLabel.TabIndex = 10;
            this.LengthRangeLabel.Text = "10-250 мм";
            // 
            // WidthRangeLabel
            // 
            this.WidthRangeLabel.AutoSize = true;
            this.WidthRangeLabel.Location = new System.Drawing.Point(271, 62);
            this.WidthRangeLabel.Name = "WidthRangeLabel";
            this.WidthRangeLabel.Size = new System.Drawing.Size(59, 13);
            this.WidthRangeLabel.TabIndex = 11;
            this.WidthRangeLabel.Text = "10-250 мм";
            // 
            // MainHeightRangeLabel
            // 
            this.MainHeightRangeLabel.AutoSize = true;
            this.MainHeightRangeLabel.Location = new System.Drawing.Point(271, 96);
            this.MainHeightRangeLabel.Name = "MainHeightRangeLabel";
            this.MainHeightRangeLabel.Size = new System.Drawing.Size(59, 13);
            this.MainHeightRangeLabel.TabIndex = 12;
            this.MainHeightRangeLabel.Text = "10-250 мм";
            // 
            // NeckHeightRangeLabel
            // 
            this.NeckHeightRangeLabel.AutoSize = true;
            this.NeckHeightRangeLabel.Location = new System.Drawing.Point(271, 129);
            this.NeckHeightRangeLabel.Name = "NeckHeightRangeLabel";
            this.NeckHeightRangeLabel.Size = new System.Drawing.Size(53, 13);
            this.NeckHeightRangeLabel.TabIndex = 13;
            this.NeckHeightRangeLabel.Text = "10-40 мм";
            // 
            // NeckRadiusRangeLabel
            // 
            this.NeckRadiusRangeLabel.AutoSize = true;
            this.NeckRadiusRangeLabel.Location = new System.Drawing.Point(271, 164);
            this.NeckRadiusRangeLabel.Name = "NeckRadiusRangeLabel";
            this.NeckRadiusRangeLabel.Size = new System.Drawing.Size(47, 13);
            this.NeckRadiusRangeLabel.TabIndex = 14;
            this.NeckRadiusRangeLabel.Text = "5-20 мм";
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CreateButton.Location = new System.Drawing.Point(127, 387);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(106, 35);
            this.CreateButton.TabIndex = 15;
            this.CreateButton.Text = "Построить";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // NeckLengthLablel
            // 
            this.NeckLengthLablel.AutoSize = true;
            this.NeckLengthLablel.Location = new System.Drawing.Point(29, 200);
            this.NeckLengthLablel.Name = "NeckLengthLablel";
            this.NeckLengthLablel.Size = new System.Drawing.Size(94, 13);
            this.NeckLengthLablel.TabIndex = 16;
            this.NeckLengthLablel.Text = "Длина горлышка";
            this.NeckLengthLablel.Visible = false;
            // 
            // NeckLengthTextBox
            // 
            this.NeckLengthTextBox.BackColor = System.Drawing.Color.White;
            this.NeckLengthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NeckLengthTextBox.Location = new System.Drawing.Point(175, 198);
            this.NeckLengthTextBox.Name = "NeckLengthTextBox";
            this.NeckLengthTextBox.Size = new System.Drawing.Size(72, 20);
            this.NeckLengthTextBox.TabIndex = 17;
            this.NeckLengthTextBox.Visible = false;
            // 
            // NeckWidthLabel
            // 
            this.NeckWidthLabel.AutoSize = true;
            this.NeckWidthLabel.Location = new System.Drawing.Point(29, 236);
            this.NeckWidthLabel.Name = "NeckWidthLabel";
            this.NeckWidthLabel.Size = new System.Drawing.Size(100, 13);
            this.NeckWidthLabel.TabIndex = 18;
            this.NeckWidthLabel.Text = "Ширина горлышка";
            this.NeckWidthLabel.Visible = false;
            // 
            // NeckWidthTextBox
            // 
            this.NeckWidthTextBox.BackColor = System.Drawing.Color.White;
            this.NeckWidthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NeckWidthTextBox.Location = new System.Drawing.Point(175, 234);
            this.NeckWidthTextBox.Name = "NeckWidthTextBox";
            this.NeckWidthTextBox.Size = new System.Drawing.Size(72, 20);
            this.NeckWidthTextBox.TabIndex = 19;
            this.NeckWidthTextBox.Visible = false;
            // 
            // MainRadiusLabel
            // 
            this.MainRadiusLabel.AutoSize = true;
            this.MainRadiusLabel.Location = new System.Drawing.Point(29, 274);
            this.MainRadiusLabel.Name = "MainRadiusLabel";
            this.MainRadiusLabel.Size = new System.Drawing.Size(125, 13);
            this.MainRadiusLabel.TabIndex = 20;
            this.MainRadiusLabel.Text = "Радиус основной части";
            this.MainRadiusLabel.Visible = false;
            // 
            // MainRadiusTextBox
            // 
            this.MainRadiusTextBox.BackColor = System.Drawing.Color.White;
            this.MainRadiusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainRadiusTextBox.Location = new System.Drawing.Point(175, 272);
            this.MainRadiusTextBox.Name = "MainRadiusTextBox";
            this.MainRadiusTextBox.Size = new System.Drawing.Size(72, 20);
            this.MainRadiusTextBox.TabIndex = 21;
            this.MainRadiusTextBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "5-20 мм";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "5-20 мм";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "10-250 мм";
            this.label3.Visible = false;
            // 
            // RoundMainRadioButton
            // 
            this.RoundMainRadioButton.AutoSize = true;
            this.RoundMainRadioButton.Location = new System.Drawing.Point(6, 19);
            this.RoundMainRadioButton.Name = "RoundMainRadioButton";
            this.RoundMainRadioButton.Size = new System.Drawing.Size(87, 17);
            this.RoundMainRadioButton.TabIndex = 25;
            this.RoundMainRadioButton.TabStop = true;
            this.RoundMainRadioButton.Text = "Окружность";
            this.RoundMainRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainPartFormGroupBox
            // 
            this.MainPartFormGroupBox.Controls.Add(this.RectangleMainRadioButton);
            this.MainPartFormGroupBox.Controls.Add(this.RoundMainRadioButton);
            this.MainPartFormGroupBox.Location = new System.Drawing.Point(32, 310);
            this.MainPartFormGroupBox.Name = "MainPartFormGroupBox";
            this.MainPartFormGroupBox.Size = new System.Drawing.Size(134, 71);
            this.MainPartFormGroupBox.TabIndex = 27;
            this.MainPartFormGroupBox.TabStop = false;
            this.MainPartFormGroupBox.Text = "Форма главной части";
            // 
            // RectangleMainRadioButton
            // 
            this.RectangleMainRadioButton.AutoSize = true;
            this.RectangleMainRadioButton.Location = new System.Drawing.Point(6, 42);
            this.RectangleMainRadioButton.Name = "RectangleMainRadioButton";
            this.RectangleMainRadioButton.Size = new System.Drawing.Size(105, 17);
            this.RectangleMainRadioButton.TabIndex = 26;
            this.RectangleMainRadioButton.TabStop = true;
            this.RectangleMainRadioButton.Text = "Прямоугольник";
            this.RectangleMainRadioButton.UseVisualStyleBackColor = true;
            // 
            // NeckFormGroupBox
            // 
            this.NeckFormGroupBox.Controls.Add(this.RectangleNeckRadioButton);
            this.NeckFormGroupBox.Controls.Add(this.RoundNeckRadioButton);
            this.NeckFormGroupBox.Location = new System.Drawing.Point(175, 310);
            this.NeckFormGroupBox.Name = "NeckFormGroupBox";
            this.NeckFormGroupBox.Size = new System.Drawing.Size(134, 71);
            this.NeckFormGroupBox.TabIndex = 28;
            this.NeckFormGroupBox.TabStop = false;
            this.NeckFormGroupBox.Text = "Форма горлышка";
            // 
            // RectangleNeckRadioButton
            // 
            this.RectangleNeckRadioButton.AutoSize = true;
            this.RectangleNeckRadioButton.Location = new System.Drawing.Point(6, 42);
            this.RectangleNeckRadioButton.Name = "RectangleNeckRadioButton";
            this.RectangleNeckRadioButton.Size = new System.Drawing.Size(105, 17);
            this.RectangleNeckRadioButton.TabIndex = 26;
            this.RectangleNeckRadioButton.TabStop = true;
            this.RectangleNeckRadioButton.Text = "Прямоугольник";
            this.RectangleNeckRadioButton.UseVisualStyleBackColor = true;
            // 
            // RoundNeckRadioButton
            // 
            this.RoundNeckRadioButton.AutoSize = true;
            this.RoundNeckRadioButton.Location = new System.Drawing.Point(6, 19);
            this.RoundNeckRadioButton.Name = "RoundNeckRadioButton";
            this.RoundNeckRadioButton.Size = new System.Drawing.Size(87, 17);
            this.RoundNeckRadioButton.TabIndex = 25;
            this.RoundNeckRadioButton.TabStop = true;
            this.RoundNeckRadioButton.Text = "Окружность";
            this.RoundNeckRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(359, 434);
            this.Controls.Add(this.NeckFormGroupBox);
            this.Controls.Add(this.MainPartFormGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainRadiusTextBox);
            this.Controls.Add(this.MainRadiusLabel);
            this.Controls.Add(this.NeckWidthTextBox);
            this.Controls.Add(this.NeckWidthLabel);
            this.Controls.Add(this.NeckLengthTextBox);
            this.Controls.Add(this.NeckLengthLablel);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.NeckRadiusRangeLabel);
            this.Controls.Add(this.NeckHeightRangeLabel);
            this.Controls.Add(this.MainHeightRangeLabel);
            this.Controls.Add(this.WidthRangeLabel);
            this.Controls.Add(this.LengthRangeLabel);
            this.Controls.Add(this.NeckRadiusTextBox);
            this.Controls.Add(this.NeckHeightTextBox);
            this.Controls.Add(this.MainHeightTextBox);
            this.Controls.Add(this.MainWidthTextBox);
            this.Controls.Add(this.MainLengthTextBox);
            this.Controls.Add(this.NeckRadiusLabel);
            this.Controls.Add(this.NeckHeightLabel);
            this.Controls.Add(this.MainHeightLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.LengthLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Бутылка";
            this.MainPartFormGroupBox.ResumeLayout(false);
            this.MainPartFormGroupBox.PerformLayout();
            this.NeckFormGroupBox.ResumeLayout(false);
            this.NeckFormGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LengthLabel;
		private System.Windows.Forms.Label WidthLabel;
		private System.Windows.Forms.Label MainHeightLabel;
		private System.Windows.Forms.Label NeckHeightLabel;
		private System.Windows.Forms.Label NeckRadiusLabel;
		private System.Windows.Forms.TextBox MainLengthTextBox;
		private System.Windows.Forms.TextBox MainWidthTextBox;
		private System.Windows.Forms.TextBox MainHeightTextBox;
		private System.Windows.Forms.TextBox NeckHeightTextBox;
		private System.Windows.Forms.TextBox NeckRadiusTextBox;
		private System.Windows.Forms.Label LengthRangeLabel;
		private System.Windows.Forms.Label WidthRangeLabel;
		private System.Windows.Forms.Label MainHeightRangeLabel;
		private System.Windows.Forms.Label NeckHeightRangeLabel;
		private System.Windows.Forms.Label NeckRadiusRangeLabel;
		private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label NeckLengthLablel;
        private System.Windows.Forms.TextBox NeckLengthTextBox;
        private System.Windows.Forms.Label NeckWidthLabel;
        private System.Windows.Forms.TextBox NeckWidthTextBox;
        private System.Windows.Forms.Label MainRadiusLabel;
        private System.Windows.Forms.TextBox MainRadiusTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RoundMainRadioButton;
        private System.Windows.Forms.GroupBox MainPartFormGroupBox;
        private System.Windows.Forms.RadioButton RectangleMainRadioButton;
        private System.Windows.Forms.GroupBox NeckFormGroupBox;
        private System.Windows.Forms.RadioButton RectangleNeckRadioButton;
        private System.Windows.Forms.RadioButton RoundNeckRadioButton;
    }
}

