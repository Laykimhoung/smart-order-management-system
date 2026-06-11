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
        string _customerName;
        public OrderDetailsForm(int CustomerID, string CustomerName)
        {
            InitializeComponent();
            _customerId = CustomerID;
            _customerName = CustomerName;
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
                    txtWaitingNumber.Text = row["WaitingNumber"].ToString();
                    txtOrderDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("g");
                    txtTotalAmount.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("C");
                    txtNote.Text = row["Notes"].ToString();
                    txtTotalAmount.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("C");
                    txtStatus.Text = "Pending";
                    txtOrderDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("g");
                    lblDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("MMMM dd, yyyy");


                }
                SqlParameter[] itemParams = new SqlParameter[] { new SqlParameter("@OrderID", _orderId) };
                DataTable itemsTable = DatabaseConnection.ExecuteQueryWithParams(ItemsQuery, itemParams);
                dgvItemOrder.DataSource = itemsTable;
                dgvItemOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvItemOrder.AllowUserToAddRows = false;

                string QRText = $"ID:{txtOrderID.Text}|TICKET:{txtWaitingNumber.Text}|TOTAL:${txtTotalAmount.Text:F2}";
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


            string cleanAmount = txtTotalAmount.Text.Replace("$", "").Trim();
            if (!decimal.TryParse(cleanAmount, out decimal totalAmount))
            {
                MessageBox.Show("Invalid total amount format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            InvoiceForm invoiceForm = new InvoiceForm(_orderId, txtCustomer.Text, totalAmount, int.Parse(txtWaitingNumber.Text));
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

        private bool UpdateOrderStatus(int orderId, string status, string action)
        {
            string updateQuery = "UPDATE Orders SET OrderStatue = @Status WHERE OrderID = @OrderID;";
            string logQuery = "INSERT INTO OrderLogs (OrderID, Action, PerformedBy) VALUES (@OrderID, @Action, 'Order Details Form');";

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
                            cmdUpdate.Parameters.AddWithValue("@Status", status);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdLog = new SqlCommand(logQuery, conn, transaction))
                        {
                            cmdLog.Parameters.AddWithValue("@OrderID", orderId);
                            cmdLog.Parameters.AddWithValue("@Action", action);
                            cmdLog.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (UpdateOrderStatus(_orderId, "Cancelled", "Order Cancelled"))
            {
                MessageBox.Show("Order cancelled successfully.");
                CustomerDashboard customerDashboard = new CustomerDashboard(_customerName);
                customerDashboard.Show();
                this.Hide();
            }
        }
    }
}
