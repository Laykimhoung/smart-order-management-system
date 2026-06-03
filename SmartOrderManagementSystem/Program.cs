using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartOrderManagementSystem.Forms.Login;
using SmartOrderManagementSystem.Forms.Admin;
using SmartOrderManagementSystem.Forms.Staff;
using SmartOrderManagementSystem.Forms.Customer;

namespace SmartOrderManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StaffDashboard());
        }
    }
}
