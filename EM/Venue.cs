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
namespace EM
{
    public partial class Venue : Form
    {
        public Venue()
        {
            InitializeComponent();
            ShowVenue();
            
        }
        
        private void Venue_Load(object sender, EventArgs e)
        {

        }

        private void Addresstxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Mahinda - Pc\Documents\VenueDb.mdf; Integrated Security = True; Connect Timeout = 30");
        private void ShowVenue()
        {
            Con.Open();
            string Query = "Select * from VenueTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            VenuesDGV.DataSource = ds.Tables[0];                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            Con.Close();
        }
        private void Clear()
        {
            VenueNametxt.Text = "";
            Phonetxt.Text = "";
            Capacitytxt.Text = "";
            Addresstxt.Text = "";
            VenueManagertxt.Text = "";
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mahinda-Pc\Documents\EventsDb.mdf;Integrated Security=True;Connect Timeout=30"); 
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (Addresstxt.Text == "" || VenueNametxt.Text == "" || Phonetxt.Text == "" || Capacitytxt.Text == "" || VenueManagertxt.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into VenueTbl(VenueName,Capacity,Address,VenueManager,phone)values(@VN,@VC,@VA,@VM,@VP)", Con);
                    cmd.Parameters.AddWithValue("@VN", VenueNametxt.Text);
                    cmd.Parameters.AddWithValue("@VC", Capacitytxt.Text);
                    cmd.Parameters.AddWithValue("@VA", Addresstxt.Text);
                    cmd.Parameters.AddWithValue("@VM", VenueManagertxt.Text);
                    cmd.Parameters.AddWithValue("@VP", Phonetxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venue Added");
                    Con.Close();
                    ShowVenue();
                    Clear();
                }
                catch ( Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FeedBack Obj = new FeedBack();
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
            Event Obj = new Event();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }
        int key = 0;
        private void VenuesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VenueNametxt.Text = VenuesDGV.SelectedRows[0].Cells[1].Value.ToString();
            Capacitytxt.Text = VenuesDGV.SelectedRows[0].Cells[2].Value.ToString();
            Addresstxt.Text = VenuesDGV.SelectedRows[0].Cells[3].Value.ToString();
            VenueManagertxt.Text = VenuesDGV.SelectedRows[0].Cells[4].Value.ToString();
            Phonetxt.Text = VenuesDGV.SelectedRows[0].Cells[5].Value.ToString();
            if(VenueNametxt.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(VenuesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Venue");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from VenueTbl Where VId=@VKey",Con);
                    cmd.Parameters.AddWithValue("@VKey", key);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venue Deleted");
                    Con.Close();
                    ShowVenue();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (Addresstxt.Text == "" || VenueNametxt.Text == "" || Phonetxt.Text == "" || Capacitytxt.Text == "" || VenueManagertxt.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update VenueTbl set VenueName=@VN,Capacity=@VC,Address=@VA,VenueManager=@VM,phone=@VP where VId=@VKey") ;
                    cmd.Parameters.AddWithValue("@VN", VenueNametxt.Text);
                    cmd.Parameters.AddWithValue("@VC", Capacitytxt.Text);
                    cmd.Parameters.AddWithValue("@VA", Addresstxt.Text);
                    cmd.Parameters.AddWithValue("@VM", VenueManagertxt.Text);
                    cmd.Parameters.AddWithValue("@VP", Phonetxt.Text);
                    cmd.Parameters.AddWithValue("@VKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venue Updated");
                    Con.Close();
                    ShowVenue();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
