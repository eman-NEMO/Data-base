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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)

        {
            try
            {
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "select category_id as 'Category ID', name as 'Category Name'from category where category_id in (select category_id from product join take_orders on product.p_id = take_orders.p_id group by category_id  having count(*) = (select MAX(o.cnt)from(select COUNT(*) as cnt  from product join take_orders on product.p_id = take_orders.p_id group by category_id) as o));";

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

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "select category_id as 'Category ID', name as 'Category Name'from category where category_id in (select category_id from product join take_orders on product.p_id = take_orders.p_id group by category_id having SUM(take_orders.amount_sales) = (select MAX(o.cnt) from(select SUM(take_orders.amount_sales) as cnt   from product join take_orders on product.p_id = take_orders.p_id group by category_id) as o)); ";

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
