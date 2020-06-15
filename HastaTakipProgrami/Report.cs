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
namespace HastaTakipProgrami
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ABRA\Desktop\CS\3.sınıf\veritabanı yönetim sistemleri\veritabani\veritabaniOdev.mdf;Integrated Security=True;Connect Timeout=30");

        private void Report_Load(object sender, EventArgs e)
        {
            txtTc.Visible = false;
            baglan.Open();


            SqlDataAdapter da = new SqlDataAdapter("Select *From Sikayetler", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand komutsil = new SqlCommand("Delete From Sikayetler where tc=@tc", baglan);
                komutsil.Parameters.AddWithValue("@tc", txtTc.Text);
                komutsil.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;

                string tc = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
               


                txtTc.Text = tc;
                
              
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GeriBildirim gb = new GeriBildirim();
            gb.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IlacSikayet Is = new IlacSikayet();
            Is.Show();
            this.Hide();
        }
    }
}
