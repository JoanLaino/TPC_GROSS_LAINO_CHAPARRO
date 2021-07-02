<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="catalogo.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {            
            background-image: url("../img/fondo-2.jpg");
            background-color: #FFFFFF4D !important;
            width: 100%;
            height: 100vh;
            background-size: cover;
            background-position: center;
        }        
    </style>

    <center>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-buscador" />
        <asp:TextBox ID="txtFiltro" runat="server" CssClass="txt-buscador"></asp:TextBox>
    </center>

    <center>
    <div class="container">
    <div class="row row-cols-1 row-cols-md-3">
        <% foreach (Dominio.Producto item in lista)
                {%>
        <div class="col mb-4">
            <div class="card stl-card h-100">
                <center>
                    <img src="<% = item.Imagen %>" class="card-img-top img-cards" alt="...">
                </center>
                <div class="card-body">
                    <h5 class="card-title"><% = item.Nombre %></h5>
                    <h6>$ <% = item.PrecioVenta %></h6>
                    <br />
                    <div class="btn-detalle-general">
                        <%--<a href="DetalleArticulo.aspx?id=<% = item.EAN %>" class="btn btn-primary btn-cards-carrito-2">Detalles</a>--%>
                        <%--<a href="#" ID="" class="btn btn-primary btn-cards-carrito">+ Carrito</a>--%>
                    </div>
                </div>
            </div>
        </div>    
         <%   } %>
    </div>
    </div>
    </center>

    <%--<center>
    <div>
    <div>
        <asp:GridView ID="dgvProductos" runat="server" Style="text-align: center"></asp:GridView>
    </div>
    </div>
    </center>   --%> 

</asp:Content>
