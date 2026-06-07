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
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            // Add selecting sex
            Sex_combobox.Items.AddRange(new string[] { "Male", "Female" });
        }

        // Load the staff information into the setting form
        private void Laod_user_staffinfo()
        {
            string query = @"SELECT u.UserID,u.Username,u.Fullname,u.Email,u.PhoneNumber,r.RoleID FROM Users
                            LEFT JOIN Roles r ON u.RoleID = r.RoleID GROUP BY u.UserID,u.Username,u.Fullname,u.Email,u.PhoneNumber,r.RoleID";
            try
            {
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Userid_txt.Text = row["UserID"].ToString();
                    Fullname_txt.Text = row["Fullname"].ToString();
                    Email_txt.Text = row["Email"].ToString();
                    Phonenumber_txt.Text = row["PhoneNumber"].ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff information: " + ex.Message);
            }
        }
    }
}
