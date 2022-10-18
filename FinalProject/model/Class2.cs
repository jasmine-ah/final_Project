using System;
using System.Collections.Generic;
using System.Data;
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
        public DateTime weddingDate { get; set; }

        static private List<Class2> class2 = new List<Class2>();
        public static string connectionString = @"Data Source=PCDOC-PC\MSSQLSERVER01; Initial catalog=final_project;Integrated Security=true;";

        public void save()
        {

            class2.Add(this);

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "insert into weddingInfo values (@id,@bf,@gn, @pn, @price, @ng,@wd); ";
                    
                    //"values(@bf,@gn, @pn, @price, @ng,@wd);";


                SqlCommand cmd = new SqlCommand(Query, connection);
               cmd.Parameters.AddWithValue("@id", this.Id);
                cmd.Parameters.AddWithValue("@bf", this.BrideName);
                cmd.Parameters.AddWithValue("@gn", this.GroomName);
                cmd.Parameters.AddWithValue("@pn", this.PackageName);
                cmd.Parameters.AddWithValue("@price", this.price);
                cmd.Parameters.AddWithValue("@ng", this.GuestNumber);
                cmd.Parameters.AddWithValue("@wd", this.weddingDate);



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

        public static void selected(int id, CheckedListBox checkedListBox1)
        {
            SqlConnection connection = new SqlConnection(connectionString);
          
            try
            {
                connection.Open();
                string query = "Exec ins_selected @id,@bs,@ps,@cat,@dj,@dec,@vb";
                SqlCommand cmd=new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@bs", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(0);
                cmd.Parameters.AddWithValue("@ps", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(1);
                cmd.Parameters.AddWithValue("@cat", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(2);
                cmd.Parameters.AddWithValue("@dj", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(3);
                cmd.Parameters.AddWithValue("@dec", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(4);
                cmd.Parameters.AddWithValue("@vb", SqlDbType.Bit).Value = checkedListBox1.GetItemCheckState(5);

            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            };

        }
        public static void total()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(connectionString, connection);
                //string query = "exec calcPrice";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            };
        }

        }
    }

