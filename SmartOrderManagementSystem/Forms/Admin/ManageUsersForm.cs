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

namespace SmartOrderManagementSystem.Forms.Admin
{
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
        }
        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadRoles();
        }
        private void LoadUsers()
        {
            try
            {
                string query = @"
        SELECT
            U.UserID AS [User ID],
            U.FullName AS [Full Name],
            U.Username,
            U.Email,
            U.Phone,
            R.RoleName AS [Role],
            FORMAT(U.CreatedDate,'dd/MM/yyyy') AS [Created Date]
        FROM Users U
        INNER JOIN Roles R
            ON U.RoleID = R.RoleID
        ORDER BY U.UserID ASC";

                dgvUsers.DataSource =
                    DatabaseConnection.ExecuteQuery(query);

                StyleUsersGrid();
                dgvUsers.Columns["User ID"].FillWeight = 70;
                dgvUsers.Columns["Email"].FillWeight = 150;
                dgvUsers.Columns["Full Name"].FillWeight = 120;
                dgvUsers.Columns["Username"].FillWeight = 100;
                dgvUsers.Columns["Phone"].FillWeight = 90;
                dgvUsers.Columns["Role"].FillWeight = 80;

                lblTotalUser.Text =
                    "Total User: " +
                    dgvUsers.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadRoles()
        {
            try
            {
                DataTable dt =
                    DatabaseConnection.ExecuteQuery(
                        "SELECT * FROM Roles");

                DataRow row = dt.NewRow();

                row["RoleID"] = 0;
                row["RoleName"] = "All";

                dt.Rows.InsertAt(row, 0);

                cmbRoleFilter.DataSource = dt;
                cmbRoleFilter.DisplayMember = "RoleName";
                cmbRoleFilter.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterUsers()
        {
            try
            {
                string query = @"
        SELECT
            U.UserID AS [User ID],
            U.FullName AS [Full Name],
            U.Username,
            U.Email,
            U.Phone,
            R.RoleName AS [Role],
            FORMAT(U.CreatedDate,'dd/MM/yyyy') AS [Created Date]
        FROM Users U
        INNER JOIN Roles R
            ON U.RoleID = R.RoleID";

                if (cmbRoleFilter.SelectedValue != null &&
    cmbRoleFilter.SelectedValue is int)
                {
                    int roleID = (int)cmbRoleFilter.SelectedValue;

                    if (roleID != 0)
                    {
                        query += " WHERE U.RoleID = " + roleID;
                    }
                }

                query += " ORDER BY U.UserID ASC";

                dgvUsers.DataSource =
                    DatabaseConnection.ExecuteQuery(query);

                lblTotalUser.Text =
                    "Total User: " +
                    dgvUsers.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StyleUsersGrid()
        {
            dgvUsers.BorderStyle = BorderStyle.None;

            dgvUsers.BackgroundColor = Color.White;

            dgvUsers.RowHeadersVisible = false;

            dgvUsers.AllowUserToAddRows = false;

            dgvUsers.AllowUserToResizeRows = false;

            dgvUsers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsers.MultiSelect = false;

            dgvUsers.ReadOnly = true;

            dgvUsers.EnableHeadersVisualStyles = false;

            // Header
            dgvUsers.ColumnHeadersHeight = 45;

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(35, 35, 35);

            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvUsers.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Rows
            dgvUsers.DefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 10);

            dgvUsers.DefaultCellStyle.ForeColor =
                Color.FromArgb(44, 62, 80);

            dgvUsers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            dgvUsers.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvUsers.RowTemplate.Height = 38;

            // Alternate Row Colors
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 246, 250);

            dgvUsers.DefaultCellStyle.BackColor =
                Color.White;

            dgvUsers.GridColor =
                Color.FromArgb(220, 221, 225);

            // Center Important Columns
            dgvUsers.Columns["User ID"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsers.Columns["Role"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsers.Columns["Created Date"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditUserForm add = new AddEditUserForm();
            add.ShowDialog();
            LoadUsers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a user first.");

                return;
            }

            int userID = Convert.ToInt32(
                dgvUsers.SelectedRows[0].Cells[0].Value);

            AddEditUserForm edit = new AddEditUserForm(userID);

            edit.ShowDialog();

            LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select a user.");

                    return;
                }

                int userID = Convert.ToInt32(
                dgvUsers.SelectedRows[0].Cells[0].Value);

                DialogResult result =
                    MessageBox.Show(
                        "Delete this user?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn =
                        DatabaseConnection.GetConnection())
                    {
                        conn.Open();

                        string query =
                            "DELETE FROM Users WHERE UserID=@UserID";

                        SqlCommand cmd =
                            new SqlCommand(query, conn);

                        cmd.Parameters.AddWithValue(
                            "@UserID", userID);

                        cmd.ExecuteNonQuery();
                    }

                    LoadUsers();

                    MessageBox.Show(
                        "User deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadUsers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword =
                    txtSearch.Text.Trim();

                string query = @"
        SELECT
            U.UserID AS [User ID],
            U.FullName AS [Full Name],
            U.Username,
            U.Email,
            U.Phone,
            R.RoleName AS [Role],
            U.CreatedDate
        FROM Users U
        INNER JOIN Roles R
            ON U.RoleID = R.RoleID
        WHERE
            U.FullName LIKE '%" + keyword + @"%'
            OR U.Username LIKE '%" + keyword + @"%'";

                dgvUsers.DataSource =
                    DatabaseConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoleFilter.SelectedValue == null)
                return;

            if (cmbRoleFilter.SelectedValue is DataRowView)
                return;

            FilterUsers();
        }
    }
}
