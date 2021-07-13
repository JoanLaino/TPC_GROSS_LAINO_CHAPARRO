<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMEmpleado.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
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
    </div>

</asp:Content>
