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
    public partial class data_barang : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        NpgsqlCommand cmd = new NpgsqlCommand();
        DataSet ds = new DataSet();
        NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        public NpgsqlDataReader rd;
        
        public data_barang()
        {
            InitializeComponent();
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
        private void data_barang_Load(object sender, EventArgs e)
        {
            dataBarang();
        }
    }
}
