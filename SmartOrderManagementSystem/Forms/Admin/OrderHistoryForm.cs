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
using System.Windows.Controls;
using System.Windows.Forms;

namespace SmartOrderManagementSystem.Forms.Admin
{
    public partial class OrderHistoryForm : Form
    {
        public OrderHistoryForm()
        {
            InitializeComponent();
        }
        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();
            LoadStaffs();
            StyleOrderHistoryGrid();
            cmbStaff.SelectedIndex = 0;
        }
        private void LoadOrderHistory()
        {
            try
            {
                string query = @"
        SELECT
            O.OrderID AS [Order ID],
            O.WaitingNumber AS [Waiting No],
            C.CustomerName AS [Customer Name],
            U.FullName AS [Staff Name],
            O.OrderStatus AS [Status],
            O.TotalAmount AS [Total Price],
            FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt')
                AS [Order Date]
        FROM Orders O
        INNER JOIN Customers C
            ON O.CustomerID = C.CustomerID
        INNER JOIN Users U
            ON O.UserID = U.UserID
        ORDER BY O.OrderID ASC";

                dgvOrderHistory.DataSource =
                    DatabaseConnection.ExecuteQuery(query);

                dgvOrderHistory.Columns["Total Price"]
                    .DefaultCellStyle.Format = "$0.00";

                lblTotalOrders.Text =
                    "Total Orders: " +
                    dgvOrderHistory.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadStaffs()
        {
            try
            {
                DataTable dt =
                    DatabaseConnection.ExecuteQuery(@"
            SELECT
                0 AS UserID,
                'All' AS FullName
            UNION
            SELECT
                U.UserID,
                U.FullName
            FROM Users U
            INNER JOIN Roles R
                ON U.RoleID = R.RoleID
            WHERE R.RoleName = 'Staff'
            ORDER BY FullName");

                cmbStaff.DataSource = dt;
                cmbStaff.DisplayMember = "FullName";
                cmbStaff.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FilterOrders()
        {
            try
            {
                string query = @"
SELECT
    O.OrderID AS [Order ID],
    O.WaitingNumber AS [Waiting No],
    C.CustomerName AS [Customer Name],
    U.FullName AS [Staff Name],
    O.OrderStatus AS [Status],
    O.TotalAmount AS [Total Price],
    FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt')
        AS [Order Date]
FROM Orders O
INNER JOIN Customers C
    ON O.CustomerID = C.CustomerID
INNER JOIN Users U
    ON O.UserID = U.UserID
WHERE 1 = 1";

                List<SqlParameter> parameters =
                    new List<SqlParameter>();

                if (cmbStaff.SelectedValue != null
                    && !(cmbStaff.SelectedValue is DataRowView)
                    && Convert.ToInt32(cmbStaff.SelectedValue) != 0)
                {
                    query += " AND O.UserID = @UserID";

                    parameters.Add(
                        new SqlParameter(
                            "@UserID",
                            cmbStaff.SelectedValue));
                }

                query += " ORDER BY O.OrderID ASC";

                dgvOrderHistory.DataSource =
                    DatabaseConnection.ExecuteQueryWithParams(
                        query,
                        parameters.ToArray());

                dgvOrderHistory.Columns["Total Price"]
                    .DefaultCellStyle.Format = "$0.00";

                lblTotalOrders.Text =
                    "Total Orders: " +
                    dgvOrderHistory.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StyleOrderHistoryGrid()
        {
            dgvOrderHistory.BorderStyle =
                BorderStyle.None;

            dgvOrderHistory.BackgroundColor =
                Color.White;

            dgvOrderHistory.RowHeadersVisible =
                false;

            dgvOrderHistory.AllowUserToAddRows =
                false;

            dgvOrderHistory.AllowUserToResizeRows =
                false;

            dgvOrderHistory.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvOrderHistory.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvOrderHistory.MultiSelect = false;

            dgvOrderHistory.ReadOnly = true;

            dgvOrderHistory.EnableHeadersVisualStyles =
                false;

            dgvOrderHistory.ColumnHeadersHeight = 45;

            dgvOrderHistory.ColumnHeadersDefaultCellStyle
                .BackColor = Color.FromArgb(35, 35, 35);

            dgvOrderHistory.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;

            dgvOrderHistory.ColumnHeadersDefaultCellStyle
                .Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            dgvOrderHistory.ColumnHeadersDefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvOrderHistory.DefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10);

            dgvOrderHistory.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvOrderHistory.RowTemplate.Height = 38;

            dgvOrderHistory.AlternatingRowsDefaultCellStyle
                .BackColor =
                Color.FromArgb(245, 246, 250);

            dgvOrderHistory.Columns["Order ID"]
                .FillWeight = 50;

            dgvOrderHistory.Columns["Waiting No"]
                .FillWeight = 60;

            dgvOrderHistory.Columns["Status"]
                .FillWeight = 70;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;

            cmbStaff.SelectedIndex = 0;

            LoadOrderHistory();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
SELECT
    O.OrderID AS [Order ID],
    O.WaitingNumber AS [Waiting No],
    C.CustomerName AS [Customer Name],
    U.FullName AS [Staff Name],
    O.OrderStatus AS [Status],
    O.TotalAmount AS [Total Price],
    FORMAT(O.OrderDate,'dd/MM/yyyy hh:mm tt')
        AS [Order Date]
FROM Orders O
INNER JOIN Customers C
    ON O.CustomerID = C.CustomerID
INNER JOIN Users U
    ON O.UserID = U.UserID
WHERE
(
    CAST(O.OrderID AS VARCHAR) LIKE @Keyword
    OR CAST(O.WaitingNumber AS VARCHAR) LIKE @Keyword
    OR C.CustomerName LIKE @Keyword
)
AND O.OrderDate BETWEEN
    @DateFrom AND @DateTo";

                List<SqlParameter> parameters =
                    new List<SqlParameter>()
                {
            new SqlParameter(
                "@Keyword",
                "%" + txtSearch.Text.Trim() + "%"),

            new SqlParameter(
                "@DateFrom",
                dtpFrom.Value.Date),

            new SqlParameter(
                "@DateTo",
                dtpTo.Value.Date.AddDays(1))
                };

                if (cmbStaff.SelectedValue != null &&
                    Convert.ToInt32(cmbStaff.SelectedValue) != 0)
                {
                    query += " AND O.UserID = @UserID";

                    parameters.Add(
                        new SqlParameter(
                            "@UserID",
                            cmbStaff.SelectedValue));
                }

                query += " ORDER BY O.OrderID ASC";

                dgvOrderHistory.DataSource =
                    DatabaseConnection.ExecuteQueryWithParams(
                        query,
                        parameters.ToArray());

                lblTotalOrders.Text =
                    "Total Orders: " +
                    dgvOrderHistory.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStaff.SelectedValue == null)
                return;

            if (cmbStaff.SelectedValue is DataRowView)
                return;

            FilterOrders();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderHistory.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select an order first.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                int orderId =
                    Convert.ToInt32(
                        dgvOrderHistory.SelectedRows[0]
                        .Cells["Order ID"].Value);

                OrderDetailsForm frm =
                    new OrderDetailsForm(orderId);

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
