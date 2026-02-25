using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace AUCASAPRO_26937
{
	public partial class Admin : Form
	{
		string connString = ConfigurationManager.ConnectionStrings["AUCASA"].ConnectionString;
		int selectedPositionID = 0;

		public Admin()
		{
			InitializeComponent();
			LoadPositions();
			button1.Click += Button1_Click;
			button2.Click += Button2_Click;
			button3.Click += Button3_Click;
			dataGridView1.CellClick += DataGridView1_CellClick;
		}

		void LoadPositions()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlDataAdapter da = new SqlDataAdapter("SELECT position_id, position_title, position_description FROM POSITIONS", conn);
					DataTable dt = new DataTable();
					da.Fill(dt);
					dataGridView1.DataSource = dt;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading positions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Position title is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("INSERT INTO POSITIONS (position_title, position_description) VALUES (@title, @desc)", conn);
					cmd.Parameters.AddWithValue("@title", textBox1.Text.Trim());
					cmd.Parameters.AddWithValue("@desc", textBox2.Text.Trim());
					cmd.ExecuteNonQuery();
					MessageBox.Show("Position created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPositions();
					textBox1.Clear();
					textBox2.Clear();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error creating position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Button2_Click(object sender, EventArgs e)
		{
			if (selectedPositionID == 0) { MessageBox.Show("Select a position!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Position title is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("UPDATE POSITIONS SET position_title=@title, position_description=@desc WHERE position_id=@id", conn);
					cmd.Parameters.AddWithValue("@title", textBox1.Text.Trim());
					cmd.Parameters.AddWithValue("@desc", textBox2.Text.Trim());
					cmd.Parameters.AddWithValue("@id", selectedPositionID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Position updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPositions();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error updating position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void Button3_Click(object sender, EventArgs e)
		{
			if (selectedPositionID == 0) { MessageBox.Show("Select a position!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
			if (MessageBox.Show("Are you sure you want to delete this position? All related applications will be deleted.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("DELETE FROM POSITIONS WHERE position_id=@id", conn);
					cmd.Parameters.AddWithValue("@id", selectedPositionID);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Position deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPositions();
					textBox1.Clear();
					textBox2.Clear();
					selectedPositionID = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error deleting position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				selectedPositionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["position_id"].Value);
				textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["position_title"].Value.ToString();
				textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["position_description"].Value.ToString();
			}
		}
	}
}
