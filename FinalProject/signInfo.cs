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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject
{
    public partial class signInfo : Form
    {
        public signInfo()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
           
        }

        private void signInfo_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "First")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;       
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "First";
                textBox2.ForeColor = Color.Silver;
            }

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Last")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Last";
                textBox3.ForeColor = Color.Silver;
            }

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "First")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                textBox6.Text = "First";
                textBox6.ForeColor = Color.Silver;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Last")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {

            if (textBox7.Text == "")
            {
                textBox7.Text = "Last";
                textBox7.ForeColor = Color.Silver;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
            custom c = new custom();
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///save customer info on your database
        }
    }
}
