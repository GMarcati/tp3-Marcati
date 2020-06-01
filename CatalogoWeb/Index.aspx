<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CatalogoWeb.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="margin-bottom: 1em; border-radius: 25px;">

            <asp:TextBox runat="server" ID="txtBusqueda" placeholder="Buscar productos" CssClass="form-control mr-sm-2" />
            <button class="btn btn-outline-success my-2 my-sm-0" type="submit" id="btnBusqueda">Buscar</button>


        </nav>
    </div>
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">

        <div class="container">
            <% foreach (var item in listaArticulo)
                { %>

            <div class="container">

                <div class="card" style="width: 18rem;">

                    <div class="container">

                        <img src="<% = item.ImagenURL %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><% = item.Nombre %></h5>
                            <p class="card-text"><% = item.Descripcion %></p>
                            <a href="Carrito.aspx?idart=<% = item.ID.ToString() %>" class="btn btn-primary">Agregar al carrito</a>
                        </div>
                    </div>
                </div>
            </div>

            <% } %>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
