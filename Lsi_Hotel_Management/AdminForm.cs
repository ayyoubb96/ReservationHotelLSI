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
    public partial class AdminForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ayous\Documents\hotel_bd.mdf;Integrated Security=True;Connect Timeout=30");

        public void populate()
        {
            Con.Open();
            string MyQuery = "select*from Admin ";
            SqlDataAdapter da = new SqlDataAdapter(MyQuery, Con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            var ds = new DataSet();
            da.Fill(ds);
            Clientgv.DataSource = ds.Tables[0];
            Con.Close();
        }

        public AdminForm()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into Admin values('" + id.Text + "','" + name.Text + "','" + mdp.Text + "','" + phone.Text + "'  )", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Admin Added");
           

            Con.Close();
            populate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            populate();
        }

        private void Clientgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = Clientgv.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = Clientgv.SelectedRows[0].Cells[1].Value.ToString();
            mdp.Text = Clientgv.SelectedRows[0].Cells[2].Value.ToString();
            phone.Text = Clientgv.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "delete from Admin where admin_id = " + id.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Admin supprimé");
            Con.Close();
            populate();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = " UPDATE Admin set admin_name = '" + name.Text + "' , admin_password ='" + mdp.Text + "' , admin_tele='" + phone.Text + "' where admin_id ='" + id.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Client Modifié");


            Con.Close();
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string MyQuery = "select * from Admin where admin_name = '" + search.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(MyQuery, Con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            var ds = new DataSet();
            da.Fill(ds);
            Clientgv.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            mn.Show();
            this.Hide();
        }
    }
}
