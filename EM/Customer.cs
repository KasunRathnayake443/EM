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
    public partial class Customer : Form
    {
        private MySqlConnection connection;
        public Customer()
        {
            InitializeComponent();
            ShowCustomer();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            connection.Open();

            
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Addresstxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ShowCustomer()
        {
           
        }
        private void Clear()
        {
            Customertxt.Text = "";
            CusPhonetxt.Text = "";
            
        }
        

        private void buttonSave_Click(object sender, EventArgs e)
        {
            

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
           

        }
       
        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
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
    

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Venues Obj = new Venues();
            Obj.Show();
            this.Hide();
        }

        private void user_Click(object sender, EventArgs e)
        {
            Customer Obj = new  Customer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    


    

