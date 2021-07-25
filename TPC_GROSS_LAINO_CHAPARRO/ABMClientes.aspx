<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="h1-abm-prod">ABM - Clientes</h1>

    <br />

    <asp:ImageButton id="imgBtnBuscar" runat="server" ToolTip="Buscar Cliente" ImageUrl="~/img/find-logo.png" onclick="imgBtnBuscar_Click" Style="width: 30px; vertical-align: middle;" cssclass="btn-buscar-filtro-abm-producto" />
    <asp:TextBox ID="txtBuscar" runat="server" ToolTip="Buscador" PlaceHolder="Buscar..." Style="width: 320px; height: 30px !important; vertical-align: middle;" ></asp:TextBox>

    <button id="btnPopUpAgregarCliente" ToolTip="Agregar nuevo Cliente" class="btnAddNewEmployee">Agregar Nuevo</button>

    <br /><br />

    <table BorderStyle="Inset" BorderWidth="5px" style="width:60%; border: solid; border-color: black; background-color: rgb(255 255 255);">

        <tr align="center" >
            <td>
                 <asp:TextBox ID="txtID" runat="server" ToolTip="ID" placeholder="ID" Visible="false" ></asp:TextBox>
                <asp:TextBox ID="txtLegajo" runat="server" ToolTip="Legajo" placeholder="Legajo" Width="200px" MaxLength="4" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="Editar Producto" onclientclick="return confirm('¿Confirma las modificaciones?');" onclick="btnUpdate_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto" Style="width: 30px; vertical-align: sub;" />
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Eliminar Producto" onclientclick="return confirm('¿Seguro que desea eliminar al empleado?');" onclick="btnDelete_Click" ImageUrl="~/img/del-logo.png" cssclass="img-btn-del-producto" Style="vertical-align: sub;" />
            </td>
            <td>
                <asp:TextBox ID="txtCuil" runat="server" ToolTip="Cuil" placeholder="Cuil" Width="200px" MaxLength="11" Rows="1" TextMode="Number" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
            </td>
        </tr>

        <tr align="center">
            <td>
                <asp:TextBox ID="txtApeNom" runat="server" ToolTip="Apellido y Nombre" placeholder="Apellido y Nombre" Width="200px" MaxLength="100" Rows="1" onkeypress="javascript:return sololetras(event)" ></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtFechaAlta" runat="server" ToolTip="Fecha de Alta" placeholder="Fecha de Alta" Width="200px" MaxLength="10" ></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" ToolTip="Fecha de Nacimiento" placeholder="Fecha de Nacimiento" Width="200px" MaxLength="10"></asp:TextBox>
            </td>
        </tr>

        <tr align="center">
            <td>
                <asp:TextBox ID="txtMail" runat="server" ToolTip="e-Mail" placeholder="e-Mail" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" ToolTip="Teléfono / Celular" placeholder="Teléfono / Celular" onkeypress="javascript:return solonumeros(event)" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtServiciosRealizados" runat="server" Enabled="false" ToolTip="Cantidad de Servicios Realizados" placeholder="Cant. Servicios Realizados" Width="200px"></asp:TextBox>
            </td>
        </tr>

	</table>

    <div id="overlay" class="overlay" align="center">

        <div id="popup" class="popup">

		        <table style="width:80%; border: inset; border-color: black; background-color: rgb(255 255 255);">

                    <tr align="center" >
                        <td>
                            <asp:TextBox ID="txtCuitCuil2" runat="server" TextMode="Number" ToolTip="CUIT / CUIL" placeholder="CUIT / CUIL" Width="200px" MaxLength="11" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                        </td>
                        <td align="center" style="vertical-align: super;">
                            <asp:Button ID="btnCerraPopup" Text="X" runat="server" ToolTip="Cancelar" OnClick="btnCerraPopup_Click" cssclass="btn-cerrar-popup" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtRazonSocial2" runat="server" ToolTip="Razón Social" placeholder="Razón Social" Width="200px" MaxLength="11" Rows="1" ></asp:TextBox>
                        </td>
                    </tr>
                                    
                    <tr align="center">
                        <td>
                            <asp:TextBox ID="txtApeNom2" runat="server" ToolTip="Apellido y Nombre" placeholder="Apellido y Nombre" Width="200px" MaxLength="100" Rows="1" onkeypress="javascript:return sololetras(event)" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaAlta2" runat="server" Type="Date" ToolTip="Fecha de Alta" placeholder="Fecha de Alta" Width="200px" MaxLength="10" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaNacimiento2" runat="server" Type="Date" ToolTip="Fecha de Nacimiento" placeholder="Fecha de Nacimiento" Width="200px" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>

                    <tr align="center">
                        <td>
                            <asp:TextBox ID="txtMail2" runat="server" ToolTip="e-Mail" placeholder="e-Mail" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTipoCliente" runat="server" ToolTip="Tipo de Cliente" placeholder="Tipo de Cliente" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefono2" runat="server" ToolTip="Teléfono / Celular" placeholder="Teléfono / Celular" onkeypress="javascript:return solonumeros(event)" Width="200px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr align="center">
                        <td>
                        </td>
                        <td align="center">
                            <span style="font-size: 10px; position: relative; top: -10px; color: red;">Empresa, Particular, Monotributista, Estatal</span>
                            <asp:Button ID="imgBtnAgregarCliente" Text="Agregar" runat="server" ToolTip="Agregar Cliente" onclientclick="return confirm('¿Confirma que desea agregar al nuevo empleado?');" onclick="imgBtnAgregarCliente_Click" cssclass="img-btn-add-producto" />
                        </td>
                        <td>
                        </td>
                    </tr>

		        </table>

                </div>

    </div>

    <br />
    
    <center>
        <asp:GridView ID="dgvClientes" runat="server" AllowSorting="True" OnSorting="dgvClientes_Sorting" AutoGenerateColumns="False" align="center" CellPadding="4" ForeColor="#333333" BackColor="Black" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CaptionAlign="Bottom" HorizontalAlign="Center" CssClass="dgv-abm-prod" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CUITCUIL" HeaderText="CUIT / CUIL" SortExpression="CUITCUIL" />
                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="RazonSocial" />
                <asp:BoundField DataField="ApeNom" HeaderText="Apellido y Nombre" SortExpression="ApeNom" />
                <asp:BoundField DataField="TipoCliente" HeaderText="Tipo de Cliente" SortExpression="TipoCliente" />
                <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta" SortExpression="FechaAlta" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" SortExpression="FechaNacimiento" />
                <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="TotalVehiculosRegistrados" HeaderText="Cant. Vehículos" SortExpression="TotalVehiculosRegistrados" />
                <asp:CheckBoxField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
            </Columns>
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
        <asp:SqlDataSource ID="ExportClientesDB" runat="server" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" SelectCommand="SELECT * FROM [ExportClientes]"></asp:SqlDataSource>
    </center>

    <script>
        function solonumeros(e) {
            var key;
            if (window.event) { key = e.keyCode; }
            else if (e.which) { key = e.which; }
            if (key < 48 || key > 57) { return false; }
            return true;
        }

        function sololetras(e) {
            var key;
            if (window.event) { key = e.keyCode; }
            else if (e.which) { key = e.which; }
            if (key >= 48 && key <= 57) { return false; }
            return true;
        }
    </script>

    <script>
        var btnAbrirPopup = document.getElementById('btnPopUpAgregarCliente'),
            overlay = document.getElementById('overlay'),
            popup = document.getElementById('popup'),
            btnCerrarPopup = document.getElementById('btn-cerrar-popup');

        btnAbrirPopup.addEventListener('click', function (e) {
            e.preventDefault();
            overlay.classList.add('active');
            popup.classList.add('active');
        });

        btnCerrarPopup.addEventListener('click', function (e) {
            e.preventDefault();
            overlay.classList.remove('active');
            popup.classList.remove('active');
        });
    </script>

</asp:Content>
