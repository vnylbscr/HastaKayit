using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaTakipProgrami
{
    public partial class LoginHasta : Form
    {
        public LoginHasta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ABRA\Desktop\CS\3.sınıf\veritabanı yönetim sistemleri\veritabani\veritabaniOdev.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                string sql = null;

                sql = @"select dbo.func_HastaLogin(@username,@password)"; // fonksiyon login

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", hasta_txtBox.Text);
                cmd.Parameters.AddWithValue("@password", hastapassword_txtBox.Text);

                int result = (int)cmd.ExecuteScalar();

                if (result == 1)
                {
                    HastaEkrani he = new HastaEkrani();
                    he.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lütfen bilgileri tekrar kontrol ediniz!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error! Kod:{0}", ex.Message); ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void LoginHasta_Load(object sender, EventArgs e)
        {

        }
    }
}
