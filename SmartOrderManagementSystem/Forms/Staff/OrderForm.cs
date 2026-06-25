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
        private Timer refresh; // auto refresh data
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Current date
            Current_date_lbl.Text = DateTime.Now.ToString("ddd, dd MMM yyyy");
            // Set the default to the current month
            From_date.Value = DateTime.Today;
            To_date.Value = DateTime.Today;
            Load_Order();

            // auto refresh
            refresh = new Timer();
            refresh.Interval = 5000;
            refresh.Tick += (s, args) =>
            {
                if (this.IsDisposed || !this.IsHandleCreated) return;
                Load_Order(From_date.Value.Date, To_date.Value.Date);
            };
            refresh.Start();

            this.FormClosing += (s, args) =>
            {
                refresh.Stop();
                refresh.Dispose();
            };
        }

        private void Load_Order(DateTime? fromDate = null, DateTime? toDate = null)
        {
           

            string query = @"SELECT o.OrderID, 
                                    o.OrderDate, 
                                    c.CustomerName,
                                    o.WaitingNumber,
                                    o.OrderStatus,
                                    o.Notes,
                                    o.TotalAmount AS TotalPrice,
                                    (SELECT STRING_AGG(p.ProductName, ', ')
                                    From OrderItems oi
                                        INNER JOIN Products p ON oi.ProductID = p.ProductID
                                        WHERE oi.OrderID = o.OrderID) AS Products 
                                FROM Orders o
                            INNER JOIN Customers c ON o.CustomerID = c.CustomerID

                              WHERE CAST(o.OrderDate AS DATE) >= CAST(@FromDate AS DATE)
                                AND CAST(o.OrderDate AS DATE) <=  CAST (@ToDate AS DATE)
                            ORDER BY o.OrderDate DESC";

            DateTime from = fromDate ?? From_date.Value.Date;
            DateTime to = toDate ?? To_date.Value.Date;
            Task.Run(() =>
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[]
                  {
                        new SqlParameter("@FromDate", from),
                        new SqlParameter("@ToDate",   to)
                  };
                    DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);

                    this.Invoke((Action)(() =>
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        Order_datagridview.DataSource = dt;
                       // ApplyGridColumns();


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

                        Order_datagridview.Columns["Products"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        Order_datagridview.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        Order_datagridview.Columns["TotalPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        Order_datagridview.Columns["TotalPrice"].DefaultCellStyle.Format = "C2"; // Format as currency
                        Order_datagridview.Columns["TotalPrice"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-US"); // Set culture for currency formatting
                                                                                                                                                             // Order_datagridview.Columns["TotalPrice"].Width = 80;
                    }));

                }
                catch (Exception ex)
                {
                    this.Invoke((Action)(() =>
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;
                        MessageBox.Show("Failed to load Order: " + ex.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }


            });
         
        }
        

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            string search = Search_txt.Text.Trim().ToLower();

            Order_datagridview.CurrentCell = null;
            Order_datagridview.ClearSelection();


            foreach (DataGridViewRow row in Order_datagridview.Rows)
            {
                if (row.IsNewRow) continue;

                if (string.IsNullOrEmpty(search))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = row.Cells["CustomerName"].Value?.ToString().ToLower().Contains(search) == true
                               || row.Cells["OrderID"].Value?.ToString().Contains(search) == true;
                }
            }
        }
        // Filter the data
        private void filter_btn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = From_date.Value.Date;
            DateTime toDate = To_date.Value.Date;
            if (fromDate > toDate)
            {
                MessageBox.Show("From date cannot be greater than To Date.", "Invalid Date Range",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Load_Order(fromDate, toDate);
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            From_date.Value = DateTime.Today;
            To_date.Value = DateTime.Today;

            Load_Order();
        }


    }
}

