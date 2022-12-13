using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectPBOFlorista
{
    public partial class kasir : Form
    {
        public kasir()
        {
            InitializeComponent();
        }

        private void kasirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beranda menuBeranda = new beranda();
            menuBeranda.Show();
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
        private void button7_Click(object sender, EventArgs e) //buttonCariPelanggan
        {
            pelanggan halamanPelanggan = new pelanggan();
            halamanPelanggan.Show();
        }

        private void button8_Click(object sender, EventArgs e) //buttonCariBarang
        {
            data_barang halamanBarang = new data_barang();
            halamanBarang.Show();
        }
        void kondisiAwal()
        {            
            dateTimePicker1.Value = DateTime.Now;
            textBox4.Text = null;
            textBox2.Text = null;
            textBox1.Text = null;                     
            dataTransaksi();
        }
        void dataTransaksi()
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
            connection.Open();
            cmd = new NpgsqlCommand("SELECT * FROM Transaksi", connection);
            ds = new DataSet();
            da = new NpgsqlDataAdapter(cmd);
            da.Fill(ds, "Transaksi");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Transaksi";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }

        NpgsqlCommand cmd = new NpgsqlCommand();
        DataSet ds = new DataSet();
        NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        public NpgsqlDataReader rd;
        
        void kondisiBayar()
        {
            textBox7.Text = null;
        }

        private void kasir_Load(object sender, EventArgs e)
        {
            kondisiAwal();
            kondisiBayar();
        }
                          
        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value == DateTime.Now || textBox4.Text.Trim() == null || textBox2.Text.Trim() == null || textBox1.Text.Trim() == null)
            {
                MessageBox.Show("Data tidak boleh kosong!");
            }
            else
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                cmd = new NpgsqlCommand("INSERT INTO Transaksi (tanggal,jumlah_Beli,id_StokBarang,id_Pelanggan) values('" + dateTimePicker1.Value + "', '" + textBox1.Text + "', '" + textBox4.Text + "', '" + textBox2.Text + "')", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!");
                kondisiAwal();                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin hapus data barang :?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE from Transaksi WHERE tanggal = '" + dateTimePicker1.Value + "'", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                MessageBox.Show("Hapus data berhasil");
            }
        }
    }
}
