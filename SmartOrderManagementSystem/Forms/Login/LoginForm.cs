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
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            btnLogin.FlatAppearance.BorderSize = 0;

            btnBack.FlatAppearance.BorderSize = 1;


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //if (user == "admin" && pass == "123")
            //{
            //    MessageBox.Show("Login Success");

            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Username or Password");
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            string user = txtUsername.Text.Trim();
            string pass = txtPass.Text.Trim();

            // Check the textbox is empty or not
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter username and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string query = @"SELECT u.UserID, u.Username,u.Fullname,u.Email,u.Phone,r.RoleID,u.Sex " +
                               "FROM Users u LEFT JOIN Roles r ON u.RoleID = r.RoleID " +
                               "WHERE u.Username = @Username AND u.Password = @Password";
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@Username", user),
                        new SqlParameter("@Password", pass)
                    };
                    DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        int userId = Convert.ToInt32(row["UserID"]);
                        string fullname = row["Fullname"].ToString();
                        int roleId = Convert.ToInt32(row["RoleID"]);

                        MessageBox.Show("Welcome " + fullname + "!", "Login Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        new StaffDashboard(userId, fullname).Show();

                        //if (roleId == 9)
                        //{
                        //    new StaffDashboard(UserID, Fullname).Show();
                        //}
                        //else if (roleId == 10)
                        //{
                        //    new StaffDashboard(UserID, Fullname).Show();
                        //}
                        //else if (roleId == 11)
                        //{
                        //    new StaffDashboard(UserID, Fullname).Show();
                        //}
                        //else
                        //{
                        //    new StaffDashboard(UserID, Fullname).Show();
                        //}

                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPass.Clear();
                        txtUsername.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login error." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginChoiceForm LogChoice = new LoginChoiceForm();
            LogChoice.Show();
            this.Hide();
        }
    }
}
