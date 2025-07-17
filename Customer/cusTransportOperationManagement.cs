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
using e_Shift_Management_Sytem.DB;
using Newtonsoft.Json;
using System.Net.Http;
using e_Shift_Management_Sytem.Admin;

namespace e_Shift_Management_Sytem.Customer
{
    public partial class cusTransportOperationManagement: Form
    {
        public cusTransportOperationManagement()
        {
            InitializeComponent();
          
        }

        private static string apiKey = "dLvrQIKxfXbVTKUZj72wk6btjwt9uSeTwFmTGU8isKBgKkqAXe4tQMreTExvrlBN";

        // Method to calculate distance between start and end location using Google Maps API
        private async Task<double> GetDistanceAsync(string startLocation, string endLocation)
        {
            if (string.IsNullOrWhiteSpace(startLocation) || string.IsNullOrWhiteSpace(endLocation))
            {
                MessageBox.Show("Start and End locations cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            try
            {
                // Construct the API URL
                string url = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={Uri.EscapeDataString(startLocation)}&destinations={Uri.EscapeDataString(endLocation)}&key={apiKey}";

                using (HttpClient client = new HttpClient())
                {
                    // Make the API request
                    HttpResponseMessage response = await client.GetAsync(url);
                    string responseString = await response.Content.ReadAsStringAsync();

                    // Log the response string for debugging
                    Console.WriteLine("API Response: " + responseString);

                    // Parse the JSON response
                    dynamic result = JsonConvert.DeserializeObject(responseString);

                    // Check if the response contains valid data
                    if (result.rows.Count > 0 && result.rows[0].elements.Count > 0)
                    {
                        double distance = Convert.ToDouble(result.rows[0].elements[0].distance.value) / 1000; // Convert from meters to kilometers
                        return distance;
                    }
                    else
                    {
                        MessageBox.Show("Unable to calculate distance. Please check the location inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log detailed error for debugging
                Console.WriteLine("Error calculating distance: " + ex.Message);
                MessageBox.Show("Error calculating distance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }



        private double CalculatePrice(double distance)
        {
            // Example price calculation (this can be customized based on your pricing model)
            double ratePerKm = 10.0; // Set rate per km
            return distance * ratePerKm;
        }

        private void LoadCustomers()
        {
            string query = "SELECT CustomerID, CustomerName FROM Customers"; // Change this to match your actual table/columns
            DataTable data = DatabaseConnection.ExecuteQuery(query);

            // Ensure comboBoxCustomer is populated with Customer Names, and CustomerID is used as value
            if (data.Rows.Count > 0)
            {
                comboBoxCustomer.DisplayMember = "CustomerName";  // This is what will be shown in the ComboBox
                comboBoxCustomer.ValueMember = "CustomerID";      // This is the value used in the query
                comboBoxCustomer.DataSource = data;
            }
            else
            {
                MessageBox.Show("No customers available.");
            }
        }

        private DataTable LinearSearchTransportOperations(string searchQuery)
        {
            DataTable data = DatabaseConnection.ExecuteQuery("SELECT * FROM TransportOperations");
            DataTable searchResults = data.Clone(); // Create a new empty DataTable with the same schema

            foreach (DataRow row in data.Rows)
            {
                if (row["OperationID"].ToString().Contains(searchQuery)) // Search for matching OperationID
                {
                    searchResults.ImportRow(row); // Add matching row to the results
                }
            }
            return searchResults;
        }

        private void LoadTransportUnits()
        {
            string query = "SELECT TransportUnitID, UnitType FROM TransportUnits";
            DataTable data = DatabaseConnection.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                comboBoxTransportUnit.DisplayMember = "UnitType";
                comboBoxTransportUnit.ValueMember = "TransportUnitID";
                comboBoxTransportUnit.DataSource = data;
            }
            else
            {
                MessageBox.Show("No transport units available.");
            }
        }

        private void LoadTransportOperations()
        {
            string query = "SELECT * FROM TransportOperations";
            DataTable data = DatabaseConnection.ExecuteQuery(query);
            dataGridViewTransportOperations.DataSource = data;
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the start and end locations
                string startLocation = txtStartLocation.Text;
                string endLocation = txtEndLocation.Text;

                // Calculate the distance
                double distance = await GetDistanceAsync(startLocation, endLocation);

                // Calculate the price
                double price = CalculatePrice(distance);

                // Set the calculated distance and price in the labels
                lblDistance.Text = $"{distance} km";
                lblPrice.Text = $"${price:F2}";

                // Insert the transport operation record into the database
                string query = "INSERT INTO TransportOperations (CustomerID, StartLocation, EndLocation, TransportUnitID, TransportDate, Status, Distance, Price) " +
                               "VALUES (@CustomerID, @StartLocation, @EndLocation, @TransportUnitID, @TransportDate, @Status, @Distance, @Price)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CustomerID", SqlDbType.Int) { Value = comboBoxCustomer.SelectedValue },
                    new SqlParameter("@StartLocation", SqlDbType.NVarChar) { Value = startLocation },
                    new SqlParameter("@EndLocation", SqlDbType.NVarChar) { Value = endLocation },
                    new SqlParameter("@TransportUnitID", SqlDbType.Int) { Value = comboBoxTransportUnit.SelectedValue },
                    new SqlParameter("@TransportDate", SqlDbType.Date) { Value = dateTimePickerTransportDate.Value },
                    new SqlParameter("@Status", SqlDbType.NVarChar) { Value = "Pending" },
                    new SqlParameter("@Distance", SqlDbType.Float) { Value = distance },
                    new SqlParameter("@Price", SqlDbType.Float) { Value = price }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Transport Operation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransportOperations();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding transport operation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cusTransportOperationManagement_Load(object sender, EventArgs e)
        {
            LoadTransportOperations();
            LoadTransportUnits();
            LoadCustomers();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE TransportOperations SET StartLocation = @StartLocation, EndLocation = @EndLocation, " +
                               "TransportUnitID = @TransportUnitID, TransportDate = @TransportDate, Status = @Status WHERE OperationID = @OperationID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@StartLocation", SqlDbType.NVarChar) { Value = txtStartLocation.Text },
                    new SqlParameter("@EndLocation", SqlDbType.NVarChar) { Value = txtEndLocation.Text },
                    new SqlParameter("@TransportUnitID", SqlDbType.Int) { Value = comboBoxTransportUnit.SelectedValue },
                    new SqlParameter("@TransportDate", SqlDbType.Date) { Value = dateTimePickerTransportDate.Value },
                    new SqlParameter("@Status", SqlDbType.NVarChar) { Value = "In-progress" },
                    new SqlParameter("@OperationID", SqlDbType.Int) { Value = int.Parse(txtOperationID.Text) }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Transport Operation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransportOperations();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating transport operation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM TransportOperations WHERE OperationID = @OperationID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@OperationID", SqlDbType.Int) { Value = int.Parse(txtOperationID.Text) }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Transport Operation deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransportOperations();  // Reload data
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting transport operation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchQuery = txtoperation.Text; // User input
                DataTable result = LinearSearchTransportOperations(searchQuery);

                if (result.Rows.Count > 0)
                {
                    dataGridViewTransportOperations.DataSource = result; // Display search results
                }
                else
                {
                    MessageBox.Show("No transport operations found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for transport operations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txtStartLocation.Clear();
            txtEndLocation.Clear();
            txtOperationID.Clear();
            comboBoxCustomer.SelectedIndex = -1; // Clear the selected customer
            comboBoxTransportUnit.SelectedIndex = -1; // Clear the selected transport unit
            dateTimePickerTransportDate.Value = DateTime.Now; // Reset to current date
        }

        //// Global variables to store user information (admin check)
        //public static int currentUserId; // To store userId of logged-in user
        //public static string currentUserType; // To store userType (Admin/User)


        private void Return_Click(object sender, EventArgs e)
        {
            userDashboard us = new userDashboard();
            us.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            adminDashboard adminDashboard = new adminDashboard();
            adminDashboard.Show();
            this.Hide();
        }
    }
}
