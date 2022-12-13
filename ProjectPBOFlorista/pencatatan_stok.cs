using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectPBOFlorista
{
    public partial class pencatatan_stok : Form
    {
        public pencatatan_stok()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection();
        NpgsqlCommand cmd = new NpgsqlCommand();
        DataSet ds = new DataSet();
        NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        public NpgsqlDataReader rd;

        void kondisiAwal()
        {
            domainUpDown1.Text = "";
            textBox3.Text = "";
            textBox7.Text = null;
            textBox2.Text = "";
            textBox4.Text = null;
            domainUpDown2.Text = "";
            dataBarang();
        }

        void dataBarang()
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
            connection.Open();
            cmd = new NpgsqlCommand("SELECT * FROM StokBarang", connection);
            ds = new DataSet();
            da = new NpgsqlDataAdapter(cmd);
            da.Fill(ds, "StokBarang");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "StokBarang";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox7.Text.Trim() == null || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == null || domainUpDown2.Text.Trim() == "")
            {
                MessageBox.Show("Data tidak boleh kosong!");
            }
            else
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                cmd = new NpgsqlCommand("INSERT INTO StokBarang (jenisBarang,nama_Barang,harga,warna,jumlah_Barang,satuan) values('" + domainUpDown1.Text + "','" + textBox3.Text + "', '" + textBox7.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + domainUpDown2.Text + "')", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!");
                kondisiAwal();
            }
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
        private void pencatatan_stok_Load(object sender, EventArgs e)
        {
            kondisiAwal();
        }

        private void button3_Click(object sender, EventArgs e) //buttonHapusStok
        {
            if (MessageBox.Show("Yakin ingin hapus data barang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE from StokBarang WHERE nama_Barang = '" + textBox3.Text + "'", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[1].RowIndex);
                MessageBox.Show("Hapus data berhasil");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                domainUpDown1.Text = row.Cells["jenisBarang"].Value.ToString();
                textBox3.Text = row.Cells["nama_Barang"].Value.ToString();
                textBox7.Text = row.Cells["harga"].Value.ToString();
                textBox2.Text = row.Cells["warna"].Value.ToString();
                textBox4.Text = row.Cells["jumlah_Barang"].Value.ToString();
                domainUpDown2.Text = row.Cells["satuan"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox7.Text.Trim() == null || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == null || domainUpDown2.Text.Trim() == "")
            {
                MessageBox.Show("Data tidak boleh kosong!");
            }
            else
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                connection.Open();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("UPDATE StokBarang SET jenisBarang='" + domainUpDown1.Text + "',nama_Barang='" + textBox3.Text + "',harga='" + textBox7.Text + "',warna='" + textBox2.Text + "',jumlah_Barang='" + textBox4.Text + "',satuan='" + domainUpDown2.Text + "'WHERE nama_Barang='" + textBox3.Text + "'", connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update data berhasil");
                    dataBarang();
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

        private void button1_Click(object sender, EventArgs e)
        {
            kondisiAwal();
        }

        void cariBarang()
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
            connection.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM StokBarang WHERE nama_Barang ilike '%" + textBox6.Text + "%'", connection);
                DataSet ds = new DataSet();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(ds, "StokBarang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "StokBarang";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
            finally
            {
                connection.Close();
            }

        }
        
    }
}
    
