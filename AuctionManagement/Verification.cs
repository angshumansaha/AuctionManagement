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
    public partial class Verification : Form
    {
        public Verification()
        {
            InitializeComponent();
            password_txt.PasswordChar = '*';
            password_txt.MaxLength = 10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AuctionManagement\Database\Data.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string query = "Select * from Users where Username='" + textBox1.Text + "' and Password='" + password_txt.Text + "' and Account='" + comboBox1.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    if (comboBox1.Text == "Admin")
                    {
                        Form ff = new Admin();

                        ff.Show();
                        this.Hide();
                    }
                    else if (comboBox1.Text == "Uploader")
                    {
                        Form ff = new Uploader();

                        ff.Show();
                        this.Hide();
                    }
                    else if (comboBox1.Text == "Bidder")
                    {
                        Form ff = new Uploader();

                        ff.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please Choose Correct information");
                    }

                }
                else
                {
                    MessageBox.Show("Please Choose Correct information");

                }
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERRORE", ex);
            }






            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ab = new Registration();
            ab.Show();
            this.Hide();
        }
    }
}
