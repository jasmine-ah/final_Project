using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.model
{
    internal class booking
    {
        static private List<booking> Aclass = new List<booking>();


        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string weddingDate { get; set; }
        public string Payment { get; set; }
        public int guests { get; set; }
        


        public void save()
        {
            Aclass.Add(this);
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {


                connection.Open();
                MessageBox.Show("connection successful!!!");
                // string gen;

                string Query = "exec ADDEMP @fname,@lname,@payement,@wd,@guests;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@fname", this.firstName);
                cmd.Parameters.AddWithValue("@lname", this.lastName);
                cmd.Parameters.AddWithValue("@payement", this.Payment);
                cmd.Parameters.AddWithValue("@wd", this.weddingDate);
                cmd.Parameters.AddWithValue("@guests", this.guests);

                var result = cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Saved!!!");



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
        static public List<booking> GetAllProducts()
        {
            List<booking> Bclass = new List<booking>();
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select * from employee;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    booking ac = new booking();

                    ac.id = (int)sdr["employeeID"];
                    ac.firstName = (string)sdr["firstName"];
                    ac.lastName = (string)sdr["lastName"];
                    /*ac.contactInfo = (string)sdr["ContactInfo"];
                    ac.DateOfBirth = (string)sdr["DOB"];
                    ac.Email = (string)sdr["email"];
                    ac.Occupation = (string)sdr["Occupation"];
                    ac.Gender = (string)sdr["gender"];
*/


                    Bclass.Add(ac);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };
            return Bclass;
        }
        public static booking findOne(int id)
        {
            List<booking> Bclass = new List<booking>();
            SqlConnection connection;
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            connection = new SqlConnection(connectionString);
            string Query = "exec bookDisplay @id;";
            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");


                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    booking bo = new booking();
                    
                    bo.id = (int)sdr["employeeID"];
                    bo.firstName = (string)sdr["firstName"];
                    bo.lastName = (string)sdr["lastName"];                   
                    bo.weddingDate = (string)sdr["DOB"];
                    

                    Bclass.Add(bo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            };
            
            return Bclass.Find(c => c.id == id);
        }
        public static void update( string date,string guests,string cb)
        {
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("connection successful!!!");
                string Query = "exec UPDATEBOOK @wd,@guests,@payment,@id;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                              
                cmd.Parameters.AddWithValue("@wd", date);
                cmd.Parameters.AddWithValue("@email", guests);
                cmd.Parameters.AddWithValue("@occupation", cb);
                

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

        public static void delete(int id)
        {
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");
                string Query = "exec DELETEBOOK @id;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                cmd.Parameters.AddWithValue("@id", id);

                var result = cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Deleted!!!");
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
