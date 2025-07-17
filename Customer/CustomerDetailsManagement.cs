using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_Shift_Management_Sytem.Admin;
using e_Shift_Management_Sytem.DB;
using e_Shift_Management_Sytem.Validation;

namespace e_Shift_Management_Sytem.Customer
{
    public partial class CustomerDetailsManagement: Form
    {
        public CustomerDetailsManagement()
        {
            InitializeComponent();
        }


        private void Return_Click(object sender, EventArgs e)
        {
            userDashboard us = new userDashboard();
            us.Show();
            this.Hide();
        }

        private DataTable LinearSearchCustomer(string searchQuery)
        {
            DataTable data = DatabaseConnection.ExecuteQuery("SELECT * FROM Customers");
            DataTable searchResults = data.Clone(); // Create a new empty DataTable with the same schema

            foreach (DataRow row in data.Rows)
            {
                if (row["CustomerName"].ToString().ToLower().Contains(searchQuery.ToLower())) // Case-insensitive search for matching CustomerName
                {
                    searchResults.ImportRow(row); // Add matching row to the results
                }
            }
            return searchResults;
        }

        private void LoadCustomers()
        {
            int currentUserId = int.Parse(text_userid.Text.Trim()); // Or however you track the logged-in user's ID.

            string query = "SELECT * FROM Customers WHERE userId = @userId";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@userId", SqlDbType.Int) { Value = currentUserId }
            };

            DataTable data = DatabaseConnection.ExecuteQuery(query, parameters);
            dataGridViewCustomers.DataSource = data;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            ErrorProvider errorProvider = new ErrorProvider();

            try
            {
                // Validate fields
                if (!RegexValidation.IsValidText(txtCustomerName.Text))
                {
                    RegexValidation.SetError(txtCustomerName, "Customer Name is required", errorProvider);
                    return;
                }
                else
                {
                    RegexValidation.ClearError(txtCustomerName, errorProvider);
                }

                if (!RegexValidation.IsValidEmail(txtEmail.Text))
                {
                    RegexValidation.SetError(txtEmail, "Invalid Email", errorProvider);
                    return;
                }
                else
                {
                    RegexValidation.ClearError(txtEmail, errorProvider);
                }

                if (!RegexValidation.IsValidContactNumber(txtContactNumber.Text))
                {
                    RegexValidation.SetError(txtContactNumber, "Invalid Contact Number", errorProvider);
                    return;
                }
                else
                {
                    RegexValidation.ClearError(txtContactNumber, errorProvider);
                }

                // Assuming the employee user ID is available
                int currentUserId = int.Parse(text_userid.Text.Trim());

                string query = "INSERT INTO Customers (CustomerName, CustomerAddress, ContactNumber, Email, userId) " +
                               "VALUES (@CustomerName, @CustomerAddress, @ContactNumber, @Email, @userId)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CustomerName", SqlDbType.NVarChar) { Value = txtCustomerName.Text },
                    new SqlParameter("@CustomerAddress", SqlDbType.NVarChar) { Value = txtCustomerAddress.Text },
                    new SqlParameter("@ContactNumber", SqlDbType.NVarChar) { Value = txtContactNumber.Text },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = txtEmail.Text },
                    new SqlParameter("@userId", SqlDbType.Int) { Value = currentUserId }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Customers SET CustomerName = @CustomerName, CustomerAddress = @CustomerAddress, " +
                               "ContactNumber = @ContactNumber, Email = @Email WHERE CustomerID = @CustomerID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CustomerName", SqlDbType.NVarChar) { Value = txtCustomerName.Text },
                    new SqlParameter("@CustomerAddress", SqlDbType.NVarChar) { Value = txtCustomerAddress.Text },
                    new SqlParameter("@ContactNumber", SqlDbType.NVarChar) { Value = txtContactNumber.Text },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = txtEmail.Text },
                    new SqlParameter("@CustomerID", SqlDbType.Int) { Value = int.Parse(txtCustomerID.Text) }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();  // Reload the data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CustomerID", SqlDbType.Int) { Value = int.Parse(txtCustomerID.Text) }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();  // Reload the data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery = txtSearchCustomerName.Text; // User input
                DataTable result = LinearSearchCustomer(searchQuery);

                if (result.Rows.Count > 0)
                {
                    dataGridViewCustomers.DataSource = result; // Display search results
                }
                else
                {
                    MessageBox.Show("No customers found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txtCustomerName.Clear();
            txtCustomerAddress.Clear();
            txtContactNumber.Clear();
            txtEmail.Clear();
            txtCustomerID.Clear();
            txtSearchCustomerName.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            adminDashboard ad = new adminDashboard();
            ad.Show();
            this.Hide();

        }
    }
}
