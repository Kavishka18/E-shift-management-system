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
using e_Shift_Management_Sytem.Customer;

namespace e_Shift_Management_Sytem.Admin
{
    public partial class adminDashboard: Form
    {
        public adminDashboard()
        {
            InitializeComponent();
            InitializeClock();
            LoadCustomerData();
            LoadTransportUnitData();
            LoadDriverData();
        }

        public static int currentUserId; // To store userId of logged-in user
        public static string currentUserType;

        private void Logout_Click(object sender, EventArgs e)
        {
            Login lA = new Login();
            lA.Show();
            this.Hide();
        }

        private void LoadDriverData()
        {
            try
            {
                // Query to get the distinct count of drivers
                string query = "SELECT COUNT(DISTINCT DriverName) AS TotalDrivers FROM [GrifindoToysSystem].[dbo].[TransportUnits]";

                // Execute the query using the DatabaseConnection class
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    int totalDrivers = Convert.ToInt32(dataTable.Rows[0]["TotalDrivers"]);

                    // Update the circular progress bar with the total drivers
                    circularProgressBarDrivers.Value = totalDrivers; // Assuming circularProgressBarDrivers is your progress bar for drivers
                    circularProgressBarDrivers.Maximum = 1000; // Adjust the maximum value based on your needs
                    circularProgressBarDrivers.Minimum = 0;

                    // Optionally, show the value as a label
                    labelDriverCount.Text = $"{totalDrivers} Drivers"; // Label for driver count
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching driver data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransportUnitData()
        {
            try
            {
                // Query to get transport unit data (count of unique transport units)
                string query = "SELECT COUNT(DISTINCT TransportUnitID) AS TotalTransportUnits FROM [GrifindoToysSystem].[dbo].[TransportUnits]";

                // Execute the query using the DatabaseConnection class
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    int totalTransportUnits = Convert.ToInt32(dataTable.Rows[0]["TotalTransportUnits"]);

                    // Update the circular progress bar with the total transport units
                    circularProgressBarTransportUnits.Value = totalTransportUnits; // Assuming circularProgressBarTransportUnits is your progress bar for transport units
                    circularProgressBarTransportUnits.Maximum = 1000; // Adjust the maximum value based on your needs
                    circularProgressBarTransportUnits.Minimum = 0;

                    // Optionally, show the value as a label
                    labelTransportUnitCount.Text = $"{totalTransportUnits} Transport Units"; // Assuming you have a label for the transport unit count
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching transport unit data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void cusDetailsManagement_Click(object sender, EventArgs e)
        {
            CustomerDetailsManagement acdm = new CustomerDetailsManagement();
            acdm.Show();
            this.Hide();
        }

        private void CusTransportOperationManagement_Click(object sender, EventArgs e)
        {
            cusTransportOperationManagement actom = new cusTransportOperationManagement();
            actom.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cusAndAdminMangement acaam = new cusAndAdminMangement();
            acaam.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OperationAcceptDeclined operationAcceptDeclined = new OperationAcceptDeclined();
            operationAcceptDeclined.Show();
            this.Hide();
        }

        private void managePT_Click(object sender, EventArgs e)
        {
            TunitAndProdManagement aapm = new TunitAndProdManagement();
            aapm.Show();
            this.Hide();
        }

        private void manageReport_Click(object sender, EventArgs e)
        {
            AdminReportForm arf = new AdminReportForm();
            arf.Show();
            this.Hide();
        }
    }
}
