using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.model
{
    internal class Class2
    {
        public int Id { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public string PackageName { get; set; }
        public double price { get; set; }
        public int GuestNumber { get; set; }

        static private List<Class2> class2 = new List<Class2>();
        public static string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";

        public void save()
        {

            class2.Add(this);

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "exec spInsert @id @bf,@gn,@pn,@price,@ng";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@id", this.Id);
                cmd.Parameters.AddWithValue("@bf", this.BrideName);
                cmd.Parameters.AddWithValue("@gn", this.GroomName);
                cmd.Parameters.AddWithValue("@pn", this.PackageName);
                cmd.Parameters.AddWithValue("@price", this.price);
                cmd.Parameters.AddWithValue("@ng", this.GuestNumber);


                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Booked!!!");



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

