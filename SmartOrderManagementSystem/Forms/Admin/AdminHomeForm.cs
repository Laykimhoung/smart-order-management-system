using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartOrderManagementSystem.Database;

namespace SmartOrderManagementSystem.Forms.Admin
{
    public partial class AdminHomeForm : Form
    {
        public AdminHomeForm()
        {
            InitializeComponent();
        }

        private void AdminHomeForm_Load(object sender, EventArgs e)
        {
            LoadDashboardStatistics();
            LoadRecentOrders();
            LoadTodaySummary();
            StyleRecentOrdersGrid();
        }

        private void LoadDashboardStatistics()
        {
            try
            {
                // Total Orders
                DataTable dtOrders = DatabaseConnection.ExecuteQuery(
                    @"SELECT COUNT(*) AS TotalOrders
                      FROM Orders
                      WHERE OrderStatus = 'Completed'");

                lblTotalOrders.Text =
                    dtOrders.Rows[0]["TotalOrders"].ToString();


                // Total Customers
                DataTable dtCustomers = DatabaseConnection.ExecuteQuery(
                    @"SELECT COUNT(DISTINCT CustomerID)
                      AS TotalCustomers
                      FROM Orders
                      WHERE OrderStatus = 'Completed'");

                lblTotalCustomers.Text =
                    dtCustomers.Rows[0]["TotalCustomers"].ToString();


                // Total Staff
                DataTable dtStaff = DatabaseConnection.ExecuteQuery(
                    @"SELECT COUNT(*) AS TotalStaff
                      FROM Users U
                      INNER JOIN Roles R ON U.RoleID = R.RoleID
                      WHERE R.RoleName = 'Staff'");

                lblTotalStaff.Text =
                    dtStaff.Rows[0]["TotalStaff"].ToString();


                // Total Revenue
                DataTable dtRevenue = DatabaseConnection.ExecuteQuery(
                @"SELECT ISNULL(SUM(TotalAmount),0) AS Revenue
                  FROM Orders
                  WHERE OrderStatus = 'Completed'");

                lblTotalRevenue.Text =
                    "$" + Convert.ToDecimal(
                    dtRevenue.Rows[0]["Revenue"]).ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading dashboard statistics.\n\n" + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LoadRecentOrders()
        {
            try
            {
                string query = @"
SELECT TOP 20
    O.OrderID AS [Order ID],
    C.CustomerName AS [Customer Name],
    U.FullName AS [Staff Name],
    O.TotalAmount AS [Total Price],
    FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt') AS [Order Time]
FROM Orders O
INNER JOIN Customers C
    ON O.CustomerID = C.CustomerID
INNER JOIN Users U
    ON O.UserID = U.UserID
WHERE O.OrderStatus='Complete'
ORDER BY
    O.OrderDate DESC,
    O.OrderID DESC;";

                dgvRecentOrder.DataSource =
                    DatabaseConnection.ExecuteQuery(query);

                dgvRecentOrder.Columns["Total Price"]
                    .DefaultCellStyle.Format = "$0.00";

                dgvRecentOrder.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvRecentOrder.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvRecentOrder.Columns["Customer Name"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

                dgvRecentOrder.Columns["Staff Name"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

                dgvRecentOrder.Columns["Order ID"].FillWeight = 15;
                dgvRecentOrder.Columns["Customer Name"].FillWeight = 30;
                dgvRecentOrder.Columns["Staff Name"].FillWeight = 25;
                dgvRecentOrder.Columns["Total Price"].FillWeight = 15;
                dgvRecentOrder.Columns["Order Time"].FillWeight = 25;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load Recent Orders",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void StyleRecentOrdersGrid()
        {
            dgvRecentOrder.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRecentOrder.RowHeadersVisible = false;

            dgvRecentOrder.RowTemplate.Height = 40;

            dgvRecentOrder.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvRecentOrder.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvRecentOrder.EnableHeadersVisualStyles = false;

            dgvRecentOrder.ColumnHeadersDefaultCellStyle.BackColor =
                Color.DarkRed;

            dgvRecentOrder.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvRecentOrder.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadTodaySummary()
        {
            try
            {
                string query = @"
SELECT
    COUNT(*) AS Orders,
    ISNULL(SUM(TotalAmount),0) AS Revenue,
    COUNT(DISTINCT CustomerID) AS Customers
FROM Orders
WHERE
CAST(OrderDate AS DATE)=
(
    SELECT MAX(CAST(OrderDate AS DATE))
    FROM Orders
)
AND OrderStatus='Complete'";

                DataTable dt =
                    DatabaseConnection.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    lblTodayOrder.Text =
                        "Today's Orders : " +
                        dt.Rows[0]["Orders"];

                    lblTodayRevenue.Text =
                        "Today's Revenue : $" +
                        Convert.ToDecimal(
                            dt.Rows[0]["Revenue"])
                        .ToString("N2");

                    lblCustomerToday.Text =
                        "Customers Today : " +
                        dt.Rows[0]["Customers"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}