using SmartOrderManagementSystem.Database;
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
using OfficeOpenXml;
using System.IO;

namespace SmartOrderManagementSystem.Forms.Admin
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadReports();
            LoadReportTypes();
            StyleReportGrid();
        }
        private void LoadReports()
        {
            try
            {
                string query = @"
        SELECT
            O.OrderID AS [Order ID],
            C.CustomerName AS [Customer Name],
            U.FullName AS [Staff Name],
            CAST(O.TotalAmount AS DECIMAL(10,2)) AS [Total Price],
            FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt')
                AS [Order Date]
        FROM Orders O
        INNER JOIN Customers C
            ON O.CustomerID = C.CustomerID
        INNER JOIN Users U
            ON O.UserID = U.UserID
        WHERE O.OrderStatus = 'Completed'
        ORDER BY O.OrderID ASC";

                dgvReports.DataSource =
                    DatabaseConnection.ExecuteQuery(query);
                dgvReports.Columns["Total Price"]
                    .DefaultCellStyle.Format = "N2";

                dgvReports.Columns["Order ID"].FillWeight = 60;

                StyleReportGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadReportTypes()
        {
            cmbReportType.Items.Clear();

            cmbReportType.Items.Add("Daily");
            cmbReportType.Items.Add("Weekly");
            cmbReportType.Items.Add("Monthly");
            cmbReportType.Items.Add("Yearly");

            cmbReportType.SelectedIndex = 0;
        }
        private void StyleReportGrid()
        {
            dgvReports.BorderStyle = BorderStyle.None;

            dgvReports.BackgroundColor = Color.White;

            dgvReports.RowHeadersVisible = false;

            dgvReports.AllowUserToAddRows = false;

            dgvReports.AllowUserToResizeRows = false;

            dgvReports.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvReports.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvReports.ReadOnly = true;

            dgvReports.EnableHeadersVisualStyles = false;

            dgvReports.ColumnHeadersHeight = 45;

            dgvReports.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(35, 35, 35);

            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvReports.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvReports.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvReports.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvReports.DefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 10);

            dgvReports.RowTemplate.Height = 38;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
        SELECT
            O.OrderID AS [Order ID],
            C.CustomerName AS [Customer Name],
            U.FullName AS [Staff Name],
            CAST(O.TotalAmount AS DECIMAL(10,2)) AS [Total Price],
            FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt')
                AS [Order Date]
        FROM Orders O
        INNER JOIN Customers C
            ON O.CustomerID = C.CustomerID
        INNER JOIN Users U
            ON O.UserID = U.UserID
        WHERE O.OrderStatus = 'Completed'
        AND O.OrderDate BETWEEN @DateFrom AND @DateTo
        ORDER BY O.OrderID ASC";

                SqlParameter[] parameters =
                {
            new SqlParameter(
                "@DateFrom",
                dtpFrom.Value.Date),

            new SqlParameter(
                "@DateTo",
                dtpTo.Value.Date.AddDays(1))
            };

                dgvReports.DataSource =
                    DatabaseConnection.ExecuteQueryWithParams(
                        query,
                        parameters);
                dgvReports.Columns["Total Price"]
                    .DefaultCellStyle.Format = "N2";

                dgvReports.Columns["Order ID"].FillWeight = 60;

                StyleReportGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;

            cmbReportType.SelectedIndex = 0;

            LoadReports();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReports.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No data to export.");

                    return;
                }

                SaveFileDialog save =
                    new SaveFileDialog();

                save.Filter =
                    "Excel File|*.xlsx";

                save.FileName =
                    cmbReportType.Text +
                    "_Report.xlsx";

                if (save.ShowDialog()
                    == DialogResult.OK)
                {
                    using (ExcelPackage package =
                        new ExcelPackage())
                    {
                        ExcelWorksheet ws =
                            package.Workbook.Worksheets
                            .Add("Reports");

                        // Headers
                        for (int i = 0;
                            i < dgvReports.Columns.Count;
                            i++)
                        {
                            ws.Cells[1, i + 1].Value =
                                dgvReports.Columns[i]
                                .HeaderText;
                        }

                        // Data
                        for (int row = 0;
                            row < dgvReports.Rows.Count;
                            row++)
                        {
                            for (int col = 0;
                                col < dgvReports.Columns.Count;
                                col++)
                            {
                                ws.Cells[row + 2, col + 1]
                                    .Value =
                                    dgvReports.Rows[row]
                                    .Cells[col]
                                    .Value;
                            }
                        }

                        ws.Cells.AutoFitColumns();

                        FileInfo file =
                            new FileInfo(save.FileName);

                        package.SaveAs(file);
                    }

                    MessageBox.Show(
                        "Excel exported successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
