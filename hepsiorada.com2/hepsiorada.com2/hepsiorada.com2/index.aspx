<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="hepsiorada.com2.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h2> Efsane Yılbaşı Fırsatlarını Sakın Kaçırma. Bütün Ürünlerde sepette %10 indirim ! </h2> <hr />
    <br />
    
    <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <asp:Literal ID="ltCarouselItems" runat="server"></asp:Literal>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div><br />

    <center>
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Daha Fazla Yükle" OnClick="Button1_Click" />
    </center>
</asp:Content>
