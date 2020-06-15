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
    public partial class HastaSikayetEkran : Form
    {
        public HastaSikayetEkran()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ABRA\Desktop\CS\3.sınıf\veritabanı yönetim sistemleri\veritabani\veritabaniOdev.mdf;Integrated Security=True;Connect Timeout=30");

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtRandevu.Visible = true;

        }

        private void HastaSikayetEkran_Load(object sender, EventArgs e)
        {

            baglan.Open();
           
            txtTc.Enabled= false;
            txtRandevu.Visible = false;
           


            SqlDataAdapter da = new SqlDataAdapter("Select *From Sikayetler", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand kayitekle = new SqlCommand("insert into DoktorInfo (tc,tarih,randevu_tarih,aciklama) values (@tc,@tarih,@randevu_tarih,@aciklama)", baglan);
                kayitekle.Parameters.AddWithValue("@tc", txtTc.Text);
                kayitekle.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.Date);
                kayitekle.Parameters.AddWithValue("@randevu_tarih", txtRandevu.Text);                           
                kayitekle.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                kayitekle.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
            MessageBox.Show("Onaylandı.");
        }
    }
}
