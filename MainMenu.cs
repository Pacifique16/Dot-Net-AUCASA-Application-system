using System;
using System.Windows.Forms;

namespace AUCASAPRO_26937
{
	public partial class MainMenu : Form
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		private void btnAdmin_Click(object sender, EventArgs e)
		{
			new Admin().Show();
		}

		private void btnStudent_Click(object sender, EventArgs e)
		{
			new ApplicationInterface().Show();
		}

		private void btnApproval_Click(object sender, EventArgs e)
		{
			new ApproveOrReject().Show();
		}

		private void btnDashboard_Click(object sender, EventArgs e)
		{
			new Dashboard().Show();
		}
	}
}
