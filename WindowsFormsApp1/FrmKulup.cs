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
namespace WindowsFormsApp1
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-273NEV0;Initial Catalog=OBS;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLKULUPLER (KULUPAD) VALUES (@P1)", baglanti);
                komut.Parameters.AddWithValue("@P1", TxtKulupAd.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kulup Listeye Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                liste();
            }
            catch (Exception)
            {

                MessageBox.Show("HATALI VERİ GİRİŞİ");
            }
   
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightYellow;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from TBLKULUPLER WHERE KULUPID = @P1",baglanti);
            komut.Parameters.AddWithValue("@P1",TxtKulupid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Silme İşlemi Gerçekleşti");
            liste();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE  TBLKULUPLER SET KULUPAD=@P1 WHERE KULUPID = @P2",baglanti);
            komut.Parameters.AddWithValue("@P1",TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKulupid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi Gerçekleşti");
            liste();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtKulupid_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtKulupAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
