using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace AUCASAPRO_26937
{
	public partial class ApplicationInterface : Form
	{
		string connString = ConfigurationManager.ConnectionStrings["AUCASA"].ConnectionString;
		int selectedStudentID = 0;

		public ApplicationInterface()
		{
			InitializeComponent();
			LoadCandidates();
			LoadPositions();
			button1.Click += Button1_Click;
			button2.Click += Button2_Click;
			button3.Click += Button3_Click;
			button4.Click += Button4_Click;
			dataGridView1.CellClick += DataGridView1_CellClick;
		}

		void LoadCandidates()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlDataAdapter da = new SqlDataAdapter("SELECT c.student_id, c.email, c.fullname, c.department, c.semester, c.current_avg_score, p.position_title, c.description FROM CANDIDATES c LEFT JOIN POSITIONS p ON c.position = p.position_id", conn);
					DataTable dt = new DataTable();
					da.Fill(dt);
					dataGridView1.DataSource = dt;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading candidates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void LoadPositions()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT position_title FROM POSITIONS", conn);
					SqlDataReader reader = cmd.ExecuteReader();
					textBox6.Items.Clear();
					while (reader.Read()) textBox6.Items.Add(reader["position_title"].ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading positions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		bool IsValidEmail(string email)
		{
			return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
		}

		void Button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || 
			    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || 
			    string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
			{
				MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (!IsValidEmail(textBox1.Text))
			{
				MessageBox.Show("Invalid email format!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (!int.TryParse(textBox4.Text, out int semester))
			{
				MessageBox.Show("Semester must be a number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (semester < 4)
			{
				MessageBox.Show("Students under semester 4 cannot apply!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (!decimal.TryParse(textBox5.Text, out decimal avg))
			{
				MessageBox.Show("Average must be a number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (avg < 15)
			{
				MessageBox.Show("Average must be 15 or above to apply!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT position_id FROM POSITIONS WHERE position_title=@title", conn);
					cmd.Parameters.AddWithValue("@title", textBox6.Text);
					object result = cmd.ExecuteScalar();
					if (result == null) { MessageBox.Show("Select a position!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
					int positionID = Convert.ToInt32(result);
					cmd = new SqlCommand("SELECT COUNT(*) FROM CANDIDATES WHERE email=@email AND position=@pos", conn);
					cmd.Parameters.AddWithValue("@email", textBox1.Text.Trim());
					cmd.Parameters.AddWithValue("@pos", positionID);
					if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
					{
						MessageBox.Show("You have already applied to this position!", "Duplicate Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					cmd = new SqlCommand("INSERT INTO CANDIDATES (email, fullname, department, semester, current_avg_score, position, description) VALUES (@email, @name, @dept, @sem, @avg, @pos, @desc)", conn);
					cmd.Parameters.AddWithValue("@email", textBox1.Text.Trim());
					cmd.Parameters.AddWithValue("@name", textBox2.Text.Trim());
					cmd.Parameters.AddWithValue("@dept", textBox3.Text.Trim());
					cmd.Parameters.AddWithValue("@sem", textBox4.Text);
					cmd.Parameters.AddWithValue("@avg", textBox5.Text);
					cmd.Parameters.AddWithValue("@pos", positionID);
					cmd.Parameters.AddWithValue("@desc", "Pending");
					cmd.ExecuteNonQuery();
					MessageBox.Show("Application submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadCandidates();
					ClearFields();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error submitting application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Button2_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Enter email to check!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT c.email, c.fullname, c.department, c.semester, c.current_avg_score, p.position_title, c.description FROM CANDIDATES c LEFT JOIN POSITIONS p ON c.position = p.position_id WHERE c.email=@email", conn);
					cmd.Parameters.AddWithValue("@email", textBox1.Text.Trim());
					SqlDataReader reader = cmd.ExecuteReader();
					if (reader.Read())
					{
						textBox2.Text = reader["fullname"].ToString();
						textBox3.Text = reader["department"].ToString();
						textBox4.Text = reader["semester"].ToString();
						textBox5.Text = reader["current_avg_score"].ToString();
						textBox6.Text = reader["position_title"].ToString();
						MessageBox.Show($"Status: {reader["description"]}", "Application Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else MessageBox.Show("No application found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error checking application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Button3_Click(object sender, EventArgs e)
		{
			if (selectedStudentID == 0) { MessageBox.Show("Select an application!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			if (MessageBox.Show("Are you sure you want to cancel this application?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("DELETE FROM CANDIDATES WHERE student_id=@id", conn);
					cmd.Parameters.AddWithValue("@id", selectedStudentID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Application cancelled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadCandidates();
					ClearFields();
					selectedStudentID = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error cancelling application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Button4_Click(object sender, EventArgs e)
		{
			if (selectedStudentID == 0) { MessageBox.Show("Select an application!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || 
			    string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
			{
				MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT position_id FROM POSITIONS WHERE position_title=@title", conn);
					cmd.Parameters.AddWithValue("@title", textBox6.Text);
					int positionID = Convert.ToInt32(cmd.ExecuteScalar());
					cmd = new SqlCommand("UPDATE CANDIDATES SET fullname=@name, department=@dept, semester=@sem, current_avg_score=@avg, position=@pos WHERE student_id=@id", conn);
					cmd.Parameters.AddWithValue("@name", textBox2.Text.Trim());
					cmd.Parameters.AddWithValue("@dept", textBox3.Text.Trim());
					cmd.Parameters.AddWithValue("@sem", textBox4.Text);
					cmd.Parameters.AddWithValue("@avg", textBox5.Text);
					cmd.Parameters.AddWithValue("@pos", positionID);
					cmd.Parameters.AddWithValue("@id", selectedStudentID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Application updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadCandidates();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error updating application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			textBox1.Clear(); textBox2.Clear(); textBox3.Text = ""; textBox4.Clear(); textBox5.Clear(); textBox6.Text = "";
		}
	}
}
