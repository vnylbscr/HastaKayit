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
    public partial class DoktorEkrani : Form
    {
        public DoktorEkrani()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ABRA\Desktop\CS\3.sınıf\veritabanı yönetim sistemleri\veritabani\veritabaniOdev.mdf;Integrated Security=True;Connect Timeout=30");


        private void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();


                SqlDataAdapter da = new SqlDataAdapter("Select *From Hasta", baglan);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                baglan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
           
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                //hasta ekleniyor
                baglan.Open();
                SqlCommand kayitekle = new SqlCommand("insert into Hasta (tc,ad,soyad,adres,tel,yaş,cinsiyet,dogumyeri,medenihali,tip) values (@tc,@ad,@soyad,@adres,@tel,@yaş,@cinsiyet,@dogumyeri,@medenihali,@tip)", baglan);
                kayitekle.Parameters.AddWithValue("@tc", txtTc.Text);
                kayitekle.Parameters.AddWithValue("@ad", txtAd.Text);
                kayitekle.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                kayitekle.Parameters.AddWithValue("@adres", txtAdres.Text);
                kayitekle.Parameters.AddWithValue("@tel", txtTel.Text);
                kayitekle.Parameters.AddWithValue("@yaş", txtYas.Text);
                kayitekle.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.Text);
                kayitekle.Parameters.AddWithValue("@dogumyeri", txtDogumYer.Text);
                kayitekle.Parameters.AddWithValue("@medenihali", cmbMedeniHal.Text);
                kayitekle.Parameters.AddWithValue("@tip", cmbHastaTipi.Text.ToString());
                kayitekle.ExecuteNonQuery();
                baglan.Close();

                
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Aynı tc'ye sahip hasta mevcut!");
                }

                MessageBox.Show(ex.Message);

               

            }
            MessageBox.Show("Bilgiler Kaydedildi.");
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand komutsil = new SqlCommand("Delete From Hasta where tc=@tc", baglan);
                komutsil.Parameters.AddWithValue("@tc", txtTc.Text);
                komutsil.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

                MessageBox.Show("Hasta bilgileri silinemedi");

            }
            
            

            this.Refresh();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;

                string tc = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                string ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                string soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                string adres = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                string tel = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                string yas = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                string cinsiyet = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
                string dogumyeri = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
                string medenihali = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
                string tip = dataGridView1.Rows[secilen].Cells[9].Value.ToString();

                txtTc.Text = tc;
                txtAd.Text = ad;
                txtSoyad.Text = soyad;
                txtAdres.Text = adres;
                txtTel.Text = tel;
                txtYas.Text = yas;
                cmbCinsiyet.Text = cinsiyet;
                txtDogumYer.Text = dogumyeri;
                cmbMedeniHal.Text = medenihali;
                cmbHastaTipi.Text = tip;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand komutguncelle = new SqlCommand("update Hasta set tc=@tc,ad=@ad,soyad=@soyad,adres=@adres,tel=@tel,yaş=@yaş,cinsiyet=@cinsiyet,dogumyeri=@dogumyeri,medenihali=@medenihali,tip=@tip where tc=@tc", baglan);
                komutguncelle.Parameters.AddWithValue("@tc", txtTc.Text);
                komutguncelle.Parameters.AddWithValue("@ad", txtAd.Text);
                komutguncelle.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                komutguncelle.Parameters.AddWithValue("@adres", txtAdres.Text);
                komutguncelle.Parameters.AddWithValue("@tel", txtTel.Text);
                komutguncelle.Parameters.AddWithValue("@yaş", txtYas.Text);
                komutguncelle.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.Text);
                komutguncelle.Parameters.AddWithValue("@dogumyeri", txtDogumYer.Text);
                komutguncelle.Parameters.AddWithValue("@medenihali", cmbMedeniHal.Text);
                komutguncelle.Parameters.AddWithValue("@tip", cmbHastaTipi.Text);
                komutguncelle.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            MessageBox.Show("Hasta Bilgileri Güncellenmiştir... Lütfen Listeyi Yenileyiniz!");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReceteIslemler ri = new ReceteIslemler();
            ri.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HastaSikayetEkran hse = new HastaSikayetEkran();
            hse.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginDoktor lg = new LoginDoktor();
            lg.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.Yes)
            {
                Form.ActiveForm.Close();
                Application.Exit();
            }
        }

        private void cmbMedeniHal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DoktorEkrani_Load(object sender, EventArgs e)
        {

        }
    }
}
