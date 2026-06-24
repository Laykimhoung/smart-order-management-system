using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
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

namespace SmartOrderManagementSystem.Forms.Staff
{
    public partial class Activity_Feed: Form
    {
        public Activity_Feed()
        {
            InitializeComponent();
        }

        private void Activity_feed_Load(object sender, EventArgs e)
        {
            From_date.Value = new DateTime(2025, 9, 1);
            To_date.Value = DateTime.Now;
            Load_orderlog();
        }
        // load_activity_feed method to load the activity feed data into the datagridview
        private void Load_orderlog(string search = "", DateTime? fromDate = null, DateTime? toDate = null)
        {
            string query = @"SELECT ol.LogID,o.OrderID,ol.Action,ol.ActionDate,u.FullName AS [FullName] FROM OrderLogs ol
                             INNER JOIN Orders o ON o.OrderID = ol.OrderID 
                             INNER JOIN Users u ON u.UserID = o.UserID
                             WHERE
                             (@Search = '' OR u.FullName LIKE @Search)
                             AND (@FromDate is null or cast (ol.ActionDate as DATE) >= @FromDate)
                             AND (@ToDate is null or cast(ol.ActionDate as DATE)<= @ToDate)
                             GROUP BY ol.LogID,o.OrderID,ol.Action,ol.ActionDate,u.FullName ORDER BY ol.ActionDate DESC";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@Search",   string.IsNullOrEmpty(search) ? "" : $"%{search}%"),
            new SqlParameter("@FromDate", fromDate.HasValue ? (object)fromDate.Value : DBNull.Value),
            new SqlParameter("@ToDate",   toDate.HasValue   ? (object)toDate.Value   : DBNull.Value)
        };
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                Orderlog_datagrodview.DataSource = dt;

                //Resize each column and alignment
                Orderlog_datagrodview.Columns["LogID"].Width = 100;
                Orderlog_datagrodview.Columns["LogID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Orderlog_datagrodview.Columns["OrderID"].Width = 100;
                Orderlog_datagrodview.Columns["OrderID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading activity feed: " + ex.Message);
            }
        }

        private void filter_btn_Click(object sender, EventArgs e)
        {
            string searchText = Search_txt.Text.Trim();
            DateTime fromDate = From_date.Value.Date;
            DateTime toDate = To_date.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show("From date cannot be greater than To Date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Load_orderlog(searchText,fromDate, toDate);
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            Search_txt.Text = "";
            From_date.Value = new DateTime(2025, 9, 1);
            To_date.Value = DateTime.Today;

            Load_orderlog();
        }

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            string search = Search_txt.Text.Trim().ToLower();
            Orderlog_datagrodview.CurrentCell = null;
            Orderlog_datagrodview.ClearSelection();

            foreach (DataGridViewRow row in Orderlog_datagrodview.Rows)
            {
                if (row.IsNewRow) continue;

                if (string.IsNullOrEmpty(search))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = row.Cells["FullName"].Value?.ToString().ToLower().Contains(search) == true
                               || row.Cells["Action"].Value?.ToString().ToLower().Contains(search) == true;
                }
            }

        }
    }
}
