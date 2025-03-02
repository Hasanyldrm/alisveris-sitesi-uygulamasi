<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="urunekle.aspx.cs" Inherits="hepsiorada.com2.urunekle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2>Ürün Ekle</h2>

        <div>
            <div class="form-group">
                <label for="txtUrunAdi">Ürün Adı:</label>
                <asp:TextBox ID="txtUrunAdi" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtFiyat">Fiyat:</label>
                <asp:TextBox ID="txtFiyat" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtAciklama">Açıklama:</label>
                <asp:TextBox ID="txtAciklama" TextMode="MultiLine" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtStokAdedi">Stok Adedi:</label>
                <asp:TextBox ID="txtStokAdedi" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtBoyut">Ürünün Boyutu:</label>
                <asp:TextBox ID="txtBoyut" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtKg">Ağırlık (kg):</label>
                <asp:TextBox ID="txtKg" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtYil">Üretim Yılı:</label>
                <asp:TextBox ID="txtYil" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="upIMG">Ürün Resmi:</label>
                <asp:FileUpload ID="upIMG" runat="server" CssClass="form-control-file" />
            </div>

            <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
        </div>
    </div>


</asp:Content>
