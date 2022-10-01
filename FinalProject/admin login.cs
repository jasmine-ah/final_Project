using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class admin_login : Form
    {
        public admin_login()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        //Drag Form
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd,int wMeg, int wParam,int lParam);

        private void admin_login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            if (guna2TextBox1.Text == "" && guna2TextBox2.Text == "")
            {
                adminHomePage screen = new adminHomePage();
                screen.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect information ");
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
