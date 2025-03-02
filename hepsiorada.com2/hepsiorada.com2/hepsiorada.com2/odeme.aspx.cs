using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hepsiorada.com2
{
    public partial class odeme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ay ve Yıl DropdownList'lerini doldurma işlemleri
                ddlMonth.DataSource = new List<ListItem>
        {
            new ListItem("Ocak", "01"),
            new ListItem("Şubat", "02"),
            new ListItem("Mart", "03"),
            new ListItem("Nisan", "04"),
            new ListItem("Mayıs", "05"),
            new ListItem("Haziran", "06"),
            new ListItem("Temmuz", "07"),
            new ListItem("Ağustos", "08"),
            new ListItem("Eylül", "09"),
            new ListItem("Ekim", "10"),
            new ListItem("Kasım", "11"),
            new ListItem("Aralık", "12"),
        };
                ddlMonth.DataBind();

                ddlYear.DataSource = new List<ListItem>
        {
            new ListItem("2023", "2023"),
            new ListItem("2024", "2024"),
            new ListItem("2025", "2025"),
            new ListItem("2026", "2026"),
            new ListItem("2027", "2027"),
            new ListItem("2028", "2028"),
            new ListItem("2029", "2029"),
            new ListItem("2030", "2030"),
        };
                ddlYear.DataBind();
            }
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string isimSoyisim = txtisim.Text;
            string telefon = txtTel.Text;
            string eposta = txtEposta.Text;
            string il = txtil.Text + "/" + txtilçe.Text;
            string adres = txtAdres.Text;
            string posta = txtPosta.Text;
            string Kartisim = txtsahip.Text;
            string kartno = txtkart.Text;
            string ay = ddlMonth.SelectedValue;
            string yıl = ddlYear.SelectedValue;
            string skt = ay + "/" + yıl;
            int kullaniciID = Convert.ToInt32(Session["KullaniciID"]);

            string connectionString = "Server=HY; Database=HO; Trusted_Connection=True;";

            string query = @"
    INSERT INTO siparisler (isim, telefon, eposta, il, adres, posta, kartisim, kartno, skt, kullaniciID, urunID, Adet)
    SELECT 
        @isim, 
        @telefon, 
        @eposta, 
        @il, 
        @adres, 
        @posta, 
        @kartisim, 
        @kartno, 
        @skt, 
        Sepet.KullaniciID, 
        Sepet.UrunID, 
        Sepet.Adet
    FROM Sepet
    WHERE Sepet.KullaniciID = @kullaniciID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Siparişleri ekle
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@isim", isimSoyisim);
                cmd.Parameters.AddWithValue("@telefon", telefon);
                cmd.Parameters.AddWithValue("@eposta", eposta);
                cmd.Parameters.AddWithValue("@il", il);
                cmd.Parameters.AddWithValue("@adres", adres);
                cmd.Parameters.AddWithValue("@posta", posta);
                cmd.Parameters.AddWithValue("@kartisim", Kartisim);
                cmd.Parameters.AddWithValue("@kartno", kartno);
                cmd.Parameters.AddWithValue("@skt", skt);
                cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                cmd.ExecuteNonQuery();

                lblmsg.Text = "Ödeme Başarılı! Siparişiniz Alınmıştır.";
                // Sepeti temizle
                string SepetTemizle = "DELETE FROM Sepet WHERE KullaniciID = @kullaniciID";
                SqlCommand deleteCmd = new SqlCommand(SepetTemizle, conn);
                deleteCmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                deleteCmd.ExecuteNonQuery();

                string StokGuncelle = @"
                    UPDATE Urunler 
                    SET StokAdedi = StokAdedi - S.Adet
                    FROM Urunler U
                    INNER JOIN siparisler S ON U.ID = S.UrunID
                    WHERE S.KullaniciID = @kullaniciID";

                SqlCommand updateStockCmd = new SqlCommand(StokGuncelle, conn);
                updateStockCmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                updateStockCmd.ExecuteNonQuery();
                txtisim.Text = "";
                txtTel.Text = "";
                txtEposta.Text = "";
                txtil.Text = "";
                txtilçe.Text = "";
                txtAdres.Text = "";
                txtPosta.Text = "";
                txtkart.Text = "";
            }
        }
    }
}