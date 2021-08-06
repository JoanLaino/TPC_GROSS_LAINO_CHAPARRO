<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="turnos.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {            
            background-image: url("../img/fondo-2.jpg");
            background-color: #FFFFFF4D !important;
            width: 100%;
            height: 100vh;
            background-size: cover;
            background-position: center;
        }
    </style>

    
    <div class="calendario-turnos" >
        <center>
            <h2 class="ttl-turno">¡Reservá tu turno Online!</h2>
            <asp:Label ID="lblRegistro" runat="server" Text="Si es su primera vez, regístrese!" Style="font-size: 10px;" />
            <br />
            <asp:Button ID="btnRegistro" runat="server" ToolTip="Registrarse" Text="Resgistrarse" onclick="btnRegistro_Click" cssclass="btn-confirmar-turno-1" style="vertical-align: middle !important;" />
            <br /><br />
            <asp:Label ID="lblCalendario" Text="Seleccioná una fecha:" runat="server" Style="font-size: 10px;" />
            <asp:Calendar ID="calendarioTurnos" runat="server" BackColor="#FFFFCC" OnSelectionChanged="calendarioTurnos_SelectionChanged" BorderColor="#FFCC66" BorderWidth="1px" CellPadding="5" CellSpacing="5" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" ToolTip="Seleccioná un día" OnDayRender="calendarioTurnos_DayRender" Width="220px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            <br />
            <asp:Label ID="lblHora" Text="Seleccioná un horario:" runat="server" Style="font-size: 10px;" />
            <asp:DropDownList ID="ddlHoraTurno" runat="server">
            </asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblCuitDni" Text="Ingrese su CUIT / DNI:" runat="server" Style="font-size: 10px;" />
            <br />
            <asp:TextBox ID="txtCuitDni" runat="server" tooltip="CUIT / DNI" placeholder="CUIT / DNI" onkeypress="javascript:return solonumeros(event);" width="200px" MaxLength="11" />
            <br /><br />
            <asp:Label ID="lblVehiculos" Text="Seleccione vehículo:" runat="server" Style="font-size: 10px;" />
            <asp:DropDownList ID="ddlVehiculos" runat="server" Style="background-color: white;">
            </asp:DropDownList>
            <br /><br />
            <asp:Button ID="btnBuscarCuitDni" runat="server" Text="Siguiente paso" onclick="btnBuscarCuitDni_Click" cssclass="btn-confirmar-turno-1" style="vertical-align: middle !important;" />
            
        </center>
    </div>

    <br />

    <div class="grilla-turnos">
        <center>
            <asp:GridView ID="dgvTurnos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="Both" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CssClass="dgv-abm-prod" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Dia" HeaderText="Día" ReadOnly="True" SortExpression="Dia" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha" />
                    <asp:BoundField DataField="Hora" HeaderText="Hora" ReadOnly="True" SortExpression="Hora" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" ReadOnly="True" SortExpression="Cliente" />
                    <asp:BoundField DataField="Patente" HeaderText="Patente" ReadOnly="True" SortExpression="Patente" />
                    <asp:BoundField DataField="IDHorario" HeaderText="IDHorario" SortExpression="IDHorario" />
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
        </center>
    </div>

    <asp:SqlDataSource ID="ExportTurnos" runat="server" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" SelectCommand="SELECT * FROM [ExportTurnos] ORDER BY [ID]"></asp:SqlDataSource>

     <script>
         function solonumeros(e) {
             var key;
             if (window.event) { key = e.keyCode; }
             else if (e.which) { key = e.which; }
             if (key < 48 || key > 57) { return false; }
             return true;
         }
    </script>

</asp:Content>
