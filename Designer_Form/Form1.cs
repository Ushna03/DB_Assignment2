using Designer_Form;
//using Microsoft.VisualBasic.Logging;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Designer_Form
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_Load() called...");
            richTextBox1.Text = "Startup...";
            try
            {
                /* 
                System.Diagnostics.Debug.WriteLine("within the try"); 
                SqlConnection connection = new SqlConnection(@"Data 
Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");                 connection.Open(); 
                txtMessageText.Text = "Connection Successful";                 connection.Close(); 
                */
                var datasource = @"MANI-JUTT\SQLEXPRESS"; // Note: Removed unnecessary semicolon
                var database = "Northwind";
                var thisUsername = Form2.username; // Make sure login.username is a valid variable.
                var thisPassword = Form2.password; // Make sure login.password is a valid variable.
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;

                SqlConnection conn = new SqlConnection(connString); conn.Open();
                richTextBox1.Text = "Connection Successful on Startup"; conn.Close();

            }
            catch (Exception ex)
            {
                richTextBox1.Text = "Error, " + ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=MANI-JUTT\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            button1.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Customers (CustomerID, CompanyName) values('" + textBox1.Text + "','" + textBox2.Text + "')";
            command.ExecuteNonQuery();
            richTextBox1.Text = "Record Inserted...";
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=MANI-JUTT\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            button2.Text = "Counting Records...";
            command.Connection = connection;
            command.CommandText = "select count(*) from Customers";
            int count = (int)command.ExecuteScalar();
            richTextBox1.Text = "Number of records: " + count;
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string currentTable = "";
            if (radioButton1.Checked)
            {
                currentTable = "Customers";
            }
            else if (radioButton3.Checked)
            {
                currentTable = "Employees";
            }
            else if (radioButton2.Checked)
            {
                currentTable = "Orders";
            }



            dataGridView1.DataSource = null;
            try
            {
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection(@"Data Source=MANI-JUTT\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                var datasource = @"MANI-JUTT\SQLEXPRESS"; var database = "Northwind"; var thisUsername = Form2.username; var thisPassword = Form2.password;
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
                SqlConnection conn = new SqlConnection(connString); conn.Open();
                richTextBox1.Text = "Retrieving Records..."; command.Connection = conn;
                command.CommandText = "select * from " + currentTable;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable(); da.Fill(dt);

                // Change this line to reference the correct DataGridView name
                dataGridView1.DataSource = dt;

                richTextBox1.Text = "Retrieval Successful!"; conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
