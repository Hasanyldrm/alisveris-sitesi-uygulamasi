<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="odeme.aspx.cs" Inherits="hepsiorada.com2.odeme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2 style="text-align: center">Satın Alma İşlemi</h2>

        <div>
            <div class="form-group col-6">
                <label for="txtUrunAdi">İsim Soyisim:</label>
                <asp:TextBox ID="txtisim" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group col-6">
                <label for="txtTel">Telefon No:</label>
                <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group col-6">
                <label for="txtEposta">Eposta Adresi:</label>
                <asp:TextBox ID="txtEposta" runat="server" CssClass="form-control" />
            </div>
            <br />
            <hr />
            <h2>Adres Bilgileri </h2>

            <div class="form-group col-6">
                <label for="txtil">İl:</label>
                <asp:TextBox ID="txtil" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group col-6">
                <label for="txtilçe">İlçe:</label>
                <asp:TextBox ID="txtilçe" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group col-6">
                <label for="txtAdres">Açık Adres</label>
                <asp:TextBox ID="txtAdres" TextMode="MultiLine" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group col-6">
                <label for="txtPosta">Posta Kodu</label>
                <asp:TextBox ID="txtPosta" runat="server" CssClass="form-control" />
            </div>
            <br />
            <hr />
            <h2>Ödeme Bilgileri </h2>

            <div class="form-group col-6">
                <label for="txtsahip">Kart Sahibinin Adı Soyadı</label>
                <asp:TextBox ID="txtsahip" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group col-6">
                <label for="txtkart">Kart Numarası</label>
                <asp:TextBox ID="txtkart" runat="server" CssClass="form-control" />
            </div>

            <div class="form-row">
                <div class="form-group col-md-2">
                    <label for="ddlMonth">Son Kullanma Tarihi</label>
                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control">
                        <asp:ListItem Value="01" Text="Ocak" />
                        <asp:ListItem Value="02" Text="Şubat" />
                        <asp:ListItem Value="03" Text="Mart" />
                        <asp:ListItem Value="04" Text="Nisan" />
                        <asp:ListItem Value="05" Text="Mayıs" />
                        <asp:ListItem Value="06" Text="Haziran" />
                        <asp:ListItem Value="07" Text="Temmuz" />
                        <asp:ListItem Value="08" Text="Ağustos" />
                        <asp:ListItem Value="09" Text="Eylül" />
                        <asp:ListItem Value="10" Text="Ekim" />
                        <asp:ListItem Value="11" Text="Kasım" />
                        <asp:ListItem Value="12" Text="Aralık" />
                    </asp:DropDownList>
                </div>

                <div class="form-group col-md-2">
                    <label for="ddlYear">Yıllık:</label>
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control">
                        <asp:ListItem Value="2023" Text="2023" />
                        <asp:ListItem Value="2024" Text="2024" />
                        <asp:ListItem Value="2025" Text="2025" />
                        <asp:ListItem Value="2026" Text="2026" />
                        <asp:ListItem Value="2027" Text="2027" />
                        <asp:ListItem Value="2028" Text="2028" />
                        <asp:ListItem Value="2029" Text="2029" />
                        <asp:ListItem Value="2030" Text="2030" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group col-1">
                <label for="txtCVV">Güvenlik Kodu</label>
                <asp:TextBox ID="txtCVV" runat="server" CssClass="form-control" />
            </div>
            <br />

            <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
            <h2>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></h2>
        </div>
    </div>


</asp:Content>
