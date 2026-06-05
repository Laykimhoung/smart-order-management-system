using SmartOrderManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartOrderManagementSystem.Forms.Customer
{
    public partial class CustomerDashboard : Form
    {
        private DataTable cartTable;
        string loginUsername;

        public CustomerDashboard(string Username)
        {
            InitializeComponent();
            loginUsername = Username;
        }
        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadProducts(null);
            InitializeCart();
            lblWelcome.Text = $"Welcome, {loginUsername}!";
        }

        private void LoadCategory()
        {
            flpCategories.Controls.Clear();
            Button btnAll = new Button
            {
                Margin = new Padding(10, 15, 10, 10),
                Width = 75,
                Height = 30,
                Text = "All",
                Tag = null,
                AutoSize = true,
                BackColor = Color.Gray,
                FlatStyle = FlatStyle.Flat
            };

            btnAll.Click += CategoryBtn_Click;
            flpCategories.Controls.Add(btnAll);

            try
            {
                DataTable categories = DatabaseConnection.ExecuteQuery("SELECT CategoryID, CategoryName FROM Categories");
                foreach (DataRow row in categories.Rows)
                {
                    Button btnCat = new Button
                    {
                        Width = 75,
                        Height = 30,
                        Text = row["CategoryName"].ToString(),
                        Tag = row["CategoryID"],
                        AutoSize = true,
                        BackColor = Color.LightGray,
                        FlatStyle = FlatStyle.Flat,
                        Margin = new Padding(10, 15, 10, 10),
                    };
                    btnCat.Click += CategoryBtn_Click;
                    flpCategories.Controls.Add(btnCat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CategoryBtn_Click(object sender, EventArgs e)
        {
            Button ClickedBtn = (Button)sender;
            int? categoryID = ClickedBtn.Tag as int?;

            foreach (Control ctrl in flpCategories.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = (btn == ClickedBtn) ? Color.LightSkyBlue : Color.WhiteSmoke;
                }
            }
            LoadProducts(categoryID);
        }

        private void LoadProducts(int? categoryID)
        {
            flpProducts.Controls.Clear();
            string query = "SELECT ProductID, ProductName, Price, ProductImage FROM Products";
            SqlParameter[] parameters = null;
            if (categoryID.HasValue)
            {
                query += " WHERE CategoryID = @CategoryID";
                parameters = new SqlParameter[] { new SqlParameter("@CategoryID", categoryID.Value) };
            }

            try
            {
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    int productId = Convert.ToInt32(row["ProductID"]);
                    string productName = row["ProductName"].ToString();
                    decimal price = Convert.ToDecimal(row["Price"]);
                    byte[] imageBytes = row["ProductImage"] as byte[];

                    Panel productCard = CreateProductCard(productId, productName, price, imageBytes);
                    flpProducts.Controls.Add(productCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateProductCard(int id, string name, decimal price, byte[] imageBytes)
        {
            Panel card = new Panel { Width = 180, Height = 250, BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(10), BackColor = Color.White };

            PictureBox pbImage = new PictureBox { Width = 160, Height = 120, Location = new Point(10, 10), SizeMode = PictureBoxSizeMode.Zoom };
            pbImage.Image = (imageBytes != null && imageBytes.Length > 0) ? ConvertByteArrayToImage(imageBytes) : SystemIcons.Question.ToBitmap();


            Label lblName = new Label { Text = name, Location = new Point(10, 135), Width = 160, Height = 35, Font = new Font("Segoe UI", 10, FontStyle.Bold), TextAlign = ContentAlignment.TopCenter };
            Label lblPrice = new Label { Text = $"${price:F2}", Location = new Point(10, 170), Width = 160, Height = 20, Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = Color.DarkGreen, TextAlign = ContentAlignment.TopCenter, };

            Button btnAdd = new Button { Text = "Add", Location = new Point(10, 210), Width = 75, Height = 30, BackColor = Color.LightGreen, FlatStyle = FlatStyle.Flat, Tag = id };
            btnAdd.Click += BtnAdd_Click;

            Button btnRemove = new Button { Text = "Remove", Location = new Point(95, 210), Width = 75, Height = 30, BackColor = Color.LightCoral, FlatStyle = FlatStyle.Flat, Tag = id };
            btnRemove.Click += BtnRemove_Click;

            card.Controls.Add(pbImage);
            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);
            card.Controls.Add(btnAdd);
            card.Controls.Add(btnRemove);

            return card;
        }

        private Image ConvertByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void InitializeCart()
        {
            dgvCart.Font = new Font("Time New Roman", 12, FontStyle.Regular);
            cartTable = new DataTable();
            cartTable.Columns.Add("ProductID", typeof(int));
            cartTable.Columns.Add("Product", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Price", typeof(decimal));

            cartTable.Columns.Add("Subtotal", typeof(decimal), "Quantity * Price");

            dgvCart.DataSource = cartTable;

            if (dgvCart.Columns["ProductID"] != null)
                dgvCart.Columns["ProductID"].Visible = false;

            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.AllowUserToAddRows = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = (int)btn.Tag;

            // Check if product is already in our cart
            DataRow[] existingRows = cartTable.Select($"ProductID = {productId}");

            if (existingRows.Length > 0)
            {
                // Increment the quantity
                int currentQty = Convert.ToInt32(existingRows[0]["Quantity"]);
                existingRows[0]["Quantity"] = currentQty + 1;
            }
            else
            {
                // Retrieve product details from database to add as a new row
                try
                {
                    DataTable itemDetails = DatabaseConnection.ExecuteQuery($"SELECT ProductName, Price FROM Products WHERE ProductID = {productId}");
                    if (itemDetails.Rows.Count > 0)
                    {
                        DataRow newRow = cartTable.NewRow();
                        newRow["ProductID"] = productId;
                        newRow["Product"] = itemDetails.Rows[0]["ProductName"];
                        newRow["Quantity"] = 1;
                        newRow["Price"] = itemDetails.Rows[0]["Price"];
                        cartTable.Rows.Add(newRow);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to retrieve item details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UpdateCartTotal();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = (int)btn.Tag;

            DataRow[] existingRows = cartTable.Select($"ProductID = {productId}");

            if (existingRows.Length > 0)
            {
                int currentQty = Convert.ToInt32(existingRows[0]["Quantity"]);
                if (currentQty > 1)
                {
                    // Decrement quantity
                    existingRows[0]["Quantity"] = currentQty - 1;
                }
                else
                {
                    // Remove item completely if quantity drops below 1
                    cartTable.Rows.Remove(existingRows[0]);
                }
            }

            UpdateCartTotal();
        }

        private void UpdateCartTotal()
        {
            decimal total = 0;

            foreach (DataRow row in cartTable.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }

            txtTotal.Text = $"Total: ${total:F2}";
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
           
            
        }
    

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cartTable == null || cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add items before placing an order.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            decimal totalAmount = 0;
            foreach (DataRow row in cartTable.Rows)
            {
                totalAmount += Convert.ToDecimal(row["Subtotal"]);
            }

            int orderId;

            int userId = 3;
            int waitingNumber = new Random().Next(100, 999);
            string notes = txtNote.Text.Trim();
            string qrCodeText = $"QR_ORDER_{waitingNumber}";

            string insertOrderQuery = @"INSERT INTO Orders (WaitingNumber, CustomerID, UserID, TotalAmount, QRCodeText, Notes) 
                                        VALUES (@WaitingNumber, @CustomerID, @UserID, @TotalAmount, @QRCodeText, @Notes);
                                        SELECT SCOPE_IDENTITY();";


            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {


                        // Insert Order Header
                        using (SqlCommand cmdOrder = new SqlCommand(insertOrderQuery, conn, transaction))
                        {
                            cmdOrder.Parameters.AddWithValue("@WaitingNumber", waitingNumber);
                            cmdOrder.Parameters.AddWithValue("@CustomerID", customerId);
                            cmdOrder.Parameters.AddWithValue("@UserID", userId);
                            cmdOrder.Parameters.AddWithValue("@TotalAmount", totalAmount);
                            cmdOrder.Parameters.AddWithValue("@QRCodeText", qrCodeText);
                            cmdOrder.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                            orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());
                        }


                        string insertItemsQuery = @"INSERT INTO OrderItems (OrderID, ProductID, Quantity, UnitPrice) VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);";

                        foreach (DataRow row in cartTable.Rows)
                        {
                            using (SqlCommand cmdItem = new SqlCommand(insertItemsQuery, conn, transaction))
                            {
                                cmdItem.Parameters.AddWithValue("@OrderID", orderId);
                                cmdItem.Parameters.AddWithValue("@ProductID", row["ProductID"]);
                                cmdItem.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                                cmdItem.Parameters.AddWithValue("@UnitPrice", row["Price"]);

                                cmdItem.ExecuteNonQuery();
                            }
                        }


                        string logQuery = "INSERT INTO OrderLogs (OrderID, Action, PerformedBy) VALUES (@OrderID, 'Order Created', 'Customer Dashboard');";
                        using (SqlCommand cmdLog = new SqlCommand(logQuery, conn, transaction))
                        {
                            cmdLog.Parameters.AddWithValue("@OrderID", orderId);
                            cmdLog.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                if (MessageBox.Show($"Order placed successfully!\nYour Waiting Number is: {waitingNumber}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    OrderDetailsForm orderDetailsForm = new OrderDetailsForm(orderId);
                    orderDetailsForm.Show();
                    this.Hide();
                }


                cartTable.Rows.Clear();
                UpdateCartTotal();
                if (txtNote != null) txtNote.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving your order: {ex.Message}", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clear All button clicked! Implement clear all functionality here.");
        }
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Remove Item button clicked! Implement remove item functionality here.");
        }
    }
}
