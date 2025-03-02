using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hepsiorada.com2
{
    public partial class liste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts("FiyatArtan");
            }
        }
        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSort = ddlSort.SelectedValue;
            LoadProducts(selectedSort);
        }
        private void LoadProducts(string sortOption)
        {
            string query = "SELECT * FROM Urunler"; // Varsayılan sorgu
            switch (sortOption)
            {
                case "FiyatArtan":
                    query += " ORDER BY Fiyat ASC";
                    break;
                case "FiyatAzalan":
                    query += " ORDER BY Fiyat DESC";
                    break;
                case "AdanZ":
                    query += " ORDER BY UrunAdi ASC";
                    break;
                case "ZdenA":
                    query += " ORDER BY UrunAdi DESC";
                    break;
                case "Stok":
                    query += " ORDER BY StokAdedi DESC";
                    break;
            }
            string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                StringBuilder html = new StringBuilder();
                while (reader.Read())
                {
                    string urunId = reader["ID"].ToString();
                    html.Append($@"
                <div class='col-md-4 mb-4'>
                    <div class='card'>
                        <img src='{reader["UrunResmi"]}' class='card-img-top' style='height:400px' alt='{reader["UrunAdi"]}'>
                        <div class='card-body'>
                            <h5 class='card-title'>{reader["UrunAdi"]}</h5>
                            <p class='card-text'>{reader["Aciklama"]}</p>
                            <p class='card-text'>Fiyat: {reader["Fiyat"]} TL</p>
                            <p class='card-text'>Stok: {reader["StokAdedi"]}</p>
                            <a href='urunDetay.aspx?id={urunId}' class='btn btn-primary'>Ürünü İncele</a>
                        </div>
                    </div>
                </div> ");
                }
                product_list.Text = html.ToString();
            }
        }
    }
}