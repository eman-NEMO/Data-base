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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "select p_id as ProductID, name as ProductName from product where p_id NOT IN ( select p_id from take_orders where MONTH(date) = " + Int32.Parse(textBox1.Text) + " and YEAR(date) =" + Int32.Parse(textBox2.Text) + " )";

                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dataGridView1.Rows.Clear();
                for (int j = 0; reader.Read(); j++)
                {
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < 2; i++)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = reader.GetValue(i).ToString();
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }
    }
}
