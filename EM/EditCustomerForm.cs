using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace EM
{
    public partial class EditCustomerForm : Form
    {
        private MySqlConnection connection;
        private int customerId;
        public EditCustomerForm(int id, string name, string phone, MySqlConnection dbConnection)
        {
            InitializeComponent();

            customerId = id;
            Customertxt.Text = name;
            CusPhonetxt.Text = phone;
            connection = dbConnection;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Customertxt.Text) || string.IsNullOrWhiteSpace(CusPhonetxt.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
             
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "UPDATE Customers SET Customer_Name = @CustomerName, Customer_Phone = @CustomerPhone WHERE id = @CustomerId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CustomerName", Customertxt.Text);
                cmd.Parameters.AddWithValue("@CustomerPhone", CusPhonetxt.Text);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer updated successfully.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
            }
            finally
            {
               
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
