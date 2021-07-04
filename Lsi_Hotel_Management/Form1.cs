using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lsi_Hotel_Management
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ayous\Documents\hotel_bd.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from Admin where admin_name='" + username.Text + "' and admin_password='"+password.Text+"' ",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if(dt.Rows[0][0].ToString()=="1")
            {
                Main mf = new Main();
                mf.Show();
                this.Hide();



                

            }
            else
            {
                MessageBox.Show("Username Or password Wrong");

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
