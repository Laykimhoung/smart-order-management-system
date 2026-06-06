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

namespace SmartOrderManagementSystem.Forms.Staff
{
    public partial class StaffHome : Form
    {
        

        public StaffHome()
        {
            InitializeComponent();
        }

        private void StaffHome_Load(object sender, EventArgs e)
        {
            Load_recentorder();

        }

        // create laod_recent idea for call to display in home staff dashboard
        private void Load_recentorder()
        {
            string query = @"SELECT o.OrderID, c.CustomerName, o.WaitingNumber, o.OrderDate FROM Orders o
                             LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
                             LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
                             GROUP BY o.OrderID, c.CustomerName,o.WaitingNumber,o.OrderDate,o.CustomerID
                             ORDER BY o.OrderDate DESC";
            try
            {
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                Recent_order_datagridview.DataSource = dt;

                // Change the name header of the columns
                Recent_order_datagridview.Columns["OrderID"].HeaderText = "ID";
                Recent_order_datagridview.Columns["CustomerName"].HeaderText = "Customer Name";
                Recent_order_datagridview.Columns["WaitingNumber"].HeaderText = "Waiting Number";
                Recent_order_datagridview.Columns["OrderDate"].HeaderText = "Date";

                // Resize each column to fit the content
                Recent_order_datagridview.Columns["OrderID"].Width = 40;
                Recent_order_datagridview.Columns["OrderID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Recent_order_datagridview.Columns["WaitingNumber"].Width = 120;
                Recent_order_datagridview.Columns["WaitingNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load Order." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
    }
}

