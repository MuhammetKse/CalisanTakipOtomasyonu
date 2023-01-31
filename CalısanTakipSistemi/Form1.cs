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

namespace CalısanTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B6GKBCE\\SQLEXPRESS;Initial Catalog=CalisanTakip;Integrated Security=True");
        void temizle()
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            txtıd.Text = "";
            mskmaas.Text = "";
            mskyas.Text = "";
            txtad.Focus();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'calisanTakipDataSet.Üyeler' table. You can move, or remove it, as needed.
            this.üyelerTableAdapter.Fill(this.calisanTakipDataSet.Üyeler);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.üyelerTableAdapter.Fill(this.calisanTakipDataSet.Üyeler);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Üyeler (ad,soyad,yas,maaş) values (@p1,@p2,@p3,@p4)",baglanti );
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskyas.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklenmiştir");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçim = dataGridView1.SelectedCells[0].RowIndex;
            txtıd.Text = dataGridView1.Rows[seçim].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[seçim].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[seçim].Cells[2].Value.ToString();
            mskyas.Text = dataGridView1.Rows[seçim].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[seçim].Cells[4].Value.ToString();
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil =new SqlCommand("Delete From Üyeler where id=@p1",baglanti);
            sil.Parameters.AddWithValue("@p1", txtıd.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Silinmiştir.");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand güncelle = new SqlCommand("Update Üyeler set ad=@p1,soyad=@p2,yas=@p3,maaş=@p4 where id=@p5", baglanti);
            güncelle.Parameters.AddWithValue("p1",txtad.Text);
            güncelle.Parameters.AddWithValue("p2", txtsoyad.Text);
            güncelle.Parameters.AddWithValue("p3", mskyas.Text);
            güncelle.Parameters.AddWithValue("p4", mskmaas.Text);
            güncelle.Parameters.AddWithValue("p5", txtıd.Text);
            güncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellemesi tamamlandı!");
       
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
