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
    public partial class IlacSikayet : Form
    {
        public IlacSikayet()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ABRA\Desktop\CS\3.sınıf\veritabanı yönetim sistemleri\veritabani\veritabaniOdev.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            try //veriler ekleniyor
            {
                baglan.Open();
                SqlCommand kayitekle = new SqlCommand("insert into Sikayetler (tc,kul_ilac,ilac_bas_tarihi,ilac_bit_tarihi,sikayet) values (@tc,@kul_ilac,@ilac_bas_tarihi,@ilac_bit_tarihi,@sikayet)", baglan);
                kayitekle.Parameters.AddWithValue("@tc", txtTc.Text);
                kayitekle.Parameters.AddWithValue("@kul_ilac", cmbIlac.Text);
                kayitekle.Parameters.AddWithValue("@ilac_bas_tarihi", dateTimePicker1.Value.Date);
                kayitekle.Parameters.AddWithValue("@ilac_bit_tarihi", dateTimePicker2.Value.Date);
                kayitekle.Parameters.AddWithValue("@sikayet", txtReport.Text);

                kayitekle.ExecuteReader();
                baglan.Close();

            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
            MessageBox.Show("Şikayetiniz Doktorunuza İletilmiştir.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            rep.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //cikis
            if (sonuc == DialogResult.Yes)
            {
                Form.ActiveForm.Close();
                Application.Exit();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HastaEkrani hs = new HastaEkrani();
            hs.Show();
            this.Hide();
        }

        private void cmbIlac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
