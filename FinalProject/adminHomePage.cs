using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class adminHomePage : Form
    {
        public adminHomePage()
        {
            InitializeComponent();
        }

        private void employeeManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            employee_page emp = new employee_page();
            emp.Show();
        }

        private void bookingManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            Material mat = new Material();
            mat.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            admin_login ad = new admin_login();
            ad.Show();
        }

        private void adminHomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
