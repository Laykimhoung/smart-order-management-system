using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageUsersForm());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm());
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderHistoryForm());
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AnalysisForm());
        }
    }
}
