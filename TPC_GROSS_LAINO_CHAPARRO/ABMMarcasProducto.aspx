﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMMarcasProducto.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMMarcasProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="h1-abm-prod">ABM - Marcas de productos</h1>

    <br />

    <asp:ImageButton ID="btnBuscar" runat="server" ToolTip="Buscar Marca" onclick="btnBuscar_Click" ImageUrl="~/img/find-logo.png" cssclass="btn-buscar-filtro-abm-producto"/>
    <asp:textbox ID="txtBuscar" runat="server" ToolTip="Filtro Marca" placeholder="Ingrese Marca" aria-label="Marca" Style="vertical-align: middle; width: 200px;"></asp:TextBox>
    
    <button id="btnAgregar" ToolTip="Agregar nueva Marca" class="btnAddNewBrand" style="vertical-align: middle !important;">Agregar Nueva</button>

    <br /><br />

    <table>

        <tr>
            <td>
                <span id="span-id-marca" align="left" style="font-size: 20px;">ID</span>
                <asp:TextBox id="txtIdMarca" runat="server" TooTip="ID" placeholder="ID" onkeypress="javascript:return solonumeros(event)" Style="width: 60px; text-align:center; vertical-align: bottom !important;" />
            </td>
            <td>
                <asp:TextBox id="txtMarca" runat="server" ToolTip="Descripción" placeholder="Descripción" onkeypress="javascript:return sololetras(event)" Style="width: 333px; vertical-align: middle;" />
            </td>
            <td align="center">
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="Editar Marca" onclientclick="return confirm('¿Confirma el cambio?');" onclick="btnUpdate_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-producto" Style="width: 30px; vertical-align: bottom !important;" />
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Eliminar Marca" onclientclick="return confirm('¿Seguro que desea eliminar el Tipo de Producto?');" onclick="btnDelete_Click" ImageUrl="~/img/del-logo.png" cssclass="img-btn-del-producto" Style="vertical-align: bottom !important;" />
            </td>
        </tr>

    </table>

    <div id="overlay" class="overlay" align="center">

        <div id="popup" class="popup">

		    <table style="width:80%; border: inset; border-color: black; background-color: rgb(255 255 255);">

                <tr align="center">
                    <td align="center" style="padding-top: .5rem; padding-bottom: .5rem;">
                        <asp:Button ID="btnCerraPopup" Text="X" runat="server" ToolTip="Cancelar" cssclass="btn-cerrar-popup" onclick="btnCerraPopup_Click" />
                    </td>
                </tr>
                
                <tr align="center">
                    <td style="padding-left: .5rem; padding-right: .5rem;">
                        <asp:TextBox id="txtMarca2" runat="server" ToolTip="Descripción" placeholder="Descripción" onkeypress="javascript:return sololetras(event)" />
                    </td>
                </tr>
                <tr align="center">
                    <td style="padding-top: .5rem; padding-bottom: .5rem;">
                        <asp:Button ID="imgBtnAgregarMarca" Text="Agregar" runat="server" ToolTip="Agregar Marca" onclientclick="return confirm('¿Confirma que desea agregar el nuevo producto?');" onclick="btnAgregar_Click" cssclass="img-btn-add-producto" />
                    </td>
                </tr>

		    </table>

        </div>

    </div>

    <br />

    <center>
        <asp:GridView ID="dgvMarcasProducto" runat="server" align="center" CellPadding="4" ForeColor="#333333" BackColor="Black" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CaptionAlign="Bottom" HorizontalAlign="Center" AutoGenerateColumns="False" PageSize="2" CssClass="dgv-abm-prod">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
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
        <asp:SqlDataSource ID="MarcasProducto" runat="server" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" SelectCommand="SELECT * FROM [MarcasProducto] ORDER BY [ID] ASC"></asp:SqlDataSource>
    </center>

    <script>
        var btnAbrirPopup = document.getElementById('btnAgregar'),
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