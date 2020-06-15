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
    public partial class ReceteListe : Form
    {
        public ReceteListe()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ABRA\Desktop\CS\3.sınıf\veritabanı yönetim sistemleri\veritabani\veritabaniOdev.mdf;Integrated Security=True;Connect Timeout=30");

        private void ReceteListe_Load(object sender, EventArgs e)
        {
            txtTc.Visible = false;
            baglan.Open();


            SqlDataAdapter da = new SqlDataAdapter("Select *From HastaRecete", baglan);
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
                SqlCommand komutsil = new SqlCommand("Delete From HastaRecete where tc=@tc", baglan);
                komutsil.Parameters.AddWithValue("@tc", txtTc.Text);
                komutsil.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();


            SqlDataAdapter da = new SqlDataAdapter("Select *From HastaRecete", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.Yes)
            {
                Form.ActiveForm.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HastaEkrani hs = new HastaEkrani();
            hs.Show();
            this.Hide();
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
