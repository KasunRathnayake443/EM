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
    public partial class Event : Form
    {
        public Event()
        {
            InitializeComponent();
            ShowEvent();
            GetVenue();
            GetCustomer();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

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
        private void ShowEvent()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mahinda-Pc\Documents\EventsDb.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                Con.Open();
                String Query = "Select * from EventTbl";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                EventDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }
        private void Clear()
        {
            EventNametxt.Text = "";
            CusNametxt.Text = "";
            Durationtxt.Text = "";
            Statuscb.SelectedIndex = -1;
            EvVenueNametxt.Text = "";
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHINDA\SQLEXPRESS;Initial Catalog=EventsDb;Integrated Security=True");

        private void GetCustomer()

        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CusId from CustomerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusId", typeof(int));
            dt.Load(Rdr);
            CusIdcb.ValueMember = "CusId";
            CusIdcb.DataSource = dt;
            Con.Close();
        }

        
        private void GetCustomerName()
        {
            //Con.Open();
            String Query = "Select * from CustomerTbl where CusId" + CusIdcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CusNametxt.Text = dr["CusName"].ToString();
            }
            Con.Close();
        }
        
        private void GetVenue()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select VId from VenueTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("VId", typeof(int));
            dt.Load(Rdr);
            EvVIdcb.ValueMember = "VId";
            EvVIdcb.DataSource = dt;
            Con.Close();
        }
        private void GetEvVenueNametxt()
        {
            Con.Open();
            String Query = "Select * from VenueTbl where VId" + EvVIdcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EventNametxt.Text = dr["VName"].ToString();
            }
            Con.Close();
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (EventNametxt.Text == "" || EvVenueNametxt.Text == "" || CusNametxt.Text == "" || Durationtxt.Text == "" || Statuscb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into EventTbl(EventName,EvDate,EvVId,VenueName,EvDuration,CustId,CustName,Status)Values(@EN,@ED,@VI,@EV,@EDU,@ECI,@ECN,@ES)", Con);
                    cmd.Parameters.AddWithValue("@EN", EventNametxt.Text);
                    cmd.Parameters.AddWithValue("@ED", EvDate.Text);
                    cmd.Parameters.AddWithValue("@VI", EvVIdcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@EV", EvVenueNametxt.Text);
                    cmd.Parameters.AddWithValue("@EDU", Durationtxt.Text);
                    cmd.Parameters.AddWithValue("@ECI", CusIdcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ECN", CusNametxt.Text);
                    cmd.Parameters.AddWithValue("@ES", Statuscb.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venue Added");
                    Con.Close();
                    ShowEvent();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
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
            GetEvVenueNametxt();
        }

        private void EvVenueNametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void CusIdcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustomerName();
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (EventNametxt.Text == "" || EvVenueNametxt.Text == "" || CusNametxt.Text == "" || Durationtxt.Text == "" || Statuscb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update EventTbl Set EventName=@EN,EvDate=@ED,EvVId=@VI,VenueName=@EV,EvDuration=@EDU,CusId=@ECI,CustName=@ECN,Status=@ES where EvId=@Ekey", Con);
                    cmd.Parameters.AddWithValue("@EN", EventNametxt.Text);
                    cmd.Parameters.AddWithValue("@ED", EvDate.Text);
                    cmd.Parameters.AddWithValue("@VI", EvVIdcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@EV", EvVenueNametxt.Text);
                    cmd.Parameters.AddWithValue("@EDU", Durationtxt.Text);
                    cmd.Parameters.AddWithValue("@ECI", CusIdcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ECN", CusNametxt.Text);
                    cmd.Parameters.AddWithValue("@ES", Statuscb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@EKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Event Updated");
                    Con.Close();
                    ShowEvent();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void EventDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EventNametxt.Text = EventDGV.SelectedRows[0].Cells[1].Value.ToString();
            EvDate.Text = EventDGV.SelectedRows[0].Cells[2].Value.ToString();
            EvVenueNametxt.Text = EventDGV.SelectedRows[0].Cells[3].Value.ToString();
            EvVIdcb.SelectedValue = EventDGV.SelectedRows[0].Cells[4].Value.ToString();
            Durationtxt.Text = EventDGV.SelectedRows[0].Cells[5].Value.ToString();
            CusIdcb.SelectedValue = EventDGV.SelectedRows[0].Cells[6].Value.ToString();
            CusNametxt.Text = EventDGV.SelectedRows[0].Cells[7].Value.ToString();
            Statuscb.SelectedItem = EventDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (EventNametxt.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EventDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
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
