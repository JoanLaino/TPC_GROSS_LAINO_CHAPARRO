<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMTurnos.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMTurnos" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="h1-abm">ABM - Turnos</h1>

    <br />

    <asp:DropDownList ID="ddlFiltroBuscar" runat="server" AppendDataBoundItems="true">
        <asp:ListItem Value="0">Buscar por...</asp:ListItem>
        <asp:ListItem Value="CUIT_DNI">CUIT / DNI</asp:ListItem>
        <asp:ListItem Value="Patente">Patente</asp:ListItem>
        <asp:ListItem Value="Fecha">Fecha</asp:ListItem>
        <asp:ListItem Value="ID">ID</asp:ListItem>
    </asp:DropDownList>

    <asp:TextBox ID="txtBuscarFiltro" runat="server" PlaceHolder="Texto buscado..." />
    
    <asp:Button ID="btnBuscarFiltro" runat="server" Text="Buscar" onclick="btnBuscarFiltro_Click" />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <asp:Label Text="Mostrar turnos..." runat="server" Style="font-size: 16px;" />
    <asp:DropDownList ID="ddlMostrar" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlMostrar_SelectedIndexChanged" >
        <asp:ListItem Value="0">Todos</asp:ListItem>
        <asp:ListItem Value="Hoy">De hoy</asp:ListItem>
        <asp:ListItem Value="Cumplidos">Cumplidos</asp:ListItem>
        <asp:ListItem Value="Futuros">Futuros</asp:ListItem>
    </asp:DropDownList>
    
    <br /><br />

    <asp:Button ID="btnExportExcel" runat="server" Text="Exportar a Excel" cssclass="btn-export-excel btn-export-excel-abm-turnos" OnClick="btnExportExcel_Click" />
    &nbsp;&nbsp;
    <Button ID="btnEditar" style="border-radius: 100px; background-color: transparent; border-color: transparent;" >
        <img src="img/edit-logo.png" alt="..." class="img-btn-edit-abm" />
    </Button>
    &nbsp;&nbsp;
    <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Cancelar Turno" onclientclick="return confirm('¿Seguro que desea cancelar el Turno?');" onclick="btnDelete_Click" ImageUrl="~/img/del-logo.png" cssclass="img-btn-del-abm" Style="vertical-align: middle;" />
    
    <div id="overlay" class="overlay" align="center">

        <div id="popup" class="popup">

		    <table style="width:80%; border: inset; border-color: black; background-color: rgb(255 255 255);">

                <tr align="center">
                    <td align="right" style="padding: .5rem;">
                        <asp:Button ID="btnCerraPopup" Text="X" runat="server" ToolTip="Cancelar" cssclass="btn-cerrar-popup" />
                    </td>
                </tr>
                <tr align="center">
                    <td style="padding: .5rem;">
                        <asp:TextBox id="txtMarca2" runat="server" ToolTip="Descripción" placeholder="Descripción" onkeypress="javascript:return sololetras(event)" />
                    </td>
                </tr>
                <tr align="center">
                    <td style="padding: .5rem;">
                        <asp:ImageButton ID="btnUpdate" runat="server" ToolTip="Editar Turno" onclientclick="return confirm('¿Confirma el cambio?');" onclick="btnUpdate_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-abm" Style="width: 40px;" />
                    </td>
                </tr>

		    </table>

        </div>

    </div>

    <br /><br /><br />

    <center>
        <asp:GridView ID="dgvTurnos" runat="server" AllowSorting="True" OnSorting="dgvTurnos_Sorting" align="center" CellPadding="4" ForeColor="#333333" BackColor="Black" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CaptionAlign="Bottom" HorizontalAlign="Center" AutoGenerateColumns="False" PageSize="2" CssClass="dgv-abm-prod" DataKeyNames="ID">
            <AlternatingRowStyle BackColor="White" />
            
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Dia" HeaderText="Día" SortExpression="Dia" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" ReadOnly="True" SortExpression="Hora" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" ReadOnly="True" SortExpression="Cliente" />
                <asp:BoundField DataField="CUIT_DNI" HeaderText="CUIT / DNI" ReadOnly="True" SortExpression="CUIT_DNI" />
                <asp:BoundField DataField="Patente" HeaderText="Patente" ReadOnly="True" SortExpression="Patente" />
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
        
        <asp:SqlDataSource ID="ExportTurnos" runat="server" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" SelectCommand="SELECT * FROM [ExportTurnos]"></asp:SqlDataSource>
        
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
        var btnAbrirPopup = document.getElementById('btnEditar'),
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
