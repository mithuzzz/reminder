using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reminder
{
    class DBConnection
    {

        public string ConnectionString = "Data Source=(local);Initial Catalog=reminder;Integrated Security=True";
        public SqlConnection con;


        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
