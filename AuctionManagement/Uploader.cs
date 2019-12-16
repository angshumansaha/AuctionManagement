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
using System.IO;

namespace AuctionManagement
{
    public partial class Uploader : Form
    {
        public Uploader()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\AuctionManagement\Database\Data.mdf;Integrated Security=True;Connect Timeout=30");
       

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ver = new Verification();
            ver.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";

            if (opf.ShowDialog() == DialogResult.OK)

            {

                pictureBox1.Image = Image.FromFile(opf.FileName);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Items (Item_Name, Image, Min_price, Time, Up_Username) VALUES(@name, @img, @mprice, @time, @upuser)", con);

            cmd.Parameters.Add("@name", SqlDbType.VarChar,50);
            cmd.Parameters.Add("@img", SqlDbType.Image);
            cmd.Parameters.Add("@mprice", SqlDbType.Int,8);
            cmd.Parameters.Add("@time", SqlDbType.Time);
            cmd.Parameters.Add("@upuser", SqlDbType.VarChar,50);

            cmd.Parameters["@name"].Value = textBoxName.Text;
            cmd.Parameters["@img"].Value = img;
            cmd.Parameters["@mprice"].Value = textBoxPrice.Text;
            cmd.Parameters["@time"].Value = textBoxTime.Text;
            cmd.Parameters["@upuser"].Value = textBoxUpuser.Text;

            if (cmd.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Data Inserted");

            }
            con.Close();


        }
    }
}
