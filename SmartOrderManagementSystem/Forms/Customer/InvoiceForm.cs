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
using SmartOrderManagementSystem.Database;

namespace SmartOrderManagementSystem.Forms.Customer
{
    public partial class InvoiceForm : Form
    {
        int _orderid;
        int _customerid;
        string _customername;
        public InvoiceForm(int orderId)
        {
            _orderid = orderId;
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {

        }

    }
}
