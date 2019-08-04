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
    public partial class Form5 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public Form5()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ajay\Documents\custm.accdb;
Persist Security Info=False;";
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "delete from cdata where c_id=" + textBox7.Text+ "";

                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Data successfully DELETED");
                connection.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Error" + ex); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
