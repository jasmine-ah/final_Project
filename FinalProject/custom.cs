﻿using FinalProject.model;
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
        {
            
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
            this.Close();
            signInfo s = new signInfo(id);
            s.Show();
        }

        private void custom_Load(object sender, EventArgs e)
        {

        }
    }
}
