<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMEmpleado.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMEmpleado" %>
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
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-buscador" CausesValidation="False" onclick="buscarEmpleado"/>
        <asp:TextBox ID="txtFiltro" runat="server" CssClass="txt-buscador"></asp:TextBox>
    </center>

    <center>
    <div class="container">
    <div class="row row-cols-1 row-cols-md-5">
        <% foreach (Dominio.Empleado item in lista)
                {%>
        <div class="col mb-4 stl-catalogo">
            <div class="card stl-card h-100">
                <center>
                    <h5 class="card-title"><% = "Cuil: " + item.CuilCuit %></h5>
                    <img src="<% = "https://cdn-3.expansion.mx/dims4/default/9afe8f5/2147483647/strip/true/crop/936x562+0+0/resize/800x480!/format/webp/quality/90/?url=https%3A%2F%2Fcherry-brightspot.s3.amazonaws.com%2F40%2F3c%2Fe8b2ffe0475faaebc4fdef72f5f7%2Fapu.JPG" %>" class="card-img-top img-cards" alt="...">
                </center>
                <div class="card-body stl-dtl-catalogo">
                    
                    <h5 class="card-title card-description"><% = item.Name %></h5>
                
                </div>
            </div>
        </div>    
         <%   } %>
    </div>
    </div>
    </center>

    <%--<div class="container">
        <div class="row justify-content-md-center">
            
            <div class="col-md-auto">
                <h5 class="card-title card-description">Legajo</h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description">Cuil</h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description">Nombre y Apellido</h5>
            </div>
            <div class="col-md-auto">
               <h5 class="card-title card-description">Fecha Alta</h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description">Fecha Nacimiento</h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description">Mail</h5>
            </div>
            <div class="col-md-auto">
               <h5 class="card-title card-description">Telefono</h5>
            </div>
          
        </div>
        <% foreach (Dominio.Empleado item in lista)
                {%>
        <div class="row justify-content-md-center">
            
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.Legajo %></h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.CuilCuit  %></h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.Name %></h5>
            </div>
            <div class="col-md-auto">
               <h5 class="card-title card-description"><% = item.FechaAlta %></h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.FechaNacimiento %></h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.Mail %></h5>
            </div>
            <div class="col-md-auto">
               <h5 class="card-title card-description"><% = item.Celular %></h5>
            </div>
           
        </div>
        <%   } %>
    </div>--%>

</asp:Content>
