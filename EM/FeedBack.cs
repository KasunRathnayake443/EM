using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EM
{
    public partial class FeedBack : Form
    {
        public FeedBack()
        {
            InitializeComponent();
            ShowFeedback();
            GetEvent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Punctualitytxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void EDatetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FeedBack_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EIdtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Hospitalitytxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HospitalitycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEName();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void ShowFeedback()
        {
            Con.Open();
            String Query = "Select * from FeedbackTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FeedbackDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            ENametxt.Text = "";
            Hospitalitycb.SelectedIndex = -1;
            Punctualitycb.SelectedIndex = -1;
            Hospitalitycb.SelectedIndex = -1;
            Venuecb.SelectedIndex = -1;

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mahinda-Pc\Documents\EventsDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetEvent()
        {
                Con.Open();
                System.Data.SqlClient.SqlCommand cmd = new SqlCommand("Select EvId from EventTbl", Con);
                SqlDataReader Rdr;
                Rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("EvId", typeof(int));
                dt.Load(Rdr);
                EIdcb.ValueMember = "EvId";
                EIdcb.DataSource = dt;
                Con.Close();
        }
        private void GetEventName()
        {
            Con.Open();
            String Query = "Select * from EventTbl where EvId" + EIdcb.SelectedValue.ToString() + "";
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
       private void Savebtn_Click(object sender, EventArgs e)
       {
                if (ENametxt.Text == "" || Venuecb.SelectedIndex == -1 || Punctualitycb.SelectedIndex == -1 || Hospitalitycb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    try
                    {
                        int Overall = (Hospitalitycb.SelectedIndex + Venuecb.SelectedIndex + Punctualitycb.SelectedIndex + 3) / 3;
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("Insert into FeedBackTbl(EvId,EName,Venue,Punctuality,Hospitality,Overall)Values(@EI,@EN@V,@P,@H,@O)", Con);
                        cmd.Parameters.AddWithValue("@EI", EIdcb.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@EN", ENametxt.Text);
                        cmd.Parameters.AddWithValue("@V", Venuecb.SelectedIndex + 1);
                        cmd.Parameters.AddWithValue("@P", Punctualitycb.SelectedIndex + 1);
                        cmd.Parameters.AddWithValue("@H", Hospitalitycb.SelectedIndex + 1);
                        cmd.Parameters.AddWithValue("@O", Overall);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Feedback Submitted");
                        Con.Close();
                        ShowFeedback();
                        Clear();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }

                }
       }
        


        internal class SqlCommandBuilder
        {
            public SqlCommandBuilder(SqlDataAdapter sda)
            {
            }
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (ENametxt.Text == "" || Venuecb.SelectedIndex == -1 || Hospitalitycb.SelectedIndex == -1 || Punctualitycb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    int Overall = (Hospitalitycb.SelectedIndex + Venuecb.SelectedIndex + Punctualitycb.SelectedIndex + 3) / 3;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into FeedBackTbl(EId,EName,Venue,Punctuality,Hospitality,OvarAll)values(@EI,@EN,@V,@P,@H,@O)", Con);
                    cmd.Parameters.AddWithValue("@EI", EIdcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@EN", ENametxt.Text);
                    cmd.Parameters.AddWithValue("@V", Venuecb.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@P", Punctualitycb.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@H", Hospitalitycb.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@O", Overall);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("FeedBack Submited");
                    Con.Close();
                    ShowFeedback();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void FeedbackDGV_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void EIdcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetEName();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Event Obj = new Event();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FeedBack Obj = new FeedBack();
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
            Venue Obj = new Venue();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    internal class SqlConnection
    {
        private string v;

        public SqlConnection(string v)
        {
            this.v = v;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}
