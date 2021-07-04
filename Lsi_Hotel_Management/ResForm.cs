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
    public partial class ResForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ayous\Documents\hotel_bd.mdf;Integrated Security=True;Connect Timeout=30");

        public void populate()
        {
            Con.Open();
         
            string MyQuery = "select*from Reservation ";
            SqlDataAdapter da = new SqlDataAdapter(MyQuery, Con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            var ds = new DataSet();
            da.Fill(ds);
            Clientgv.DataSource = ds.Tables[0];
            Con.Close();
        }

       public void fillroom()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select room_id from Room", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable ft = new DataTable();
            ft.Columns.Add("room_id", typeof(int));
            ft.Load(rdr);
            num.ValueMember = "room_id";
            num.DataSource = ft;



          
            
            Con.Close();

        }

        public void fillc()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select client_name from Client", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable ft = new DataTable();
            ft.Columns.Add("client_name", typeof(string));
            ft.Load(rdr);
            name.ValueMember = "client_name";
            name.DataSource = ft;
            Con.Close();
        }


        public ResForm()
        {
            InitializeComponent();
        }
        DateTime todayy;

        private void etat_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int res = DateTime.Compare(dateout.Value, datein.Value);
            if (res < 0)
                MessageBox.Show("Date sortie incorrect");
        }

        private void Clientgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = Clientgv.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = Clientgv.SelectedRows[0].Cells[1].Value.ToString();
            num.Text = Clientgv.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = " UPDATE Reservation set client ='" + name.SelectedValue.ToString() + "' , room='" + num.SelectedValue.ToString() + "'  , date_in='" + datein.Value + "'  , date_out='" + dateout.Value + "' where reservation_id ='" + id.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Client Modifié");


            Con.Close();
            populate();
        }

        private void ResForm_Load(object sender, EventArgs e)
        {
            todayy = datein.Value;
            fillroom();
            fillc();
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            populate();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        public void updatestate()
        {
            string newstate = "busy";

            Con.Open();
            string query = " UPDATE Room set room_etat ='" + newstate + "'  where room_id ='" + Convert.ToInt32( num.SelectedValue.ToString()) + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
         //   MessageBox.Show("Client Modifié");


            Con.Close();
            fillroom();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into Reservation values('" + id.Text + "','" + name.SelectedValue.ToString() + "','" + num.SelectedValue.ToString() + "','" + datein.Value + "','" + dateout.Value + "')", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Room Added");


            Con.Close();
            updatestate();
            populate();
            
        }

        private void datein_ValueChanged(object sender, EventArgs e)
        {
            int res = DateTime.Compare(datein.Value, todayy);
            if (res < 0)
                MessageBox.Show("Date entrée incorrect");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "delete from Reservation where reservation_id = " + id.Text + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Res supprimé");
            Con.Close();
            populate();
        }

        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string MyQuery = "select * from Reservation where reservation_id = '" + search.Text + "' ";
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
