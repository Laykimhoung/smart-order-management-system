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
    CAST(O.TotalAmount AS DECIMAL(10,2)) AS [Total Price],
    FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt') AS [Order Time]
FROM Orders O
INNER JOIN Customers C
    ON O.CustomerID = C.CustomerID
INNER JOIN Users U
    ON O.UserID = U.UserID
WHERE O.OrderStatus = 'Completed'
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
                string latestDateQuery = @"
SELECT CAST(MAX(OrderDate) AS DATE)
FROM Orders";

                DataTable dtLatest =
                    DatabaseConnection.ExecuteQuery(latestDateQuery);

                string latestDate =
                    Convert.ToDateTime(dtLatest.Rows[0][0])
                    .ToString("yyyy-MM-dd");

                // Today's Orders
                DataTable dtOrders =
                    DatabaseConnection.ExecuteQuery($@"
SELECT COUNT(*) AS Total
FROM Orders
WHERE CAST(OrderDate AS DATE) = '{latestDate}'
AND OrderStatus = 'Completed'");

                lblTodayOrder.Text =
                    "Today's Orders : " +
                    dtOrders.Rows[0]["Total"];


                // Today's Revenue
                DataTable dtRevenue =
                    DatabaseConnection.ExecuteQuery($@"
SELECT ISNULL(SUM(TotalAmount),0) AS Revenue
FROM Orders
WHERE CAST(OrderDate AS DATE) = '{latestDate}'
AND OrderStatus = 'Completed'");

                lblTodayRevenue.Text =
                    "Today's Revenue : $" +
                    Convert.ToDecimal(
                        dtRevenue.Rows[0]["Revenue"])
                    .ToString("N2");


                // Today's Customers
                DataTable dtCustomers =
                    DatabaseConnection.ExecuteQuery($@"
SELECT COUNT(DISTINCT CustomerID) AS Customers
FROM Orders
WHERE CAST(OrderDate AS DATE) = '{latestDate}'
AND OrderStatus = 'Completed'");

                lblCustomerToday.Text =
                    "Customers Today : " +
                    dtCustomers.Rows[0]["Customers"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}