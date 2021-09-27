<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMServicios.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="h1-abm">ABM - Turnos</h1>

    <br />

    <asp:DropDownList ID="ddlFiltroBuscar" runat="server" AppendDataBoundItems="true" Style="height: 31px; vertical-align: top;">
        <asp:ListItem Value="0">Buscar por...</asp:ListItem>
        <asp:ListItem Value="ID">ID</asp:ListItem>
        <asp:ListItem Value="Patente">Patente</asp:ListItem>
        <asp:ListItem Value="CUIT_DNI">CUIT / DNI</asp:ListItem>
        <asp:ListItem Value="Fecha">Fecha</asp:ListItem>
    </asp:DropDownList>

    <asp:TextBox ID="txtBuscarFiltro" runat="server" PlaceHolder="Texto buscado..." />
    
    <asp:Button ID="btnBuscarFiltro" runat="server" Text="Buscar" onclick="btnBuscarFiltro_Click" />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <asp:Label Text="Mostrar servicios..." runat="server" Style="font-size: 16px;" />
    <asp:DropDownList ID="ddlMostrar" runat="server" AppendDataBoundItems="true" AutoPostBack="True" >
        <asp:ListItem Value="0">Todos</asp:ListItem>
        <asp:ListItem Value="Hoy">De hoy</asp:ListItem>
        <asp:ListItem Value="Cumplidos">Cumplidos</asp:ListItem>
        <asp:ListItem Value="Futuros">Futuros</asp:ListItem>
    </asp:DropDownList>

    <asp:TextBox ID="txtBorrarServiciosPorPatente" runat="server" tooltip="Ingresar patente" placeholder="Patente..." />
    <asp:Button ID="btnBorrarServiciosPorPatente" runat="server" Text="Borrar Servicios por Patente" />

    <br /><br />

</asp:Content>
