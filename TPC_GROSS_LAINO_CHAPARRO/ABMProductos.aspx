<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMProductos.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
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

    <%--<asp:ImageButton ID="btnUpdateGeneral" runat="server" OnClick="btnUpdateGeneral_Click" Text="Actualizar Producto" />--%>
    
    <h1 align="center" class="h1-abm-prod">ABM - Productos</h1>

    <br />
    <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar" keydown="btnBuscarProducto" onclick="btnBuscarProducto_Click" cssclass="btn-buscar-filtro-abm-producto" />
    <asp:TextBox ID="txtEAN" runat="server" placeholder="EAN" Width="200px" TextMode="Number" onkeypress="javascript:return solonumeros(event)" cssclass="txtbox-abm-prod-ean" ></asp:TextBox>
    <asp:ImageButton ID="btnDelete" runat="server" onclientclick="return confirm('¿Seguro que desea eliminar el producto?');" OnClick="btnDelete_Click" ImageUrl="~/img/del-logo.png" cssclass="img-btn-del-producto" />

    <asp:DropDownList ID="ddlCampo" runat="server" AppendDataBoundItems="True" CssClass="ddl-campo-filtro-abm-producto" AutoPostBack="True">
        <asp:ListItem Value="Seleccione..." Selected="True">Seleccione...</asp:ListItem>
        <asp:ListItem Value="EAN">EAN</asp:ListItem>
        <asp:ListItem Value="Descripción">Descripción</asp:ListItem>
        <asp:ListItem Value="Marca">Marca</asp:ListItem>
        <asp:ListItem Value="TipoProducto">Tipo de producto</asp:ListItem>
        <asp:ListItem Value="Proveedor">Proveedor</asp:ListItem>
        <asp:ListItem Value="Fecha de Compra">Fecha de Compra (DD-MM-AAAA)</asp:ListItem>
        <asp:ListItem Value="Fecha de Vencimiento">Fecha de Vencimiento (DD-MM-AAAA)</asp:ListItem>
        <asp:ListItem Value="Costo">Costo (solo números)</asp:ListItem>
        <asp:ListItem Value="PrecioVenta">Precio de Venta (solo números)</asp:ListItem>
        <asp:ListItem Value="Stock">Stock</asp:ListItem>
        <asp:ListItem Value="Estado">Estado (1/0)</asp:ListItem>
    </asp:DropDownList>
    
    <asp:TextBox ID="txtCampo" runat="server" PlaceHolder="Ingrese palabra/s clave/s" cssclass="txt-campo-filtro-abm-producto" ></asp:TextBox>
    
    <br /><br />

    <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripción" Width="200px" MaxLength="60" cssclass="txtbox-abm-prod-descripcion" ></asp:TextBox>
    <asp:ImageButton ID="btnUpdateDescription" runat="server" OnClick="btnUpdateDescription_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-description" />

    <br /><br />

    <asp:TextBox ID="txtUrlImagen" runat="server" placeholder="Url de Imágen" Width="200px" MaxLength="300" Rows="1" TextMode="Url" cssclass="txtbox-abm-prod-url-imagen" ></asp:TextBox>
    <asp:ImageButton ID="btnUpdateUrlImagen" runat="server" OnClick="btnUpdateUrlImagen_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-url-imagen"/>

    <br /><br />
    
    <asp:DropDownList ID="ddlTipoProducto" runat="server" Width="200px" AppendDataBoundItems="true" CssClass="ddl-abm-prod-tipo-producto">
        <asp:ListItem Value="0">Tipo de Producto</asp:ListItem>
    </asp:DropDownList>
    <asp:ImageButton ID="btnUpdateTipoProducto" runat="server" OnClick="btnUpdateTipoProducto_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-abm-prod-tipo-producto"/>

    <br /><br />
    
    <asp:DropDownList ID="ddlMarcaProducto" runat="server" Width="200px" AppendDataBoundItems="true" CssClass="ddl-abm-prod-marca-producto">
        <asp:ListItem Value="0">Marca</asp:ListItem>
    </asp:DropDownList>
    <asp:ImageButton ID="btnUpdateMarcaProducto" runat="server" OnClick="btnUpdateMarcaProducto_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-marca-producto"/>

    <br /><br />
    
    <asp:DropDownList ID="ddlProveedor" runat="server" Width="200px" AppendDataBoundItems="true" CssClass="ddl-abm-prod-proveedor">
        <asp:ListItem Value="0">Proveedor</asp:ListItem>
    </asp:DropDownList>
    <asp:ImageButton ID="btnUpdateProveedor" runat="server" OnClick="btnUpdateProveedor_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-proveedor"/>
    
    <br /><br />

    <asp:Label ID="lblFechaCompra" Text="Fecha de Compra:" runat="server" CssClass="lbl-fecha-compra-abm-prod"></asp:Label>
    <asp:TextBox ID="txtFechaCompra" runat="server" Width="200px" MaxLength="10" TextMode="Date" cssclass="txtbox-abm-prod-fecha-compra" ></asp:TextBox>
    <asp:ImageButton ID="btnUpdateFechaCompra" runat="server" placeholder="Fecha de Compra" OnClick="btnUpdateFechaCompra_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-fecha-compra"/>
    
    <br /><br />

    <asp:Label ID="lblFechaVencimiento" Text="Fecha de Vencimiento:" runat="server" CssClass="lbl-fecha-vencimiento-abm-prod"></asp:Label>
    <asp:TextBox ID="txtFechaVencimiento" runat="server" placeholder="Fecha de Vencimiento" Width="200px" MaxLength="10" TextMode="Date" cssclass="txtbox-abm-prod-fecha-vencimiento" ></asp:TextBox>
    <asp:ImageButton ID="btnUpdateFechaVencimiento" runat="server" OnClick="btnUpdateFechaVencimiento_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-fecha-vencimiento"/>
    
    <br /><br />

    <asp:TextBox ID="txtCosto" runat="server" placeholder="Costo" Width="200px" cssclass="txtbox-abm-prod-costo" ></asp:TextBox>
    <asp:ImageButton ID="btnUpdateCosto" runat="server" OnClick="btnUpdateCosto_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-costo"/>
    
    <br /><br />

    <asp:TextBox ID="txtPrecioVenta" runat="server" placeholder="Precio de Venta" Width="200px" cssclass="txtbox-abm-prod-precio-venta" ></asp:TextBox>
    <asp:ImageButton ID="btnUpdatePrecioVenta" runat="server" OnClick="btnUpdatePrecioVenta_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-precio-venta"/>
    
    <br /><br />

    <asp:TextBox ID="txtStock" runat="server" placeholder="Stock" Width="200px" TextMode="Number" onkeypress="javascript:return solonumeros(event)" cssclass="txtbox-abm-prod-stock" ></asp:TextBox>
    <asp:ImageButton ID="btnUpdateStock" runat="server" OnClick="btnUpdateStock_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-stock"/>
    
    <br /><br />

    <asp:DropDownList ID="ddlEstado" runat="server" Width="200px" AppendDataBoundItems="true" CssClass="ddl-abm-prod-estado-producto">
        <asp:ListItem Value="0" Selected="True">Estado</asp:ListItem>
        <asp:ListItem>Desactivar</asp:ListItem>
        <asp:ListItem>Activar</asp:ListItem>
    </asp:DropDownList>
    <asp:ImageButton ID="btnUpdateEstado" runat="server" OnClick="btnUpdateEstado_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto img-btn-edit-estado-producto"/>
    
    <br /><br />

    <asp:ImageButton ID="btnAdd" runat="server" onclientclick="return confirm('¿Seguro que desea agregar el producto?');" OnClick="btnAdd_Click" ImageUrl="~/img/add-logo.png" cssclass="img-btn-add-producto" />
    <asp:Label ID="lblAddProduct" runat="server" Text="Agregar Nuevo Producto" cssclass="lbl-add-abm-prod"></asp:Label>
    
    <%-- EL ESTADO POR DEFECTO, SE CARGA COMO TRUE --%>
    
    <br /><br /><br />
    
    <center>
        <asp:GridView ID="dgvInventario" runat="server" align="center" CellPadding="4" ForeColor="#333333" BackColor="Black" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CaptionAlign="Bottom" HorizontalAlign="Center" AutoGenerateColumns="False" PageSize="2" CssClass="dgv-abm-prod">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="EAN" HeaderText="EAN" SortExpression="EAN" />
                <asp:ImageField DataAlternateTextField="Imagen" DataImageUrlField="Imagen" HeaderText="Imagen" ControlStyle-Width="25px">
                <ControlStyle Width="25px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="Descripción" HeaderText="Descripción" SortExpression="Descripción" />
                <asp:BoundField DataField="TipoProducto" HeaderText="TipoProducto" SortExpression="TipoProducto" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" SortExpression="Proveedor" />
                <asp:BoundField DataField="Fecha de Compra" HeaderText="Fecha de Compra" ReadOnly="True" SortExpression="Fecha de Compra" />
                <asp:BoundField DataField="Fecha de Vencimiento" HeaderText="Fecha de Vencimiento" SortExpression="Fecha de Vencimiento" ReadOnly="True" />
                <asp:BoundField DataField="Costo" HeaderText="Costo" SortExpression="Costo" />
                <asp:BoundField DataField="PrecioVenta" HeaderText="PrecioVenta" SortExpression="PrecioVenta" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:CheckBoxField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
            </Columns>
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
        <asp:SqlDataSource ID="ExportInventario" runat="server" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" SelectCommand="SELECT * FROM [ExportInventario] ORDER BY [Stock]"></asp:SqlDataSource>
    </center>

</asp:Content>
