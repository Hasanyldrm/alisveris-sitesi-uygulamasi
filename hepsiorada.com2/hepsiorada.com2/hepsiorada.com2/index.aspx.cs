using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hepsiorada.com2
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                urunGoruntule();
            }
        }
        protected void urunGoruntule()
        {
            string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Urunler";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool firstItem = true;
                string carouselItems = "";
                int itemCount = 0;
                string currentItemGroup = "";

                while (reader.Read())
                {
                    string resimYolu = reader["UrunResmi"].ToString();
                    string urunId = reader["ID"].ToString();
                    // Ürün kartı
                    currentItemGroup += $@"
                    <div class='col'>
                        <div class='card mx-auto' style='width: 18rem;'>
                            <img src='{resimYolu}' class='card-img-top' style='max-height:200px' alt='{reader["UrunAdi"]}'>
                            <div class='card-body'>
                                <h5 class='card-title'>{reader["UrunAdi"]}</h5>
                                <p class='card-text'>{reader["Aciklama"]}</p>
                                <p class='card-text'>Fiyat: {reader["Fiyat"]} TL</p>
                                <p class='card-text'>Stok: {reader["StokAdedi"]} adet</p>
                                <a href='urunDetay.aspx?id={urunId}' class='btn btn-primary'>Detayları Gör</a>
                            </div>
                        </div>
                    </div>";
                    itemCount++;

                    // Her 3 üründe bir yeni carousel-item oluştur
                    if (itemCount % 3 == 0 || !reader.HasRows)
                    {
                        string activeClass = firstItem ? "active" : "";
                        carouselItems += $@"
                    <div class='carousel-item {activeClass}'>
                        <div class='row'>
                            {currentItemGroup}
                        </div>
                    </div>";
                        currentItemGroup = "";
                        firstItem = false;
                    }
                }
                // Kalan ürünler varsa ekle
                if (!string.IsNullOrEmpty(currentItemGroup))
                {
                    string activeClass = firstItem ? "active" : "";
                    carouselItems += $@"
                <div class='carousel-item {activeClass}'>
                    <div class='row'>
                        {currentItemGroup}
                    </div>
                </div>";
                }
                ltCarouselItems.Text = carouselItems;
                conn.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("liste.aspx");
        }
    }
}
