using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reminder
{
    public partial class frmTaskView : Form
    {
        SqlConnection con;
        DataGridViewRow row;

        public frmTaskView()
        {
            InitializeComponent();
        }

        private void frmTaskView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reminderDataSet.tbl_reminder' table. You can move, or remove it, as needed.
            this.tbl_reminderTableAdapter.Fill(this.reminderDataSet.tbl_reminder);

        }

  

        private void frmTaskView_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reminderDataSet1.tbl_reminder' table. You can move, or remove it, as needed.
            this.tbl_reminderTableAdapter1.Fill(this.reminderDataSet1.tbl_reminder);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                row = this.dataGridView2.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtTitle.Text = row.Cells[1].Value.ToString();
                txtDescri.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
  

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to update ' "+ txtTitle.Text.Trim() + " ' task.", "Confirm Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con = new SqlConnection("Data Source=(local);Initial Catalog=reminder;Integrated Security=True");

                try
                {
                    con.Open();
                    string query = "UPDATE tbl_reminder SET title = @EventTitle, description = @EventDescr, date_time = @EventDate WHERE id='"+ txtId.Text+"'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@EventTitle", this.txtTitle.Text);
                    cmd.Parameters.AddWithValue("@EventDescr", this.txtDescri.Text);
                    cmd.Parameters.AddWithValue("@EventDate", this.dateTimePicker1.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated.");
                }
                finally
                {
                    con.Close();
                }

            } else
            {
                MessageBox.Show("no");
            }
        }
    }
}
