using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartOrderManagementSystem.Forms.Login
{
    public partial class LoginChoiceForm : Form
    {
        Color StaOriCol;
        Color CusOriCol;
        Color AdmOriCol;
        public LoginChoiceForm()
        {
            InitializeComponent();

            StaffLogBut.Cursor = Cursors.Hand;
            
            AdminLogBut.Cursor = Cursors.Hand;

            StaOriCol = StaffLogBut.BackColor;
            
            AdmOriCol = AdminLogBut.BackColor;
        }

        private void CusLogBut_Click(object sender, EventArgs e)
        {
            CustomerLoginForm CusForm = new CustomerLoginForm("panuth");
            CusForm.Show();
            this.Hide();
        }

        private void AdminLogBut_Click(object sender, EventArgs e)
        {
            AdminLoginForm AdmForm = new AdminLoginForm();
            AdmForm.Show();
            this.Hide();
        }

        private void StaffLogBut_Click(object sender, EventArgs e)
        {
            LoginForm StaForm = new LoginForm();
            StaForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void AdminLogBut_MouseEnter(object sender, EventArgs e)
        {
            AdminLogBut.BackColor = Color.DarkRed;
        }

        private void AdminLogBut_MouseLeave(object sender, EventArgs e)
        {
            AdminLogBut.BackColor = AdmOriCol;
        }

        private void StaffLogBut_MouseEnter(object sender, EventArgs e)
        {
            StaffLogBut.BackColor = Color.DarkGreen;
        }

        private void StaffLogBut_MouseLeave(object sender, EventArgs e)
        {
            StaffLogBut.BackColor = StaOriCol;
        }
    }
}
