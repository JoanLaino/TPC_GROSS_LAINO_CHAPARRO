<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMProducto.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblEan" runat="server" Text="EAN *"></asp:Label>
    <asp:TextBox ID="txtEAN" runat="server"></asp:TextBox>

    <%-- Para el botón modificar y eliminar, que sea un buscador por EAN 
         y que muestre todos los datos cargados en el sistema, de ese producto--%>
    
    <br /><br />

    <asp:Label ID="lblNombre" runat="server" Text="Nombre *"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    
    <br /><br />

    <asp:Label ID="lblImagen" runat="server" Text="Url Imágen *"></asp:Label>
    <asp:TextBox ID="txtImagen" runat="server"></asp:TextBox>
    
    <br /><br />
    
    <asp:Label ID="lblTipoProducto" runat="server" Text="TipoProducto"></asp:Label>
    <asp:DropDownList ID="ddlTipoProducto" runat="server">
    </asp:DropDownList>
    
    <br /><br />
    
    <asp:Label ID="lblMarcaProducto" runat="server" Text="MarcaProducto"></asp:Label>
    <asp:DropDownList ID="ddlMarcaProducto" runat="server">
    </asp:DropDownList>
    
    <br /><br />
    
    <asp:Label ID="lblProveedor" runat="server" Text="Proveedor"></asp:Label>
    <asp:DropDownList ID="ddlProveedor" runat="server">
    </asp:DropDownList>

    <br /><br />

    <asp:Label ID="lblFechaCompra" runat="server" Text="Fecha de Compra *"></asp:Label>
    <asp:TextBox ID="txtFechaCompra" runat="server"></asp:TextBox>&nbsp;
        
    <br /><br />

    <asp:Label ID="lblFechaVencimiento" runat="server" Text="Fecha Vencimiento *"></asp:Label>
    <asp:TextBox ID="txtFechaVencimiento" runat="server"></asp:TextBox>&nbsp;
        
    <br /><br />

    <asp:Label ID="lblCosto" runat="server" Text="Costo $ *"></asp:Label>
    <asp:TextBox ID="txtCosto" runat="server"></asp:TextBox>
    
    <br /><br />

    <asp:Label ID="lblPrecioVenta" runat="server" Text="PrecioVenta $ *"></asp:Label>
    <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="lblStock" runat="server" Text="Cantidad *"></asp:Label>
    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
    <asp:DropDownList ID="ddlEstado" runat="server">
        <asp:ListItem>Desactivar</asp:ListItem>
        <asp:ListItem Selected="True">Activar</asp:ListItem>
    </asp:DropDownList>

    <%-- EL ESTADO NO SE USA PARA AGREGAR UN ARTICULO, XQ POR DEFECTO, SE CARGA COMO TRUE --%>

    <%-- PERO SI SE CARGA PARA MODIFICAR UN PRODUCTO --%>
    
    <br /><br /><br />
    
    <center>  

    <asp:Button ID="btnAdd" runat="server" OnClick="AddArticulo" Text="Agregar" /> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Modificar" /> &nbsp;&nbsp;&nbsp;&nbsp;
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
