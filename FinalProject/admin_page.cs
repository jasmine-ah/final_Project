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
    public partial class Admin_page : Form
    {
        public Admin_page()
        {
            InitializeComponent();
        }


        private void Admin_page_Load(object sender, EventArgs e)
        {

        }
     

        private void staffManagementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            employee_page emp = new employee_page();
            emp.Show();
        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            homePage emp = new homePage();
            emp.Show();
        }

        private void materialManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            Material mat = new Material();
            mat.Show();
        }
    }
}
