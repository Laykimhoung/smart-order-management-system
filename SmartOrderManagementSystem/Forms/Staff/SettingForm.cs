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
            //Sex_combobox.Items.AddRange(new string[] { "Male", "Female" });
            Load_user_staffinfo();
        }

        // Load the staff information into the setting form
        // Declare the constructure of the query to get the staff information from the database
        private int Staff_id;

        public void Profile_Form(int StaffID)
        {
            InitializeComponent();
            Staff_id = StaffID;
        }
        private void Load_user_staffinfo()
        {
            string query = @"SELECT UserID,Username,Fullname,Email,Phone,RoleID " + "FROM Users WHERE UserID = " + Staff_id;
                            //LEFT JOIN (SELECT UserID FROM Users WHERE )Roles r ON u.RoleID = r.RoleID GROUP BY u.UserID,u.Username,u.Fullname,u.Email,u.PhoneNumber,r.RoleID";
            try
            {
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    // Fill the data to each textbox
                    Userid_txt.Text = row["UserID"].ToString();
                    Fullname_txt.Text = row["Fullname"].ToString();
                    Email_txt.Text = row["Email"].ToString();
                    Phonenumber_txt.Text = row["Phone"].ToString();
                    Role_txt.Text = row["RoleID"].ToString();
                    Sex_txt.Text = row["RoleID"].ToString();
                    username_txt.Text = row["username"].ToString();

                    // name under the photo in Profil
                    Name_lbl.Text = row["Fullname"].ToString();
                }
                else
                {
                    MessageBox.Show("No profile data found.", "Info",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff information: " + ex.Message);
            }
        }
    }
}
