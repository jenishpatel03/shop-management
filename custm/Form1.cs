using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace custm
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajay\Documents\custm.accdb;
Persist Security Info=False;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
               
                
                connection.Open();
             
                connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
 
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "Select * from cdata where u_name='"+txt_uname.Text+"'and pass= '"+text_pass.Text+"'";
           
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while(reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("LOGIN SUCCESSFULLY!!!");
                connection.Close();
                connection.Dispose();
                this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else if (count > 1)
            {
                MessageBox.Show(" duplicat Username and password");
            }
            else
            {
                MessageBox.Show("Username and password is not corract");
            }
            



            connection.Close();
        }
    }
}
