using FinalProject.model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class signInfo : Form
    {
        string selected;
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
            if (rbcustom.Checked == true)
            {
                selected = rbcustom.Text;
            }
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
            else if (rbcustom.Checked)
            {
                pn = "Custom";
               // custom c = new custom(id);
                //pr = c.price;
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

        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            // Class2.displayBooked(id);

            //this.Close();
            /*
            SeeOrders s = new SeeOrders(id);
            s.bridename = bFN.Text;
            s.bridelname = bLN.Text;
            s.groomname = gFN.Text;
            s.groomlname = gLN.Text;
            s.guests = tbGuestNum.Text;
            s.royal = rbRoyal.Checked.ToString();
            s.premium = rbPremium.Checked.ToString();
            s.simple = rbSimple.Checked.ToString();
            s.luxury = rbLuxury.Checked.ToString();
            s.basic = rbBasic.Checked.ToString();
            s.custom = rbcustom.Checked.ToString();
            s.weddingDate = guna2DateTimePicker1.Text;
            s.package = selected;
            s.ShowDialog();
       */
        }
        private void gFN_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbRoyal_CheckedChanged(object sender, EventArgs e)
        {

            if (rbRoyal.Checked == true)
            {
                selected = rbRoyal.Text;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rbPremium_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPremium.Checked == true)
            {
                selected = rbPremium.Text;
            }
        }

        private void rbSimple_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSimple.Checked == true)
            {
                selected = rbSimple.Text;
            }
        }

        private void rbLuxury_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLuxury.Checked == true)
            {
                selected = rbLuxury.Text;
            }
        }

        private void rbBasic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBasic.Checked == true)
            {
                selected = rbBasic.Text;
            }
        }
    }
}
