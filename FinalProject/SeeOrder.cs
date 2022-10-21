using FinalProject.model;
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
    public partial class SeeOrder : Form
    {
        
        public SeeOrder()
        {

            /* signInfo s = new signInfo(id);
             bn = s.bFN.Text;
             InitializeComponent();

             label1.Text = bn;*/
        }

        private void SeeOrder_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            contact_us c=new contact_us();
            c.Show();
        }
    }
}
