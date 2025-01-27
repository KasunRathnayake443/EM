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

            DatePick.Format = DateTimePickerFormat.Custom;
            DatePick.CustomFormat = "yyyy-MM-dd"; 
            DatePick.ShowUpDown = false;
            LoadCustomers(); 
            LoadVenues();
            LoadEvents();
            CustomizeEventDataGridView();
            EventDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EventDataGrid.MultiSelect = false;
        }

        private void Clear()
        {
            EventNametxt.Text = "";
            
            Durationtxt.Text = "";
            Statuscb.SelectedIndex = -1;
            VenueNameBox.SelectedIndex = -1;
            CusNameBox.SelectedIndex = -1;

        }

        private void LoadEvents()
        {
            try
            {
                
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

              
                string query = "SELECT id, Event_Name, Event_Date, Venue_Name, Status, Hours FROM event";

               
                DataTable eventTable = new DataTable();

               
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(eventTable); 
                        }
                    }
                }

              
                EventDataGrid.DataSource = eventTable;

                EventDataGrid.Columns["id"].HeaderText = "Event ID";
                EventDataGrid.Columns["Event_Name"].HeaderText = "Event Name";
                EventDataGrid.Columns["Event_Date"].HeaderText = "Event Date";
                EventDataGrid.Columns["Venue_Name"].HeaderText = "Venue";
                EventDataGrid.Columns["Status"].HeaderText = "Status";
                EventDataGrid.Columns["Hours"].HeaderText = "Duration (Hours)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events: " + ex.Message);
            }
        }


        

        private void CustomizeEventDataGridView()
        {
            
            EventDataGrid.BackgroundColor = Color.White;
            EventDataGrid.BorderStyle = BorderStyle.None;
            EventDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EventDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

           
            EventDataGrid.EnableHeadersVisualStyles = false;
            EventDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); 
            EventDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            EventDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            EventDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
            EventDataGrid.DefaultCellStyle.BackColor = Color.White;
            EventDataGrid.DefaultCellStyle.ForeColor = Color.Black;
            EventDataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            EventDataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219); 
            EventDataGrid.DefaultCellStyle.SelectionForeColor = Color.White;

            
            EventDataGrid.GridColor = Color.FromArgb(230, 230, 230);

            
            EventDataGrid.RowHeadersVisible = false;

          
            EventDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); 
            EventDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            
            EventDataGrid.DefaultCellStyle.Padding = new Padding(5);

         
            EventDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EventDataGrid.ColumnHeadersHeight = 40;
            EventDataGrid.RowTemplate.Height = 40;

           
            EventDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
        }

        private void LoadVenues()
        {
            try
            {
                string query = "SELECT venue_name FROM venues";
                MySqlCommand cmd = new MySqlCommand(query, connection);
               
                MySqlDataReader reader = cmd.ExecuteReader();

                
                VenueNameBox.Items.Clear();

                
                while (reader.Read())
                {
                    VenueNameBox.Items.Add(reader["venue_name"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading venues: " + ex.Message);
            }
           
        }

        private void LoadCustomers()
        {
            try
            {
                string query = "SELECT Customer_Name FROM Customers";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                CusNameBox.Items.Clear();


                while (reader.Read())
                {
                    CusNameBox.Items.Add(reader["Customer_Name"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }

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
            if (string.IsNullOrWhiteSpace(EventNametxt.Text) ||
                string.IsNullOrWhiteSpace(Durationtxt.Text) ||
                VenueNameBox.SelectedIndex == -1 ||
                CusNameBox.SelectedIndex == -1 ||
                Statuscb.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                int duration;
                if (!int.TryParse(Durationtxt.Text, out duration))
                {
                    MessageBox.Show("Please enter a valid number for duration.");
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

            
                string query = "INSERT INTO event (Event_Name, Event_Date, Venue_Name, Status, Hours) " +
                               "VALUES (@EventName, @EventDate, @VenueName, @Status, @Duration)";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@EventName", EventNametxt.Text);
                        cmd.Parameters.AddWithValue("@EventDate", DatePick.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@VenueName", VenueNameBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Status", Statuscb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Duration", duration);

                        
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Event saved successfully!");
                LoadEvents();


                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving event: " + ex.Message);
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
          
        }

        private void EvVenueNametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void CusIdcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (EventDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }

            try
            {
             
                int eventId = Convert.ToInt32(EventDataGrid.SelectedRows[0].Cells["id"].Value);
                string eventName = EventDataGrid.SelectedRows[0].Cells["Event_Name"].Value.ToString();
                DateTime eventDate = Convert.ToDateTime(EventDataGrid.SelectedRows[0].Cells["Event_Date"].Value);
                string venueName = EventDataGrid.SelectedRows[0].Cells["Venue_Name"].Value.ToString();
                string status = EventDataGrid.SelectedRows[0].Cells["Status"].Value.ToString();
                int hours = Convert.ToInt32(EventDataGrid.SelectedRows[0].Cells["Hours"].Value);

                
                EditEventForm editForm = new EditEventForm(eventId, eventName, eventDate, venueName, status, hours);
                editForm.ShowDialog();

                LoadEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening the edit form: " + ex.Message);
            }
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

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            
            
                if (EventDataGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.");
                    return;
                }

                try
                {
                    
                    string selectedEventName = EventDataGrid.SelectedRows[0].Cells["Event_Name"].Value.ToString();

                    
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the event: {selectedEventName}?",
                                                          "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        
                        string query = "DELETE FROM event WHERE Event_Name = @EventName";

                       
                        string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                              
                                cmd.Parameters.AddWithValue("@EventName", selectedEventName);

                               
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Event deleted successfully!");

                                    
                                    LoadEvents();
                                }
                                else
                                {
                                    MessageBox.Show("Error: No matching event found in the database.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting event: " + ex.Message);
                }
            

        }
    }
}
