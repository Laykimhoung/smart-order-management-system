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
        int _waitingNumber;
        string _staffname;
        int _userId;
        string _username;
        public InvoiceForm(int orderId, string customerName, decimal totalAmount, int waitingNumber, string staffname, int userId, string username)
        {
            _staffname = staffname;
            _userId = userId;
            _orderId = orderId;
            _customerName = customerName;
            _totalAmount = totalAmount;
            _waitingNumber = waitingNumber;
            _username = username;
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            txtInvoiceDate.Text = DateTime.Now.ToString("g");
            //txtInvoiceID.Text = $"INV-{_invoiceID:D5}";
            txtOrderID.Text = $"ORD-{_orderId:D5}";
            txtCustomerName.Text = _customerName;
            lblTotalAmount.Text = $"${_totalAmount:F2}";
            txtWaitingNumber.Text = _waitingNumber.ToString("0000");
            txtCashier.Text = _staffname;

            LoadOrderItems();
            LoadInvoiID();
        }

        private void LoadInvoiID()
        {
            string query = "SELECT InvoiceID FROM Invoices WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@OrderID", _orderId) };
            try
            {
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    _invoiceID = Convert.ToInt32(dt.Rows[0][0]);
                    txtInvoiceID.Text = $"INV-{_invoiceID:D5}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Invoice ID: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private bool SaveInvoiceAndPaymentToDatabase()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {

                        /*
                         string insertInvoiceQuery = @"INSERT INTO Invoices (OrderID, InvoiceDate) 
                                                     VALUES (@OrderID, GETDATE());
                                                     SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmdInvoice = new SqlCommand(insertInvoiceQuery, conn, transaction))
                        {
                            cmdInvoice.Parameters.AddWithValue("@OrderID", _orderId);
                            _invoiceID = Convert.ToInt32(cmdInvoice.ExecuteScalar());
                        }
                        */


                        string insertPaymentQuery = @"INSERT INTO Payments (InvoiceID, Amount, PaymentDate) 
                                                     VALUES (@InvoiceID, @Amount, GETDATE());";

                        using (SqlCommand cmdPayment = new SqlCommand(insertPaymentQuery, conn, transaction))
                        {
                            cmdPayment.Parameters.AddWithValue("@InvoiceID", _invoiceID);
                            cmdPayment.Parameters.AddWithValue("@Amount", _totalAmount);
                            cmdPayment.ExecuteNonQuery();
                        }


                        string logQuery = "INSERT INTO OrderLogs (OrderID, Action) VALUES (@OrderID, 'Invoice Paid');";
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

            printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDoc.PrinterSettings.PrintToFile = true;

            string dateStr = DateTime.Now.ToString("yyyyMMdd");

            
            string directoryPath = @"C:\Invoice";

            
            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }

            string fileName = $"INV-{_invoiceID:D5}-[{_customerName}]-{dateStr}.pdf";
            string fullPath = System.IO.Path.Combine(directoryPath, fileName);

            printDoc.PrinterSettings.PrintFileName = fullPath;
            printDoc.PrintController = new StandardPrintController();

            try
            {
                printDoc.Print();
                MessageBox.Show($"Invoice saved successfully to:\n{fullPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to auto-save PDF: {ex.Message}", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font fontRegular = new Font("Times New Roman", 12, FontStyle.Regular);
            Font fontBold = new Font("Times New Roman", 14, FontStyle.Bold);
            Font fontHeader = new Font("Times New Roman", 18, FontStyle.Bold);
            Font fontTitle = new Font("Times New Roman", 25, FontStyle.Bold);
            Font fontwaiting = new Font("Times New Roman", 23, FontStyle.Bold);

            int startX = 50;
            int startY = 50;
            int offset = 40;

            int pageWidth = e.MarginBounds.Width + e.MarginBounds.Left * 2;
           
            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            graphics.DrawString("JINGHAB CAFE", fontTitle, Brushes.DarkBlue, pageWidth / 2, startY, centerFormat);
            startY += 45;
            graphics.DrawString("Waiting Number:", fontRegular, Brushes.Black, pageWidth / 2, startY, centerFormat);
            startY += 30;
            graphics.DrawString(Convert.ToInt32(txtWaitingNumber.Text).ToString("0000"), fontwaiting, Brushes.Red, pageWidth / 2, startY, centerFormat);
            startY += 30;
            graphics.DrawString("INVOICE RECEIPT", fontHeader, Brushes.Black, startX, startY);
            startY += offset;

            graphics.DrawString($"Invoice No: INV-{txtInvoiceID.Text:D5}", fontRegular, Brushes.Black, startX, startY);
            startY += 25;
            graphics.DrawString($"Invoice Date: {txtInvoiceDate.Text}", fontRegular, Brushes.Black, startX, startY);
            startY += 25;
            graphics.DrawString($"Ref Order: {txtOrderID.Text:D5}", fontRegular, Brushes.Black, startX, startY);
            startY += 25;
            graphics.DrawString($"Customer Name: {txtCustomerName.Text}", fontRegular, Brushes.Black, startX, startY);
            startY += 25;
            graphics.DrawString($"Cashier: {txtCashier.Text}", fontRegular, Brushes.Black, startX, startY);

            startY += offset;
            graphics.DrawString("-------------------------------------------------------------------------------------------------------------------", fontRegular, Brushes.Black, startX, startY);
            startY += 20;


            graphics.DrawString("Product", fontBold, Brushes.Black, startX, startY);
            graphics.DrawString("Qty", fontBold, Brushes.Black, startX + 250, startY);
            graphics.DrawString("Price", fontBold, Brushes.Black, startX + 350, startY);
            graphics.DrawString("Total", fontBold, Brushes.Black, startX + 450, startY);

            startY += 25;
            graphics.DrawString("-------------------------------------------------------------------------------------------------------------------", fontRegular, Brushes.Black, startX, startY);
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
            graphics.DrawString("-------------------------------------------------------------------------------------------------------------------", fontRegular, Brushes.Black, startX, startY);
            startY += 20;

            graphics.DrawString($"Grand Total: {lblTotalAmount.Text}", fontBold, Brushes.DarkGreen, startX + 320, startY);
        }

        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            if (SaveInvoiceAndPaymentToDatabase())
            {

                txtInvoiceID.Text = _invoiceID.ToString("D5");

                MessageBox.Show($"Payment and Invoice #{_invoiceID:D5} saved successfully! Proceeding to print...",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                PrintInvoiceToPdf();

                CustomerDashboard dashboard = new CustomerDashboard(_customerName, _username, _userId);
                dashboard.Show();
                this.Close();
            }
        }
    }
}
