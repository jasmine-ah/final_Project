using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FinalProject.model
{
    internal class Class1
    {


        static private List<Class1> class1 = new List<Class1>();
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }
        public string weddingDate { get; set; }
        public string contactInfo { get; set; }




        public void save()
        {
            class1.Add(this);
            string connectionString = @"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
               
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "exec sp_ins @fn,@ln,@email,@ci,@password,@wd";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@fn", this.firstName);
                cmd.Parameters.AddWithValue("@ln", this.lastName);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@ci", this.contactInfo);
                cmd.Parameters.AddWithValue("@password", this.Password);
                cmd.Parameters.AddWithValue("@wd", this.weddingDate);

                var result = cmd.ExecuteNonQuery();
                
                MessageBox.Show("Successfully Signed up!!!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };


        }

        
        public static Class1 findOne(string email,string password)
        {
            List<Class1> temp = new List<Class1>();
            try
            {
                string connectionString = @"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select email,password from sign_up ;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())

                {
                    string em, pwd;


                    em = (string)sdr["email"];

                    pwd = (string)sdr["password"];

                    

                    if (em==email && pwd == password)
                    {

                        signInfo screen = new signInfo();
                        screen.Show();
                        
                        //this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Email or Password");
                    }
                   
                }

                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
            return temp.Find(c => c.Email == email);
        }



        public static List<Class1> getAllProducts()
        {

            List<Class1> temp = new List<Class1>();
            try
            {
                string connectionString = @"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select * from employee;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())

                {
                    Class1 c = new Class1();
                    c.id=(int)sdr["id"];
                    c.firstName = (string)sdr["firstName"];
                    c.lastName = (string)sdr["lastName"];
                    c.Email = (string)sdr["email"];
                    c.contactInfo = (string)sdr["contactInfo"];
                    c.Password = (string)sdr["password"];
                    c.weddingDate = (string)sdr["weddingDate"];



                    temp.Add(c);
                }
                connection.Close();
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
            return temp;
        }
        public static void update(string fn, string ln, string email, string cont, string pass, string date)
        {
            string connectionString = @"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("connection successful!!!");
                string Query = "exec UPDATEsign_up @fname,@lname,@email,@contactInfo,@pass,@wd;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@fname", fn);
                cmd.Parameters.AddWithValue("@lname", ln);
                cmd.Parameters.AddWithValue("@contactInfo", cont);
                cmd.Parameters.AddWithValue("@wd", date);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", pass);
                //cmd.Parameters.AddWithValue("@id", id);

                var result = cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Updated!!!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };



        }


    }
}



