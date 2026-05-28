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
    }
}
