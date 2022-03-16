using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
         
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtDersAd.Text);
            MessageBox.Show("Ders ekleme işlemi yapılmıştır.");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(TxtDersid.Text));
            MessageBox.Show("Ders Silinmiştir.");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtDersAd.Text, byte.Parse(TxtDersid.Text));
            MessageBox.Show("Ders Güncellenmiştir.");
        }
    }
}
