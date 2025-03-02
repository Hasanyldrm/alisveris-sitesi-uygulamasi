<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="liste.aspx.cs" Inherits="hepsiorada.com2.liste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h2 class="text-center">Ürün Listesi</h2>

        <!-- Sıralama Seçenekleri -->
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="ddlSort">Sırala:</label>
                <asp:DropDownList ID="ddlSort" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                    <asp:ListItem Text="Fiyata Göre (Artan)" Value="FiyatArtan" />
                    <asp:ListItem Text="Fiyata Göre (Azalan)" Value="FiyatAzalan" />
                    <asp:ListItem Text="İsme Göre (A-Z)" Value="AdanZ" />
                    <asp:ListItem Text="İsme Göre (Z-A)" Value="ZdenA" />
                    <asp:ListItem Text="Stok Durumuna Göre" Value="Stok" />
                </asp:DropDownList>
            </div>
        </div>

        <!-- Ürün Kartları -->
        <div class="row" id="product-list">
            <asp:Literal ID="product_list" runat="server"></asp:Literal>
        </div>
    </div>

</asp:Content>
