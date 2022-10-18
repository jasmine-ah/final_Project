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
        public string emailextension { get; set; }
        public string contactInfo { get; set; }


     public static string connectionString = @"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;";

        public void save()
        {
            class1.Add(this);
            
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
               
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "exec sp_ins @fn,@ln,@email,@ci,@password";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@fn", this.firstName);
                cmd.Parameters.AddWithValue("@ln", this.lastName);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@ci", this.contactInfo);
                cmd.Parameters.AddWithValue("@password", this.Password);
              

                 cmd.ExecuteNonQuery();
                
                MessageBox.Show("Successfully Signed up!!!");

                string query2 = "exec sp_insert @email,@password";

                SqlCommand cmd2 = new SqlCommand(query2, connection);
                cmd2.Parameters.AddWithValue("@password", this.Password);
                cmd2.Parameters.AddWithValue("@email", this.Email);
                cmd2.ExecuteNonQuery();


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
        
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select * from login ;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())

                {
                    Class1 c1 = new Class1();
                    
                    c1.Email = (string)sdr["email"];

                    c1.Password = (string)sdr["password"];
                    temp.Add(c1);

                }
                connection.Close();
                
                connection.Open();
                String query2 = "select userId from sign_up where email='"+email+"' and password='"+password+"'";
                SqlCommand cmd2=new SqlCommand(query2, connection);
                SqlDataReader sdr2=cmd2.ExecuteReader();
                while (sdr2.Read())
                {
                        Class1 c2 = new Class1();
                        c2.id= (int)sdr2["id"];
                       temp.Add(c2);
                    
                }

                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
            return temp.Find(c => c.Email == email && c.Password == password);
        }


/*
        public static List<Class1> getAllProducts()
        {

            List<Class1> temp = new List<Class1>();
            try
            {
               // string connectionString = @"Data Source=PCDOC; Initial catalog=final_project;Integrated Security=true;";
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
                   // c.weddingDate = (string)sdr["weddingDate"];



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
            //string connectionString = @"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("connection successful!!!");
                string Query = "exec UPDATEsign_up @fname,@lname,@email,@contactInfo,@pass;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@fname", fn);
                cmd.Parameters.AddWithValue("@lname", ln);
                cmd.Parameters.AddWithValue("@contactInfo", cont);
                //cmd.Parameters.AddWithValue("@wd", date);
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
              */


        }


    }



