<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMTiposProducto.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMTiposProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <center>
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Agregar nuevo Tipo de Producto" Style="background-color:green; color:white" /> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Modificar Tipo de Producto" /> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Eliminar Producto" Style="background-color:lightcoral; color:darkred" />
    </center>

    <br /><br />

    <asp:Label ID="lblID" runat="server" Text="ID" Width="150px"></asp:Label>
    <asp:TextBox ID="txtEAN" runat="server" Width="200px"></asp:TextBox>

</asp:Content>
