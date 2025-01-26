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
    public partial class EditVenueForm : Form
    {
        private int venueID;
        private MySqlConnection connection;
        public EditVenueForm(int id, string venueName, string capacity, string address, string manager, string phone, MySqlConnection dbConnection)
        {
            InitializeComponent();
            venueID = id;
            connection = dbConnection;

           
            IDTxt.Text = id.ToString();
            VenueNameTxt.Text = venueName;
            CapacityTxt.Text = capacity;
            AddressTxt.Text = address;
            ManagerTxt.Text = manager;
            PhoneTxt.Text = phone;
        }

        private void EditVenueForm_Load(object sender, EventArgs e)
        {

        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VenueNameTxt.Text) || string.IsNullOrWhiteSpace(CapacityTxt.Text) ||
           string.IsNullOrWhiteSpace(AddressTxt.Text) || string.IsNullOrWhiteSpace(ManagerTxt.Text) ||
           string.IsNullOrWhiteSpace(PhoneTxt.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                

                string query = "UPDATE venues SET venue_name = @VenueName, capacity = @Capacity, address = @Address, " +
                               "manager = @Manager, phone = @Phone WHERE venue_ID = @VenueID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@VenueName", VenueNameTxt.Text);
                cmd.Parameters.AddWithValue("@Capacity", CapacityTxt.Text);
                cmd.Parameters.AddWithValue("@Address", AddressTxt.Text);
                cmd.Parameters.AddWithValue("@Manager", ManagerTxt.Text);
                cmd.Parameters.AddWithValue("@Phone", PhoneTxt.Text);
                cmd.Parameters.AddWithValue("@VenueID", venueID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Venue updated successfully.");

                this.DialogResult = DialogResult.OK; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating venue: " + ex.Message);
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
