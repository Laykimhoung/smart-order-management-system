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
                    .DefaultCellStyle.Format = "$0.00";

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

                DateTime dateFrom;
                DateTime dateTo;

                switch (cmbReportType.Text)
                {
                    case "Daily":

                        dateFrom = dtpFrom.Value.Date;

                        dateTo = dateFrom.AddDays(1);

                        break;

                    case "Weekly":

                        dateFrom =
                            dtpFrom.Value.Date.AddDays(
                                -(int)dtpFrom.Value.DayOfWeek);

                        dateTo =
                            dateFrom.AddDays(7);

                        break;

                    case "Monthly":

                        dateFrom =
                            new DateTime(
                                dtpFrom.Value.Year,
                                dtpFrom.Value.Month,
                                1);

                        dateTo =
                            dateFrom.AddMonths(1);

                        break;

                    case "Yearly":

                        dateFrom =
                            new DateTime(
                                dtpFrom.Value.Year,
                                1,
                                1);

                        dateTo =
                            dateFrom.AddYears(1);

                        break;

                    default:

                        dateFrom = dtpFrom.Value.Date;

                        dateTo = dtpTo.Value.Date.AddDays(1);

                        break;
                }

                SqlParameter[] parameters =
                {
                    new SqlParameter("@DateFrom", dateFrom),
                    new SqlParameter("@DateTo", dateTo)
                };

                dgvReports.DataSource =
                    DatabaseConnection.ExecuteQueryWithParams(
                        query,
                        parameters);
                dgvReports.Columns["Total Price"]
                    .DefaultCellStyle.Format = "$0.00";

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
                    MessageBox.Show("No data to export.");
                    return;
                }

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "Excel File (*.xlsx)|*.xlsx";

                save.FileName =
                    cmbReportType.Text + "_Report.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage package =
                        new ExcelPackage())
                    {
                        ExcelWorksheet ws =
                            package.Workbook.Worksheets.Add(
                                "Order Report");

                        // ==================================
                        // MAIN TITLE
                        // ==================================

                        ws.Cells["A1:E1"].Merge = true;

                        ws.Cells["A1"].Value =
                            "SMART ORDER MANAGEMENT SYSTEM";

                        ws.Cells["A1"].Style.Font.Bold = true;
                        ws.Cells["A1"].Style.Font.Size = 18;

                        ws.Cells["A1"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        // ==================================
                        // REPORT TITLE
                        // ==================================

                        string periodText = "";

                        switch (cmbReportType.Text)
                        {
                            case "Daily":

                                periodText =
                                    DateTime.Now.ToString(
                                        "dd/MM/yyyy");

                                break;

                            case "Weekly":

                                DateTime startOfWeek =
                                    DateTime.Now.Date.AddDays(
                                        -(int)DateTime.Now.DayOfWeek);

                                DateTime endOfWeek =
                                    startOfWeek.AddDays(6);

                                periodText =
                                    startOfWeek.ToString("dd/MM/yyyy")
                                    + " - " +
                                    endOfWeek.ToString("dd/MM/yyyy");

                                break;

                            case "Monthly":

                                periodText =
                                    DateTime.Now.ToString(
                                        "MMMM yyyy");

                                break;

                            case "Yearly":

                                periodText =
                                    DateTime.Now.Year.ToString();

                                break;
                        }

                        ws.Cells["A3:E3"].Merge = true;

                        ws.Cells["A3"].Value =
                            cmbReportType.Text.ToUpper()
                            + " ORDER REPORT";

                        ws.Cells["A3"].Style.Font.Bold = true;
                        ws.Cells["A3"].Style.Font.Size = 14;

                        ws.Cells["A3"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        ws.Cells["A4:E4"].Merge = true;

                        ws.Cells["A4"].Value =
                            "Period: " + periodText;

                        ws.Cells["A4"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        ws.Cells["A5:E5"].Merge = true;

                        ws.Cells["A5"].Value =
                            "Generated: "
                            + DateTime.Now.ToString(
                                "dd/MM/yyyy hh:mm tt");

                        ws.Cells["A5"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        // ==================================
                        // TABLE HEADER
                        // ==================================

                        int startRow = 7;

                        for (int i = 0;
                            i < dgvReports.Columns.Count;
                            i++)
                        {
                            ws.Cells[startRow, i + 1].Value =
                                dgvReports.Columns[i].HeaderText;
                        }

                        var headerRange =
                            ws.Cells[
                                startRow,
                                1,
                                startRow,
                                dgvReports.Columns.Count];

                        headerRange.Style.Font.Bold = true;

                        headerRange.Style.Font.Color.SetColor(
                            Color.White);

                        headerRange.Style.Fill.PatternType =
                            OfficeOpenXml.Style.ExcelFillStyle.Solid;

                        headerRange.Style.Fill.BackgroundColor
                            .SetColor(Color.DarkBlue);

                        headerRange.Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        // ==================================
                        // DATA
                        // ==================================

                        for (int row = 0;
                            row < dgvReports.Rows.Count;
                            row++)
                        {
                            for (int col = 0;
                                col < dgvReports.Columns.Count;
                                col++)
                            {
                                ws.Cells[
                                    row + startRow + 1,
                                    col + 1].Value =
                                    dgvReports.Rows[row]
                                    .Cells[col].Value;
                            }
                        }

                        int lastRow =
                            startRow + dgvReports.Rows.Count;

                        // ==================================
                        // CENTER TABLE
                        // ==================================

                        ws.Cells[
                            startRow,
                            1,
                            lastRow,
                            dgvReports.Columns.Count]
                            .Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        // ==================================
                        // PRICE COLUMN FORMAT
                        // Column D = Total Price
                        // ==================================

                        for (int row = startRow + 1;
                            row <= lastRow;
                            row++)
                        {
                            decimal price =
                                Convert.ToDecimal(
                                ws.Cells[row, 4].Value);

                            ws.Cells[row, 4].Value =
                                "$" + price.ToString("N2");
                        }

                        // ==================================
                        // BORDER
                        // ==================================

                        var tableRange =
                            ws.Cells[
                                startRow,
                                1,
                                lastRow,
                                dgvReports.Columns.Count];

                        tableRange.Style.Border.Top.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        tableRange.Style.Border.Bottom.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        tableRange.Style.Border.Left.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        tableRange.Style.Border.Right.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        // ==================================
                        // TOTALS
                        // ==================================

                        decimal totalRevenue = 0;

                        foreach (DataGridViewRow row
                            in dgvReports.Rows)
                        {
                            if (row.Cells["Total Price"].Value != null)
                            {
                                totalRevenue +=
                                    Convert.ToDecimal(
                                    row.Cells["Total Price"].Value);
                            }
                        }

                        ws.Cells[lastRow + 2, 1].Value =
                            "Total Orders";

                        ws.Cells[lastRow + 2, 2].Value =
                            dgvReports.Rows.Count;

                        ws.Cells[lastRow + 3, 1].Value =
                            "Total Revenue";

                        ws.Cells[lastRow + 3, 2].Value =
                            "$" + totalRevenue.ToString("N2");

                        ws.Cells[lastRow + 2, 1].Style.Font.Bold = true;
                        ws.Cells[lastRow + 3, 1].Style.Font.Bold = true;

                        ws.Cells[lastRow + 2, 2]
                            .Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        ws.Cells[lastRow + 3, 2]
                            .Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        // ==================================
                        // AUTO FIT
                        // ==================================

                        ws.Cells.AutoFitColumns();

                        package.SaveAs(
                            new FileInfo(save.FileName));
                    }

                    MessageBox.Show(
                        "Excel exported successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
