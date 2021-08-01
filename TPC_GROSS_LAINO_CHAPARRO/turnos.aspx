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

    <div class="calendario-turnos">
    <center>
        <h2 class="ttl-turno">¡Reservá tu turno Online!</h2>
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
         <asp:DropDownList ID="ddlHoraTurno" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnAgregarTurno" OnClick="btnAgregarTurno_Click" runat="server" Text="Reservar Turno"></asp:Button>
    </center>
    </div>

    <asp:TextBox ID="txtPruebaTurnos" runat="server" Visible="false"></asp:TextBox>
    
    <br />

    <center>
        <asp:GridView ID="dgvTurnos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="Both" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CssClass="dgv-abm-prod" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Dia" HeaderText="Día" ReadOnly="True" SortExpression="Dia" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" ReadOnly="True" SortExpression="Hora" />
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

    <asp:SqlDataSource ID="ExportTurnos" runat="server" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" SelectCommand="SELECT * FROM [ExportTurnos] ORDER BY [ID]"></asp:SqlDataSource>

</asp:Content>
