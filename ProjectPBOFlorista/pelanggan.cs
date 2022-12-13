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
    public partial class pelanggan : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        NpgsqlCommand cmd = new NpgsqlCommand();
        DataSet ds = new DataSet();
        NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        public NpgsqlDataReader rd;
        void kondisiAwal()
        {            
            textBox1.Text = "";
            textBox2.Text = "";
            dataPelanggan();
        }
        public pelanggan()
        {
            InitializeComponent();
        }
        void dataPelanggan()
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
            connection.Open();
            cmd = new NpgsqlCommand("SELECT * FROM Pelanggan", connection);
            ds = new DataSet();
            da = new NpgsqlDataAdapter(cmd);
            da.Fill(ds, "Pelanggan");
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = "Pelanggan";
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.Refresh();
        }        

        private void pelanggan_Load(object sender, EventArgs e)
        {
            kondisiAwal();            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Data tidak boleh kosong!");
            }
            else
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                cmd = new NpgsqlCommand("INSERT INTO Pelanggan (nama_Pelanggan,no_Telepon) values('" + textBox1.Text + "', '" + textBox2.Text + "')", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!");
                kondisiAwal();               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Data tidak boleh kosong!");
            }
            else
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
                cmd = new NpgsqlCommand("INSERT INTO Pelanggan (nama_Pelanggan,no_Telepon) values('" + textBox1.Text + "', '" + textBox2.Text + "')", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!");
                kondisiAwal();                
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin hapus data barang?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=floristaPalsu;Username=postgres;Password=chintyadewi");
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE from Pelanggan WHERE nama_Pelanggan = '" + textBox1.Text + "'", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                dataGridView3.Rows.RemoveAt(dataGridView3.SelectedCells[0].RowIndex);
                MessageBox.Show("Hapus data berhasil");
            }
        }
    }
}
