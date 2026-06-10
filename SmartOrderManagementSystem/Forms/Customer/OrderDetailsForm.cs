using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartOrderManagementSystem.Database;
using QRCoder;
using System.Drawing.Printing;

namespace SmartOrderManagementSystem.Forms.Customer
{
    public partial class OrderDetailsForm : Form
    {
        int _orderId;
        int _customerId;
        public OrderDetailsForm(int CustomerID)
        {
            InitializeComponent();
            _customerId = CustomerID;
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            GetOrderId();
            LoadOrderData();
        }
        private void GetOrderId()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@CustomerID", _customerId)
                };

                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(
                    @"SELECT TOP 1 OrderID FROM Orders WHERE CustomerID = @CustomerID 
                    ORDER BY OrderDate DESC, OrderID DESC",
                    parameters
                );

                if (dt.Rows.Count > 0)
                {
                    _orderId = Convert.ToInt32(dt.Rows[0]["OrderID"]);
                }
                else
                {
                    MessageBox.Show("Customer not found.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load customer: {ex.Message}", "Database Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadOrderData()
        {
            string HeaderQuery = 
                @"SELECT o.OrderID, o.WaitingNumber, o.OrderDate, o.TotalAmount, o.Notes, c.CustomerName
                FROM Orders o JOIN Customers c ON o.CustomerID = c.CustomerID
                WHERE o.OrderID = @OrderID";

            string ItemsQuery = 
                @"SELECT p.ProductName AS [Product], oi.Quantity, oi.UnitPrice AS [Price], oi.Subtotal
                FROM OrderItems oi JOIN Products p ON oi.ProductID = p.ProductID
                WHERE oi.OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@OrderID", _orderId) };
            try
            {
                DataTable header = DatabaseConnection.ExecuteQueryWithParams(HeaderQuery, parameters);
                if(header.Rows.Count > 0)
                {
                    DataRow row = header.Rows[0];
                    txtOrderID.Text = row["OrderID"].ToString();
                    txtCustomer.Text = row["CustomerName"].ToString();
                    lblWaitingNumber.Text = row["WaitingNumber"].ToString();
                    txtOrderDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("g");
                    txtTotalAmount.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("C");
                    txtNote.Text = row["Notes"].ToString();
                    txtTotalAmount.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("C");
                    txtStatus.Text = "Pending";
                    txtOrderDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("g");
                    lblDate.Text = DateTime.Now.ToString("g");

                }
                SqlParameter[] itemParams = new SqlParameter[] { new SqlParameter("@OrderID", _orderId) };
                DataTable itemsTable = DatabaseConnection.ExecuteQueryWithParams(ItemsQuery, itemParams);
                dgvItemOrder.DataSource = itemsTable;
                dgvItemOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvItemOrder.AllowUserToAddRows = false;

                string QRText = $"OrderID:{txtOrderID.Text}\nYour Waiting Number: {lblWaitingNumber.Text}\nCustomer: {txtCustomer.Text}\nTOTAL: {txtTotalAmount.Text:F2}\nSTATUS: Completed";
                GenerateQR(QRText);
            }
            catch (Exception ex)
            {
                    MessageBox.Show($"Failed to load order details: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerateQR(string textToEncode)
        {
            try
            {
                
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(textToEncode, QRCodeGenerator.ECCLevel.Q))
                    {
                        
                        using (QRCode qrCode = new QRCode(qrCodeData))
                        {
                           
                            Bitmap qrCodeImage = qrCode.GetGraphic(5);


                            picQRCode.Image = qrCodeImage;


                            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating visual QR Code matrix: {ex.Message}", "QR Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGetInvoice_Click(object sender, EventArgs e)
        {
            if (_orderId <= 0)
            {
                MessageBox.Show("No valid order is currently loaded to generate an invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (UpdateOrderStatusToComplete(_orderId))
            {
                
                txtStatus.Text = "Complete";
            }
            else
            {
                
                return;
            }

            
            string cleanAmount = txtTotalAmount.Text.Replace("$", "").Replace("£", "").Replace("€", "").Trim();
            if (!decimal.TryParse(cleanAmount, out decimal totalAmount))
            {
                MessageBox.Show("Invalid total amount format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            InvoiceForm invoiceForm = new InvoiceForm(_orderId, txtCustomer.Text, totalAmount);
            invoiceForm.Show();
            //this.Hide();
        }
        private bool UpdateOrderStatusToComplete(int orderId)
        {
           
            string updateQuery = "UPDATE Orders SET OrderStatue = 'Complete' WHERE OrderID = @OrderID;";
            string logQuery = "INSERT INTO OrderLogs (OrderID, Action, PerformedBy) VALUES (@OrderID, 'Order Completed', 'Order Details Form');";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                       
                        using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@OrderID", orderId);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        
                        using (SqlCommand cmdLog = new SqlCommand(logQuery, conn, transaction))
                        {
                            cmdLog.Parameters.AddWithValue("@OrderID", orderId);
                            cmdLog.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update order status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
