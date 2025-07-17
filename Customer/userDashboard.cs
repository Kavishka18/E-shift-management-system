using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_Shift_Management_Sytem.DB;
using CircularProgressBar;



namespace e_Shift_Management_Sytem.Customer
{
    public partial class userDashboard: Form
    {
        public userDashboard()
        {
            InitializeComponent();
            LoadCustomerData();
            LoadApprovedStatusCount();
            InitializeClock();
        }

        private void LoadCustomerData()
        {
            try
            {
                // Query to get customer data and calculate the sum (count of unique customers)
                string query = "SELECT COUNT(DISTINCT CustomerID) AS TotalCustomers FROM [GrifindoToysSystem].[dbo].[TransportOperations]";

                // Execute the query using the DatabaseConnection class
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    int totalCustomers = Convert.ToInt32(dataTable.Rows[0]["TotalCustomers"]);

                    // Now update the circular progress bar with the total customers
                    circularProgressBar.Value = totalCustomers; // Assuming you set the value to display customer count
                    circularProgressBar.Maximum = 1000; // Adjust the maximum value based on your needs
                    circularProgressBar.Minimum = 0;

                    // Optionally, show the value as a label
                    labelCustomerCount.Text = $"{totalCustomers} Customers"; // Assuming you have a label to show the customer count
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching customer data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApprovedStatusCount()
        {
            try
            {
                // Query to get the count of 'Approved' status records
                string query = "SELECT COUNT(*) AS ApprovedCount FROM [GrifindoToysSystem].[dbo].[TransportOperations] WHERE [Status] = 'Accepted'";

                // Execute the query using the DatabaseConnection class
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    int approvedCount = Convert.ToInt32(dataTable.Rows[0]["ApprovedCount"]);

                    // Update the circular progress bar for the approved count
                    circularProgressBarApproved.Value = approvedCount;
                    circularProgressBarApproved.Maximum = 1000; // Adjust the maximum value based on your needs
                    circularProgressBarApproved.Minimum = 0;

                    // Optionally, display the approved count in a label
                    labelApprovedCount.Text = $"{approvedCount} Approved"; // Label showing approved status count
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching approved status count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeClock()
        {
            // Create a Timer control to update the time every second
            Timer clockTimer = new Timer();
            clockTimer.Interval = 1000; // 1000 milliseconds = 1 second
            clockTimer.Tick += new EventHandler(UpdateClock);
            clockTimer.Start();
        }

        // Method to update the time on the label
        private void UpdateClock(object sender, EventArgs e)
        {
            // Update the label with the current time
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt"); // 12-hour format with AM/PM
        }


        private void Logout_Click(object sender, EventArgs e)
        {
            Login l1 = new Login(); 
            l1.Show();
            this.Hide();
        }

        private void cusDetailsManagement_Click(object sender, EventArgs e)
        {
            CustomerDetailsManagement cdm = new CustomerDetailsManagement();
            cdm.Show();
            this.Hide();
        }

        private void CusTransportOperationManagement_Click(object sender, EventArgs e)
        {
            cusTransportOperationManagement ctom = new cusTransportOperationManagement();
            ctom.Show();
            this.Hide();
        }
    }
}
