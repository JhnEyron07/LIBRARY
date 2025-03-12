using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY
{
    public partial class BORROWINGRECORDS : Form
    {
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=librarydb;";
        private string selectedRecordId = string.Empty; // Store selected Record_Id
        public BORROWINGRECORDS()
        {
            InitializeComponent();
        }
        QUERIES queries = new QUERIES();
        private void BORROWINGRECORDS_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = queries.Fetchborrowrecords();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Record_Id"].Value != null)
            {
                selectedRecordId = dataGridView1.Rows[e.RowIndex].Cells["Record_Id"].Value.ToString();
                MessageBox.Show("Selected Record ID: " + selectedRecordId); // Debugging
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedRecordId))
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM borrowrecords WHERE Record_Id = @RecordId";

                            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@RecordId", selectedRecordId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dataGridView1.DataSource = queries.Fetchborrowrecords(); // Refresh DataGridView
                                    selectedRecordId = string.Empty; // Reset selection
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

    }
}
