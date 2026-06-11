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
using SmartOrderManagementSystem.Database;

namespace SmartOrderManagementSystem.Forms.Admin
{
    public partial class AddEditUserForm : Form
    {
        private int userID = 0;
        public AddEditUserForm()
        {
            InitializeComponent();
        }      
        public AddEditUserForm(int id)
        {
            InitializeComponent();
            userID = id;
        }

        private void AddEditUserForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadSex();

            if (userID != 0)
            {
                lblTitle.Text = "Edit User";
                LoadUserData();
            }
            else
            {
                lblTitle.Text = "Add User";
            }
        }
        private void LoadSex()
        {
            cmbSex.Items.Clear();
            cmbSex.Items.Add("Male");
            cmbSex.Items.Add("Female");
        }
        private void LoadRoles()
        {
            try
            {
                DataTable dt =
                    DatabaseConnection.ExecuteQuery(
                        "SELECT * FROM Roles");

                cmbRole.DataSource = dt;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadUserData()
        {
            try
            {
                string query =
                    "SELECT * FROM Users WHERE UserID = " + userID;

                DataTable dt =
                    DatabaseConnection.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    txtFullName.Text =
                        dt.Rows[0]["FullName"].ToString();

                    txtUsername.Text =
                        dt.Rows[0]["Username"].ToString();

                    txtPassword.Text =
                        dt.Rows[0]["Password"].ToString();

                    txtEmail.Text =
                        dt.Rows[0]["Email"].ToString();

                    txtPhone.Text =
                        dt.Rows[0]["Phone"].ToString();

                    cmbSex.Text =
                        dt.Rows[0]["Sex"].ToString();

                    cmbRole.SelectedValue =
                        dt.Rows[0]["RoleID"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter full name.");
                return;
            }

            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter username.");
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter password.");
                return;
            }

            try
            {
                using (SqlConnection conn =
                    DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd;

                    if (userID == 0)
                    {
                        string query = @"
                INSERT INTO Users
                (
                    Username,
                    Password,
                    FullName,
                    Sex,
                    Email,
                    Phone,
                    RoleID
                )
                VALUES
                (
                    @Username,
                    @Password,
                    @FullName,
                    @Sex,
                    @Email,
                    @Phone,
                    @RoleID
                )";

                        cmd =
                            new SqlCommand(query, conn);
                    }
                    else
                    {
                        string query = @"
                UPDATE Users
                SET
                    Username=@Username,
                    Password=@Password,
                    FullName=@FullName,
                    Sex=@Sex,
                    Email=@Email,
                    Phone=@Phone,
                    RoleID=@RoleID
                WHERE UserID=@UserID";

                        cmd =
                            new SqlCommand(query, conn);

                        cmd.Parameters.AddWithValue(
                            "@UserID",
                            userID);
                    }

                    cmd.Parameters.AddWithValue(
                        "@Username",
                        txtUsername.Text);

                    cmd.Parameters.AddWithValue(
                        "@Password",
                        txtPassword.Text);

                    cmd.Parameters.AddWithValue(
                        "@FullName",
                        txtFullName.Text);

                    cmd.Parameters.AddWithValue(
                        "@Sex",
                        cmbSex.Text);

                    cmd.Parameters.AddWithValue(
                        "@Email",
                        txtEmail.Text);

                    cmd.Parameters.AddWithValue(
                        "@Phone",
                        txtPhone.Text);

                    cmd.Parameters.AddWithValue(
                        "@RoleID",
                        cmbRole.SelectedValue);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "User saved successfully.");

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
