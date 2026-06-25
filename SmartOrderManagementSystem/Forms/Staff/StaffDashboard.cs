using SmartOrderManagementSystem.Forms.Customer;
using SmartOrderManagementSystem.Forms.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SmartOrderManagementSystem.Forms.Staff
{
    public partial class StaffDashboard : Form
    {
        // Contructor that call for My profile that show the information of the staff ater log in 
        private string full_name;
        private int user_ID;
     

        

        public StaffDashboard(int UserID, string Fullname)
        {
            InitializeComponent();
            user_ID = UserID;
            full_name= Fullname;
           
            
        }

        private void StaffDashboard_Load(object sender, EventArgs e)
        {
            // show the name in the button staff sccount
       
            ShowSubForm(new StaffHome(full_name));
            Staff_accout_btn.ButtonText = full_name;
           


        }
        //method help to show the subform in the panel
        public void ShowSubForm(Form subForm)
        {
            // Clear existing controls from the panel
            panel_container.Controls.Clear();
            // Set the subform's properties to fit within the panel
            // set the widow into a child form
            subForm.TopLevel = false;
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            // Add the subform to the panel and display it
            panel_container.Controls.Add(subForm);
            subForm.Show();
        }

        private void Home_btn(object sender, EventArgs e)
        {
            ShowSubForm(new StaffHome(full_name));
        }
        //Cutomer btn click event to show the customer record form
        private void Customer_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new CustomerRecordForm());
        }

        private void Order_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new OrderForm());
        }

        

        private void Message_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Activity_Feed());
        }

        

        private void Setting_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new SettingForm(user_ID));
          
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            
                LoginChoiceForm loginChoice = new LoginChoiceForm();
                loginChoice.Show();
                this.Close();
            
        }

        private void Cutomer_dashboard_Click(object sender, EventArgs e)
        {
          
            CustomerLoginForm customerlogin = new CustomerLoginForm(full_name);
            customerlogin.Show();
            this.Hide();
        }
    }
}
