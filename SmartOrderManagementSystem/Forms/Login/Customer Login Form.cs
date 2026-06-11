using SmartOrderManagementSystem.Forms.Customer;
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
            string name = txtName.Text.Trim();
            string phoneNumber = txtPhNum.Text.Trim();

            // Validate Name
            if (string.IsNullOrWhiteSpace(name) || name == "Enter your name")
            {
                MessageBox.Show("Please enter your name.",
                                "Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtName.Focus();
                return;
            }

            // Name length check
            if (name.Length < 2)
            {
                MessageBox.Show("Name must be at least 2 characters.",
                                "Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtName.Focus();
                return;
            }

            if (name.Length > 50)
            {
                MessageBox.Show("Name cannot exceed 50 characters.",
                                "Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtName.Focus();
                return;
            }

            // Name cannot contain numbers
            if (name.Any(char.IsDigit))
            {
                MessageBox.Show("Name cannot contain numbers.",
                                "Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtName.Focus();
                return;
            }

            // Validate Phone Number
            if (!string.IsNullOrWhiteSpace(phoneNumber) &&
                phoneNumber != "0123456789")
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

                if (phoneNumber.Length < 10 || phoneNumber.Length > 15)
                {
                    MessageBox.Show("Phone number must be between 10 and 15 digits.",
                                    "Alert",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    txtPhNum.Focus();
                    return;
                }
            }

            // Confirmation Message
            DialogResult result = MessageBox.Show(
                $"Name: {name}\n" +
                $"Phone Number: {(phoneNumber == "0123456789" ? "Not Provided" : phoneNumber)}\n\n" +
                "Start ordering?",
                "Confirm Customer Information",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // ... (Keep your validation code up here) ...

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                // FIX: Call your helper class to get the correct connection
                using (SqlConnection conn = SmartOrderManagementSystem.Database.DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO Customers (CustomerName, Phone)
                         VALUES (@CustomerName, @Phone)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", name);

                        if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber == "0123456789")
                        {
                            cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                // Go to Customer Dashboard
                CustomerDashboard CusForm = new CustomerDashboard(name, _staffname);
                CusForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving customer information:\n" + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void CustomerLoginForm_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
        
    }
}
