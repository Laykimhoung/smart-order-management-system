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
    public partial class Activity_Feed: Form
    {
        public Activity_Feed()
        {
            InitializeComponent();
        }

        private void Activity_feed_Load(object sender, EventArgs e)
        {
            Load_orderlog();
        }
        // load_activity_feed method to load the activity feed data into the datagridview
        private void Load_orderlog()
        {
            string query = @"SELECT ol.LogID,o.OrderID,ol.Action,ol.ActionDate,ol.PerformedBy FROM OrderLogs ol
                             LEFT JOIN Orders o ON o.OrderID = ol.OrderID GROUP BY ol.LogID,o.OrderID,ol.Action,ol.ActionDate,ol.PerformedBy ORDER BY ol.ActionDate DESC";
            try
            {
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
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
    }
}
