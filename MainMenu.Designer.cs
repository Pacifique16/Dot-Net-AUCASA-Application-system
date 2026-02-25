namespace AUCASAPRO_26937
{
	partial class MainMenu
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			btnAdmin = new Button();
			btnStudent = new Button();
			btnApproval = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// btnAdmin
			// 
			btnAdmin.BackColor = Color.RosyBrown;
			btnAdmin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			btnAdmin.Location = new Point(100, 100);
			btnAdmin.Name = "btnAdmin";
			btnAdmin.Size = new Size(250, 50);
			btnAdmin.TabIndex = 0;
			btnAdmin.Text = "Position Management";
			btnAdmin.UseVisualStyleBackColor = false;
			btnAdmin.Click += btnAdmin_Click;
			// 
			// btnStudent
			// 
			btnStudent.BackColor = Color.FromArgb(255, 192, 192);
			btnStudent.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			btnStudent.Location = new Point(100, 170);
			btnStudent.Name = "btnStudent";
			btnStudent.Size = new Size(250, 50);
			btnStudent.TabIndex = 1;
			btnStudent.Text = "Student Application";
			btnStudent.UseVisualStyleBackColor = false;
			btnStudent.Click += btnStudent_Click;
			// 
			// btnApproval
			// 
			btnApproval.BackColor = Color.FromArgb(128, 255, 128);
			btnApproval.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			btnApproval.Location = new Point(100, 240);
			btnApproval.Name = "btnApproval";
			btnApproval.Size = new Size(250, 50);
			btnApproval.TabIndex = 2;
			btnApproval.Text = "Approve/Reject";
			btnApproval.UseVisualStyleBackColor = false;
			btnApproval.Click += btnApproval_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
			label1.Location = new Point(50, 30);
			label1.Name = "label1";
			label1.Size = new Size(350, 31);
			label1.TabIndex = 3;
			label1.Text = "AUCA Application System";
			// 
			// MainMenu
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(450, 350);
			Controls.Add(label1);
			Controls.Add(btnApproval);
			Controls.Add(btnStudent);
			Controls.Add(btnAdmin);
			Name = "MainMenu";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Main Menu";
			ResumeLayout(false);
			PerformLayout();
		}

		private Button btnAdmin;
		private Button btnStudent;
		private Button btnApproval;
		private Label label1;
	}
}
