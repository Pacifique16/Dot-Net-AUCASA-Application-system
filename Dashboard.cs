using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace AUCASAPRO_26937
{
	public partial class Dashboard : Form
	{
		string connString = ConfigurationManager.ConnectionStrings["AUCASA"].ConnectionString;

		public Dashboard()
		{
			InitializeComponent();
			LoadStatistics();
		}

		void LoadStatistics()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					
					// Total Applications
					SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM CANDIDATES", conn);
					int totalApps = (int)cmd1.ExecuteScalar();
					label2.Text = totalApps.ToString();
					
					// Pending Applications
					SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM CANDIDATES WHERE description='Pending'", conn);
					int pending = (int)cmd2.ExecuteScalar();
					label4.Text = pending.ToString();
					
					// Approved Applications
					SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM CANDIDATES WHERE description='Approved'", conn);
					int approved = (int)cmd3.ExecuteScalar();
					label6.Text = approved.ToString();
					
					// Rejected Applications
					SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM CANDIDATES WHERE description='Rejected'", conn);
					int rejected = (int)cmd4.ExecuteScalar();
					label8.Text = rejected.ToString();
					
					// Total Positions
					SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM POSITIONS", conn);
					int positions = (int)cmd5.ExecuteScalar();
					label10.Text = positions.ToString();
					
					// Applications by Department
					SqlDataAdapter da1 = new SqlDataAdapter("SELECT department AS Department, COUNT(*) as Total FROM CANDIDATES GROUP BY department", conn);
					DataTable dt1 = new DataTable();
					da1.Fill(dt1);
					dataGridView1.DataSource = dt1;
					
					// Applications by Position
					SqlDataAdapter da2 = new SqlDataAdapter("SELECT p.position_title AS Position, COUNT(c.student_id) as Applications FROM POSITIONS p LEFT JOIN CANDIDATES c ON p.position_id = c.position GROUP BY p.position_title", conn);
					DataTable dt2 = new DataTable();
					da2.Fill(dt2);
					dataGridView2.DataSource = dt2;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
