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
        public CustomerDashboard()
        {
            InitializeComponent();
        }
        private void CustomerDashboard_Load(object sender, EventArgs e)
        {

        }
        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add to Order button clicked! Implement order functionality here.");
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Place Order button clicked! Implement place order functionality here.");
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
