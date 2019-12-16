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
    public partial class Bidder : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AuctionManagement\Database\Data.mdf;Integrated Security=True;Connect Timeout=30");

        public Bidder()
        {
            InitializeComponent();
            
        }
        private DataTable GetUsers()
        {
            DataTable dtusers = new DataTable();

            con.Open();
            SqlCommand cmd = new SqlCommand("Select Item_Name, Image, Min_price from Users", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dtusers.Load(reader);
            con.Close();
            return dtusers;
        }

        private void Bidder_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = GetUsers();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ob = new Verification();
            ob.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
