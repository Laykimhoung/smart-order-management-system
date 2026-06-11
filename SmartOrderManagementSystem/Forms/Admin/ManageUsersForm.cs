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
            StyleUsersGrid();
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
            U.CreatedDate AS [Created Date]
        FROM Users U
        INNER JOIN Roles R
            ON U.RoleID = R.RoleID
        ORDER BY U.UserID DESC";

                dgvUsers.DataSource =
                    DatabaseConnection.ExecuteQuery(query);

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

                cmbRoleFilter.DataSource = dt;

                cmbRoleFilter.DisplayMember = "RoleName";

                cmbRoleFilter.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StyleUsersGrid()
        {
            dgvUsers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsers.RowHeadersVisible = false;

            dgvUsers.RowTemplate.Height = 35;

            dgvUsers.EnableHeadersVisualStyles = false;

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.DeepSkyBlue;

            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
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

            int userID =
                Convert.ToInt32(
                dgvUsers.SelectedRows[0]
                .Cells["User ID"].Value);

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

                int userID =
                    Convert.ToInt32(
                    dgvUsers.SelectedRows[0]
                    .Cells["User ID"].Value);

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
    }
}
