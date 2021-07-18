<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMProductos.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="h1-abm-prod">ABM - Productos</h1>

    <br />

    <asp:TextBox ID="txtCampo" runat="server" PlaceHolder="Ingrese un EAN" TextMode="Number" onkeypress="javascript:return solonumeros(event)" cssclass="txt-campo-filtro-abm-producto" ></asp:TextBox>
    <asp:ImageButton id="imgBtnBuscarProducto" runat="server" AutoPostBack="false" OnClick="imgBtnBuscarProducto_Click" ImageUrl="~/img/find-logo.png" cssclass="btn-buscar-filtro-abm-producto" />
    
    <br /><br />

    <%--<asp:DropDownList ID="ddlCampo" runat="server" AppendDataBoundItems="True" CssClass="ddl-campo-filtro-abm-producto" AutoPostBack="True" Visible="false">
        <asp:ListItem Value="Seleccione..." Selected="True">Seleccione...</asp:ListItem>
        <asp:ListItem Value="EAN">EAN</asp:ListItem>
        <asp:ListItem Value="Descripcion">Descripción</asp:ListItem>
        <asp:ListItem Value="IdTipo">Tipo de producto</asp:ListItem>
        <asp:ListItem Value="IdMarca">Marca</asp:ListItem>
        <asp:ListItem Value="IdProveedor">Proveedor</asp:ListItem>
        <asp:ListItem Value="Stock">Stock</asp:ListItem>
        <asp:ListItem Value="Estado">Estado (1/0)</asp:ListItem>
    </asp:DropDownList>

    <asp:TextBox ID="txtFiltro" runat="server" PlaceHolder="Filtro" cssclass="txt-campo-filtro-abm-producto" Visible="false"></asp:TextBox>

    <br /><br />--%>
    
    <asp:ImageButton ID="btnAgregarProducto" runat="server" AutoPostBack="false" ImageUrl="~/img/add-logo.png" cssclass="img-btn-add-producto" CausesValidation="False" />
    <asp:Label ID="lblAgregarProducto" runat="server" Text="Agregar Nuevo Producto" Style="vertical-align:middle;"></asp:Label>
    
    <div id="overlay" class="overlay" align="center">

        <div id="popup" class="popup active">

		        <table style="width:60%; border: solid; border-color: black; background-color: rgb(255 255 255);">

                    <tr align="center">
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="right" style="padding-right: 1rem; padding-top: .5rem;">
                            <asp:Button ID="btnCerraPopup" Text="X" runat="server" onclick="btnCerraPopup_Click" />
                        </td>
                    </tr>

                    <tr align="center">
                        <td></td>
                        <td>
                            <span>Editar</span>
                            <asp:ImageButton ID="btnUpdate" runat="server" onclientclick="return confirm('¿Seguro que desea actualizar el producto?');" OnClick="btnUpdate_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto" Style="width: 30px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="btnDelete" runat="server" onclientclick="return confirm('¿Seguro que desea eliminar el producto?');" OnClick="btnDelete_Click" ImageUrl="~/img/del-logo.png" cssclass="img-btn-del-producto" />
                            <span>Eliminar</span>
                        </td>
                        <td></td>
                    </tr>
                    
                    <tr align="center">
                        <td>
                            <asp:TextBox ID="txtEAN" runat="server" placeholder="EAN" Width="200px" TextMode="Number" onkeypress="javascript:return solonumeros(event)" cssclass="txtbox-abm-prod-ean" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripción" Width="200px" MaxLength="60" cssclass="txtbox-abm-prod-descripcion" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUrlImagen" runat="server" placeholder="Url de Imágen" Width="200px" MaxLength="300" Rows="1" TextMode="Url" cssclass="txtbox-abm-prod-url-imagen" ></asp:TextBox>
                        </td>
                    </tr>

                    <tr align="center">
                        <td>
                            <asp:DropDownList ID="ddlTipoProducto" runat="server" Width="200px" AppendDataBoundItems="true" CssClass="ddl-abm-prod-tipo-producto">
                                <asp:ListItem Value="0">Tipo de Producto</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMarcaProducto" runat="server" Width="200px" AppendDataBoundItems="true" CssClass="ddl-abm-prod-marca-producto">
                                <asp:ListItem Value="0">Marca</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProveedor" runat="server" Width="200px" AppendDataBoundItems="true" CssClass="ddl-abm-prod-proveedor">
                                <asp:ListItem Value="0">Proveedor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr align="center">
                        <td>
                            <asp:TextBox ID="txtFechaCompra" runat="server" placeholder="Fecha de Compra" Width="200px" MaxLength="10" cssclass="txtbox-abm-prod-fecha-compra" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaVencimiento" runat="server" placeholder="Fecha de Vencimiento" Width="200px" MaxLength="10" cssclass="txtbox-abm-prod-fecha-vencimiento" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCosto" runat="server" placeholder="Costo" Width="200px" cssclass="txtbox-abm-prod-costo" ></asp:TextBox>
                        </td>
                    </tr>

                    <tr align="center">
                        <td>
                            <asp:TextBox ID="txtPrecioVenta" runat="server" placeholder="Precio de Venta" Width="200px" cssclass="txtbox-abm-prod-precio-venta" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStock" runat="server" placeholder="Stock" Width="200px" TextMode="Number" onkeypress="javascript:return solonumeros(event)" cssclass="txtbox-abm-prod-stock"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstado" runat="server" Width="200px" AppendDataBoundItems="true" CssClass="ddl-abm-prod-estado-producto">
                                <asp:ListItem Value="0" Selected="True">Estado</asp:ListItem>
                                <asp:ListItem Value="1" >Activar</asp:ListItem>
                                <asp:ListItem Value="2" >Desactivar</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

		        </table>

                </div>

    </div>

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

    <script>
        function solonumeros(e) {
            var key;
            if (window.event) { key = e.keyCode; }
            else if (e.which) { key = e.which; }
            if (key < 48 || key > 57) { return false; }
            return true;
        }
    </script>

    <script>
        var btnAbrirPopup = document.getElementById('imgBtnBuscarProducto'),
            overlay = document.getElementById('overlay'),
            btnCerrarPopup = document.getElementById('btnCerraPopup');

        btnAbrirPopup.addEventListener('click', function () {
            overlay.classList.add('active');
        });

        btnCerrarPopup.addEventListener('click', function (e) {
            e.preventDefault();
            overlay.classList.remove('active');
        });
    </script>

</asp:Content>
