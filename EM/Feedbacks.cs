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
    public partial class Feedbacks : Form
    {
        public Feedbacks()
        {
            InitializeComponent();
            ShowFeedbacks();
            GetEvent();

        }

        private void Feedbacks_Load(object sender, EventArgs e)
        {

        }

        private void HospitalitycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void ShowFeedbacks()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=MAHINDA\SQLEXPRESS;Initial Catalog=EventsDb;Integrated Security=True");
            try
            {
                Con.Open();
                String Query = "Select * from FeedbackTbl";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                FeedbacksDGV.DataSource = ds.Tables[0];
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
            ENametxt.Text = "";
            HospitalityCb.SelectedIndex = -1;
            PunctualityCb.SelectedIndex = -1;
            VenueCb.SelectedIndex = -1;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MAHINDA\SQLEXPRESS;Initial Catalog=EventsDb;Integrated Security=True");

        private void GetEvent()

        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select EvId from EventTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EventId", typeof(int));
            dt.Load(Rdr);
            EventIdCb.ValueMember = "CusId";
            EventIdCb.DataSource = dt;
            Con.Close();
        }
        private void GetEventName()
        {
            //Con.Open();
            String Query = "Select * from EventTbl where EvId" + EventIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ENametxt.Text = dr["EName"].ToString();
            }
            Con.Close();
        }
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            if (ENametxt.Text == "" || VenueCb.SelectedIndex == -1 || HospitalityCb.SelectedIndex == -1 || PunctualityCb.SelectedIndex == -1 )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    int Overall = (HospitalityCb.SelectedIndex + PunctualityCb.SelectedIndex + VenueCb.SelectedIndex+3)/3;

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into FeedbackTbl(EvId,EvName,Venue,Punctuality,Hospitality,Overall)Values(@EI,@EN,@V,@P,@H,@O)", Con);
                    cmd.Parameters.AddWithValue("@EI", EventIdCb.SelectedValue.ToString() );
                    cmd.Parameters.AddWithValue("@EN", ENametxt.Text);
                    cmd.Parameters.AddWithValue("@V", VenueCb.SelectedIndex);
                   cmd.Parameters.AddWithValue("@H", HospitalityCb.SelectedIndex);
                    cmd.Parameters.AddWithValue("@P", PunctualityCb.SelectedIndex);
                    cmd.Parameters.AddWithValue("@O", Overall);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venue Added");
                    Con.Close();
                    ShowFeedbacks();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EventIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetEventName();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
