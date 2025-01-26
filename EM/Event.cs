using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace EM
{
    public partial class Event : Form
    {
        private MySqlConnection connection;
        public Event()
        {
            InitializeComponent();
           
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void Clear()
        {
            EventNametxt.Text = "";
            CusNametxt.Text = "";
            Durationtxt.Text = "";
            Statuscb.SelectedIndex = -1;
            EvVenueNametxt.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EventDatetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void VenueIdtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Duratintxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Feedbacks Obj = new Feedbacks();
            Obj.Show();
            this.Hide();
        }
    

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EventNametxt_TextChanged(object sender, EventArgs e)
        {

        }
        
      
        

      
        private void Savebtn_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EvVIdcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EvVIdcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        }

        private void EvVenueNametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void CusIdcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            
        }
        int key = 0;
        private void EventDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
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
    }
}
