using SmartOrderManagementSystem.Database;
using SmartOrderManagementSystem.Forms.Admin;
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
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
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
                MessageBox.Show("Please enter your username.",
                                "Login Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtUsername.Focus();
                return;
            }

            // Password Validation
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.",
                                "Login Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtPass.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT COUNT(*)
                FROM Admin
                WHERE Username = @Username
                AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Login Successful!",
                                            "Success",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            AdminDashboard dashboard = new AdminDashboard();
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.",
                                            "Login Failed",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);

                            txtPass.Clear();
                            txtPass.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
