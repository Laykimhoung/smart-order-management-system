using SmartOrderManagementSystem.Forms.Customer;
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
    public partial class CustomerLoginForm : Form
    {
        Color OriGoToCusBut;
        Color OriBackBut;
        string _staffname;

        public CustomerLoginForm(string staffname)
        {
            InitializeComponent();
            _staffname = staffname;

            btnBack.Cursor = Cursors.Hand;
            btnGoToCusForm.Cursor = Cursors.Hand;

            OriGoToCusBut = btnGoToCusForm.BackColor;
            OriBackBut = btnBack.BackColor;

            
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginChoiceForm LogChoice = new LoginChoiceForm();
            LogChoice.Show();
            this.Hide();
        }

        private void CustomerLoginForm_Load(object sender, EventArgs e)
        {
            txtName.Text = "Enter your name";
            txtName.ForeColor = Color.Gray;

            txtPhNum.Text = "0123456789";
            txtPhNum.ForeColor = Color.Gray;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Enter your name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "Enter your name";
                txtName.ForeColor = Color.Gray;
            }
        }

        private void txtPhNum_Enter(object sender, EventArgs e)
        {
            if (txtPhNum.Text == "0123456789")
            {
                txtPhNum.Text = "";
                txtPhNum.ForeColor = Color.Black;
            }
        }

        private void txPhNum_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhNum.Text))
            {
                txtPhNum.Text = "0123456789";
                txtPhNum.ForeColor = Color.Gray;
            }
        }

        private void btnGoToCusForm_MouseEnter(object sender, EventArgs e)
        {
            btnGoToCusForm.BackColor = Color.Green;
        }

        private void btnGoToCusForm_MouseLeave(object sender, EventArgs e)
        {
            btnGoToCusForm.BackColor = OriGoToCusBut;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = OriBackBut;
        }
        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.Red;
        }

        private void btnGoToCusForm_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phoneNumber = txtPhNum.Text;
            if (string.IsNullOrWhiteSpace(name) || name == "Enter your name")
            {
                MessageBox.Show("Please enter your name.",
                                "Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtName.Focus();
                return;
            }
            if (!string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber != "0123456789")
            {
                if (!phoneNumber.All(char.IsDigit))
                {
                    MessageBox.Show("Phone number must contain digits only.",
                                    "Alert",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    txtPhNum.Focus();
                    return;
                }
            }


            // Go to mi K'Nath form

            CustomerDashboard CusForm = new CustomerDashboard(txtName.Text, _staffname);
            CusForm.Show();
            this.Hide();



            // Insert data to database

            //Query....

        }

        private void CustomerLoginForm_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
        
    }
}
