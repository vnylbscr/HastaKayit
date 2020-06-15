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
    public partial class LoginDoktor : Form
    {
        public LoginDoktor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ABRA\Desktop\CS\3.sınıf\veritabanı yönetim sistemleri\veritabani\veritabaniOdev.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();

                string sql=null;

                

                sql = @"select dbo.func_Login(@name,@pword)"; // fonksiyon login

                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@name", dkuserName_txt.Text);
                cmd.Parameters.AddWithValue("@pword", dkpass_txt.Text);

                int result = (int)cmd.ExecuteScalar(); 

                if (result==1) //giris basarili
                {
                    DoktorEkrani dk = new DoktorEkrani();
                    dk.Show();
                    this.Hide();
                }
                else //giris basarisiz
                {
                    MessageBox.Show("Lütfen bilgileri tekrar kontrol ediniz!");
                }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error! Kod:{0}",ex.Message);;
            }
            




        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
