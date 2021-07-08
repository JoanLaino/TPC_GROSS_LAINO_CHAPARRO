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
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-buscador" CausesValidation="False" />
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
                    <img src="<% = item.Imagen %>" class="card-img-top img-cards" alt="...">
                </center>
                <div class="card-body stl-dtl-catalogo">
                    
                    <h5 class="card-title"><% = item.Nombre %></h5>
                    <h6>$ <% = (item.Costo)*2 %></h6>
                    <br />
                
                </div>
            </div>
        </div>    
         <%   } %>
    </div>
    </div>
    </center>

    

</asp:Content>
