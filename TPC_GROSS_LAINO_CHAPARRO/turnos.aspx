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
        <asp:Calendar ID="calendarioTurnos" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" CellPadding="5" CellSpacing="5" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" ToolTip="Seleccioná un día" OnDayRender="calendarioTurnos_DayRender" Width="220px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
    </center>
    </div>

</asp:Content>
