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
    public partial class Feedbacks : Form
    {
        private MySqlConnection connection;
        public Feedbacks()
        {
            InitializeComponent();
            ShowFeedbacks();
            GetEvent();

        }

        private void Feedbacks_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            connection.Open();

            LoadFeedbacksToDataGrid();
            LoadEvents();


            CustomizeFeedbacksDataGridView();
        }

        private void LoadEvents()
        {
            try
            {
                string query = "SELECT Event_Name FROM Event";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();


                EventBox.Items.Clear();


                while (reader.Read())
                {
                    EventBox.Items.Add(reader["Event_Name"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading venues: " + ex.Message);
            }
        }
        private void LoadFeedbacksToDataGrid()
        {
            try
            {
                
                string query = "SELECT id, Event_name, Punctuality, Hospitality FROM Feedbacks";

                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);

                        
                        FeedbacksDataGrid.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading feedback data: " + ex.Message);
            }
        }

        private void CustomizeFeedbacksDataGridView()
        {
            FeedbacksDataGrid.BackgroundColor = Color.White;
            FeedbacksDataGrid.BorderStyle = BorderStyle.None;
            FeedbacksDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            FeedbacksDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            FeedbacksDataGrid.EnableHeadersVisualStyles = false;
            FeedbacksDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            FeedbacksDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            FeedbacksDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            FeedbacksDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            FeedbacksDataGrid.DefaultCellStyle.BackColor = Color.White;
            FeedbacksDataGrid.DefaultCellStyle.ForeColor = Color.Black;
            FeedbacksDataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            FeedbacksDataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            FeedbacksDataGrid.DefaultCellStyle.SelectionForeColor = Color.White;

            FeedbacksDataGrid.GridColor = Color.FromArgb(230, 230, 230);

            FeedbacksDataGrid.RowHeadersVisible = false;

            FeedbacksDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            FeedbacksDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            FeedbacksDataGrid.DefaultCellStyle.Padding = new Padding(5);

            FeedbacksDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            FeedbacksDataGrid.ColumnHeadersHeight = 40;
            FeedbacksDataGrid.RowTemplate.Height = 40;

            FeedbacksDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
        }

        private void HospitalitycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void ShowFeedbacks()
        {
           
        }
        private void Clear()
        {
            EventBox.SelectedIndex = -1;
            HospitalityCb.SelectedIndex = -1;
            PunctualityCb.SelectedIndex = -1;
         
        }
       

        private void GetEvent()

        {
           
        }
        private void GetEventName()
        {
            
        }
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            String EventName = EventBox.Text;
            String Punctuality = PunctualityCb.Text;
            String Hospitality = HospitalityCb.Text;

            if (string.IsNullOrWhiteSpace(EventName) ||
                string.IsNullOrWhiteSpace(Punctuality) ||
                string.IsNullOrWhiteSpace(Hospitality))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                
                string query = "INSERT INTO Feedbacks (Event_name, Punctuality, Hospitality) " +
                               "VALUES (@EventName, @Punctuality, @Hospitality)";

              
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        
                        cmd.Parameters.AddWithValue("@EventName", EventName);
                        cmd.Parameters.AddWithValue("@Punctuality", Punctuality);
                        cmd.Parameters.AddWithValue("@Hospitality", Hospitality);

                       
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Feedback submitted successfully!");

                LoadFeedbacksToDataGrid();


                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting feedback: " + ex.Message);
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

        private void FeedbacksDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
