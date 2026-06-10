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
using SmartOrderManagementSystem.Database;
using System.Drawing.Printing;

namespace SmartOrderManagementSystem.Forms.Customer
{
    public partial class InvoiceForm : Form
    {
        int _orderId;
        string _customerName;
        decimal _totalAmount;
        int _invoiceID;
        public InvoiceForm(int orderId, string customerName, decimal totalAmount)
        {
            InitializeComponent();
            _orderId = orderId;
            _customerName = customerName;
            _totalAmount = totalAmount;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            txtInvoiceDate.Text = DateTime.Now.ToString("g");
            txtInvoiceID.Text = _invoiceID.ToString();
            txtOrderID.Text = $"ORD-{_orderId:D5}";
            txtCustomerName.Text = _customerName;
            lblTotalAmount.Text = $"${_totalAmount:F2}";

            LoadOrderItems();
        }

        private void LoadOrderItems()
        {
            string LoadItemsquery = @"SELECT p.ProductName AS [Product], oi.Quantity, oi.UnitPrice AS [Price], oi.Subtotal
                             FROM OrderItems oi 
                             JOIN Products p ON oi.ProductID = p.ProductID
                             WHERE oi.OrderID = @OrderID";

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@OrderID", _orderId) };

            try
            {
                DataTable itemsTable = DatabaseConnection.ExecuteQueryWithParams(LoadItemsquery, parameters);
                dgvInvoiceItems.DataSource = itemsTable;
                dgvInvoiceItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvInvoiceItems.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load invoice items: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            if (SaveInvoiceAndPaymentToDatabase())
            {
                
                txtInvoiceID.Text = _invoiceID.ToString();

                MessageBox.Show($"Payment and Invoice #{_invoiceID} saved successfully! Proceeding to print...",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                PrintInvoiceToPdf();

                this.Close();
            }
        }
        private bool SaveInvoiceAndPaymentToDatabase()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                      
                        string insertInvoiceQuery = @"INSERT INTO Invoices (OrderID, InvoiceDate) 
                                                     VALUES (@OrderID, GETDATE());
                                                     SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmdInvoice = new SqlCommand(insertInvoiceQuery, conn, transaction))
                        {
                            cmdInvoice.Parameters.AddWithValue("@OrderID", _orderId);
                            _invoiceID = Convert.ToInt32(cmdInvoice.ExecuteScalar());
                        }

                        
                        string insertPaymentQuery = @"INSERT INTO Payments (InvoiceID, Amount, PaymentDate) 
                                                     VALUES (@InvoiceID, @Amount, GETDATE());";

                        using (SqlCommand cmdPayment = new SqlCommand(insertPaymentQuery, conn, transaction))
                        {
                            cmdPayment.Parameters.AddWithValue("@InvoiceID", _invoiceID);
                            cmdPayment.Parameters.AddWithValue("@Amount", _totalAmount);
                            cmdPayment.ExecuteNonQuery();
                        }

                       
                        string logQuery = "INSERT INTO OrderLogs (OrderID, Action, PerformedBy) VALUES (@OrderID, 'Invoice Paid', 'Invoice Form');";
                        using (SqlCommand cmdLog = new SqlCommand(logQuery, conn, transaction))
                        {
                            cmdLog.Parameters.AddWithValue("@OrderID", _orderId);
                            cmdLog.ExecuteNonQuery();
                        }

                      
                        transaction.Commit();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database transaction failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private void PrintInvoiceToPdf()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            
            printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font fontRegular = new Font("Arial", 12, FontStyle.Regular);
            Font fontBold = new Font("Arial", 14, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 18, FontStyle.Bold);

            int startX = 50;
            int startY = 50;
            int offset = 40;

            
            graphics.DrawString("INVOICE RECEIPT", fontHeader, Brushes.Black, startX, startY);
            startY += offset;

            graphics.DrawString($"Invoice No: {txtInvoiceID.Text}", fontRegular, Brushes.Black, startX, startY);
            startY += 25;
            graphics.DrawString($"Invoice Date: {txtInvoiceDate.Text}", fontRegular, Brushes.Black, startX, startY);
            startY += 25;
            graphics.DrawString($"Ref Order: {txtOrderID.Text}", fontRegular, Brushes.Black, startX, startY);
            startY += 25;
            graphics.DrawString($"Customer Name: {txtCustomerName.Text}", fontRegular, Brushes.Black, startX, startY);

            startY += offset;
            graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------", fontRegular, Brushes.Black, startX, startY);
            startY += 20;

            
            graphics.DrawString("Product", fontBold, Brushes.Black, startX, startY);
            graphics.DrawString("Qty", fontBold, Brushes.Black, startX + 250, startY);
            graphics.DrawString("Price", fontBold, Brushes.Black, startX + 350, startY);
            graphics.DrawString("Total", fontBold, Brushes.Black, startX + 450, startY);

            startY += 25;
            graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------", fontRegular, Brushes.Black, startX, startY);
            startY += 20;

           
            foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
            {
                if (row.Cells["Product"].Value != null)
                {
                    string name = row.Cells["Product"].Value.ToString();
                    string qty = row.Cells["Quantity"].Value.ToString();
                    string price = string.Format("${0:F2}", row.Cells["Price"].Value);
                    string subtotal = string.Format("${0:F2}", row.Cells["Subtotal"].Value);

                    graphics.DrawString(name, fontRegular, Brushes.Black, startX, startY);
                    graphics.DrawString(qty, fontRegular, Brushes.Black, startX + 250, startY);
                    graphics.DrawString(price, fontRegular, Brushes.Black, startX + 350, startY);
                    graphics.DrawString(subtotal, fontRegular, Brushes.Black, startX + 450, startY);
                    startY += 25;
                }
            }

            startY += 15;
            graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------", fontRegular, Brushes.Black, startX, startY);
            startY += 20;

            graphics.DrawString($"Grand Total: {lblTotalAmount.Text}", fontBold, Brushes.DarkGreen, startX + 320, startY);
        }
    }
}
