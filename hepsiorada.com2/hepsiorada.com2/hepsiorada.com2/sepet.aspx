<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="sepet.aspx.cs" Inherits="hepsiorada.com2.sepet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Alışveriş Sepeti</h2>
    <asp:GridView ID="gvSepet" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="SepetID" HeaderText="SepetID" />
            <asp:BoundField DataField="UrunAdi" HeaderText="Ürün Adı" />
            <asp:BoundField DataField="Fiyat" HeaderText="Fiyat" />
            <asp:BoundField DataField="Adet" HeaderText="Adet" />


        </Columns>
    </asp:GridView>

    <asp:Button ID="btnSatın" runat="server" Text="Satın Al" CssClass="btn btn-success" OnClick="btnSatın_Click" /> 
    <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label><hr /><br />

    <asp:Label ID="lblSepetID" runat="server" Text="Silmek istediğiniz sepetin ID sini giriniz :"></asp:Label><br />
    <asp:TextBox ID="txtSepetID" runat="server"></asp:TextBox>
    <asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" CssClass="btn btn-danger" /><br />
    <h3><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h3>



</asp:Content>
