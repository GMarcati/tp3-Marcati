<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CatalogoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <%--Visto en clase 11:--%>
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
                        <%--<td><% = art.Cantidad %></td>--%>
                        <td><a href="Carrito.aspx?idQuitar=<% = art.ID.ToString() %>" class="btn btn-primary">Quitar</a></td>
                    </tr>


                    <% } %>
                </table>
                
                
            </div>
            
            
             
        </div>
    </div>
    

    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
