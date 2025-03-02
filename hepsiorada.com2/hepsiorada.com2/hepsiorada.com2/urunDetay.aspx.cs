using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hepsiorada.com2
{
    public partial class urunDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // URL'den gelen ID parametresini al
                string urunId = Request.QueryString["Id"];
                if (!string.IsNullOrEmpty(urunId))
                {
                    // Veritabanından ürünü çek
                    string query = "SELECT * FROM Urunler WHERE ID = @Id";
                    string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", urunId);
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                lblUrunAdi.Text = reader["UrunAdi"].ToString();
                                lblFiyat.Text = "Fiyat:" + reader["Fiyat"].ToString() + " ₺";
                                lblAciklama.Text = reader["Aciklama"].ToString();
                                lblBoyut.Text = reader["UrunBoyut"].ToString();
                                lblKg.Text = reader["UrunKg"].ToString();
                                lblYıl.Text = reader["UretimYili"].ToString();
                                lblStok.Text = reader["StokAdedi"].ToString();
                                imgUrun.ImageUrl = reader["UrunResmi"].ToString();
                            }
                        }
                    }
                }
            }
        }
        protected void btnSepet_Click(object sender, EventArgs e)
        {
            string urunId = Request.QueryString["Id"];
            int adet = Convert.ToInt32(txtAdet.Text);
            int kullaniciId = Convert.ToInt32(Session["KullaniciID"]);

            string query = "INSERT INTO Sepet (UrunID, KullaniciID, Adet) VALUES (@UrunID, @KullaniciID, @Adet)";
            string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UrunID", urunId);
                    cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    cmd.Parameters.AddWithValue("@Adet", adet);
                    cmd.ExecuteNonQuery();
                }
            }
            lblmsg.Text = "Ürün sepete eklendi!";
        } 
    }
}