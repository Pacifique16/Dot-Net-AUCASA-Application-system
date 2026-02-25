namespace AUCASAPRO_26937
{
	partial class Admin
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
			label1 = new Label();
			label2 = new Label();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			dataGridView1 = new DataGridView();
			label3 = new Label();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(72, 65);
			label1.Name = "label1";
			label1.Size = new Size(94, 20);
			label1.TabIndex = 0;
			label1.Text = "Position Title:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(72, 114);
			label2.Name = "label2";
			label2.Size = new Size(139, 20);
			label2.TabIndex = 1;
			label2.Text = "Position Description:";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(224, 62);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(199, 27);
			textBox1.TabIndex = 2;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(224, 114);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(199, 27);
			textBox2.TabIndex = 3;
			// 
			// button1
			// 
			button1.BackColor = Color.RosyBrown;
			button1.Location = new Point(522, 65);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 4;
			button1.Text = "CREATE";
			button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			button2.Location = new Point(522, 116);
			button2.Name = "button2";
			button2.Size = new Size(94, 29);
			button2.TabIndex = 5;
			button2.Text = "UPDATE";
			button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			button3.BackColor = Color.IndianRed;
			button3.Location = new Point(522, 167);
			button3.Name = "button3";
			button3.Size = new Size(94, 29);
			button3.TabIndex = 6;
			button3.Text = "DELETE";
			button3.UseVisualStyleBackColor = false;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(97, 248);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(519, 188);
			dataGridView1.TabIndex = 7;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(277, 9);
			label3.Name = "label3";
			label3.Size = new Size(254, 25);
			label3.TabIndex = 8;
			label3.Text = "POSITION CREATION";
			// 
			// admin
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(label3);
			Controls.Add(dataGridView1);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "Admin";
			Text = "Admin";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private TextBox textBox1;
		private TextBox textBox2;
		private Button button1;
		private Button button2;
		private Button button3;
		private DataGridView dataGridView1;
		private Label label3;
	}
}
