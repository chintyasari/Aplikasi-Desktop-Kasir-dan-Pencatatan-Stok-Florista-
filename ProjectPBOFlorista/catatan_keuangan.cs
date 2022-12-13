using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectPBOFlorista
{
    public partial class catatan_keuangan : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        NpgsqlCommand cmd = new NpgsqlCommand();
        DataSet ds = new DataSet();
        NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        public NpgsqlDataReader rd;
        void kondisiAwal()
        {
            dateTimePicker1.Text = "";
            domainUpDown1.Text = "";
            textBox5.Text = null;
            textBox3.Text = "";
            dataKeuangan();
        }
        void dataKeuangan()
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
            connection.Open();
            cmd = new NpgsqlCommand("SELECT * FROM PencatatanKeuangan", connection);
            ds = new DataSet();
            da = new NpgsqlDataAdapter(cmd);
            da.Fill(ds, "PencatatanKeuangan");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "PencatatanKeuangan";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }

        private void catatan_keuangan_Load(object sender, EventArgs e)
        {

            kondisiAwal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text.Trim() == "" || domainUpDown1.Text.Trim() == "" || textBox5.Text.Trim() == null || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Data tidak boleh kosong!");
            }
            else
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                cmd = new NpgsqlCommand("INSERT INTO PencatatanKeuangan (tanggal_Catat,jenisKas,jumlah,keterangan) values('" + dateTimePicker1.Text + "','" + domainUpDown1.Text + "', '" + textBox5.Text + "', '" + textBox3.Text + "')", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!");
                kondisiAwal();
            }
        }
        public catatan_keuangan()
        {
            InitializeComponent();
        }

        private void kasirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beranda menuBeranda = new beranda();
            menuBeranda.Show();
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

        private void akunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login halamanLogin = new login();
            halamanLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kondisiAwal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin hapus data barang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE from PencatatanKeuangan WHERE keterangan = '" + textBox3.Text + "'", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                MessageBox.Show("Hapus data berhasil");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                dateTimePicker1.Text = row.Cells["tanggal_Catat"].Value.ToString();
                domainUpDown1.Text = row.Cells["jenisKas"].Value.ToString();
                textBox5.Text = row.Cells["jumlah"].Value.ToString();
                textBox3.Text = row.Cells["keterangan"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value == DateTime.Now || domainUpDown1.Text.Trim() == "" || textBox5.Text.Trim() == null || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Data tidak boleh kosong!");
            }
            else
            {                
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                connection.Open();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("UPDATE PencatatanKeuangan SET tanggal_Catat='" + dateTimePicker1.Value + "',jenisKas='" + domainUpDown1.Text + "',jumlah='" + textBox5.Text + "',keterangan='" + textBox3.Text + "'WHERE keterangan='" + textBox3.Text + "'", connection);
                    //connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update data berhasil");
                    dataKeuangan();
                    kondisiAwal();
                    dataGridView1.Refresh();
                    dataGridView1.Update();                    
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }
        }
    }
}
