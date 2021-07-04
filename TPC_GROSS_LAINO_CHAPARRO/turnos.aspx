<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="turnos.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.turnos" %>
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

    <div class="calendario-turnos">
    <center>
        <h2 class="ttl-turno">¡Reservá tu turno Online!</h2>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    </center>
    </div>

</asp:Content>
