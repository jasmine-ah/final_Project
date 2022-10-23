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
    public partial class SeeOrders : Form
    {
        public string bridename { set; get; }
        public string bridelname { set; get; }
        public string groomname { set; get; }
        public string groomlname { set; get; }
        public string package { set; get; }
        public string guests { set; get; }
        public string weddingDate { set; get; }
        public string royal { set; get; }
        public string premium { set; get; }
        public string simple { set; get; }
        public string luxury { set; get; }
        public string basic { set; get; }
        public string custom { set; get; }

        public SeeOrders()
        {
            InitializeComponent();
        }

        private void SeeOrders_Load(object sender, EventArgs e)
        {
            label1.Text = bridename+" "+bridelname;
            label2.Text = groomname + " " + groomlname;
            label3.Text = guests;
            label4.Text = package;
            label5.Text = weddingDate; 

        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            contact_us c = new contact_us();
            c.Show();
        }
    }
}
