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
			this.LengthTextBox = new System.Windows.Forms.TextBox();
			this.WidthTextBox = new System.Windows.Forms.TextBox();
			this.MainHeightTextBox = new System.Windows.Forms.TextBox();
			this.NeckHeightTextBox = new System.Windows.Forms.TextBox();
			this.NeckRadiusTextBox = new System.Windows.Forms.TextBox();
			this.LengthRangeLabel = new System.Windows.Forms.Label();
			this.WidthRangeLabel = new System.Windows.Forms.Label();
			this.MainHeightRangeLabel = new System.Windows.Forms.Label();
			this.NeckHeightRangeLabel = new System.Windows.Forms.Label();
			this.NeckRadiusRangeLabel = new System.Windows.Forms.Label();
			this.CreateButton = new System.Windows.Forms.Button();
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
			// LengthTextBox
			// 
			this.LengthTextBox.Location = new System.Drawing.Point(175, 26);
			this.LengthTextBox.Name = "LengthTextBox";
			this.LengthTextBox.Size = new System.Drawing.Size(73, 20);
			this.LengthTextBox.TabIndex = 5;
			this.LengthTextBox.TextChanged += new System.EventHandler(this.LengthTextBox_TextChanged);
			this.LengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthTextBox_KeyPress);
			// 
			// WidthTextBox
			// 
			this.WidthTextBox.Location = new System.Drawing.Point(175, 59);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.Size = new System.Drawing.Size(73, 20);
			this.WidthTextBox.TabIndex = 6;
			this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
			// 
			// MainHeightTextBox
			// 
			this.MainHeightTextBox.Location = new System.Drawing.Point(175, 93);
			this.MainHeightTextBox.Name = "MainHeightTextBox";
			this.MainHeightTextBox.Size = new System.Drawing.Size(73, 20);
			this.MainHeightTextBox.TabIndex = 7;
			this.MainHeightTextBox.TextChanged += new System.EventHandler(this.MainHeightTextBox_TextChanged);
			// 
			// NeckHeightTextBox
			// 
			this.NeckHeightTextBox.Location = new System.Drawing.Point(175, 126);
			this.NeckHeightTextBox.Name = "NeckHeightTextBox";
			this.NeckHeightTextBox.Size = new System.Drawing.Size(73, 20);
			this.NeckHeightTextBox.TabIndex = 8;
			this.NeckHeightTextBox.TextChanged += new System.EventHandler(this.NeckHeightTextBox_TextChanged);
			// 
			// NeckRadiusTextBox
			// 
			this.NeckRadiusTextBox.Location = new System.Drawing.Point(175, 164);
			this.NeckRadiusTextBox.Name = "NeckRadiusTextBox";
			this.NeckRadiusTextBox.Size = new System.Drawing.Size(73, 20);
			this.NeckRadiusTextBox.TabIndex = 9;
			this.NeckRadiusTextBox.TextChanged += new System.EventHandler(this.NeckRadiusTextBox_TextChanged);
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
			this.CreateButton.Location = new System.Drawing.Point(125, 202);
			this.CreateButton.Name = "CreateButton";
			this.CreateButton.Size = new System.Drawing.Size(106, 35);
			this.CreateButton.TabIndex = 15;
			this.CreateButton.Text = "Построить";
			this.CreateButton.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 249);
			this.Controls.Add(this.CreateButton);
			this.Controls.Add(this.NeckRadiusRangeLabel);
			this.Controls.Add(this.NeckHeightRangeLabel);
			this.Controls.Add(this.MainHeightRangeLabel);
			this.Controls.Add(this.WidthRangeLabel);
			this.Controls.Add(this.LengthRangeLabel);
			this.Controls.Add(this.NeckRadiusTextBox);
			this.Controls.Add(this.NeckHeightTextBox);
			this.Controls.Add(this.MainHeightTextBox);
			this.Controls.Add(this.WidthTextBox);
			this.Controls.Add(this.LengthTextBox);
			this.Controls.Add(this.NeckRadiusLabel);
			this.Controls.Add(this.NeckHeightLabel);
			this.Controls.Add(this.MainHeightLabel);
			this.Controls.Add(this.WidthLabel);
			this.Controls.Add(this.LengthLabel);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.Text = "Бутылка";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LengthLabel;
		private System.Windows.Forms.Label WidthLabel;
		private System.Windows.Forms.Label MainHeightLabel;
		private System.Windows.Forms.Label NeckHeightLabel;
		private System.Windows.Forms.Label NeckRadiusLabel;
		private System.Windows.Forms.TextBox LengthTextBox;
		private System.Windows.Forms.TextBox WidthTextBox;
		private System.Windows.Forms.TextBox MainHeightTextBox;
		private System.Windows.Forms.TextBox NeckHeightTextBox;
		private System.Windows.Forms.TextBox NeckRadiusTextBox;
		private System.Windows.Forms.Label LengthRangeLabel;
		private System.Windows.Forms.Label WidthRangeLabel;
		private System.Windows.Forms.Label MainHeightRangeLabel;
		private System.Windows.Forms.Label NeckHeightRangeLabel;
		private System.Windows.Forms.Label NeckRadiusRangeLabel;
		private System.Windows.Forms.Button CreateButton;
	}
}

