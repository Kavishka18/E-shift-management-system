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

namespace e_Shift_Management_Sytem.Admin
{
    public partial class cusAndAdminMangement: Form
    {
        public cusAndAdminMangement()
        {
            InitializeComponent();
            gridUser();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            adminDashboard ad = new adminDashboard();
            ad.Show();
            this.Hide();

        }

        private void gridUser()
        {
            try
            {
                string query = "SELECT * FROM loginUser";
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                dataGridView_userData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_userId.Text) || string.IsNullOrWhiteSpace(txt_conPassword.Text))
                {
                    MessageBox.Show("Fill in the User ID and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txt_password.Text != txt_conPassword.Text)
                {
                    MessageBox.Show("Passwords do not match. Please confirm your password.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_conPassword.Clear();
                    txt_conPassword.Focus();
                    return;
                }

                if (!int.TryParse(txt_userId.Text, out int userId))
                {
                    MessageBox.Show("User ID must be a valid integer.", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_userId.Clear();
                    txt_userId.Focus();
                    return;
                }

                string userType = radio_admin.Checked ? "Admin" : "User";

                string query = "INSERT INTO loginUser (userId, password, userType) VALUES (@userId, @password, @userType)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@userId", SqlDbType.Int) { Value = userId },
                    new SqlParameter("@password", SqlDbType.NVarChar) { Value = txt_conPassword.Text },
                    new SqlParameter("@userType", SqlDbType.NVarChar) { Value = userType }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);

                MessageBox.Show("Successfully Added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_userId.Text) || string.IsNullOrWhiteSpace(txt_conPassword.Text))
                {
                    MessageBox.Show("Fill in both User ID and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txt_password.Text != txt_conPassword.Text)
                {
                    MessageBox.Show("Passwords do not match. Please confirm your password.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_conPassword.Clear();
                    txt_conPassword.Focus();
                    return;
                }

                if (!int.TryParse(txt_userId.Text, out int userId))
                {
                    MessageBox.Show("User ID must be a valid integer.", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_userId.Clear();
                    txt_userId.Focus();
                    return;
                }

                string userType = radio_admin.Checked ? "Admin" : "User";

                string query = "UPDATE loginUser SET password = @password, userType = @userType WHERE userId = @userId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@userId", SqlDbType.Int) { Value = userId },
                    new SqlParameter("@password", SqlDbType.NVarChar) { Value = txt_conPassword.Text },
                    new SqlParameter("@userType", SqlDbType.NVarChar) { Value = userType }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);

                MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_userId.Text))
                {
                    MessageBox.Show("Fill in the User ID field.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txt_userId.Text, out int userId))
                {
                    MessageBox.Show("User ID must be a valid integer.", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_userId.Clear();
                    txt_userId.Focus();
                    return;
                }

                string query = "DELETE FROM loginUser WHERE userId = @userId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@userId", SqlDbType.Int) { Value = userId }
                };

                DatabaseConnection.ExecuteNonQuery(query, parameters);

                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            txt_userId.Clear();
            txt_password.Clear();
            txt_conPassword.Clear();
            radio_admin.Checked = false;
            radio_user.Checked = false;
        }

        private void btn_newAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT MAX(userId) FROM loginUser";
                DataTable result = DatabaseConnection.ExecuteQuery(query);

                int latestUserId = result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value ? (int)result.Rows[0][0] : 0;

                int newUserId = latestUserId + 1;
                txt_userId.Text = newUserId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picture_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txt_search.Text, out int userIdToSearch))
                {
                    MessageBox.Show("Please enter a valid User ID for searching.", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "SELECT * FROM loginUser WHERE userId = @userId";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@userId", SqlDbType.Int) { Value = userIdToSearch }
                };

                DataTable result = DatabaseConnection.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    dataGridView_userData.DataSource = result;
                }
                else
                {
                    MessageBox.Show("No record found with the provided User ID.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView_userData.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
