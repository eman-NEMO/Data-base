using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace form1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select count(*) from admin, Human_user, website_login where admin.Admin_id = Human_user.User_id and website_login.User_id=Human_user.User_id and user_name ='" + textBox5.Text + "' and password = '" + textBox6.Text + "';";
            if (sqlCommand.ExecuteScalar().ToString() == "1")
            {
                Form7 f7 = new Form7();
                f7.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please check username and password again!");
            }

            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
