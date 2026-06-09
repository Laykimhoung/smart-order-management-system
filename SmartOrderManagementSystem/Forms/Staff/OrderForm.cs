using SmartOrderManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SmartOrderManagementSystem.Forms.Staff
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            //call teh method to load the order data into the datagridview
            Load_Order();

            // Set the default to the current month
            From_date.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            To_date.Value = DateTime.Now;

        }

        private void Load_Order()
        {
            string query = @"SELECT o.OrderID, o.OrderDate,c.CustomerName,o.WaitingNumber,o.OrderStatus, o.Notes,STRING_AGG(p.ProductName, ', ') AS Products, SUM(p.Price) AS TotalPrice FROM Orders o
                                LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
                                LEFT JOIN Products p ON oi.ProductID = p.ProductID
                                LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
                                GROUP BY o.OrderID,o.OrderDate, o.WaitingNumber,o.Notes,c.CustomerName,o.OrderStatus
                                ORDER BY o.OrderDate DESC";
            try
            {
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                Order_datagridview.DataSource = dt;
                //ApplyGridStyle();

                // Set column headers
                Order_datagridview.Columns["TotalPrice"].HeaderText = "Total Price";
                Order_datagridview.Columns["OrderID"].HeaderText = "ID";
                Order_datagridview.Columns["OrderDate"].HeaderText = "Date";
                Order_datagridview.Columns["WaitingNumber"].HeaderText = "Waiting Number";
                Order_datagridview.Columns["OrderStatus"].HeaderText = "Status";
                Order_datagridview.Columns["Notes"].HeaderText = "Notes";
                Order_datagridview.Columns["Products"].HeaderText = "Products";
                Order_datagridview.Columns["CustomerName"].HeaderText = "Customer Name";

                // Resize columns to fit content and alignment the text
                Order_datagridview.Columns["OrderID"].Width = 50;
                Order_datagridview.Columns["OrderID"].Resizable = DataGridViewTriState.False;
                Order_datagridview.Columns["OrderID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Order_datagridview.Columns["WaitingNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
              //  Order_datagridview.Columns["WaitingNumber"].Width = 70;

                Order_datagridview.Columns["Products"].DefaultCellStyle.WrapMode= DataGridViewTriState.True;

                Order_datagridview.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                Order_datagridview.Columns["TotalPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Order_datagridview.Columns["TotalPrice"].DefaultCellStyle.Format = "C2"; // Format as currency
                Order_datagridview.Columns["TotalPrice"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-US"); // Set culture for currency formatting
               // Order_datagridview.Columns["TotalPrice"].Width = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load Order." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            string search = Search_txt.Text.ToLower();
            Order_datagridview.CurrentCell = null;
            Order_datagridview.ClearSelection();

            foreach (DataGridViewRow row in Order_datagridview.Rows)
            {
                if (row.IsNewRow) continue;

                row.Visible = row.Cells["CustomerName"].Value?.ToString().ToLower().Contains(search) == true
                   || row.Cells["OrderID"].Value?.ToString().Contains(search) == true;
            }
        }
        // Filter the data
        private void filter_btn_Click(object sender, EventArgs e)
        {
            string query = @"SELECT o.OrderID, o.OrderDate,c.CustomerName,o.WaitingNumber, o.OrderStatus, o.Notes,STRING_AGG(p.ProductName, ', ') AS Products, SUM(p.Price) AS TotalPrice FROM Orders o
                                LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
                                LEFT JOIN Products p ON oi.ProductID = p.ProductID
                                LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
                                WHERE o.OrderDate BETWEEN @FromDate AND  @ToDate
                                GROUP BY o.OrderID,o.OrderDate, o.WaitingNumber,o.OrderStatus,o.Notes,c.CustomerName
                                ORDER BY o.OrderDate DESC";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FromDate", From_date.Value.Date),
                    new SqlParameter("@ToDate", To_date.Value.Date.AddDays(1)) // Include the entire end date
                };
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                Order_datagridview.DataSource = dt;
                //ApplyGridStyle();

            }catch(Exception ex)
            {
                MessageBox.Show("Failed to filter orders.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {

        }


    }
}

