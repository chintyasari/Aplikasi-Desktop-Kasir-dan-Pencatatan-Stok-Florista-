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

namespace ProjectPBOFlorista
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=florista;Username=postgres;Password=chintyadewi");
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd = new NpgsqlCommand("SELECT * from Login where username='" + usernameBox.Text + "' and passwords='" + passwordBox.Text + "'", connection);
                cmd.ExecuteNonQuery();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    beranda menuUtama = new beranda();
                    menuUtama.Show();
                }
                else
                {
                    MessageBox.Show("Login Anda gagal. Silakan coba lagi", "Peringatan");
                }
            }
                            
            //if (usernameBox.Text == "" || passwordBox.Text == "")
            //{
            //    MessageBox.Show("Username dan password tidak boleh kosong, silakan coba lagi", "Peringatan");
            //}
            //else
            //{
            //    if ((usernameBox.Text == "macakayu") && (passwordBox.Text == "123456"))
            //    {
            //        //MessageBox.Show("Login berhasil. Selamat datang di Florista!", "Florista");
            //        beranda menuUtama = new beranda();
            //        menuUtama.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Login Anda gagal. Silakan coba lagi", "Peringatan");
            //    }
            //}
            //this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passwordBox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordBox.UseSystemPasswordChar = true;
            }
        }
    }
}
