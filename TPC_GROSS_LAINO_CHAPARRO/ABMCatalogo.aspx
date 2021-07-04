<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCatalogo.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function checkSeleccionado(seleccionado) {
            //obtenemos la referencias de la fila de la tabla
            var row = seleccionado.parentNode.parentNode;

            //verificamos si esta seleccionada
            if (seleccionado.checked) {
                row.style.backgroundColor = "aqua";
            }
            else {
                row.style.backgroundColor = "white";
            }
        }
    
    </script>

    <center>
    <div>
    <div>
        <asp:Button runat="server" Text="Agregar" Class="btn-abm btn-add-abm"/> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="Eliminar" Class="btn-abm btn-delete-abm" ID="BtnDelAbmCat" BorderStyle="None" OnClick="BtnDelAbmCat_Click" OnLoad="BtnDelAbmCat_Click"/> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="Modificar" Class="btn-abm btn-edit-abm"/>
        <br />
        <br />
        <asp:GridView ID="dgvCatalogo" runat="server" Style="text-align: center" CellPadding="10" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" OnSelectedIndexChanged="dgvCatalogo_SelectedIndexChanged"> 

            
            <Columns>
                <asp:CommandField CausesValidation="False" InsertVisible="False" ShowCancelButton="False" ShowHeader="True" ShowSelectButton="True" Visible="True" ButtonType="Button" SelectText="■" />
            </Columns>

            
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
         
        </asp:GridView>
    </div> 
    </div>
    </center>    

</asp:Content>
