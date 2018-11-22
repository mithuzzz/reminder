using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reminder
{
    public partial class frmTaskAdd : Form
    {
        String taskTitle;
        String taskDescri;
        DateTime date;
        SqlConnection con;

        public frmTaskAdd()
        {
            InitializeComponent();
            dateAndTime.Format = DateTimePickerFormat.Custom;
            dateAndTime.CustomFormat = "MM/dd/yyyy hh:mm:ss";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            taskTitle = txtTitle.Text;
            taskDescri = txtDescription.Text;
            date = dateAndTime.Value;

            con = new SqlConnection("Data Source=(local);Initial Catalog=reminder;Integrated Security=True");

            try
            {
                con.Open();
                string query = "INSERT INTO  tbl_reminder (title, description, date_time) VALUES (@EventTitle, @EventDescr, @EventDate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EventTitle", this.txtTitle.Text);
                cmd.Parameters.AddWithValue("@EventDescr", this.txtDescription.Text);
                cmd.Parameters.AddWithValue("@EventDate", this.date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                Schedular sc = new Schedular();
                sc.Start(date);
            }
            finally
            {
                con.Close();
            }




        }

        private void frmTaskAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
