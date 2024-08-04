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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            { // Add Customer
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";

                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert Into Human_user values ( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',' C'," + Int32.Parse(textBox8.Text) + ")", con);
                SqlCommand cmd2 = new SqlCommand("Insert Into Human_user_Phone values ( '" + textBox4.Text + "'," + Int32.Parse(textBox8.Text) + ")", con);
                SqlCommand cmd3 = new SqlCommand("Insert Into website_login values ( '" + textBox5.Text + "','" + textBox6.Text + "'," + Int32.Parse(textBox8.Text) + ")", con);
                SqlCommand cmd4 = new SqlCommand("Insert Into customer values ( " + Int32.Parse(textBox8.Text) + ")", con);



                /* /*cmd.CommandText*/
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();

                MessageBox.Show(" Inseration Sucess");
                con.Close();
            }
         
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "select Customer_id, First_Name, Last_Name, Adress, Phone, user_name, password from customer, Human_user, Human_user_Phone, website_login where customer.Customer_id = Human_user.User_id and Human_user.User_id = Human_user_Phone.User_id and website_login.User_id=Human_user.User_id";

                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dataGridView1.Rows.Clear();
                for (int j = 0; reader.Read(); j++)
                {
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < 7; i++)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Update Customer
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";

                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                   SqlCommand cmd = new SqlCommand("UPDATE  Human_user SET First_Name= '" + textBox1.Text + "',Last_Name='" + textBox2.Text + "',Adress='" + textBox3.Text + "',type= 'C'" + " where User_id=" + Int32.Parse(textBox8.Text) + ";", con);
                SqlCommand cmd2 = new SqlCommand("UPDATE Human_user_Phone SET Phone= '" + textBox4.Text + "'where User_id=" + Int32.Parse(textBox8.Text) + ";", con);
                SqlCommand cmd3 = new SqlCommand("UPDATE  website_login  SET user_name = '" + textBox5.Text + "',password='" + textBox6.Text + "' where User_id= " + Int32.Parse(textBox8.Text) + ";", con);

                
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                MessageBox.Show(" Update Sucess");
                con.Close();
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {   // Delete Customer
                string ConnectionString = @"Data Source=DESKTOP-UVPHDH6;Initial Catalog=SuperMarket;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlcommand.CommandText = "delete from take_orders where User_id=" + Int32.Parse(textBox8.Text) + ";";
                sqlcommand.ExecuteNonQuery();
                sqlcommand.CommandText = "delete from customer where customer_id=" + Int32.Parse(textBox8.Text) + ";";
                sqlcommand.ExecuteNonQuery();
                sqlcommand.CommandText = "delete from Human_user_Phone where user_id=" + Int32.Parse(textBox8.Text) + ";";
                sqlcommand.ExecuteNonQuery();
                sqlcommand.CommandText = "delete from website_login where user_id=" + Int32.Parse(textBox8.Text) + ";";
                sqlcommand.ExecuteNonQuery();
                sqlcommand.CommandText = "delete from browsing where user_id=" + Int32.Parse(textBox8.Text) + ";";
                sqlcommand.ExecuteNonQuery();
                sqlcommand.CommandText = "delete from handle where Customer_id=" + Int32.Parse(textBox8.Text) + ";";
                sqlcommand.ExecuteNonQuery();
                sqlcommand.CommandText = "delete from Human_user where user_id=" + Int32.Parse(textBox8.Text) + ";";
                sqlcommand.ExecuteNonQuery();
                sqlConnection.Close();
                //show messsage sucssefully
                MessageBox.Show("Delete sucssefully");



            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
