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
    public partial class RoomForm : Form

    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ayous\Documents\hotel_bd.mdf;Integrated Security=True;Connect Timeout=30");

        public void populate()
        {
            Con.Open();
            string MyQuery = "select*from Room ";
            SqlDataAdapter da = new SqlDataAdapter(MyQuery, Con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            var ds = new DataSet();
            da.Fill(ds);
            Clientgv.DataSource = ds.Tables[0];
            Con.Close();
        }
        public RoomForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void phone_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaMediumRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            populate();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void AddBtn_Click(object sender, EventArgs e)

        {
            string state;
            if (yes.Checked == true)
                state = "free";
            else
                state = "busy";
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into Room values('" + id.Text + "','" + state + "','" + etat.Text + "')", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Room Added");


            Con.Close();
            populate();
        }

        private void Clientgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = Clientgv.SelectedRows[0].Cells[0].Value.ToString();
            etat.Text = Clientgv.SelectedRows[0].Cells[2].Value.ToString();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "delete from Room where room_id = " + id.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Room supprimé");
            Con.Close();
            populate();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            string state;
            if (yes.Checked == true)
                state = "free";
            else
                state = "busy";

            Con.Open();
            string query = " UPDATE Room set room_phone ='" + etat.Text + "' , room_etat='" + state + "' where room_id ='" + id.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Client Modifié");


            Con.Close();
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string MyQuery = "select * from Room where room_id = '" + search.Text + "' ";
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
