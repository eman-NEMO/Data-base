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
    public partial class Form14 : Form
    {
        public Form14()
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
                sqlCommand.CommandText = "select Customer_id as CustomerID, First_Name , Last_Name from customer join Human_user on Customer_id = User_id where Customer_id in (select User_id from take_orders where MONTH(date) = MONTH(GETDATE()) and YEAR(date) = YEAR(GETDATE()) group by User_id having COUNT(*) = (select MAX(o.cnt)from(select COUNT(*) as cnt from take_orders where MONTH(date) = MONTH(GETDATE()) and YEAR(date) = YEAR(GETDATE()) group by User_id) as o));";

                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dataGridView1.Rows.Clear();
                for (int j = 0; reader.Read(); j++)
                {
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = reader.GetValue(i).ToString();
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "select Customer_id as CustomerID, First_Name , Last_Name from customer join Human_user on Customer_id = User_id where Customer_id in (select User_id from take_orders where MONTH(date) = MONTH(GETDATE()) and YEAR(date) = YEAR(GETDATE())group by User_id having SUM(amount_sales) = ( select MAX(o.cnt)from (select SUM(amount_sales) as cnt  from take_orders where MONTH(date) = MONTH(GETDATE()) and YEAR(date) = YEAR(GETDATE()) group by User_id ) as o));";
               
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dataGridView1.Rows.Clear();
                for (int j = 0; reader.Read(); j++)
                {
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < 3; i++)
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
