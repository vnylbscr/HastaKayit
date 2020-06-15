using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaTakipProgrami
{
    public partial class HastaEkrani : Form
    {
        public HastaEkrani()
        {
            InitializeComponent();
        }

        private void HastaEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IlacSikayet ilac = new IlacSikayet();
            ilac.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReceteListe Rl = new ReceteListe();
            Rl.Show();
            this.Hide();
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
            LoginHasta lg = new LoginHasta();
            lg.Show();
            this.Hide();

        }
    }
}
