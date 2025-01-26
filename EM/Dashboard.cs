using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EM
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            countEvents();
            countVenues();
            countCustomers();
            countExcellent();
            countGood();
            countOk();
            countBad();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHINDA\SQLEXPRESS;Initial Catalog=EventsDb;Integrated Security=True");
        private void countEvents()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from EventTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EventLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void countCustomers()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from CustomerTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CustomerLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void countVenues()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from VenueTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            VenueLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void countExcellent()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from FeedBackTbl where OverAll =" + 4 + "", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ExcellentLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void countGood()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from FeedBackTbl where OverAll =" + 3 + "", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GoodLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void countOk()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from FeedBackTbl where OverAll =" + 2 + "", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ExcellentLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void countBad()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from FeedBackTbl where OverAll =" + 1 + "", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BadLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Feedbacks Obj = new Feedbacks();
            Obj.Show();
            this.Hide();
        }
    

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Venues Obj = new Venues();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void ExcellentLbl_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from EventTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EventLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
    }
}
