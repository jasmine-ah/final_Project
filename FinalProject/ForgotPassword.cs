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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("No information entered.");
            }
            else
            {
                var log = Class1.findpass(textBox1.Text, textBox2.Text);
                if (log == null)
                {
                    MessageBox.Show("You entered incorrect information try again ");
                }
            }
        }
    }
}

