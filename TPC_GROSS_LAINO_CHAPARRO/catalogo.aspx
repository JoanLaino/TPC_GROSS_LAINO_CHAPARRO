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
    <div>
    <div>
        <asp:GridView ID="dgvProductos" runat="server" Style="text-align: center"></asp:GridView>
    </div>
    </div>
    </center>    

</asp:Content>
