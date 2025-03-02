using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hepsiorada.com2
{
    public partial class urunekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string urunAdi = txtUrunAdi.Text;
            decimal fiyat = decimal.Parse(txtFiyat.Text);
            string aciklama = txtAciklama.Text;
            int stokAdedi = int.Parse(txtStokAdedi.Text);
            string boyut = txtBoyut.Text;
            string Kg = txtKg.Text;
            string yil = txtYil.Text;
            string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";
            if (upIMG.HasFile)
            {
                string fileName = Path.GetFileName(upIMG.PostedFile.FileName);
                string filePath = "/pictures/" + fileName;
                upIMG.SaveAs(Server.MapPath(filePath));
                // Resim yolunu veritabanına kaydet
                string query = "INSERT INTO Urunler (UrunAdi, Fiyat, Aciklama, StokAdedi, UrunBoyut, UrunKg, UretimYili, UrunResmi) VALUES (@UrunAdi, @Fiyat, @Aciklama, @StokAdedi, @UrunBoyut, @UrunKg, @UretimYili, @UrunResmi)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UrunAdi", txtUrunAdi.Text);
                    cmd.Parameters.AddWithValue("@Fiyat", txtFiyat.Text);
                    cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                    cmd.Parameters.AddWithValue("@StokAdedi", txtStokAdedi.Text);
                    cmd.Parameters.AddWithValue("@UrunBoyut", txtBoyut.Text);
                    cmd.Parameters.AddWithValue("@UrunKg", txtKg.Text);
                    cmd.Parameters.AddWithValue("@UretimYili", txtYil.Text);
                    cmd.Parameters.AddWithValue("@UrunResmi", filePath);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    txtUrunAdi.Text = "";
                    txtFiyat.Text = "";
                    txtAciklama.Text = "";
                    txtStokAdedi.Text = "";
                    txtBoyut.Text = "";
                    txtKg.Text = "";
                    txtYil.Text = "";
                }
            }
        }
    }
}