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
    public partial class StaffDashboard : Form
    {
        public StaffDashboard()
        {
            InitializeComponent();
        }

        private void StaffDashboard_Load(object sender, EventArgs e)
        {

        }
        //method help to show the subform in the panel
        private void ShowSubForm(Form subForm)
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
            ShowSubForm(new StaffHome());
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

        private void Staff_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new StaffForm());
        }

        private void Report_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new ReportsForm());
        }

        private void Message_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new MessageForm());
        }

        private void Schedule_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new ScheduleForm());
        }

        private void Setting_btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(new SettingForm());
        }
    }
}
