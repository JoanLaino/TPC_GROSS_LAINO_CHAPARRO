<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebInterna.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.WebInterna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="btnABMProducto" onclick="btnABMProducto_Click" runat="server" Text="ABM - Productos" />

    <asp:Button ID="btnABMTiposProducto" onclick="btnABMTiposProducto_Click" runat="server" Text="ABM - Tipos de Producto" />

    <asp:Button ID="btnABMMarcasProducto" onclick="btnABMMarcasProducto_Click" runat="server" Text="ABM - Marcas de Productos)" />

    <asp:Button ID="btnABMProveedores" onclick="btnABMProveedores_Click" runat="server" Text="ABM - Proveedores" />

</asp:Content>
