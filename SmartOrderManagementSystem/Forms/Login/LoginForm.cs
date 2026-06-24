using Microsoft.VisualBasic.ApplicationServices;
using SmartOrderManagementSystem.Database;
using SmartOrderManagementSystem.Forms.Admin;
using SmartOrderManagementSystem.Forms.Customer;
using SmartOrderManagementSystem.Forms.Staff;
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

namespace SmartOrderManagementSystem.Forms.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            btnBack.Cursor = Cursors.Hand;
            btnLogin.Cursor = Cursors.Hand;
            chkShowPassword.Cursor = Cursors.Hand;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            btnLogin.FlatAppearance.BorderSize = 0;

            btnBack.FlatAppearance.BorderSize = 1;

            txtPass.UseSystemPasswordChar = true;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginChoiceForm LogChoice = new LoginChoiceForm();
            LogChoice.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text.Trim();

            // Username Validation
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your username.","Login Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                txtUsername.Focus();
                return;
            }

            // Password Validation
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.","Login Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                txtPass.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT U.FullName,U.UserID,U.Username,U.Password, R.RoleName FROM Users U INNER JOIN Roles R ON U.RoleID = R.RoleID WHERE
                                   U.Username = @Username AND U.Password = @Password AND R.RoleName IN ('Admin', 'Staff')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               int userID = reader.GetInt32(reader.GetOrdinal("UserID"));
                               string fullName = reader.GetString(reader.GetOrdinal("FullName"));


                               MessageBox.Show($"Welcome {fullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               StaffDashboard staffForm = new StaffDashboard(userID, username);
                                  staffForm.Show();

                                 this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPass.Focus();
                            }
                        }

                         
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error:\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
