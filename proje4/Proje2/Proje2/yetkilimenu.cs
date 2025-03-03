﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje2
{
    public partial class yetkilimenu : Form
    {
        SqlCommand con3;
        Musterimenu musterimenu = new Musterimenu();

        public yetkilimenu()
        {
            InitializeComponent();

        }
        void UrunTakip()
        {
            SqlConnection baglanti3 = new SqlConnection("Data Source=JARVIS;Initial Catalog=SiparisOtomasyonu;Integrated Security=True");
            SqlCommand komut3 = new SqlCommand("select * from Tbl_Urunler", baglanti3);
            SqlDataAdapter adap3 = new SqlDataAdapter(komut3);
            DataTable table3 = new DataTable();
            adap3.Fill(table3);
            dataGridView2.DataSource = table3;
            dataGridView2.AutoResizeColumns();
        }
        void MusteriTakip()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=JARVIS;Initial Catalog=SiparisOtomasyonu;Integrated Security=True");
            SqlCommand komut = new SqlCommand("select * from SiparişKaydı ", baglanti);
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            DataTable table = new DataTable();
            adap.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoResizeColumns();
        }

        private void yetkilimenu_Load(object sender, EventArgs e)
        {
            MusteriTakip();
            UrunTakip();
        }
         SqlConnection baglanti2=new SqlConnection("Data Source=JARVIS;Initial Catalog=SiparisOtomasyonu;Integrated Security=True");
        
        private void ürüncıkarbutton_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection("Data Source=JARVIS;Initial Catalog=SiparisOtomasyonu;Integrated Security=True");
            string sil = "Delete From SiparişKaydı where id=@id";
            con3= new SqlCommand(sil,baglanti2);
            con3.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti2.Open();
            con3.ExecuteNonQuery();
            baglanti2.Close();
            MusteriTakip();


        }

       
        private  void güncellebutton_Click(object sender, EventArgs e)
        {

            
            
            string guncelle = "Update Tbl_Urunler SET  UrunFiyati=@UrunFiyati,UrunAgirligi=@UrunAgirligi,UrunAciklama=@UrunAciklama where  id=@id";
            con3 = new SqlCommand(guncelle, baglanti2);
            con3.Parameters.AddWithValue("@id", Convert.ToInt32(txtboxUrunId.Text));
            con3.Parameters.AddWithValue("@UrunFiyati", Convert.ToInt32(txtboxUrunF.Text));
            con3.Parameters.AddWithValue("@UrunAgirligi", Convert.ToInt32(txtboxUrunA.Text));
            con3.Parameters.AddWithValue("@UrunAciklama", txtboxUrunAciklama.Text);                    
            baglanti2.Open();
            con3.ExecuteNonQuery();
            baglanti2.Close();
            UrunTakip();

            SqlConnection baglantı4 = new SqlConnection("Data Source=JARVIS;Initial Catalog=SiparisOtomasyonu;Integrated Security=True");
            baglantı4.Open();
            SqlCommand komut4 = new SqlCommand("Select UrunAgirligi,UrunFiyati From Tbl_Urunler where id=1", baglantı4);
            SqlDataReader dr2 = komut4.ExecuteReader();
            while (dr2.Read())
            {
                musterimenu.lblSapkaAgirlik.Text = dr2[0].ToString();
                musterimenu.lblSapkaFiyat.Text = dr2[1].ToString();

            }
            baglantı4.Close();
            baglantı4.Open();
            SqlCommand komut5 = new SqlCommand("Select UrunAgirligi,UrunFiyati From Tbl_Urunler where id=2", baglantı4);
            SqlDataReader dr3 = komut5.ExecuteReader();
            while (dr3.Read())
            {
                musterimenu.lblAyakkabiAgirlik.Text = dr3[0].ToString();
                musterimenu.lblAyakkabiFiyat.Text = dr3[1].ToString();

            }
            baglantı4.Close(); baglantı4.Open();
            SqlCommand komut6 = new SqlCommand("Select UrunAgirligi,UrunFiyati From Tbl_Urunler where id=3", baglantı4);
            SqlDataReader dr4 = komut6.ExecuteReader();
            while (dr4.Read())
            {
                musterimenu.lblGomlekAgirlik.Text = dr4[0].ToString();
                musterimenu.lblGomlekFiyat.Text = dr4[1].ToString();

            }
            baglantı4.Close(); baglantı4.Open();
            SqlCommand komut7 = new SqlCommand("Select UrunAgirligi,UrunFiyati From Tbl_Urunler where id=4", baglantı4);
            SqlDataReader dr5 = komut7.ExecuteReader();
            while (dr5.Read())
            {
                musterimenu.lblPantolonAgirlik.Text = dr5[0].ToString();
                musterimenu.lblPantolonFiyat.Text = dr5[1].ToString();

            }
            baglantı4.Close(); baglantı4.Open();
            SqlCommand komut8 = new SqlCommand("Select UrunAgirligi,UrunFiyati From Tbl_Urunler where id=5", baglantı4);
            SqlDataReader dr6 = komut8.ExecuteReader();
            while (dr6.Read())
            {
                musterimenu.lblSaatAgirlik.Text = dr6[0].ToString();
                musterimenu.lblSaatFiyat.Text = dr6[1].ToString();

            }
            baglantı4.Close(); baglantı4.Open();
            SqlCommand komut9 = new SqlCommand("Select UrunAgirligi,UrunFiyati From Tbl_Urunler where id=6", baglantı4);
            SqlDataReader dr7 = komut9.ExecuteReader();
            while (dr7.Read())
            {
                musterimenu.lblGozlukAgirlik.Text = dr7[0].ToString();
                musterimenu.lblGozlukFiyat.Text = dr7[1].ToString();

            }
            baglantı4.Close();

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtboxUrunId.Text= dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtboxUrunF.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtboxUrunA.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtboxUrunAciklama.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            musterimenu.Show();
            
        }

        private void ürüneklebutton_Click(object sender, EventArgs e)
        {
            musterimenu.lblGozlukAgirlik.Visible = true;
            musterimenu.lblGozlukFiyat.Visible = true;
            musterimenu.gozlukbutton.Visible = true;
            MessageBox.Show("Gözlük eklendi");
        }
    }
}
