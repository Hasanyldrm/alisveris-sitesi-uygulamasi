<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="urunDetay.aspx.cs" Inherits="hepsiorada.com2.urunDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="product-detail">
            <asp:Image ID="imgUrun" runat="server" CssClass="foto" AlternateText="Ürün Resmi" />
            <br />
            <hr />

            <h1>
                <asp:Label ID="lblUrunAdi" runat="server"></asp:Label></h1>
            <br />

            <h3>
                <asp:Label ID="lblAciklama" runat="server"></asp:Label></h3>
            <br />

            <h4>•Boyut Ebatları :
                <asp:Label ID="lblBoyut" runat="server"></asp:Label></h4>
            <h4>•Robotun Kilosu :
                <asp:Label ID="lblKg" runat="server"></asp:Label></h4>
            <h4>•Üretim Yılı :
                <asp:Label ID="lblYıl" runat="server"></asp:Label></h4>
            <h4>•Stok Adedi :
                <asp:Label ID="lblStok" runat="server"></asp:Label></h4>

            <h5>
                <asp:Label ID="lblFiyat" BackColor="LawnGreen" runat="server" CssClass="urun-fiyat"></asp:Label></h5>

            <asp:Button ID="btnSepet" runat="server" CssClass="btn btn-primary" Text="Sepete Ekle" OnClick="btnSepet_Click" />
            <asp:TextBox ID="txtAdet" CssClass="col-1" Text="1" runat="server"></asp:TextBox>
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>

        </div>
    </center>
</asp:Content>
