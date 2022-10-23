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
using System.Data.SqlClient;
using System.Configuration;

namespace FinalProject
{
    public partial class custom : Form
    {
        int id;
        public custom(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        //{ for (int i=0; i<=checkedListBox1.Items.Count-1; i++)
        //    { 
        //        string connectionString = @"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;";
        //        SqlConnection con = new SqlConnection(connectionString);
        //        string Query = "insert into selected values(@id,@bs,@ps,@c,@dj,@d,@vb);";
        //        SqlCommand cmd = new SqlCommand(Query, con);
        //        cmd.Parameters.AddWithValue("@id",id);
        //        cmd.Parameters.AddWithValue("beautyService",@bs);
        //        cmd.Parameters.AddWithValue("id", @ps);
        //        cmd.Parameters.AddWithValue("id", @id);
        //        cmd.Parameters.AddWithValue("id", @id);
        //        cmd.Parameters.AddWithValue("id", @id);

        //    }


        { 
            
            Class2 c2=new Class2();
            c2.selected(id, checkedListBox1);
            MessageBox.Show("customized");
            label4.Text = c2.price.ToString();
           /* signInfo s = new signInfo(id)
            s.Show();
            this.Close();*/

          /*  string chkboxselect = "";
           for (int i = 0; i <=checkedListBox1.CheckedItems.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (chkboxselect == "")
                    {
                        chkboxselect = checkedListBox1.Items[i].ToString();
                    }

                 
                    }
                
            }*/
           /* string str = @"Data Source=TINELLA\SQLEXPRESS;Initial Catalog=final_project;Integrated Security=true;";
            SqlConnection con = new SqlConnection(str);
            try
            {
                con.Open();
                string query = "insert into selected values('" + chkboxselect+ "')";
                SqlCommand cmd=new SqlCommand(query, con);
                /*cmd.Parameters.AddWithValue("@id",this.id);
                cmd.Parameters.AddWithValue("@BeautyService", );
                
                label3.Text=
                cmd.ExecuteNonQuery();
                MessageBox.Show("succesful");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            };
*/
            /*
          string chkboxselect="";
            for(int i=0;i<checkedListbox1.Items.Count;i++){
            if(checkedListBox1.Items[i].Selected){
            if(chkboxselect=""){
            chkboxselect=CheckedListBox1.Items[i].Text;
            }else{
            chkbocselect+=","+checkedListBox1.Items[i].Text;
            }}}
          */
            /*this.Close();
            signInfo s = new signInfo(id);
            s.Show();*/
        }

        private void custom_Load(object sender, EventArgs e)
        {

        }
    }
}
