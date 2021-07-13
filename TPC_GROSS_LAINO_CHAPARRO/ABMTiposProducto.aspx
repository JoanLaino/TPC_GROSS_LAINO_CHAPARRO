<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMTiposProducto.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMTiposProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <script>
        function solonumeros(e)
        {
            var key;
            if (window.event) { key = e.keyCode; }
            else if (e.which) { key = e.which;}
            if (key < 48 || key > 57) { return false;}
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

    <asp:DropDownList ID="ddlID" runat="server" Width="50px" AppendDataBoundItems="true" CssClass="ddl-abm-tipos-prod-id" AutoPostBack="True" OnSelectedIndexChanged="ddlID_SelectedIndexChanged">
        <asp:ListItem Value="0" Selected="True">ID</asp:ListItem>
    </asp:DropDownList>
    <asp:ImageButton ID="btnDelete" runat="server" onclientclick="return confirm('¿Seguro que desea eliminar el tipo de producto?');" onclick="btnDelete_Click" ImageUrl="~/img/del-logo.png" cssclass="img-btn-del-tipo-producto" />

    <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripción" onkeypress="javascript:return sololetras(event)" Width="200px" Style="position: relative; top: 0px; left: 68px;" ></asp:TextBox>
    <asp:ImageButton ID="btnUpdateDescription" runat="server" onclick="btnUpdateDescription_Click" ImageUrl="~/img/edit-logo.png" cssclass="img-btn-edit-tipo-producto img-btn-edit-descripcion-tipo-producto" />
    
    <asp:ImageButton ID="btnAddTipoProducto" runat="server" onclientclick="return confirm('¿Confirma agregar nuevo tipo de producto?');" onclick="btnAddTipoProducto_Click" ImageUrl="~/img/add-logo.png" cssclass="img-btn-add-tipo-producto" />

    <br /><br />

    <asp:GridView ID="dgvTiposProducto" runat="server" CssClass="dgv-abm-tipo-prod" align="center" CellPadding="4" ForeColor="#333333" BackColor="Black" BorderColor="Black" BorderStyle="Inset" BorderWidth="5px" CaptionAlign="Bottom" HorizontalAlign="Center" AutoGenerateColumns="True" Width="600px">
        <AlternatingRowStyle BackColor="White" />
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

</asp:Content>
