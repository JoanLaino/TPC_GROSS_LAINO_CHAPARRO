<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCatalogo.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="lblEan" runat="server" Text="EAN"></asp:Label>
    <asp:DropDownList ID="ddlEan" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    
    <br /><br />

    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    
    <br /><br />
    
    <asp:Label ID="lblTipoProducto" runat="server" Text="TipoProducto"></asp:Label>
    <asp:DropDownList ID="ddlTipoProducto" runat="server">
    </asp:DropDownList>
    
    <br /><br />
    
    <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
    <asp:DropDownList ID="ddlMarca" runat="server">
    </asp:DropDownList>
    
    <br /><br />
    
    <asp:Label ID="lblProveedor" runat="server" Text="Proveedor"></asp:Label>
    <asp:DropDownList ID="ddlProveedor" runat="server">
    </asp:DropDownList>
    
    <br /><br /><br />
    
    <center>
        
    <asp:Button ID="btnAdd" runat="server" OnClick="AddArticulo" Text="Agregar" /> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Actualizar" /> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Eliminar" />
    </center>

    <br /><br /><br />
    
    <center>
    <asp:GridView ID="dgvInventario" runat="server" align="center" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    </center>

</asp:Content>
