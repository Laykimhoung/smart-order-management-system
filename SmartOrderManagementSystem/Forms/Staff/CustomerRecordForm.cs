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
        //TImer
        private Timer refresh;
        
        public CustomerRecordForm()
        {
            InitializeComponent();
        }

        private void CustomerRecordForm_Load(object sender, EventArgs e)
        {
            // Current date 
            Current_date_lbl.Text = DateTime.Now.ToString("ddd, dd MMM yyyy");

            // Set the default to the current month
            From_date.Value = DateTime.Today;
            To_date.Value = DateTime.Today;
            Load_Customer();

            refresh = new Timer();
            refresh.Interval = 5000;
            refresh.Tick += (s,args) =>
            {
                if (this.IsDisposed || !this.IsHandleCreated) return;
                Load_Customer(From_date.Value.Date, To_date.Value.Date);
            };
            refresh.Start();

            this.FormClosing += (s, args) =>
            {
                refresh.Stop();
                refresh.Dispose();
            };
        }
       
        
        private void Load_Customer(DateTime? fromDate = null, DateTime? toDate = null)
        { 
                string query = @"SELECT c.CustomerID, 
                                c.CustomerName,
                                c.Phone,
                                o.TotalOrders, 
                                p.TotalPaid 
                                FROM Customers c
                                INNER JOIN
                                (
                                  SELECT CustomerID, COUNT(*) AS TotalOrders    
                                  FROM Orders
                                  WHERE CAST(OrderDate AS DATE) >= CAST(@FromDate AS DATE)
                                   AND CAST(OrderDate AS DATE) <= CAST(@ToDate AS DATE)
                                  GROUP BY CustomerID) o ON c.CustomerID = o.CustomerID
                                
                                INNER JOIN(SELECT o.CustomerID,  SUM(pr.Price * oi.Quantity) AS Totalpaid 
                                FROM Orders o 
                                INNER JOIN OrderItems oi ON o.OrderID = oi.OrderID 
                                INNER JOIN Products pr ON pr.ProductID = oi.ProductID
                                    WHERE  CAST(o.OrderDate AS DATE) >= CAST(@FromDate AS DATE)
                                     AND CAST(o.OrderDate AS DATE) <= CAST(@ToDate AS DATE)
                                    GROUP BY o.CustomerID) p ON c.CustomerID = p.CustomerID
                                    ORDER BY o.TotalOrders DESC";
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

                        Customer_datagrideview.DataSource = dt;
                        // Rename the header text

                        Customer_datagrideview.Columns["CustomerID"].HeaderText = "ID";
                        Customer_datagrideview.Columns["CustomerName"].HeaderText = "Name";
                        Customer_datagrideview.Columns["Phone"].HeaderText = "Phone";

                        Customer_datagrideview.Columns["TotalOrders"].HeaderText = "Orders";
                        // Customer_datagrideview.Columns["TotalInvoiceAmount"].HeaderText = "Invoice";
                        Customer_datagrideview.Columns["TotalPaid"].HeaderText = "Paid";

                        // Formatting the currency columns
                        //Customer_datagrideview.Columns["TotalInvoiceAmount"].DefaultCellStyle.Format = "C2";
                        //Customer_datagrideview.Columns["TotalInvoiceAmount"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-US");
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

                        Customer_datagrideview.Columns["Phone"].Width = 80;
                        Customer_datagrideview.Columns["Phone"].Resizable = DataGridViewTriState.False;
                        Customer_datagrideview.Columns["Phone"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        Customer_datagrideview.Columns["TotalOrders"].Width = 60;
                        Customer_datagrideview.Columns["TotalOrders"].Resizable = DataGridViewTriState.False;
                        Customer_datagrideview.Columns["TotalOrders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Customer_datagrideview.Columns["TotalOrders"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        //Customer_datagrideview.Columns["TotalInvoiceAmount"].Width = 70;
                        //Customer_datagrideview.Columns["TotalInvoiceAmount"].Resizable = DataGridViewTriState.False;
                        //Customer_datagrideview.Columns["TotalInvoiceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //Customer_datagrideview.Columns["TotalInvoiceAmount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        Customer_datagrideview.Columns["TotalPaid"].Width = 120;
                        Customer_datagrideview.Columns["TotalPaid"].Resizable = DataGridViewTriState.False;
                        Customer_datagrideview.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        Customer_datagrideview.Columns["TotalPaid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke((Action)(() =>
                {
                    if (this.IsDisposed || !this.IsHandleCreated) return;
                    MessageBox.Show("Failed to load customer data: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));

                }
            });
            
        }

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

            //call the load_customer
            Load_Customer(fromDate, toDate);

        }
        // Search the data in datagridview
        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            string search = Search_txt.Text.Trim().ToLower();
           Customer_datagrideview.CurrentCell = null;
           Customer_datagrideview.ClearSelection();
            foreach (DataGridViewRow row in Customer_datagrideview.Rows)
            {
                if (row.IsNewRow) continue;

                if (string.IsNullOrEmpty(search))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = row.Cells["CustomerName"].Value?.ToString().ToLower().Contains(search) == true
                               || row.Cells["CustomerID"].Value?.ToString().Contains(search) == true;
                }
            }
        }
        // Refrexh Button to reload the data
        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            Search_txt.Text = "";
            From_date.Value = DateTime.Today;
            To_date.Value = DateTime.Today;
            Load_Customer();
        }

    }
}
