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
        public string groomName { get; set; }
        public string brideName { get; set; }
        public DateTime weddingDate { get; set; }
        public string Payment { get; set; }
        public int guests { get; set; }


        public static string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
        public void save()
        {
            Aclass.Add(this);
           // string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            //SqlConnection connection = new SqlConnection(connectionString);
            //try
            //{


            //    connection.Open();
            //    MessageBox.Show("connection successful!!!");
            //    // string gen;

            //    string Query = "exec ADDEMP @fname,@lname,@payment,@guests;";

            //    SqlCommand cmd = new SqlCommand(Query, connection);
            //    cmd.Parameters.AddWithValue("@fname", this.firstName);
            //    cmd.Parameters.AddWithValue("@lname", this.lastName);
            //    cmd.Parameters.AddWithValue("@payment", this.Payment);
            //    //cmd.Parameters.AddWithValue("@wd", this.weddingDate);
            //    cmd.Parameters.AddWithValue("@guests", this.guests);

            //    var result = cmd.ExecuteNonQuery();

            //    MessageBox.Show("Successfully Saved!!!");



            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}
            //finally
            //{
            //    connection.Close();
            //};


        }
        static public List<booking> GetAllProducts()
        {
            List<booking> Bclass = new List<booking>();
            
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select * from booked;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    booking ac = new booking();

                    ac.id = (int)sdr["id"];
                    ac.groomName = (string)sdr["brideName"];
                    ac.brideName = (string)sdr["groomName"];
                    ac.guests = (int)sdr["guests"];
                    ac.weddingDate = (DateTime)sdr["Weddingdate"];
                    //ac.Payment=(string) sdr["payment"];


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
          //  string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            connection = new SqlConnection(connectionString);
            string Query = "select * from booked";
            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");


                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();
               // cmd.Parameters.AddWithValue("@id", id);
                while (sdr.Read())
                {
                    
                    booking bo = new booking();
                    
                    bo.id = (int)sdr["id"];
                    bo.groomName = (string)sdr["brideName"];
                    bo.brideName = (string)sdr["groomName"];
                    bo.guests = (int)sdr["guests"];
                    bo.weddingDate = (DateTime)sdr["WeddingDate"];
                    //bo.Payment = (string)sdr["payment"];
                    

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
            
            return Bclass.Find(bo => bo.id == id);
        }
        public static void update( int id,string guests,string cb,string wd)
        {
            //string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("connection successful!!!");
                string Query = "exec UPDATEBOOK @guests,@payment,@wd,@id;";

                SqlCommand cmd = new SqlCommand(Query, connection);

                cmd.Parameters.AddWithValue("@guests", guests);
                cmd.Parameters.AddWithValue("@payment", cb);
                cmd.Parameters.AddWithValue("@wd", wd);
                cmd.Parameters.AddWithValue("@id", id);


                 cmd.ExecuteNonQuery();

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

        public static void delete(string id)
        {
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");
                string Query = "exec DB @id;";
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
