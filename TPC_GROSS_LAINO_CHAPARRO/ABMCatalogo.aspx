<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCatalogo.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <center>
    <div>
    <div>
        <asp:Button runat="server" Text="Agregar" Class="btn-abm btn-add-abm"/> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="Eliminar" Class="btn-abm btn-delete-abm" ID="BtnDelAbmCat" OnClick="btnDelAbmCat_Click"/> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="Modificar" Class="btn-abm btn-edit-abm"/>
        <br />
        <br />
        <asp:GridView ID="dgvCatalogo" runat="server" Style="text-align: center" CellPadding="10" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
            <Columns>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkActivo" runat="server" class="chkb-abm"/>
                    </ItemTemplate>
                </asp:TemplateField>

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
