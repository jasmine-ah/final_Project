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
        int id;
        public signInfo(int id)
        {
            InitializeComponent();
            this.id = id;
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
            if (bFN.Text == "First")
            {
                bFN.Text = "";
                bFN.ForeColor = Color.Black;       
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (bFN.Text == "")
            {
                bFN.Text = "First";
                bFN.ForeColor = Color.Silver;
            }

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (bLN.Text == "Last")
            {
                bLN.Text = "";
                bLN.ForeColor = Color.Black;
            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (bLN.Text == "")
            {
                bLN.Text = "Last";
                bLN.ForeColor = Color.Silver;
            }

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (gFN.Text == "First")
            {
                gFN.Text = "";
                gFN.ForeColor = Color.Black;
            }

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

            if (gFN.Text == "")
            {
                gFN.Text = "First";
                gFN.ForeColor = Color.Silver;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (gLN.Text == "Last")
            {
                gLN.Text = "";
                gLN.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {

            if (gLN.Text == "")
            {
                gLN.Text = "Last";
                gLN.ForeColor = Color.Silver;
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
            custom c = new custom(id);
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pn = null;
            int pr = 0;
            if (rbBasic.Checked)
            {
                pn = "Basic";
                pr = 150000;
            }
                
            else if (rbRoyal.Checked)
            {
                pn = "Royal";
                pr = 600000;
            }
               
            else if (rbLuxury.Checked)
            {
                pn = "Luxury";
                pr = 450000;
            }
            else if (rbSimple.Checked)
            {
                pn = "Simple";
                pr = 100000;
            }

            else if (rbPremium.Checked)
            {
                pn = "Premium";
                pr = 300000;
            }

            //save customer info on your database
            Class2 c2 = new Class2
            {
                Id = id,
                BrideName = bFN.Text + " " + bLN.Text,
                GroomName = gFN.Text + " " + gLN.Text,
                PackageName = pn,
                price = pr,
                GuestNumber = int.Parse(tbGuestNum.Text),
                 weddingDate = guna2DateTimePicker1.Value,
            };
            c2.save();
            SeeOrder s = new SeeOrder();
            s.label1.Text = bFN.Text;
        }

  

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void gFN_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbRoyal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
