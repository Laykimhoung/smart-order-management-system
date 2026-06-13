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
            O.OrderStatus AS [Status],
            O.TotalAmount AS [Total Price],
            FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt')
                AS [Order Date]
        FROM Orders O
        INNER JOIN Customers C
            ON O.CustomerID = C.CustomerID
        INNER JOIN Users U
            ON O.UserID = U.UserID
        ORDER BY O.OrderID ASC";

                dgvReports.DataSource =
                    DatabaseConnection.ExecuteQuery(query);
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
            O.OrderStatus AS [Status],
            O.TotalAmount AS [Total Price],
            FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt')
                AS [Order Date]
        FROM Orders O
        INNER JOIN Customers C
            ON O.CustomerID = C.CustomerID
        INNER JOIN Users U
            ON O.UserID = U.UserID
        WHERE O.OrderDate
        BETWEEN @DateFrom
        AND @DateTo
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
