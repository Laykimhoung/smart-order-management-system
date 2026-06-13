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
using PdfDocument = iTextSharp.text.Document;
using PdfFont = iTextSharp.text.Font;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

            cmbReportType.Items.Add("");
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
                new System.Drawing.Font(
                    "Segoe UI",
                    11,
                    System.Drawing.FontStyle.Bold);

            dgvReports.DefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    10);

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

                if (string.IsNullOrWhiteSpace(cmbReportType.Text))
                {
                    dateFrom = dtpFrom.Value.Date;

                    dateTo =
                        dtpTo.Value.Date.AddDays(1);
                }
                else
                {
                    switch (cmbReportType.Text)
                    {
                        case "Daily":

                            dateFrom =
                                dtpFrom.Value.Date;

                            dateTo =
                                dateFrom.AddDays(1);

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

                            dateFrom =
                                dtpFrom.Value.Date;

                            dateTo =
                                dtpTo.Value.Date.AddDays(1);

                            break;
                    }
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

                // =====================
                // EXPORT CONFIRMATION
                // =====================

                string exportType;

                if (string.IsNullOrWhiteSpace(
                    cmbReportType.Text))
                {
                    exportType =
                        "Custom Date Range";
                }
                else
                {
                    exportType =
                        cmbReportType.Text;
                }

                string periodText = "";

                if (string.IsNullOrWhiteSpace(
                    cmbReportType.Text))
                {
                    periodText =
                        dtpFrom.Value.ToString("dd/MM/yyyy")
                        + " - " +
                        dtpTo.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    periodText = cmbReportType.Text;
                }

                DialogResult confirm =
                    MessageBox.Show(
                        "Export current report?\n\n" +
                        "Type: " + exportType +
                        "\nPeriod: " + periodText,
                        "Confirm Export",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                {
                    return;
                }

                // =====================
                // SAVE FILE
                // =====================

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "Excel File (*.xlsx)|*.xlsx";

                save.FileName =
                string.IsNullOrWhiteSpace(cmbReportType.Text)
                ? "Custom_Report.xlsx"
                : cmbReportType.Text + "_Report.xlsx";

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
                        if (string.IsNullOrWhiteSpace(cmbReportType.Text))
                        {
                            periodText =
                                dtpFrom.Value.ToString("dd/MM/yyyy")
                                + " - " +
                                dtpTo.Value.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            switch (cmbReportType.Text)
                            {
                                case "Daily":

                                    periodText =
                                        dtpFrom.Value.ToString(
                                            "dd/MM/yyyy");

                                    break;

                                case "Weekly":

                                    DateTime startOfWeek =
                                        dtpFrom.Value.Date.AddDays(
                                            -(int)dtpFrom.Value.DayOfWeek);

                                    DateTime endOfWeek =
                                        startOfWeek.AddDays(6);

                                    periodText =
                                        startOfWeek.ToString("dd/MM/yyyy")
                                        + " - " +
                                        endOfWeek.ToString("dd/MM/yyyy");

                                    break;

                                case "Monthly":

                                    periodText =
                                        dtpFrom.Value.ToString(
                                            "MMMM yyyy");

                                    break;

                                case "Yearly":

                                    periodText =
                                        dtpFrom.Value.Year.ToString();

                                    break;
                            }
                        }

                        ws.Cells["A3:E3"].Merge = true;

                        ws.Cells["A3"].Value = "ORDER REPORT";

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
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReports.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No data to export.",
                        "PDF Export",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string periodText = "";

                if (string.IsNullOrWhiteSpace(cmbReportType.Text))
                {
                    periodText =
                        dtpFrom.Value.ToString("dd/MM/yyyy")
                        + " - " +
                        dtpTo.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    switch (cmbReportType.Text)
                    {
                        case "Daily":

                            periodText =
                                dtpFrom.Value.ToString(
                                    "dd/MM/yyyy");

                            break;

                        case "Weekly":

                            DateTime startOfWeek =
                                dtpFrom.Value.Date.AddDays(
                                    -(int)dtpFrom.Value.DayOfWeek);

                            DateTime endOfWeek =
                                startOfWeek.AddDays(6);

                            periodText =
                                startOfWeek.ToString("dd/MM/yyyy")
                                + " - " +
                                endOfWeek.ToString("dd/MM/yyyy");

                            break;

                        case "Monthly":

                            periodText =
                                dtpFrom.Value.ToString(
                                    "MMMM yyyy");

                            break;

                        case "Yearly":

                            periodText =
                                dtpFrom.Value.Year.ToString();

                            break;
                    }
                }

                DialogResult confirm =
                    MessageBox.Show(
                        "Export current report as PDF?\n\n" +
                        "Period: " + periodText,
                        "Confirm Export",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                {
                    return;
                }

                SaveFileDialog save =
                    new SaveFileDialog();

                save.Filter =
                    "PDF File (*.pdf)|*.pdf";

                save.FileName =
                    string.IsNullOrWhiteSpace(cmbReportType.Text)
                    ? "Custom_Report.pdf"
                    : cmbReportType.Text + "_Report.pdf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    Document document =
                        new Document(
                            PageSize.A4.Rotate(),
                            20,
                            20,
                            20,
                            20);

                    PdfWriter.GetInstance(
                        document,
                        new FileStream(
                            save.FileName,
                            FileMode.Create));

                    document.Open();

                    iTextSharp.text.Font titleFont =
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        18);

                    iTextSharp.text.Font subTitleFont =
                        FontFactory.GetFont(
                            FontFactory.HELVETICA_BOLD,
                            14);

                    iTextSharp.text.Font normalFont =
                        FontFactory.GetFont(
                            FontFactory.HELVETICA,
                            11);

                    Paragraph title =
                        new Paragraph(
                            new Phrase(
                                "SMART ORDER MANAGEMENT SYSTEM",
                                titleFont));

                    title.Alignment =
                        Element.ALIGN_CENTER;

                    document.Add(title);

                    document.Add(
                        new Paragraph(" "));

                    Paragraph reportTitle =
                        new Paragraph(
                            new Phrase(
                                "ORDER REPORT",
                                subTitleFont));

                    reportTitle.Alignment =
                        Element.ALIGN_CENTER;

                    document.Add(reportTitle);

                    Paragraph period =
                        new Paragraph(
                            new Phrase(
                                "Period: " + periodText,
                                normalFont));

                    period.Alignment =
                        Element.ALIGN_CENTER;

                    document.Add(period);

                    Paragraph generated =
                        new Paragraph(
                            new Phrase(
                                "Generated: "
                                + DateTime.Now.ToString(
                                    "dd/MM/yyyy hh:mm tt"),
                                normalFont));

                    generated.Alignment =
                        Element.ALIGN_CENTER;

                    document.Add(generated);

                    document.Add(
                        new Paragraph(" "));

                    PdfPTable table =
                        new PdfPTable(
                            dgvReports.Columns.Count);

                    table.DefaultCell.HorizontalAlignment =
                     Element.ALIGN_CENTER;

                    table.DefaultCell.VerticalAlignment =
                        Element.ALIGN_MIDDLE;

                    table.WidthPercentage = 100;

                    foreach (DataGridViewColumn col
                        in dgvReports.Columns)
                    {
                        PdfPCell cell =
                            new PdfPCell(
                                new Phrase(
                                    col.HeaderText,
                                    normalFont));

                        cell.BackgroundColor =
                            BaseColor.DARK_GRAY;

                        cell.VerticalAlignment =
                        Element.ALIGN_MIDDLE;

                        cell.HorizontalAlignment =
                            Element.ALIGN_CENTER;

                        cell.Phrase.Font.Color =
                            BaseColor.WHITE;

                        table.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dgvReports.Rows)
                    {
                        for (int col = 0; col < row.Cells.Count; col++)
                        {
                            string value =
                                row.Cells[col].Value?.ToString() ?? "";

                            // Total Price column
                            if (col == 3)
                            {
                                value =
                                    "$" +
                                    Convert.ToDecimal(value)
                                    .ToString("N2");
                            }

                            // Order Date column
                            if (col == 4)
                            {
                                value =
                                    value.Replace(" AM", "    AM")
                                         .Replace(" PM", "    PM");
                            }

                            PdfPCell pdfCell =
                                new PdfPCell(
                                    new Phrase(value));

                            pdfCell.HorizontalAlignment =
                                Element.ALIGN_CENTER;

                            pdfCell.VerticalAlignment =
                                Element.ALIGN_MIDDLE;

                            table.AddCell(pdfCell);
                        }
                    }

                    document.Add(table);

                    document.Add(
                        new Paragraph(" "));

                    decimal totalRevenue = 0;

                    foreach (DataGridViewRow row
                        in dgvReports.Rows)
                    {
                        if (row.Cells["Total Price"].Value
                            != null)
                        {
                            totalRevenue +=
                                Convert.ToDecimal(
                                row.Cells["Total Price"].Value);
                        }
                    }

                    Paragraph totalOrders =
                        new Paragraph(
                            new Phrase(
                                "Total Orders : "
                                + dgvReports.Rows.Count,
                                subTitleFont));


                    totalOrders.Alignment =
                        Element.ALIGN_CENTER;

                    document.Add(totalOrders);

                    Paragraph totalRevenueText =
                        new Paragraph(
                            new Phrase(
                                "Total Revenue : $"
                                + totalRevenue.ToString("N2"),
                                subTitleFont));

                    document.Add(totalRevenueText);
                    totalRevenueText.Alignment =
                        Element.ALIGN_CENTER;

                    document.Close();

                    MessageBox.Show(
                        "PDF exported successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "PDF Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
