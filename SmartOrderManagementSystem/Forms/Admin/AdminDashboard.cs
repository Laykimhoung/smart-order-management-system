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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            OpenChildForm(new AdminHomeForm());
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Connected!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Form activeForm = null;

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AdminHomeForm());
            lbWelcome.Text = "Home";
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageUsersForm());
            lbWelcome.Text = "Manage Users";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm());
            lbWelcome.Text = "Reports";
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderHistoryForm());
            lbWelcome.Text = "Order History";
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AnalysisForm());
            lbWelcome.Text = "Analysis";
        }
    }
}
