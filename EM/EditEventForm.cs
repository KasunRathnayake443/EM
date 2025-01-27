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
    public partial class EditEventForm : Form
    {
        private MySqlConnection connection;
        private int eventId;
        public EditEventForm(int id, string eventName, DateTime eventDate, string venueName, string status, int hours)
        {
            InitializeComponent();

            eventId = id;

            
            EventNametxt.Text = eventName;
            DatePick.Value = eventDate;
            VenueNameBox.SelectedItem = venueName;
            Statuscb.SelectedItem = status; 
            Durationtxt.Text = hours.ToString();
        }

        private void EditEventForm_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            connection.Open();

            LoadVenues();
            LoadCustomers();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EventNametxt.Text) ||
            string.IsNullOrWhiteSpace(Durationtxt.Text) ||
            VenueNameBox.SelectedIndex == -1 ||
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

                string query = "UPDATE event SET Event_Name = @EventName, Event_Date = @EventDate, Venue_Name = @VenueName, Status = @Status, Hours = @Duration WHERE id = @EventId";

                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

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
                        cmd.Parameters.AddWithValue("@EventId", eventId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Event updated successfully!");
                this.DialogResult = DialogResult.OK; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating event: " + ex.Message);
            }
        }
    }
    
}
