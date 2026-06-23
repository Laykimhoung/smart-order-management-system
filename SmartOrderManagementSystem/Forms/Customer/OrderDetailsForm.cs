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
        int _userId;
        string _staffname;
        string _username;
        public OrderDetailsForm(int CustomerID, string CustomerName, int UserID, string staffname)
        {
            InitializeComponent();
            _customerId = CustomerID;
            _customerName = CustomerName;
            _userId = UserID;
            _staffname = staffname;
        }

        private void LoadUsername()
        {
            string query = "SELECT Username FROM Users WHERE UserID = @UserID";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _userId)
                };
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                if (dt != null)
                {
                    _username = dt.Rows[0]["Username"].ToString();
                }
                else
                {
                    MessageBox.Show("Username not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load username: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            LoadUsername();
            LoadStaffName();
            GetOrderId();
            LoadOrderData();
            this.dgvItemOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            this.dgvItemOrder.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            if (dgvItemOrder.Columns["Product"] != null) dgvItemOrder.Columns["Product"].FillWeight = 160;   
            if (dgvItemOrder.Columns["Quantity"] != null) dgvItemOrder.Columns["Quantity"].FillWeight = 70;  
            if (dgvItemOrder.Columns["Price"] != null) dgvItemOrder.Columns["Price"].FillWeight = 80;        
            if (dgvItemOrder.Columns["Subtotal"] != null) dgvItemOrder.Columns["Subtotal"].FillWeight = 90;
           this.FormBorderStyle = FormBorderStyle.Fixed3D;
            dgvItemOrder.BorderStyle = BorderStyle.None;
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

        private void LoadStaffName()
        {
            string query = "SELECT FullName FROM Users WHERE UserID = @UserID";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", _userId)
                };
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                if (dt != null)
                {
                    _staffname = dt.Rows[0]["FullName"].ToString();
                }
                else
                {
                    MessageBox.Show("FullName not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load staff name: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtWaitingNumber.Text = Convert.ToInt32(row["WaitingNumber"]).ToString("0000");
                    txtOrderDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("g");
                    lblTotalAmount.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("C");
                    txtNote.Text = row["Notes"].ToString();
                    lblTotalAmount.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("C");
                    txtStatus.Text = "Pending";
                    txtOrderDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("g");
                    lblDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("MMMM dd, yyyy");


                }
                SqlParameter[] itemParams = new SqlParameter[] { new SqlParameter("@OrderID", _orderId) };
                DataTable itemsTable = DatabaseConnection.ExecuteQueryWithParams(ItemsQuery, itemParams);
                dgvItemOrder.DataSource = itemsTable;
                dgvItemOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvItemOrder.AllowUserToAddRows = false;

                string QRText = $"Date: {lblDate.Text}\nOrder Ref: ORD-{txtOrderID.Text}\nYour WaitingNumber: {Convert.ToInt32(txtWaitingNumber.Text).ToString("0000")}\nTOTAL Cost: {lblTotalAmount.Text:F2}";
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
            string qt = "INSERT INTO Invoices(OrderID, InvoiceDate) VALUES(@OrderID, @InvoiceDate);";
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(qt, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", _orderId);
                        cmd.Parameters.AddWithValue("@InvoiceDate", txtOrderDate.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to create invoice: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            

            if (UpdateOrderStatusToComplete(_orderId))
            {

                txtStatus.Text = "Complete";
            }
            else
            {

                return;
            }


            string cleanAmount = lblTotalAmount.Text.Replace("$", "").Trim();
            if (!decimal.TryParse(cleanAmount, out decimal totalAmount))
            {
                MessageBox.Show("Invalid total amount format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            InvoiceForm invoiceForm = new InvoiceForm(_orderId, txtCustomer.Text, totalAmount, int.Parse(txtWaitingNumber.Text), _staffname, _userId, _username);
            invoiceForm.Show();
            this.Hide();
        }

        private bool UpdateOrderStatusToComplete(int orderId)
        {

            string updateQuery = "UPDATE Orders SET OrderStatus = 'Complete' WHERE OrderID = @OrderID;";
            string logQuery = "INSERT INTO OrderLogs (OrderID, Action) VALUES (@OrderID, 'Order Completed');";

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
            string updateQuery = "UPDATE Orders SET OrderStatus = @Status WHERE OrderID = @OrderID;";
            string logQuery = "INSERT INTO OrderLogs (OrderID, Action) VALUES (@OrderID, @Action);";

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
                CustomerDashboard customerDashboard = new CustomerDashboard(_customerName, _username, _userId);
                customerDashboard.Show();
                this.Hide();
            }
        }
    }
}
