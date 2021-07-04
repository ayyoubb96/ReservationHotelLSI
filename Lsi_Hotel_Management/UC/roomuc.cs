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

namespace Lsi_Hotel_Management.UC
{
    public partial class roomuc : UserControl


    {
        public int Num { get; set; }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ayous\Documents\hotel_bd.mdf;Integrated Security=True;Connect Timeout=30");


       
        public roomuc()
        {
            InitializeComponent();
        }

        private void lbnum_Click(object sender, EventArgs e)
        {

        }
        /*public ListRoom lstRoom()
        {

        }*/
        private void roomuc_Load(object sender, EventArgs e)
        {
            lbnum.Text = Num.ToString();
        }
    }
}
