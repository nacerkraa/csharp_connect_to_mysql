using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace csharp_connect_to_mysql
{
    public partial class Open_Close_Connection : Form
    {
        MySqlConnection conn;
        public Open_Close_Connection()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection("datasource= localhost;port=3306;username=root;password="your_pasword");
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    label1.Text = "Connected succefuly";
                    label1.ForeColor = Color.Green;
                }
                else
                {
                    label1.Text = "Not Connected";
                    label1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                label1.Text = "Not Connected";
                label1.ForeColor = Color.Red;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                label1.Text = "Connected";
                label1.ForeColor = Color.Green;
            }
        }
    }
}
