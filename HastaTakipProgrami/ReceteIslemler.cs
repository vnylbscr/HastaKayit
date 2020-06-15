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
// kubilay kaynan 
//mert genç
namespace HastaTakipProgrami
{
    public partial class ReceteIslemler : Form
    { 
        public ReceteIslemler()
        {
            InitializeComponent();
        }

        private void ReceteIslemler_Load(object sender, EventArgs e)
        {
            txtTc.Enabled = false;
            txtAd.Enabled = false;
            txtSoyad.Enabled = false;
           

            baglan.Open();


            SqlDataAdapter da = new SqlDataAdapter("Select *From Hasta", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ABRA\Desktop\CS\3.sınıf\veritabanı yönetim sistemleri\veritabani\veritabaniOdev.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTc.Text==" ")
            {
                MessageBox.Show("Hasta Bilgileri Belirlenmemiş !");
            }
            try
            {
                baglan.Open();
                SqlCommand kayitekle = new SqlCommand("insert into HastaRecete (tc,ad,soyad,ilac_isim) values (@tc,@ad,@soyad,@ilac_isim)", baglan);
                kayitekle.Parameters.AddWithValue("@tc", txtTc.Text);
                kayitekle.Parameters.AddWithValue("@ad", txtAd.Text);
                kayitekle.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                kayitekle.Parameters.AddWithValue("@ilac_isim", cmbIlac.Text);
                
                kayitekle.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
            MessageBox.Show("Reçete Hastaya Yollanmıştır.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReceteListe Rl = new ReceteListe();
            Rl.Show();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;

                string tc = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                string ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                string soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
               
                
                txtTc.Text = tc;
                txtAd.Text = ad;
                txtSoyad.Text = soyad;
                
               
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }
    }
}
