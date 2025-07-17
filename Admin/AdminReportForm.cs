using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using e_Shift_Management_Sytem.DB;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace e_Shift_Management_Sytem.Admin
{
    public partial class AdminReportForm : Form
    {
        public AdminReportForm()
        {
            InitializeComponent();
            cmbReportType.Items.Add("Customer Report");
            cmbReportType.Items.Add("Transport Operations Report");
            cmbReportType.Items.Add("Transport Units Report");
            cmbReportType.Items.Add("Products Report");
            cmbReportType.SelectedIndex = 0; // Default selection
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string reportType = cmbReportType.SelectedItem.ToString();
                string query = string.Empty;

                // Generate query based on selected report type
                if (reportType == "Customer Report")
                {
                    query = "SELECT * FROM Customers";
                }
                else if (reportType == "Transport Operations Report")
                {
                    query = "SELECT * FROM TransportOperations";
                }
                else if (reportType == "Transport Units Report")
                {
                    query = "SELECT * FROM TransportUnits";
                }
                else if (reportType == "Products Report")
                {
                    query = "SELECT * FROM Products";
                }

                // Apply filter if any (optional)
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    query += " WHERE CustomerName LIKE @searchText"; // Modify according to filter column
                }

                // Execute query and load data into DataGridView
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@searchText", SqlDbType.NVarChar) { Value = "%" + txtSearch.Text + "%" }
                };

                DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
                dataGridViewReport.DataSource = dt;

                // Show the count of records in label
                lblCount.Text = $"Total Records: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownloadReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewReport.Rows.Count == 0)
                {
                    MessageBox.Show("No data available to download.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a SaveFileDialog to choose the save location
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save Report as PDF";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Create a Document and a PdfWriter instance to generate the PDF
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    doc.Open();

                    // Adding Title to the PDF
                    doc.Add(new Paragraph("Report - " + cmbReportType.SelectedItem.ToString()));
                    doc.Add(new Paragraph("Generated on: " + DateTime.Now.ToString()));
                    doc.Add(new Paragraph("\n"));

                    // Adding DataGridView content to the PDF
                    PdfPTable table = new PdfPTable(dataGridViewReport.Columns.Count);

                    // Set table widths (adjust based on your needs)
                    float[] columnWidths = new float[dataGridViewReport.Columns.Count];
                    for (int i = 0; i < dataGridViewReport.Columns.Count; i++)
                    {
                        columnWidths[i] = 2f; // Adjust column width ratio based on your needs
                    }
                    table.SetWidths(columnWidths);

                    // Adding table headers (without unnecessary font styles)
                    foreach (DataGridViewColumn column in dataGridViewReport.Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText));
                        headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(headerCell);
                    }

                    // Adding table rows
                    foreach (DataGridViewRow row in dataGridViewReport.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string cellValue = cell.Value?.ToString() ?? "";
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue));
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(pdfCell);
                            }
                        }
                    }

                    // Add table to document
                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("Report downloaded as PDF successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            adminDashboard ada = new adminDashboard();
            ada.Show();
            this.Hide();
        }
    }
}
