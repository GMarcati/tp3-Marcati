<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CatalogoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-end">
        <div class="d-flex justify-content-end">
            Mi carrito de compra
        (<% = listaCarrito.Count() %>)    
            
        </div>

    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                        <td>Nombre</td>
                        <td>Precio</td>
                        <td>Cantidad</td>
                        <td>Accion</td>
                    </tr>
                    <%foreach (var art in listaCarrito)
                        {
                    %>
                    <tr>
                        <td><% = art.articulo.Nombre %></td>
                        <td><% = art.articulo.Precio %></td>
                        <td><% = art.Cantidad %></td>
                        <td><a href="Carrito.aspx?idQuitar=<% = art.articulo.ID.ToString() %>" class="btn btn-primary">Quitar</a></td>
                    </tr>


                    <% } %>
                </table>


            </div>



        </div>
    </div>


    <footer>
        <div class="d-flex justify-content-end">
            <div class="d-flex justify-content-end">
                Total: $
        <% = PrecioTotal %>
            </div>
        </div>


    </footer>







</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
