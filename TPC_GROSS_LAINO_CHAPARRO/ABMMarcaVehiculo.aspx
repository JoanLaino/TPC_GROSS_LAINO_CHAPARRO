<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMarcaVehiculo.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMMarcaVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
        <asp:textbox ID="txtMarca" runat="server" placeholder="Marca" aria-label="Marca" cssclass="txtbox-abm-prod-ean"></asp:TextBox>
        
        <asp:Button ID="btnAceptar" onclick="btnAceptar_Click" runat="server" Text="Aceptar" />


</asp:Content>
