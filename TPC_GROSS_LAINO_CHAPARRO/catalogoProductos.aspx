<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="catalogoProductos.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.catalogo" %>
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
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-buscador" CausesValidation="False" onclick="buscarProducto"/>
        <asp:TextBox ID="txtFiltro" runat="server" CssClass="txt-buscador"></asp:TextBox>
    </center>

    <center>
    <div class="container">
    <div class="row row-cols-1 row-cols-md-3">
        <% foreach (Dominio.Producto item in lista)
                {%>
        <div class="col mb-4 stl-catalogo">
            <div class="card stl-card h-100">
                <center>
                    <h5 class="card-title"><% = "EAN: " + item.EAN %></h5>
                    <br />
                    <img src="<% = item.Imagen %>" class="card-img-top img-cards" alt="...">
                </center>
                <div class="card-body stl-dtl-catalogo">
                    
                    <h5 class="card-title"><% = item.Descripción %></h5> 
                    <br />
                    <h5 class="card-title"><% = "Marca: " + item.MarcaProducto %></h5>
                    <br />
                    <h6>$ <% = item.PrecioVenta%></h6>
                
                </div>
            </div>
        </div>    
         <%   } %>
    </div>
    </div>
    </center>

    

</asp:Content>
