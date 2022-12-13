using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPBOFlorista
{
    public partial class beranda : Form
    {
       
        public beranda()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            pencatatan_stok pencatatanStok = new pencatatan_stok();
            pencatatanStok.Show();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kasir lamanKasir = new kasir();
            lamanKasir.Show();
        }

        private void tombolPKeuangan_Click(object sender, EventArgs e)
        {
            catatan_keuangan keuangan = new catatan_keuangan();
            keuangan.Show();
        }

        private void pencatatanStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kasir lamanKasir = new kasir();
            lamanKasir.Show();
        }

        private void pencatatanKeuanganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pencatatan_stok pencatatanStok = new pencatatan_stok();
            pencatatanStok.Show();
        }

        private void pencatatanKeuanganToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            catatan_keuangan keuangan = new catatan_keuangan();
            keuangan.Show();
        }

        private void akunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login halamanLogin = new login();
            halamanLogin.Show();
        }
    }
}
