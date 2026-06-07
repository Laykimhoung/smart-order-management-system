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
                    txtWaitingNumber.Text = row["WaitingNumber"].ToString();
                    txtOrderDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("g");
                    txtTotalAmount.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("C");
                    txtNote.Text = row["Notes"].ToString();
                    txtTotalAmount.Text = Convert.ToDecimal(row["TotalAmount"]).ToString("C");
                    txtStatus.Text = "Pending";
                    txtOrderDate.Text = Convert.ToDateTime(row["OrderDate"]).ToString("g");
                 
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
    }
}
