<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMProducto.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function solonumeros(e)
        {
            var key;
            if (window.event) { key = e.keyCode; }
            else if (e.which) { key = e.which;}
            if (key < 48 || key > 57) { return false;}
            return true;
        }
    </script>

    <%--<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Modificar" />--%>
    
    <h1 align="center">ABM - Productos</h1>

    <p style="color: red; text-shadow: 1px black;">
       ***Para agregar un nuevo producto debe completar todos los campos.<br />
       ***Para modificar un producto debe completar el EAN, el campo a modificar y oprimir el botón "Modificar", 
          correspondiente a ese campo.<br />
       ***Para eliminar un producto debe completar el EAN y hacer click en eliminar.
    </p>

    <asp:Label ID="lblEan" runat="server" Text="EAN" Width="150px"></asp:Label>
    <asp:TextBox ID="txtEAN" runat="server" Width="200px" TextMode="Number" onkeypress="javascript:return solonumeros(event)"></asp:TextBox><span style="color:red;">*</span>
    <asp:ImageButton ID="btnDelete" runat="server" onclientclick="return confirm('¿Seguro que desea eliminar el producto?');" OnClick="btnDelete_Click" ImageUrl="~/img/del-logo.png" Style="width: 30px; vertical-align: bottom; position: relative; top: -2px;" />
    <asp:Label ID="lblDeleteProduct" runat="server" Text="Eliminar Producto" Style="position: relative; top: -3px;"></asp:Label>

    <br /><br />

    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" Width="150px"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" Width="200px" MaxLength="60"></asp:TextBox><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateDescription" runat="server" OnClick="btnUpdateDescription_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Descripción</span>

    <br /><br />

    <asp:Label ID="lblImagen" runat="server" Text="Url Imágen" Width="150px"></asp:Label>
    <asp:TextBox ID="txtUrlImagen" runat="server" Width="200px" MaxLength="300" Rows="1" TextMode="Url"></asp:TextBox><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateUrlImagen" runat="server" OnClick="btnUpdateUrlImagen_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Imágen</span>

    <br /><br />
    
    <asp:Label ID="lblTipoProducto" runat="server" Text="TipoProducto" Width="150px"></asp:Label>
    <asp:DropDownList ID="ddlTipoProducto" runat="server" Width="200px">
    </asp:DropDownList><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateTipoProducto" runat="server" OnClick="btnUpdateTipoProducto_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Tipo de Producto</span>

    <br /><br />
    
    <asp:Label ID="lblMarcaProducto" runat="server" Text="MarcaProducto" Width="150px"></asp:Label>
    <asp:DropDownList ID="ddlMarcaProducto" runat="server" Width="200px">
    </asp:DropDownList><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateMarcaProducto" runat="server" OnClick="btnUpdateMarcaProducto_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Marca</span>

    <br /><br />
    
    <asp:Label ID="lblProveedor" runat="server" Text="Proveedor" Width="150px"></asp:Label>
    <asp:DropDownList ID="ddlProveedor" runat="server" Width="200px">
    </asp:DropDownList><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateProveedor" runat="server" OnClick="btnUpdateProveedor_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Proveedor</span>
    
    <br /><br />

    <asp:Label ID="lblFechaCompra" runat="server" Text="Fecha de Compra" Width="150px"></asp:Label>
    <asp:TextBox ID="txtFechaCompra" runat="server" Width="200px" MaxLength="10" TextMode="Date"></asp:TextBox><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateFechaCompra" runat="server" OnClick="btnUpdateFechaCompra_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Fecha de Compra</span>  
    
    <br /><br />

    <asp:Label ID="lblFechaVencimiento" runat="server" Text="Fecha Vencimiento" Width="150px"></asp:Label>
    <asp:TextBox ID="txtFechaVencimiento" runat="server" Width="200px" MaxLength="10" TextMode="Date"></asp:TextBox><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateFechaVencimiento" runat="server" OnClick="btnUpdateFechaVencimiento_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Fecha de Vencimiento</span>    
    
    <br /><br />

    <asp:Label ID="lblCosto" runat="server" Text="Costo $" Width="150px"></asp:Label>
    <asp:TextBox ID="txtCosto" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateCosto" runat="server" OnClick="btnUpdateCosto_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Costo</span>
    
    <br /><br />

    <asp:Label ID="lblPrecioVenta" runat="server" Text="Precio de Venta $" Width="150px"></asp:Label>
    <asp:TextBox ID="txtPrecioVenta" runat="server" Width="200px"></asp:TextBox><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdatePrecioVenta" runat="server" OnClick="btnUpdatePrecioVenta_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Precio de Venta</span>
    
    <br /><br />

    <asp:Label ID="lblStock" runat="server" Text="Stock a cargar" Width="150px"></asp:Label>
    <asp:TextBox ID="txtStock" runat="server" Width="200px" TextMode="Number" onkeypress="javascript:return solonumeros(event)"></asp:TextBox><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateStock" runat="server" OnClick="btnUpdateStock_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Stock</span>
    
    <br /><br />

    <asp:Label ID="lblEstado" runat="server" Text="Estado" Width="150px"></asp:Label>
    <asp:DropDownList ID="ddlEstado" runat="server" Width="200px">
        <asp:ListItem>Desactivar</asp:ListItem>
        <asp:ListItem Selected="True">Activar</asp:ListItem>
    </asp:DropDownList><span style="color:red;">*</span>
    <asp:ImageButton ID="btnUpdateEstado" runat="server" OnClick="btnUpdateEstado_Click" ImageUrl="~/img/edit-logo.png" Style="width: 20px; vertical-align: bottom; position: relative; top: -5px;"/>
    <span style="position: relative; top: -2px;">Editar Estado</span>
    
    <br /><br />

    <asp:ImageButton ID="btnAdd" runat="server" onclientclick="return confirm('¿Seguro que desea agregar el producto?');" OnClick="btnAdd_Click" ImageUrl="~/img/add-logo.png" Style="width: 50px; vertical-align: bottom; position: relative; left: 180px;" />
    <asp:Label ID="lblAddProduct" runat="server" Text="Agregar Nuevo Producto" Style="position: relative; left: 185px; top: -15px;"></asp:Label>
    
    <%-- EL ESTADO POR DEFECTO, SE CARGA COMO TRUE --%>
    
    <br /><br /><br />
    
    <center>
        <asp:GridView ID="dgvInventario" runat="server" align="center" CellPadding="4" ForeColor="#333333" AllowPaging="True" AllowSorting="True" BackColor="Black" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CaptionAlign="Bottom" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerSettings Position="TopAndBottom" />
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
