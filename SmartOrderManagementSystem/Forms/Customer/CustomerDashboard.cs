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

namespace SmartOrderManagementSystem.Forms.Customer
{
    public partial class CustomerDashboard : Form
    {
        public CustomerDashboard()
        {
            InitializeComponent();
        }
        public DataTable GetProducts(string categoryName = "All")
        {
            DataTable productsTable = new DataTable();
            string query = @"SELECT p.ProductID, p.ProductName, p.Price, p.StockQuantity, c.CategoryName, p.ProductImage 
                FROM Products p
                INNER JOIN Categories c ON p.CategoryID = c.CategoryID";

            if(categoryName != "All")
            {
                query += " WHERE c.CategoryName = @CategoryName";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (categoryName != "All")
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    }

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(productTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error fetching products: " + ex.Message);
                    }
                }
            }
            reeturn productsTable;
        }
    }
}
