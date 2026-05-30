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
                                  GROUP BY CustomerID) o ON c.CustomerID = o.CustomerID
                                LEFT JOIN
                                (
                                    SELECT o.CustomerID, SUM(i.TotalAmount) AS TotalInvoiceAmount FROM Orders o INNER JOIN Invoices i ON o.OrderID=i.OrderID GROUP BY o.CustomerID) i On c.CustomerID = i.CustomerID
                                LEFT JOIN(SELECT o.CustomerID, SUM(p.Amount) AS Totalpaid FROM Orders o INNER JOIN Invoices i ON o.OrderID = i.OrderID INNER JOIN Payments p ON i.InvoiceID = p.InvoiceID GROUP BY o.CustomerID) p ON c.CustomerID = p.CustomerID";

            try
            {
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                Customer_datagrideview.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to load customer data." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
