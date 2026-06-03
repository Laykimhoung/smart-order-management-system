using SmartOrderManagementSystem.Database;
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
using System.Configuration;

namespace SmartOrderManagementSystem.Forms.Staff
{
    public partial class CustomerRecordForm : Form
    {
        public CustomerRecordForm()
        {
            InitializeComponent();
        }

        private void CustomerRecordForm_Load(object sender, EventArgs e)
        {
            // Set the default to the current month
            From_date.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month-1, 1);
            To_date.Value = DateTime.Now;
            Load_Customer();
       
        }
        private void Load_Customer()
        { 
                string query = @"SELECT c.CustomerID, c.CustomerName,c.Phone,Email, c.Address, c.CreatedDate,
                                ISNULL(o.TotalOrders,0) AS TotalOrders, ISNULL(i.TotalInvoiceAmount,0) AS TotalInvoiceAmount, ISNULL(p.TotalPaid,0) AS TotalPaid FROM Customers c
                                LEFT JOIN
                                (
                                  SELECT CustomerID, COUNT(*) AS TotalOrders
                                  FROM Orders
                                  WHERE OrderDate BETWEEN @FromDate AND @ToDate
                                  GROUP BY CustomerID) o ON c.CustomerID = o.CustomerID
                                LEFT JOIN
                                (
                                    SELECT o.CustomerID, SUM(i.TotalAmount) AS TotalInvoiceAmount FROM Orders o 
                                    INNER JOIN Invoices i ON o.OrderID=i.OrderID 
                                    WHERE o.OrderDate BETWEEN @FromDate AND @ToDate
                                    GROUP BY o.CustomerID) i On c.CustomerID = i.CustomerID
                                LEFT JOIN(SELECT o.CustomerID, SUM(p.Amount) AS Totalpaid FROM Orders o INNER JOIN Invoices i ON o.OrderID = i.OrderID INNER JOIN Payments p ON i.InvoiceID = p.InvoiceID
                                    WHERE o.OrderDate BETWEEN @FromDate AND @ToDate
                                    GROUP BY o.CustomerID) p ON c.CustomerID = p.CustomerID";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
 {
    new SqlParameter("@FromDate", From_date.Value.Date),
    new SqlParameter("@ToDate",   To_date.Value.Date.AddDays(1))
 };
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                Customer_datagrideview.DataSource = dt;
                // Rename the header text
                Customer_datagrideview.Columns["CustomerID"].HeaderText = "ID";
                Customer_datagrideview.Columns["CustomerName"].HeaderText = "Name";
                Customer_datagrideview.Columns["Phone"].HeaderText = "Phone";
                Customer_datagrideview.Columns["Email"].HeaderText = "Email";
                Customer_datagrideview.Columns["Address"].HeaderText = "Address";
                Customer_datagrideview.Columns["CreatedDate"].HeaderText = "Join Date";
                Customer_datagrideview.Columns["TotalOrders"].HeaderText = "Orders";
                Customer_datagrideview.Columns["TotalInvoiceAmount"].HeaderText = "Invoice";
                Customer_datagrideview.Columns["TotalPaid"].HeaderText = "Paid";

                // Formatting the currency columns
                Customer_datagrideview.Columns["TotalInvoiceAmount"].DefaultCellStyle.Format = "C2";
                Customer_datagrideview.Columns["TotalInvoiceAmount"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                Customer_datagrideview.Columns["TotalPaid"].DefaultCellStyle.Format = "C2";
                Customer_datagrideview.Columns["TotalPaid"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-US");

                // Resize the size of somes columns and alignment
                Customer_datagrideview.Columns["CustomerID"].Width = 50;
                Customer_datagrideview.Columns["CustomerID"].Resizable = DataGridViewTriState.False;
                Customer_datagrideview.Columns["CustomerID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Customer_datagrideview.Columns["CustomerID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Customer_datagrideview.Columns["CustomerName"].Width = 100;
                Customer_datagrideview.Columns["CustomerName"].Resizable = DataGridViewTriState.False;
                Customer_datagrideview.Columns["CustomerName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Customer_datagrideview.Columns["Phone"].Width = 100;
                Customer_datagrideview.Columns["Phone"].Resizable = DataGridViewTriState.False;
                Customer_datagrideview.Columns["Phone"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Customer_datagrideview.Columns["Email"].Width = 150;
                Customer_datagrideview.Columns["Email"].Resizable = DataGridViewTriState.False;
                Customer_datagrideview.Columns["Email"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Customer_datagrideview.Columns["Address"].Width = 120;
                Customer_datagrideview.Columns["Address"].Resizable = DataGridViewTriState.False;

                Customer_datagrideview.Columns["TotalOrders"].Width = 60;
                Customer_datagrideview.Columns["TotalOrders"].Resizable = DataGridViewTriState.False;
                Customer_datagrideview.Columns["TotalOrders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Customer_datagrideview.Columns["TotalOrders"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Customer_datagrideview.Columns["TotalInvoiceAmount"].Width = 70;
                Customer_datagrideview.Columns["TotalInvoiceAmount"].Resizable = DataGridViewTriState.False;
                Customer_datagrideview.Columns["TotalInvoiceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Customer_datagrideview.Columns["TotalInvoiceAmount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Customer_datagrideview.Columns["TotalPaid"].Width = 70;
                Customer_datagrideview.Columns["TotalPaid"].Resizable = DataGridViewTriState.False;
                Customer_datagrideview.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Customer_datagrideview.Columns["TotalPaid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load customer data." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filter_btn_Click(object sender, EventArgs e)
        {
            string query = @"SELECT c.CustomerID, c.CustomerName,c.Phone,Email, c.Address, c.CreatedDate,
                                ISNULL(o.TotalOrders,0) AS TotalOrders, ISNULL(i.TotalInvoiceAmount,0) AS TotalInvoiceAmount, ISNULL(p.TotalPaid,0) AS TotalPaid FROM Customers c
                                LEFT JOIN
                                (
                                  SELECT CustomerID, COUNT(*) AS TotalOrders
                                  FROM Orders
                                  WHERE OrderDate BETWEEN @FromDate AND @ToDate
                                  GROUP BY CustomerID) o ON c.CustomerID = o.CustomerID
                                LEFT JOIN
                                (
                                    SELECT o.CustomerID, SUM(i.TotalAmount) AS TotalInvoiceAmount FROM Orders o 
                                    INNER JOIN Invoices i ON o.OrderID=i.OrderID 
                                    WHERE o.OrderDate BETWEEN @FromDate AND @ToDate
                                    GROUP BY o.CustomerID) i On c.CustomerID = i.CustomerID
                                LEFT JOIN(SELECT o.CustomerID, SUM(p.Amount) AS Totalpaid FROM Orders o INNER JOIN Invoices i ON o.OrderID = i.OrderID INNER JOIN Payments p ON i.InvoiceID = p.InvoiceID
                                    WHERE o.OrderDate BETWEEN @FromDate AND @ToDate
                                    GROUP BY o.CustomerID) p ON c.CustomerID = p.CustomerID";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FromDate", From_date.Value.Date),
                    new SqlParameter("@ToDate", To_date.Value.Date.AddDays(1)) // Include the entire end date
                };
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                Customer_datagrideview.DataSource = dt;
                //ApplyGridStyle();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to filter orders.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //call the load_customer
            Load_Customer();

        }
        // Search the data in datagridview
        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            string search = Search_txt.Text.ToLower();
           Customer_datagrideview.CurrentCell = null;
           Customer_datagrideview.ClearSelection();

            foreach (DataGridViewRow row in Customer_datagrideview.Rows)
            {
                if (row.IsNewRow) continue;

                row.Visible = row.Cells["CustomerName"].Value?.ToString().ToLower().Contains(search) == true
                   || row.Cells["CustomerID"].Value?.ToString().Contains(search) == true;
            }
        }
        // Refrexh Button to reload the data
        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            From_date.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            To_date.Value = DateTime.Now;
            Load_Customer();
        }

    }
}
