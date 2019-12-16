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

namespace AuctionManagement
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        SqlConnection connection= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AuctionManagement\Database\Data.mdf;Integrated Security=True;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Users(Name,Username, Password, Account, Mobile) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + comboBox1.Items + "','"+textBox5.Text+ "')";

            connection.Open();

            SqlCommand command = new SqlCommand(insertQuery, connection);




            try

            {

                if (command.ExecuteNonQuery() == 1)

                {

                    MessageBox.Show("Data Inserted");

                }

                else

                {

                    MessageBox.Show("Data Not Inserted");

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }




            connection.Close();
        }
    }
}
