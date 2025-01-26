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
    public partial class Venues : Form
    {
        private MySqlConnection connection;
        public Venues()
        {
            InitializeComponent();
            
        }

        private void Venues_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            connection.Open();

            LoadVenues();
            CustomizeDataGridView();
            venuesDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            venuesDataGrid.MultiSelect = false; 
        }

        private void LoadVenues()
        {
            try
            {
              
                string query = "SELECT * FROM venues";

                
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable venuesTable = new DataTable();
                adapter.Fill(venuesTable);

               
                venuesDataGrid.DataSource = venuesTable;

           
                venuesDataGrid.Columns["venue_ID"].HeaderText = "ID";
                venuesDataGrid.Columns["venue_name"].HeaderText = "Venue Name";
                venuesDataGrid.Columns["capacity"].HeaderText = "Capacity";
                venuesDataGrid.Columns["address"].HeaderText = "Address";
                venuesDataGrid.Columns["manager"].HeaderText = "Manager";
                venuesDataGrid.Columns["phone"].HeaderText = "Phone Number";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading venues: " + ex.Message);
            }
          


        }

        private void CustomizeDataGridView()
        {
            
            venuesDataGrid.BackgroundColor = Color.White;
            venuesDataGrid.BorderStyle = BorderStyle.None;
            venuesDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            venuesDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

           
            venuesDataGrid.EnableHeadersVisualStyles = false;
            venuesDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); 
            venuesDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            venuesDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            venuesDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           
            venuesDataGrid.DefaultCellStyle.BackColor = Color.White;
            venuesDataGrid.DefaultCellStyle.ForeColor = Color.Black;
            venuesDataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            venuesDataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219); 
            venuesDataGrid.DefaultCellStyle.SelectionForeColor = Color.White;

           
            venuesDataGrid.GridColor = Color.FromArgb(230, 230, 230);

            venuesDataGrid.RowHeadersVisible = false;

           
            venuesDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            venuesDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

         
            venuesDataGrid.DefaultCellStyle.Padding = new Padding(5);

            
            venuesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            venuesDataGrid.ColumnHeadersHeight = 40;
            venuesDataGrid.RowTemplate.Height = 40;

           
            venuesDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
        }

        private void Clear()
        {
            VenueNametxt.Text = "";
            Phonetxt.Text = "";
            Capacitytxt.Text = "";
            Addresstxt.Text = "";
            VenueManagertxt.Text = "";
        }
        
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Addresstxt.Text) ||
        string.IsNullOrWhiteSpace(VenueNametxt.Text) ||
        string.IsNullOrWhiteSpace(Phonetxt.Text) ||
        string.IsNullOrWhiteSpace(Capacitytxt.Text) ||
        string.IsNullOrWhiteSpace(VenueManagertxt.Text))
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
               
                

                
                string query = "INSERT INTO venues (venue_name, capacity, address, manager, phone) VALUES (@VN, @VC, @VA, @VM, @VP)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                   
                    cmd.Parameters.AddWithValue("@VN", VenueNametxt.Text);
                    cmd.Parameters.AddWithValue("@VC", Capacitytxt.Text);
                    cmd.Parameters.AddWithValue("@VA", Addresstxt.Text);
                    cmd.Parameters.AddWithValue("@VM", VenueManagertxt.Text);
                    cmd.Parameters.AddWithValue("@VP", Phonetxt.Text);

                   
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Venue Added");

                
                LoadVenues();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
           

        }
      
        private void VenuesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //VenueNametxt.Text = VenueDGV.SelectedRows[0].Cells[1].Value.ToString();
            //Capacitytxt.Text = VenueDGV.SelectedRows[0].Cells[2].Value.ToString();
            //Addresstxt.Text = VenueDGV.SelectedRows[0].Cells[3].Value.ToString();
            //VenueManagertxt.Text = VenueDGV.SelectedRows[0].Cells[4].Value.ToString();
            //Phonetxt.Text = VenueDGV.SelectedRows[0].Cells[5].Value.ToString();
            //if (VenueNametxt.Text == "")
            //{
            //    key = 0;
            //}
            //else
            //{
            //    key = Convert.ToInt32(VenueDGV.SelectedRows[0].Cells[0].Value.ToString());
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            
            if (venuesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            
            DataGridViewRow selectedRow = venuesDataGrid.SelectedRows[0];
            int venueID = Convert.ToInt32(selectedRow.Cells["venue_ID"].Value);

            
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this venue?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    

                    
                    string deleteQuery = "DELETE FROM venues WHERE venue_ID = @VenueID";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                    cmd.Parameters.AddWithValue("@VenueID", venueID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Venue deleted successfully.");

                    
                    LoadVenues();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting venue: " + ex.Message);
                }
               
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (venuesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }

           
            DataGridViewRow selectedRow = venuesDataGrid.SelectedRows[0];
            int venueID = Convert.ToInt32(selectedRow.Cells["venue_ID"].Value);
            string venueName = selectedRow.Cells["venue_name"].Value.ToString();
            string capacity = selectedRow.Cells["capacity"].Value.ToString();
            string address = selectedRow.Cells["address"].Value.ToString();
            string manager = selectedRow.Cells["manager"].Value.ToString();
            string phone = selectedRow.Cells["phone"].Value.ToString();

           
            using (EditVenueForm editDialog = new EditVenueForm(venueID, venueName, capacity, address, manager, phone, connection))
            {
                if (editDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    LoadVenues();
                }
            }
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
    }
    
    
    
    
    
}

