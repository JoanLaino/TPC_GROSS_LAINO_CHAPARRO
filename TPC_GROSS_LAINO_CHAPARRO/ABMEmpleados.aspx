<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMEmpleados.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMEmpleado" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<style>
        body {            
            background-image: url("../img/fondo-2.jpg");
            background-color: #FFFFFF4D !important;
            width: 100%;
            height: 100vh;
            background-size: cover;
            background-position: center;
        }        
    </style>

    <center>  
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn-buscador" CausesValidation="False" onclick="buscarEmpleado"/>
        <asp:TextBox ID="txtFiltro" runat="server" CssClass="txt-buscador"></asp:TextBox>
    </center>

    <center>
    <div class="container">
    <div class="row row-cols-1 row-cols-md-5">
        <% foreach (Dominio.Empleado item in lista)
                {%>
        <div class="col mb-4 stl-catalogo">
            <div class="card stl-card h-100">
                <center>
                    <h5 class="card-title"><% = "Cuil: " + item.CuilCuit %></h5>
                    <img src="<% = "https://cdn-3.expansion.mx/dims4/default/9afe8f5/2147483647/strip/true/crop/936x562+0+0/resize/800x480!/format/webp/quality/90/?url=https%3A%2F%2Fcherry-brightspot.s3.amazonaws.com%2F40%2F3c%2Fe8b2ffe0475faaebc4fdef72f5f7%2Fapu.JPG" %>" class="card-img-top img-cards" alt="...">
                </center>
                <div class="card-body stl-dtl-catalogo">
                    
                    <h5 class="card-title card-description"><% = item.Name %></h5>
                
                </div>
            </div>
        </div>    
         <%   } %>
    </div>
    </div>
    </center>--%>

    <%--<div class="container">
        <div class="row justify-content-md-center">
            
            <div class="col-md-auto">
                <h5 class="card-title card-description">Legajo</h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description">Cuil</h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description">Nombre y Apellido</h5>
            </div>
            <div class="col-md-auto">
               <h5 class="card-title card-description">Fecha Alta</h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description">Fecha Nacimiento</h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description">Mail</h5>
            </div>
            <div class="col-md-auto">
               <h5 class="card-title card-description">Telefono</h5>
            </div>
          
        </div>
        <% foreach (Dominio.Empleado item in lista)
                {%>
        <div class="row justify-content-md-center">
            
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.Legajo %></h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.CuilCuit  %></h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.Name %></h5>
            </div>
            <div class="col-md-auto">
               <h5 class="card-title card-description"><% = item.FechaAlta %></h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.FechaNacimiento %></h5>
            </div>
            <div class="col-md-auto">
                <h5 class="card-title card-description"><% = item.Mail %></h5>
            </div>
            <div class="col-md-auto">
               <h5 class="card-title card-description"><% = item.Celular %></h5>
            </div>
           
        </div>
        <%   } %>
    </div>--%>

    <h1 class="h1-abm">ABM - Empleados</h1>

    <br />

    <asp:ImageButton id="imgBtnBuscar" runat="server" ToolTip="Buscar Empleado" ImageUrl="~/img/find-logo.png" onclick="imgBtnBuscar_Click" Style="vertical-align: middle;" cssclass="btn-buscar-filtro-abm" />
    <asp:TextBox ID="txtBuscar" runat="server" ToolTip="Buscador" PlaceHolder="Buscar..." Style="width: 320px; height: 30px !important; vertical-align: middle;" ></asp:TextBox>

    <button id="btnPopUpAgregarEmpleado" ToolTip="Agregar nuevo Empleado" class="btnAddNewEmployee">Agregar Nuevo</button>

    <br /><br />

    <table BorderStyle="Inset" BorderWidth="5px" style="width:60%; border: solid; border-color: black; background-color: rgb(255 255 255);">

        <tr align="center" >
            <td Style="padding: .5rem;">
                 <asp:TextBox ID="txtID" runat="server" ToolTip="ID" placeholder="ID" Visible="false" ></asp:TextBox>
                <asp:TextBox ID="txtLegajo" runat="server" ToolTip="Legajo" placeholder="Legajo" Width="200px" MaxLength="4" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
            </td>
            <td Style="padding: .5rem;">
                <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="Editar Producto" onclientclick="return confirm('¿Confirma las modificaciones?');" onclick="btnUpdate_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-abm" Style="vertical-align: sub;" />
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Eliminar Producto" onclientclick="return confirm('¿Seguro que desea eliminar al empleado?');" onclick="btnDelete_Click" ImageUrl="~/img/del-logo.png" cssclass="img-btn-del-abm" Style="vertical-align: sub;" />
            </td>
            <td Style="padding: .5rem;">
                <asp:TextBox ID="txtCuil" runat="server" ToolTip="Cuil" placeholder="Cuil" Width="200px" MaxLength="11" Rows="1" TextMode="Number" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
            </td>
        </tr>

        <tr align="center">
            <td Style="padding: .5rem;">
                <asp:TextBox ID="txtApeNom" runat="server" ToolTip="Apellido y Nombre" placeholder="Apellido y Nombre" Width="200px" MaxLength="100" Rows="1" onkeypress="javascript:return sololetras(event)" ></asp:TextBox>
            </td>
            <td Style="padding: .5rem;">
                <asp:TextBox ID="txtFechaAlta" runat="server" ToolTip="Fecha de Alta" placeholder="Fecha de Alta" Width="200px" MaxLength="10" ></asp:TextBox>
            </td>
            <td Style="padding: .5rem;">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" ToolTip="Fecha de Nacimiento" placeholder="Fecha de Nacimiento" Width="200px" MaxLength="10"></asp:TextBox>
            </td>
        </tr>

        <tr align="center">
            <td Style="padding: .5rem;">
                <asp:TextBox ID="txtMail" runat="server" ToolTip="e-Mail" placeholder="e-Mail" Width="200px"></asp:TextBox>
            </td>
            <td Style="padding: .5rem;">
                <asp:TextBox ID="txtTelefono" runat="server" ToolTip="Teléfono / Celular" placeholder="Teléfono / Celular" onkeypress="javascript:return solonumeros(event)" Width="200px"></asp:TextBox>
            </td>
            <td Style="padding: .5rem;">
                <asp:TextBox ID="txtServiciosRealizados" runat="server" Enabled="false" ToolTip="Cantidad de Servicios Realizados" placeholder="Cant. Servicios Realizados" Width="200px"></asp:TextBox>
            </td>
        </tr>

	</table>

    <div id="overlay" class="overlay" align="center">

        <div id="popup" class="popup">

		        <table style="width:80%; border: inset; border-color: black; background-color: rgb(255 255 255);">

                    <tr align="center" >
                        <td Style="padding: .5rem;">
                            <asp:TextBox ID="txtLegajo2" runat="server" TextMode="Number" ToolTip="Legajo" placeholder="Legajo" Width="200px" MaxLength="4" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                        </td>
                        <td align="center" style="vertical-align: super;  padding: .5rem;">
                            <asp:Button ID="btnCerraPopup" Text="X" runat="server" ToolTip="Cancelar" OnClick="btnCerraPopup_Click" cssclass="btn-cerrar-popup" />
                        </td>
                        <td Style="padding: .5rem;">
                            <asp:TextBox ID="txtCuil2" runat="server" ToolTip="Cuil" placeholder="Cuil" Width="200px" MaxLength="11" Rows="1" TextMode="Number" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                        </td>
                    </tr>
                                    
                    <tr align="center">
                        <td Style="padding: .5rem;">
                            <asp:TextBox ID="txtApeNom2" runat="server" ToolTip="Apellido y Nombre" placeholder="Apellido y Nombre" Width="200px" MaxLength="100" Rows="1" onkeypress="javascript:return sololetras(event)" ></asp:TextBox>
                        </td>
                        <td Style="padding: .5rem;">
                            <asp:TextBox ID="txtFechaAlta2" runat="server" Type="Date" ToolTip="Fecha de Alta" placeholder="Fecha de Alta" Width="200px" MaxLength="10" ></asp:TextBox>
                        </td>
                        <td Style="padding: .5rem;">
                            <asp:TextBox ID="txtFechaNacimiento2" runat="server" Type="Date" ToolTip="Fecha de Nacimiento" placeholder="Fecha de Nacimiento" Width="200px" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>

                    <tr align="center">
                        <td Style="padding: .5rem;">
                            <asp:TextBox ID="txtMail2" runat="server" ToolTip="e-Mail" placeholder="e-Mail" Width="200px"></asp:TextBox>
                        </td>
                        <td align="center" Style="padding: .5rem;">
                            <asp:Button ID="imgBtnAgregarEmpleado" Text="Agregar" runat="server" ToolTip="Agregar Empleado" onclientclick="return confirm('¿Confirma que desea agregar al nuevo empleado?');" onclick="imgBtnAgregarEmpleado_Click" cssclass="img-btn-add-producto" />
                        </td>
                        <td Style="padding: .5rem;">
                            <asp:TextBox ID="txtTelefono2" runat="server" ToolTip="Teléfono / Celular" placeholder="Teléfono / Celular" onkeypress="javascript:return solonumeros(event)" Width="200px"></asp:TextBox>
                        </td>
                    </tr>

		        </table>

                </div>

    </div>

    <asp:Button ID="btnExportExcel" runat="server" Text="Exportar a Excel" cssclass="btn-export-excel btn-export-excel-abm-emp" OnClick="btnExportExcel_Click" />

    <center>
        <asp:GridView ID="dgvEmpleados" runat="server" AllowSorting="True" OnSorting="dgvEmpleados_Sorting" AutoGenerateColumns="False" align="center" CellPadding="4" ForeColor="#333333" BackColor="Black" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CaptionAlign="Bottom" HorizontalAlign="Center" CssClass="dgv-abm-prod" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
                <asp:BoundField DataField="Cuil" HeaderText="Cuil" SortExpression="Cuil" />
                <asp:BoundField DataField="ApeNom" HeaderText="Apellido y Nombre" SortExpression="ApeNom" />
                <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta" SortExpression="FechaAlta" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" SortExpression="FechaNacimiento" />
                <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="ServiciosRealizados" HeaderText="Servicios Realizados" SortExpression="ServiciosRealizados" />
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
        <asp:SqlDataSource ID="ExportEmpleadosDB" runat="server" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" SelectCommand="SELECT * FROM [ExportEmpleados] ORDER BY [ApeNom], [FechaAlta]"></asp:SqlDataSource>
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
        var btnAbrirPopup = document.getElementById('btnPopUpAgregarEmpleado'),
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
