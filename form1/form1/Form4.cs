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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Delete Product
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";

                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM  Discount where discount_id=" + Int32.Parse(textBox7.Text) + ";", con);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("DELETE FROM  browsing where p_id=" + Int32.Parse(textBox7.Text) + ";", con);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("DELETE FROM  manage where p_id=" + Int32.Parse(textBox7.Text) + ";", con);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand("DELETE FROM  take_orders where p_id=" + Int32.Parse(textBox7.Text) + ";", con);
                cmd4.ExecuteNonQuery();

                SqlCommand cmd5 = new SqlCommand("DELETE FROM  product where p_id=" + Int32.Parse(textBox7.Text) + ";", con);
                cmd5.ExecuteNonQuery();

                MessageBox.Show(" Delete Sucess");

                con.Close();

            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Update Product
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";

                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                
                SqlCommand cmd = new SqlCommand("UPDATE  product SET name= '" + textBox1.Text + "',price='" + textBox2.Text + "',quantity='" + textBox3.Text + "',category_id=" + Int32.Parse(textBox4.Text) + "where p_id=" + Int32.Parse(textBox7.Text) + ";", con);
                

                /* /*cmd.CommandText*/
                cmd.ExecuteNonQuery();
               
                MessageBox.Show(" Update Sucess");
                con.Close();
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            { //Add Product
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlConnection;
                sqlConnection.Open();
                //Insetr into product table by button clickadd,1,
                sqlcommand.CommandText = "INSERT INTO product(p_id,name,price,quantity,category_id) VALUES(" + Int32.Parse(textBox7.Text) + ",'" + textBox1.Text + "'," + float.Parse(textBox2.Text) + "," + Int32.Parse(textBox3.Text) + "," + Int32.Parse(textBox4.Text) + ")";
                sqlcommand.ExecuteNonQuery();
                MessageBox.Show(" Add Successfully");

                sqlConnection.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'superMarketDataSet2.product' table. You can move, or remove it, as needed.
            this.productTableAdapter1.Fill(this.superMarketDataSet2.product);
        }
    }
    
}
