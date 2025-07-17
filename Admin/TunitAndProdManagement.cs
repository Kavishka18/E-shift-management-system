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
    public partial class TunitAndProdManagement: Form
    {
        public TunitAndProdManagement()
        {
            InitializeComponent();
        }


        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Products WHERE ProductName LIKE @ProductName";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@ProductName", SqlDbType.NVarChar) { Value = "%" + txtSearchProductName.Text + "%" }
                };
                DataTable data = DatabaseConnection.ExecuteQuery(query, parameters);
                dataGridViewProducts.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            adminDashboard ad = new adminDashboard();
            ad.Show();
            this.Hide();
        }

        private void TunitAndProdManagement_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadTransportUnits();
            LoadProductsForTransportUnits();
        }

        private void LoadProductsForTransportUnits()
        {
            string query = "SELECT ProductID, ProductName FROM Products";
            DataTable data = DatabaseConnection.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                comboBoxProduct.DisplayMember = "ProductName";
                comboBoxProduct.ValueMember = "ProductID";
                comboBoxProduct.DataSource = data;
            }
            else
            {
                MessageBox.Show("No products available.");
            }
        }

        private void LoadProducts()
        {
            string query = "SELECT * FROM Products";
            DataTable data = DatabaseConnection.ExecuteQuery(query);
            dataGridViewProducts.DataSource = data;
        }

        // Load Transport Units into DataGridView
        private void LoadTransportUnits()
        {
            string query = "SELECT * FROM TransportUnits";
            DataTable data = DatabaseConnection.ExecuteQuery(query);
            dataGridViewTransportUnits.DataSource = data;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Products (ProductName, ProductDescription, Price, Quantity) " +
                               "VALUES (@ProductName, @ProductDescription, @Price, @Quantity)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@ProductName", SqlDbType.NVarChar) { Value = txtProductName.Text },
            new SqlParameter("@ProductDescription", SqlDbType.NVarChar) { Value = txtProductDescription.Text },
            new SqlParameter("@Price", SqlDbType.Decimal) { Value = decimal.Parse(txtPrice.Text) },
            new SqlParameter("@Quantity", SqlDbType.Int) { Value = int.Parse(txtQuantity.Text) }
                };
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                LoadProducts();
                MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Products SET ProductName = @ProductName, ProductDescription = @ProductDescription, " +
                               "Price = @Price, Quantity = @Quantity WHERE ProductID = @ProductID";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@ProductName", SqlDbType.NVarChar) { Value = txtProductName.Text },
            new SqlParameter("@ProductDescription", SqlDbType.NVarChar) { Value = txtProductDescription.Text },
            new SqlParameter("@Price", SqlDbType.Decimal) { Value = decimal.Parse(txtPrice.Text) },
            new SqlParameter("@Quantity", SqlDbType.Int) { Value = int.Parse(txtQuantity.Text) },
            new SqlParameter("@ProductID", SqlDbType.Int) { Value = int.Parse(txtProductID.Text) }
                };
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                LoadProducts();
                MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@ProductID", SqlDbType.Int) { Value = int.Parse(txtProductID.Text) }
                };
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                LoadProducts();
                MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTransportUnit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO TransportUnits (UnitType, DriverName, AssistantName, VehicleNumber, ProductID) " +
                               "VALUES (@UnitType, @DriverName, @AssistantName, @VehicleNumber, @ProductID)";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@UnitType", SqlDbType.NVarChar) { Value = txtUnitType.Text },
            new SqlParameter("@DriverName", SqlDbType.NVarChar) { Value = txtDriverName.Text },
            new SqlParameter("@AssistantName", SqlDbType.NVarChar) { Value = txtAssistantName.Text },
            new SqlParameter("@VehicleNumber", SqlDbType.NVarChar) { Value = txtVehicleNumber.Text },
            new SqlParameter("@ProductID", SqlDbType.Int) { Value = comboBoxProduct.SelectedValue }
                };
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                LoadTransportUnits();
                MessageBox.Show("Transport unit added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding transport unit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        

        private void btnSearchTransportUnit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM TransportUnits WHERE UnitType LIKE @UnitType";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@UnitType", SqlDbType.NVarChar) { Value = "%" + txtSearchUnitType.Text + "%" }
                };
                DataTable data = DatabaseConnection.ExecuteQuery(query, parameters);
                dataGridViewTransportUnits.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for transport unit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
