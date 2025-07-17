using e_Shift_Management_Sytem.DB;
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

namespace e_Shift_Management_Sytem.Admin
{
    public partial class OperationAcceptDeclined: Form
    {
        public OperationAcceptDeclined()
        {
            InitializeComponent();
        }

        private void admin_acept_Load(object sender, EventArgs e)
        {
            LoadTransportOperations();

        }

        private void LoadTransportOperations()
        {
            string query = "SELECT * FROM TransportOperations";
            DataTable data = DatabaseConnection.ExecuteQuery(query);
            dataGridViewTransportOperations.DataSource = data;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            adminDashboard sd = new adminDashboard();
            sd.Show();
            this.Hide();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE TransportOperations SET Status = @Status WHERE OperationID = @OperationID";
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Status", SqlDbType.NVarChar) { Value = "Accepted" },
                    new SqlParameter("@OperationID", SqlDbType.Int) { Value = txtOperationID.Text }
                };
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                LoadTransportOperations();  // Reload data after accepting
                MessageBox.Show("Transport operation accepted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while accepting the transport operation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE TransportOperations SET Status = @Status WHERE OperationID = @OperationID";
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Status", SqlDbType.NVarChar) { Value = "Declined" },
                    new SqlParameter("@OperationID", SqlDbType.Int) { Value = txtOperationID.Text }
                };
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                LoadTransportOperations();  // Reload data after declining
                MessageBox.Show("Transport operation declined.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while declining the transport operation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
