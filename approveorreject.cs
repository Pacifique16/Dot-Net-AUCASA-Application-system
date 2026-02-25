using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace AUCASAPRO_26937
{
	public partial class ApproveOrReject : Form
	{
		string connString = ConfigurationManager.ConnectionStrings["AUCASA"].ConnectionString;
		int selectedStudentID = 0;

		public ApproveOrReject()
		{
			InitializeComponent();
			textBox1.ReadOnly = true;
			textBox2.ReadOnly = true;
			textBox3.ReadOnly = true;
			textBox4.ReadOnly = true;
			textBox5.ReadOnly = true;
			textBox6.ReadOnly = true;
			LoadPendingCandidates();
			button1.Click += Button1_Click;
			button2.Click += Button2_Click;
			dataGridView1.CellClick += DataGridView1_CellClick;
		}

		void LoadPendingCandidates()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlDataAdapter da = new SqlDataAdapter("SELECT c.student_id, c.email, c.fullname, c.department, c.semester, c.current_avg_score, p.position_title, c.description FROM CANDIDATES c LEFT JOIN POSITIONS p ON c.position = p.position_id WHERE c.description='Pending'", conn);
					DataTable dt = new DataTable();
					da.Fill(dt);
					dataGridView1.DataSource = dt;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Button1_Click(object sender, EventArgs e)
		{
			if (selectedStudentID == 0) { MessageBox.Show("Select an application!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			if (MessageBox.Show("Are you sure you want to approve this application?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("UPDATE CANDIDATES SET description='Approved' WHERE student_id=@id", conn);
					cmd.Parameters.AddWithValue("@id", selectedStudentID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Application approved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPendingCandidates();
					ClearFields();
					selectedStudentID = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error approving application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Button2_Click(object sender, EventArgs e)
		{
			if (selectedStudentID == 0) { MessageBox.Show("Select an application!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			if (MessageBox.Show("Are you sure you want to reject this application?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("UPDATE CANDIDATES SET description='Rejected' WHERE student_id=@id", conn);
					cmd.Parameters.AddWithValue("@id", selectedStudentID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Application rejected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPendingCandidates();
					ClearFields();
					selectedStudentID = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error rejecting application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				selectedStudentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["student_id"].Value);
				textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
				textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["fullname"].Value.ToString();
				textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["department"].Value.ToString();
				textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["semester"].Value.ToString();
				textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["current_avg_score"].Value.ToString();
				textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["position_title"].Value.ToString();
			}
		}

		void ClearFields()
		{
			textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
		}
	}
}
