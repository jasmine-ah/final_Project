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

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }
        public string weddingDate { get; set; }
        public int contactInfo { get; set; }




        public void save()
        {
            class1.Add(this);
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
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
                string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
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

                        MainPage screen = new MainPage();
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



        /*public static List<Class1> getAllProducts()
        {

            List<Class1> temp = new List<Class1>();
            try
            {
                string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select * from employee;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())

                {
                    Class1 c = new Class1();

                    c.firstName = (string)sdr["firstName"];
                    c.lastName = (string)sdr["lastName"];
                    c.contactInfo = (int)sdr["ContactInfo"];
                    c.weddingDate = (string)sdr["weddindDate"];
                    c.Email = (string)sdr["email"];            
                    c.Password = (string)sdr["Password"];



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
*/
        
    }
}



