using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EM
{
    public partial class Customer : Form
    {
        private MySqlConnection connection;
        public Customer()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            connection.Open();  
            LoadCustomers();
            CustomizeDataGridView();
            CustomerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomerDataGrid.MultiSelect = false;
        }

        private void LoadCustomers()
        {
            try
            {
               
                string query = "SELECT * FROM Customers";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable customersTable = new DataTable();
                adapter.Fill(customersTable);

                CustomerDataGrid.DataSource = customersTable;
                CustomerDataGrid.Columns["id"].HeaderText = "ID";
                CustomerDataGrid.Columns["Customer_Name"].HeaderText = "Customer Name";
                CustomerDataGrid.Columns["Customer_Phone"].HeaderText = "Phone Number";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
          
        }

        private void Clear()
        {
            Customertxt.Text = "";
            CusPhonetxt.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Customer Name: '{Customertxt.Text.Trim()}'");
            Console.WriteLine($"Customer Phone: '{CusPhonetxt.Text.Trim()}'");

            if (string.IsNullOrWhiteSpace(Customertxt.Text.Trim()) || string.IsNullOrWhiteSpace(CusPhonetxt.Text.Trim()))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                
                string query = "INSERT INTO Customers (Customer_Name, Customer_Phone) VALUES (@CustomerName, @CustomerPhone)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CustomerName", Customertxt.Text.Trim());
                cmd.Parameters.AddWithValue("@CustomerPhone", CusPhonetxt.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Customer added successfully.");
                LoadCustomers();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message);
            }
            
        }

        private void CustomizeDataGridView()
        {
            CustomerDataGrid.BackgroundColor = Color.White;
            CustomerDataGrid.BorderStyle = BorderStyle.None;
            CustomerDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            CustomerDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            CustomerDataGrid.EnableHeadersVisualStyles = false;
            CustomerDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); 
            CustomerDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            CustomerDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            CustomerDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CustomerDataGrid.DefaultCellStyle.BackColor = Color.White;
            CustomerDataGrid.DefaultCellStyle.ForeColor = Color.Black;
            CustomerDataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            CustomerDataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219); 
            CustomerDataGrid.DefaultCellStyle.SelectionForeColor = Color.White;

            CustomerDataGrid.GridColor = Color.FromArgb(230, 230, 230);

            CustomerDataGrid.RowHeadersVisible = false;

            CustomerDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); 
            CustomerDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            CustomerDataGrid.DefaultCellStyle.Padding = new Padding(5);

            CustomerDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CustomerDataGrid.ColumnHeadersHeight = 40;
            CustomerDataGrid.RowTemplate.Height = 40;

            CustomerDataGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
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


        private void label5_Click(object sender, EventArgs e)
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



        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (CustomerDataGrid.SelectedRows.Count > 0)
            {
              
                int customerId = Convert.ToInt32(CustomerDataGrid.SelectedRows[0].Cells["id"].Value);
                string customerName = CustomerDataGrid.SelectedRows[0].Cells["Customer_Name"].Value.ToString();
                string customerPhone = CustomerDataGrid.SelectedRows[0].Cells["Customer_Phone"].Value.ToString();

                
                EditCustomerForm editForm = new EditCustomerForm(customerId, customerName, customerPhone, connection);

              
                DialogResult result = editForm.ShowDialog();

               
                if (result == DialogResult.OK)
                {
                    LoadCustomers(); 
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.");
            }
        }


        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CustomerDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = CustomerDataGrid.SelectedRows[0];
                int customerID = Convert.ToInt32(selectedRow.Cells["id"].Value);

                try
                {
                   
                    string query = "DELETE FROM Customers WHERE id = @CustomerID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer deleted successfully.");
                    LoadCustomers();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message);
                }
                
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
           
            Venues obj = new Venues();
            obj.Show();
            this.Hide();
        }
    }
}
    


    

