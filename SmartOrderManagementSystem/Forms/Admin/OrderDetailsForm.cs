using System;
using SmartOrderManagementSystem.Database;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PdfFont = iTextSharp.text.Font;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SmartOrderManagementSystem.Forms.Admin
{
    public partial class OrderDetailsForm : Form
    {
        private int orderId;

        public OrderDetailsForm(int selectedOrderId)
        {
            InitializeComponent();
            orderId = selectedOrderId;
        }
        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            LoadOrderInformation();
            LoadOrderItems();
        }
        private void LoadOrderInformation()
        {
            try
            {
                string query = @"
SELECT
    O.OrderID,
    O.WaitingNumber,
    O.OrderStatus,
    O.OrderDate,
    O.TotalAmount,
    C.CustomerName,
    U.FullName
FROM Orders O
INNER JOIN Customers C
    ON O.CustomerID = C.CustomerID
INNER JOIN Users U
    ON O.UserID = U.UserID
WHERE O.OrderID = @OrderID";

                SqlParameter[] parameters =
                {
            new SqlParameter("@OrderID", orderId)
        };

                DataTable dt =
                    DatabaseConnection.ExecuteQueryWithParams(
                        query,
                        parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    lblOrderIDValue.Text =
                        row["OrderID"].ToString();

                    lblWaitingNoValue.Text =
                        row["WaitingNumber"].ToString();

                    lblCustomerNameValue.Text =
                        row["CustomerName"].ToString();

                    lblStaffNameValue.Text =
                        row["FullName"].ToString();

                    lblStatusValue.Text =
                        row["OrderStatus"].ToString();

                    lblOrderDateValue.Text =
                        Convert.ToDateTime(
                            row["OrderDate"])
                        .ToString("dd/MM/yyyy  hh:mm tt");

                    lblTotalAmountValue.Text =
                        "$" +
                        Convert.ToDecimal(
                            row["TotalAmount"])
                        .ToString("N2");

                    // Status Color
                    if (lblStatusValue.Text == "Completed")
                        lblStatusValue.ForeColor = Color.Green;

                    else if (lblStatusValue.Text == "Pending")
                        lblStatusValue.ForeColor = Color.Orange;

                    else if (lblStatusValue.Text == "Cancelled")
                        lblStatusValue.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadOrderItems()
        {
            try
            {
                string query = @"
SELECT
    P.ProductName AS [Product],
    OI.Quantity AS [Qty],
    OI.UnitPrice AS [Unit Price],
    (OI.Quantity * OI.UnitPrice)
        AS [Subtotal]
FROM OrderItems OI
INNER JOIN Products P
    ON OI.ProductID = P.ProductID
WHERE OI.OrderID = @OrderID";

                SqlParameter[] parameters =
                {
            new SqlParameter("@OrderID", orderId)
        };

                dgvOrderItems.DataSource =
                    DatabaseConnection.ExecuteQueryWithParams(
                        query,
                        parameters);

                dgvOrderItems.Columns["Unit Price"]
                    .DefaultCellStyle.Format = "$0.00";

                dgvOrderItems.Columns["Subtotal"]
                    .DefaultCellStyle.Format = "$0.00";

                StyleOrderItemsGrid();

                // Total Items
                int totalItems = 0;

                foreach (DataGridViewRow row
                    in dgvOrderItems.Rows)
                {
                    totalItems +=
                        Convert.ToInt32(
                            row.Cells["Qty"].Value);
                }

                lblTotalItemsValue.Text =
                    totalItems.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StyleOrderItemsGrid()
        {
            dgvOrderItems.BorderStyle = BorderStyle.None;

            dgvOrderItems.BackgroundColor = Color.White;

            dgvOrderItems.RowHeadersVisible = false;

            dgvOrderItems.AllowUserToAddRows = false;

            dgvOrderItems.AllowUserToResizeRows = false;

            dgvOrderItems.ReadOnly = true;

            dgvOrderItems.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvOrderItems.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvOrderItems.EnableHeadersVisualStyles = false;

            dgvOrderItems.ColumnHeadersHeight = 40;

            dgvOrderItems.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(35, 35, 35);

            dgvOrderItems.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvOrderItems.ColumnHeadersDefaultCellStyle.Font =
    new System.Drawing.Font(
        "Segoe UI",
        10,
        System.Drawing.FontStyle.Bold);


            dgvOrderItems.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvOrderItems.DefaultCellStyle.Font =
    new System.Drawing.Font(
        "Segoe UI",
        10);

            dgvOrderItems.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvOrderItems.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 246, 250);

            dgvOrderItems.RowTemplate.Height = 35;

            // Column Size
            dgvOrderItems.Columns["Product"].FillWeight = 230;
            dgvOrderItems.Columns["Qty"].FillWeight = 50;
            dgvOrderItems.Columns["Unit Price"].FillWeight = 120;
            dgvOrderItems.Columns["Subtotal"].FillWeight = 80;
        }
        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            GenerateInvoicePDF();
        }
        private void GenerateInvoicePDF()
        {
            try
            {
                SaveFileDialog save =
                    new SaveFileDialog();

                save.Filter =
                    "PDF File (*.pdf)|*.pdf";

                save.FileName =
                    "Invoice_Order_" +
                    orderId +
                    ".pdf";

                if (save.ShowDialog()
                    != DialogResult.OK)
                    return;

                Document document =
                    new Document(
                        PageSize.A4,
                        40,
                        40,
                        40,
                        40);

                PdfWriter.GetInstance(
                    document,
                    new FileStream(
                        save.FileName,
                        FileMode.Create));

                document.Open();

                PdfFont titleFont =
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        20);

                PdfFont sectionFont =
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        12);

                PdfFont normalFont =
                    FontFactory.GetFont(
                        FontFactory.HELVETICA,
                        11);

                PdfFont whiteHeaderFont =
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        11,
                        BaseColor.WHITE);

                PdfFont totalFont =
                    FontFactory.GetFont(
                        FontFactory.HELVETICA_BOLD,
                        14,
                        new BaseColor(220, 53, 69));

                Paragraph title =
                    new Paragraph(
                        "SMART ORDER MANAGEMENT SYSTEM",
                        titleFont);

                title.Alignment =
                    Element.ALIGN_CENTER;

                document.Add(title);

                Paragraph subTitle =
                    new Paragraph(
                        "ORDER DETAILS",
                        sectionFont);

                subTitle.Alignment =
                    Element.ALIGN_CENTER;

                document.Add(subTitle);

                document.Add(
                    new Paragraph("\n"));

                Paragraph infoTitle =
                    new Paragraph(
                        "ORDER INFORMATION",
                        sectionFont);

                document.Add(infoTitle);

                document.Add(
                    new Paragraph("\n"));

                PdfPTable infoTable =
                    new PdfPTable(2);

                infoTable.WidthPercentage = 75;

                infoTable.SetWidths(
                    new float[]
                    {
                2f,
                4f
                    });

                infoTable.AddCell(
                    new Phrase(
                        "Order ID",
                        sectionFont));

                infoTable.AddCell(
                    new Phrase(
                        lblOrderIDValue.Text,
                        normalFont));

                infoTable.AddCell(
                    new Phrase(
                        "Waiting Number",
                        sectionFont));

                infoTable.AddCell(
                    new Phrase(
                        lblWaitingNoValue.Text,
                        normalFont));

                infoTable.AddCell(
                    new Phrase(
                        "Customer Name",
                        sectionFont));

                infoTable.AddCell(
                    new Phrase(
                        lblCustomerNameValue.Text,
                        normalFont));

                infoTable.AddCell(
                    new Phrase(
                        "Staff Name",
                        sectionFont));

                infoTable.AddCell(
                    new Phrase(
                        lblStaffNameValue.Text,
                        normalFont));

                infoTable.AddCell(
                    new Phrase(
                        "Status",
                        sectionFont));

                infoTable.AddCell(
                    new Phrase(
                        lblStatusValue.Text,
                        normalFont));

                infoTable.AddCell(
                    new Phrase(
                        "Order Date",
                        sectionFont));

                infoTable.AddCell(
                    new Phrase(
                        lblOrderDateValue.Text,
                        normalFont));

                document.Add(infoTable);

                document.Add(
                    new Paragraph("\n"));

                Paragraph itemsTitle =
                    new Paragraph(
                        "ORDERED ITEMS",
                        sectionFont);

                document.Add(itemsTitle);

                document.Add(
                    new Paragraph("\n"));

                PdfPTable table =
                    new PdfPTable(4);

                table.WidthPercentage = 100;

                table.SetWidths(
                    new float[]
                    {
                5f,
                1.5f,
                2f,
                2f
                    });

                BaseColor headerColor =
                    new BaseColor(
                        35,
                        35,
                        35);

                PdfPCell cell;

                cell = new PdfPCell(
                    new Phrase(
                        "Product",
                        whiteHeaderFont));

                cell.BackgroundColor =
                    headerColor;

                cell.HorizontalAlignment =
                    Element.ALIGN_CENTER;

                cell.Padding = 8;

                table.AddCell(cell);

                cell = new PdfPCell(
                    new Phrase(
                        "Qty",
                        whiteHeaderFont));

                cell.BackgroundColor =
                    headerColor;

                cell.HorizontalAlignment =
                    Element.ALIGN_CENTER;

                cell.Padding = 8;

                table.AddCell(cell);

                cell = new PdfPCell(
                    new Phrase(
                        "Unit Price",
                        whiteHeaderFont));

                cell.BackgroundColor =
                    headerColor;

                cell.HorizontalAlignment =
                    Element.ALIGN_CENTER;

                cell.Padding = 8;

                table.AddCell(cell);

                cell = new PdfPCell(
                    new Phrase(
                        "Subtotal",
                        whiteHeaderFont));

                cell.BackgroundColor =
                    headerColor;

                cell.HorizontalAlignment =
                    Element.ALIGN_CENTER;

                cell.Padding = 8;

                table.AddCell(cell);

                foreach (DataGridViewRow row
                    in dgvOrderItems.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    PdfPCell productCell =
    new PdfPCell(
        new Phrase(
            row.Cells["Product"]
            .Value.ToString(),
            normalFont));

                    productCell.HorizontalAlignment =
                        Element.ALIGN_LEFT;

                    productCell.Padding = 5;

                    table.AddCell(productCell);

                    PdfPCell qtyCell =
                        new PdfPCell(
                            new Phrase(
                                row.Cells["Qty"]
                                .Value.ToString(),
                                normalFont));

                    qtyCell.HorizontalAlignment =
                        Element.ALIGN_CENTER;

                    qtyCell.Padding = 5;

                    table.AddCell(qtyCell);

                    PdfPCell unitCell =
                        new PdfPCell(
                            new Phrase(
                                "$" +
                                Convert.ToDecimal(
                                    row.Cells["Unit Price"]
                                    .Value)
                                .ToString("N2"),
                                normalFont));

                    unitCell.HorizontalAlignment =
                        Element.ALIGN_CENTER;

                    unitCell.Padding = 5;

                    table.AddCell(unitCell);

                    PdfPCell subtotalCell =
                        new PdfPCell(
                            new Phrase(
                                "$" +
                                Convert.ToDecimal(
                                    row.Cells["Subtotal"]
                                    .Value)
                                .ToString("N2"),
                                normalFont));

                    subtotalCell.HorizontalAlignment =
                        Element.ALIGN_CENTER;

                    subtotalCell.Padding = 5;

                    table.AddCell(subtotalCell);
                }

                document.Add(table);

                document.Add(
                    new Paragraph("\n"));

                // =========================
                // SUMMARY
                // =========================

                PdfPTable summaryTable =
                    new PdfPTable(2);

                summaryTable.WidthPercentage = 35;

                summaryTable.HorizontalAlignment =
                    Element.ALIGN_RIGHT;

                summaryTable.SetWidths(
                    new float[]
                    {
                2f,
                2f
                    });

                PdfPCell summaryCell;

                summaryCell =
                    new PdfPCell(
                        new Phrase(
                            "Total Items",
                            sectionFont));

                summaryCell.Border =
                    iTextSharp.text.Rectangle.NO_BORDER;

                summaryTable.AddCell(summaryCell);

                summaryCell =
                    new PdfPCell(
                        new Phrase(
                            lblTotalItemsValue.Text,
                            normalFont));

                summaryCell.Border =
                    iTextSharp.text.Rectangle.NO_BORDER;

                summaryCell.HorizontalAlignment =
                    Element.ALIGN_RIGHT;

                summaryTable.AddCell(summaryCell);

                summaryCell =
                    new PdfPCell(
                        new Phrase(
                            "Total Amount",
                            sectionFont));

                summaryCell.Border =
                    iTextSharp.text.Rectangle.TOP_BORDER;

                summaryTable.AddCell(summaryCell);

                summaryCell =
                    new PdfPCell(
                        new Phrase(
                            lblTotalAmountValue.Text,
                            totalFont));

                summaryCell.Border =
                    iTextSharp.text.Rectangle.TOP_BORDER;

                summaryCell.HorizontalAlignment =
                    Element.ALIGN_RIGHT;

                summaryTable.AddCell(summaryCell);

                document.Add(summaryTable);

                document.Add(
                    new Paragraph("\n"));

                // =========================
                // FOOTER
                // =========================

                Paragraph footer =
                    new Paragraph(
                        "Thank you for your purchase!",
                        sectionFont);

                footer.Alignment =
                    Element.ALIGN_CENTER;

                document.Add(footer);

                document.Add(
                    new Paragraph(
                        "\nGenerated by Smart Order Management System",
                        normalFont)
                    {
                        Alignment =
                            Element.ALIGN_CENTER
                    });

                document.Close();

                MessageBox.Show(
                    "Invoice PDF generated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "PDF Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
