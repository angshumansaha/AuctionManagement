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
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AuctionManagement\Database\Data.mdf;Integrated Security=True;Connect Timeout=30");


        public Admin()
        {
            InitializeComponent();
        }
        private DataTable GetUsers()
        {
            DataTable dtusers = new DataTable();

            con.Open();
            SqlCommand cmd=new SqlCommand("Select * from Users",con);
            SqlDataReader reader = cmd.ExecuteReader();
            dtusers.Load(reader);
            con.Close();
            return dtusers;
        }
        private DataTable GetUploaders()
        {
            DataTable dtusers = new DataTable();

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users where Account='Uploader'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dtusers.Load(reader);
            con.Close();
            return dtusers;
        }
        private DataTable GetBidders()
        {
            DataTable dtusers = new DataTable();

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users where Account='Bidder'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dtusers.Load(reader);
            con.Close();
            return dtusers;
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uploaderRportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form upr = new UploaderReport();
            upr.Show();
            this.Hide();
        }

        private void biddersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form bdr = new BidderReport();
            bdr.Show();
            this.Hide();
        }

        private void edditUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form action = new EdUpdel();
            action.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ver = new Verification();
            ver.Show();
            this.Hide();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showUploaderInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetUploaders();
        }

        private void showBidderInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetBidders();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetUsers();
        }
    }
}
