using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace FinalProject
{
    public partial class resetpwd : Form
    {
        string email = Fp.to;
        public resetpwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnewpwd.Text == txtnewcp.Text)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;");
                SqlCommand cmd = new SqlCommand("UPDATE[dbo].[login] SET [password] = '"+txtnewcp.Text+"' WHERE email='"+email+"'",connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("password reset successfully");
            }
            else
            {
                MessageBox.Show("Enter the same password as above");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            homePage hp = new homePage();
            this.Hide();
            hp.Show();
        }
    }
}
