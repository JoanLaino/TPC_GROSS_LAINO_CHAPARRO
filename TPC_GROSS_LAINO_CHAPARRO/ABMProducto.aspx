<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMProducto.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <center>
    <asp:Button ID="btnAdd" runat="server" OnClick="AddArticulo" Text="Agregar Nuevo Producto" Style="background-color:green; color:white" /> &nbsp;&nbsp;&nbsp;&nbsp;
    <%--<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Modificar" /> &nbsp;&nbsp;&nbsp;&nbsp;--%>
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Eliminar Producto" Style="background-color:lightcoral; color:darkred" />
    </center>

    <br /><br />

    <asp:Label ID="lblEan" runat="server" Text="EAN *" Width="150px"></asp:Label>
    <asp:TextBox ID="txtEAN" runat="server" Width="200px"></asp:TextBox>

    <%-- Para el botón modificar y eliminar, que sea un buscador por EAN 
         y que muestre todos los datos cargados en el sistema, de ese producto--%>
    
    <br /><br />

    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" Width="150px"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateDescription" runat="server" OnClick="btnUpdateDescription_Click" Text="Modificar" Width="80px" Style="background-color:yellow;"/>
    
    <br /><br />

    <asp:Label ID="lblImagen" runat="server" Text="Url Imágen" Width="150px"></asp:Label>
    <asp:TextBox ID="txtUrlImagen" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateUrlImagen" runat="server" OnClick="btnUpdateUrlImagen_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>
    
    <br /><br />
    
    <asp:Label ID="lblTipoProducto" runat="server" Text="TipoProducto" Width="150px"></asp:Label>
    <asp:DropDownList ID="ddlTipoProducto" runat="server" Width="200px">
    </asp:DropDownList><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateTipoProducto" runat="server" OnClick="btnUpdateTipoProducto_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>
    
    <br /><br />
    
    <asp:Label ID="lblMarcaProducto" runat="server" Text="MarcaProducto" Width="150px"></asp:Label>
    <asp:DropDownList ID="ddlMarcaProducto" runat="server" Width="200px">
    </asp:DropDownList><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateMarcaProducto" runat="server" OnClick="btnUpdateMarcaProducto_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>
    
    <br /><br />
    
    <asp:Label ID="lblProveedor" runat="server" Text="Proveedor" Width="150px"></asp:Label>
    <asp:DropDownList ID="ddlProveedor" runat="server" Width="200px">
    </asp:DropDownList><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateProveedor" runat="server" OnClick="btnUpdateProveedor_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>

    <br /><br />

    <asp:Label ID="lblFechaCompra" runat="server" Text="Fecha de Compra" Width="150px"></asp:Label>
    <asp:TextBox ID="txtFechaCompra" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateFechaCompra" runat="server" OnClick="btnUpdateFechaCompra_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>
        
    <br /><br />

    <asp:Label ID="lblFechaVencimiento" runat="server" Text="Fecha Vencimiento" Width="150px"></asp:Label>
    <asp:TextBox ID="txtFechaVencimiento" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateFechaVencimiento" runat="server" OnClick="btnUpdateFechaVencimiento_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>
        
    <br /><br />

    <asp:Label ID="lblCosto" runat="server" Text="Costo $" Width="150px"></asp:Label>
    <asp:TextBox ID="txtCosto" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateCosto" runat="server" OnClick="btnUpdateCosto_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>
    
    <br /><br />

    <asp:Label ID="lblPrecioVenta" runat="server" Text="Precio de Venta $" Width="150px"></asp:Label>
    <asp:TextBox ID="txtPrecioVenta" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:Button ID="btnUpdatePrecioVenta" runat="server" OnClick="btnUpdatePrecioVenta_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>

    <br /><br />

    <asp:Label ID="lblStock" runat="server" Text="Stock a cargar" Width="150px"></asp:Label>
    <asp:TextBox ID="txtStock" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateStock" runat="server" OnClick="btnUpdateStock_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>

    <br /><br />

    <asp:Label ID="lblEstado" runat="server" Text="Estado" Width="150px"></asp:Label>
    <asp:DropDownList ID="ddlEstado" runat="server" Width="200px">
        <asp:ListItem>Desactivar</asp:ListItem>
        <asp:ListItem Selected="True">Activar</asp:ListItem>
    </asp:DropDownList><span style="color:red;">*</span>
    <asp:Button ID="btnUpdateEstado" runat="server" OnClick="btnUpdateEstado_Click" Text="Modificar" Width="80px" Style="background-color:yellow; "/>

    <%-- EL ESTADO POR DEFECTO, SE CARGA COMO TRUE --%>
    
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
