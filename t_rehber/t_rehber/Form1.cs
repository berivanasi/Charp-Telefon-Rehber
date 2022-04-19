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

namespace t_rehber
{
    public partial class Form1 : Form

    {
         
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        void rehber()
        {
            con= new SqlConnection ("server=DESKTOP-VJBC22E;Initial Catalog=dbrehber;Integrated Security =True");
            da = new SqlDataAdapter("Select * from telefon_rehberi ",con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds,"telefon_rehberi");
            dtg_rehber.DataSource = ds.Tables["telefon_rehberi"];
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rehber();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into telefon_rehberi (isim,soyad,numara) values ('" + txt_isim.Text + "','" + txt_soyad.Text + "','" + txt_numara.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            rehber();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from telefon_rehberi where isim ='" + txt_isim.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            rehber();
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update telefon_rehberi  set isim='" + txt_isim.Text + "', soyad='" + txt_soyad.Text + "', numara='" + txt_numara.Text + "' where id='" + txt_id.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            rehber();
        }
    }
}
