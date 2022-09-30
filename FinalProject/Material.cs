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

namespace FinalProject
{
    public partial class Material : Form
    {
        public Material()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox_search.Text);
            var product = booking.findOne(i);
            if (product == null)
            {
                MessageBox.Show("Customer doesn't Exist");
            }
            else
            {
                textBox_fn.Text = product.firstName;
                textBox_ln.Text = product.lastName;                
                dateTimePicker1.Value = DateTime.Parse(product.weddingDate);
                
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            booking.update(  dateTimePicker1.Text, textBox_ng.Text, comboBox1.Text);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = booking.GetAllProducts();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int i = int.Parse(label7.Text);
            booking.delete(i);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = booking.GetAllProducts();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
