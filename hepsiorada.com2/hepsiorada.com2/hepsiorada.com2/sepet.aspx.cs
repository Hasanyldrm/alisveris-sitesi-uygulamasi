using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static hepsiorada.com2.index;

namespace hepsiorada.com2
{
    public partial class sepet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSepet();
            }
            int kullaniciId = Convert.ToInt32(Session["KullaniciID"]);
            string query = "SELECT Urunler.UrunAdi, Urunler.Fiyat, Sepet.SepetID, Sepet.Adet FROM Sepet INNER JOIN Urunler ON Sepet.UrunID = Urunler.ID WHERE Sepet.KullaniciID = @KullaniciID";
            string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    gvSepet.DataSource = reader;
                    gvSepet.DataBind();
                }
            }
        }
        protected void btnSil_Click(object sender, EventArgs e)
        {
            int sepetId;
            if (int.TryParse(txtSepetID.Text, out sepetId))
            {
                string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
                string query = "DELETE FROM Sepet WHERE SepetID = @SepetID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SepetID", sepetId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                // Sepet tablosunu yeniden bağla
                BindSepet();
                lblMessage.Text = "Ürün Silindi !";
            }
            else
            {
                lblMessage.Text = "Geçersiz SepetID.";
            }
        }
        private void BindSepet()
        {
            string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
            string query = "SELECT S.SepetID, U.UrunAdi, U.Fiyat, S.Adet FROM Sepet S INNER JOIN Urunler U ON S.UrunID = U.ID";
            string toplam = "SELECT SUM(U.Fiyat * S.Adet) AS ToplamFiyat FROM Sepet S INNER JOIN Urunler U ON S.UrunID = U.ID WHERE S.KullaniciID = @KullaniciID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    gvSepet.DataSource = reader;
                    gvSepet.DataBind();

                    if (!reader.HasRows)
                    {
                        lblMessage.Text = "Sepetiniz boş.";
                        return;
                    }
                    reader.Close();
                }
                using (SqlCommand totalCmd = new SqlCommand(toplam, conn))
                {
                    totalCmd.Parameters.AddWithValue("@KullaniciID", Convert.ToInt32(Session["KullaniciID"]));
                    object result = totalCmd.ExecuteScalar();
                    lblTotalPrice.Text = "Toplam Fiyat: " + (result != DBNull.Value ? Convert.ToDecimal(result).ToString("C") : "0,00 ₺");
                }
            }
        }
        protected void btnSatın_Click(object sender, EventArgs e)
        {
            int kullaniciId = Convert.ToInt32(Session["KullaniciID"]);
            bool sepetBosDegil = IsSepetBosDegil(kullaniciId);

            if (sepetBosDegil)
            {
                // Ödeme sayfasına yönlendirme işlemi
                Response.Redirect("odeme.aspx");
            }
            else
            {
                lblMessage.Text = "Sepetiniz boş. Lütfen ürün ekleyin.";
            }
        }
        private bool IsSepetBosDegil(int kullaniciId)
        {
            string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
            string query = "SELECT COUNT(*) FROM Sepet WHERE KullaniciID = @KullaniciID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}