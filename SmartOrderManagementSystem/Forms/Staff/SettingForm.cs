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

namespace SmartOrderManagementSystem.Forms.Staff
{
    public partial class SettingForm : Form
    {

        private int user_ID;

        // Constructure recieve userID from StaffDashboard to load the staff information in the setting form
        public SettingForm(int UserID)
        {
            InitializeComponent();
            user_ID = UserID;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            // Current date
            Current_date_lbl.Text = DateTime.Now.ToString("ddd, dd MMM yyyy");
            Load_user_staffinfo();
        }

       
       
        private void Load_user_staffinfo()
        {
            string query = @"SELECT u.UserID,u.Username,u.FullName,u.Email,u.Phone,r.RoleName,u.Sex
                                FROM Users u
                                LEFT JOIN Roles r ON u.RoleID = r.RoleID WHERE u.UserID = @UserID";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", user_ID)
                };
                DataTable dt = DatabaseConnection.ExecuteQueryWithParams(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    // Fill the data to each textbox
                    Userid_txt.Text = row["UserID"].ToString();
                    Fullname_txt.Text = row["Fullname"].ToString();
                    Email_txt.Text = row["Email"].ToString();
                    Phonenumber_txt.Text = row["Phone"].ToString();
                    Role_txt.Text = row["RoleName"].ToString();
                    Sex_txt.Text = row["Sex"].ToString();
                    username_txt.Text = row["Username"].ToString();

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
