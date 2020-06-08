<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CatalogoWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-fluid">
        <div class="container">
            <h1 class="display-4">ERROR!</h1>
            <p class="lead"></p>
        </div>
        
    </div>
    <br />
    <a href="Index.aspx" class="btn btn-primary">Volver al inicio</a>
    <p><% = Session["Error" + Session.SessionID] %></p>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
