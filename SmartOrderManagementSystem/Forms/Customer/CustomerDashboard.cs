using SmartOrderManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartOrderManagementSystem.Forms.Customer
{
    public partial class CustomerDashboard : Form
    {
        private int selectedProductId = -1;
        private decimal selectedProductPrice = 0.00m;
        public CustomerDashboard()
        {
            InitializeComponent();
        }
        private void LoadProducts(string categoryName)
        {
            
            string query = @"
                SELECT p.ProductID, p.ProductName, p.Price, p.StockQuantity, c.CategoryName 
                FROM Products p
                INNER JOIN Categories c ON p.CategoryID = c.CategoryID";

            DataTable dt;

            if (categoryName == "All")
            {
                dt = DatabaseConnection.ExecuteQuery(query);
            }
            else
            {
                query += " WHERE c.CategoryName = @CategoryName";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CategoryName", categoryName)
                };
                dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
            }
        }
        private void SetupListViewColumns()
        {
            
            lvCart.View = View.Details;
            lvCart.FullRowSelect = true;
            lvCart.GridLines = true;

            
            lvCart.Columns.Clear();

            lvCart.Columns.Add("Product", 150, HorizontalAlignment.Left);
            lvCart.Columns.Add("Qty", 60, HorizontalAlignment.Center);
            lvCart.Columns.Add("Price", 90, HorizontalAlignment.Right);
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            LoadProducts("All");
            SetupListViewColumns();
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if(selectedProductId == -1)
            {
                MessageBox.Show("Please select a product first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int qty = (int)numQty.Value;
            decimal itemTotal = selectedProductPrice * qty;
            string productName = txtSelectProduct.Text.Split('—')[0].Trim();

            ListViewItem item = new ListViewItem(selectedProductId.ToString());
            
            item.SubItems.Add(productName);
            item.SubItems.Add(qty.ToString());
            item.SubItems.Add($"${itemTotal:F2}");

            lvCart.Items.Add(item);

            CalculateGrandTotal();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (lvCart.SelectedItems.Count > 0)
            {
                lvCart.Items.Remove(lvCart.SelectedItems[0]);
                CalculateGrandTotal();
            }
            else
            {
                MessageBox.Show("Please select an item from the cart to remove.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lvCart.Items.Clear();
            txtNote.Clear();
            txtTotal.Text = "$0.00";
        }

        private void CalculateGrandTotal()
        {
            decimal total = 0;
            foreach (ListViewItem item in lvCart.Items)
            {
                // The price sits at index 3 (ProductID=0, Product=1, Qty=2, Price=3)
                string priceString = item.SubItems[3].Text.Replace("$", "");
                total += Convert.ToDecimal(priceString);
            }
            txtTotal.Text = $"${total:F2}";
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (lvCart.Items.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal grandTotal = Convert.ToDecimal(txtTotal.Text.Replace("$", "")); ;
            string note = txtNote.Text.Trim();

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string InsertOrderQuery = @"
                        INSERT INTO Orders (WaitingNumber, CustomerID, UserID, TotalAmount, Notes, OrderDate)
                        VALUES (
                            (SELECT ISNULL(MAX(WaitingNumber), 0) + 1 FROM Orders WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)), 
                            @CustomerID, @UserID, @TotalAmount, @Notes, GETDATE()
                        );
                        SELECT SCOPE_IDENTITY();";
                    int currentCustomerId = 1;
                    int currentUserId = 2;
                    int newOrderId;
                    using (SqlCommand cmd = new SqlCommand(InsertOrderQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", currentCustomerId);
                        cmd.Parameters.AddWithValue("@UserID", currentUserId);
                        cmd.Parameters.AddWithValue("@TotalAmount", grandTotal);
                        cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(note) ? (object)DBNull.Value : note);

                        newOrderId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    foreach (ListViewItem item in lvCart.Items)
                    {
                        int prodId = Convert.ToInt32(item.SubItems[0].Text);
                        int qty = Convert.ToInt32(item.SubItems[2].Text);

                        // Parse original unit price (Total row price divided by quantity)
                        decimal rowTotalPrice = Convert.ToDecimal(item.SubItems[3].Text.Replace("$", ""));
                        decimal unitPrice = rowTotalPrice / qty;

                        // Insert item record
                        string insertItemQuery = @"
                            INSERT INTO OrderItems (OrderID, ProductID, Quantity, UnitPrice)
                            VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);";

                        using (SqlCommand cmdItem = new SqlCommand(insertItemQuery, conn, transaction))
                        {
                            cmdItem.Parameters.AddWithValue("@OrderID", newOrderId);
                            cmdItem.Parameters.AddWithValue("@ProductID", prodId);
                            cmdItem.Parameters.AddWithValue("@Quantity", qty);
                            cmdItem.Parameters.AddWithValue("@UnitPrice", unitPrice);
                            cmdItem.ExecuteNonQuery();
                        }

                        // Deduct product inventory stock level safely
                        string updateStockQuery = "UPDATE Products SET StockQuantity = StockQuantity - @Qty WHERE ProductID = @PID";
                        using (SqlCommand cmdStock = new SqlCommand(updateStockQuery, conn, transaction))
                        {
                            cmdStock.Parameters.AddWithValue("@Qty", qty);
                            cmdStock.Parameters.AddWithValue("@PID", prodId);
                            cmdStock.ExecuteNonQuery();
                        }
                    }
                    string logQuery = "INSERT INTO OrderLogs (OrderID, Action, PerformedBy) VALUES (@OrderID, 'Order Placed', @User)";
                    using (SqlCommand cmdLog = new SqlCommand(logQuery, conn, transaction))
                    {
                        cmdLog.Parameters.AddWithValue("@OrderID", newOrderId);
                        cmdLog.Parameters.AddWithValue("@User", "Customer Dashboard - Kimhoung");
                        cmdLog.ExecuteNonQuery();
                    }

                    // Commit whole batch process together
                    transaction.Commit();
                    MessageBox.Show($"Order placed successfully! Your order ID is {newOrderId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear cart UI tracking fields
                    ClearAllFields();
                    LoadProducts("All"); // Refresh menu display lists to see structural stock reductions
                }
                catch (Exception ex)
                {
                    // Rollback system completely if any loop iteration encounters problems
                    transaction.Rollback();
                    MessageBox.Show($"Transaction error processing order framework: {ex.Message}", "Order Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearAllFields()
        {
            lvCart.Items.Clear();
            txtNote.Clear();
            txtTotal.Text = "$0.00";
            selectedProductId = -1;
            selectedProductPrice = 0.00m;
            txtSelectProduct.Clear();
            numQty.Value = 1;
        }
    }
}
