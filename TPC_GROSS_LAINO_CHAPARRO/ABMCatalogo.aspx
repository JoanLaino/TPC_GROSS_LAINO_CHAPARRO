<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCatalogo.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMCatalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <center>
        
        <asp:Button runat="server" Text="Agregar" ID="btnAgregar" Class="btn-abm btn-add-abm"/>
        <asp:DropDownList ID="ddlTiposProducto" runat="server" DataSourceID="SqlDataSource2" DataTextField="Descripcion" DataValueField="Descripcion">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" SelectCommand="SELECT [Descripcion] FROM [TiposProducto] ORDER BY [ID]"></asp:SqlDataSource>
        <br />
        <br />

        <div>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Codigo" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" CausesValidation="False" InsertVisible="False" />
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" InsertVisible="False" ReadOnly="True" SortExpression="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Imagen" HeaderText="Imagen" SortExpression="Imagen" />
            <asp:BoundField DataField="IdTipo" HeaderText="IdTipo" SortExpression="IdTipo" />
            <asp:BoundField DataField="IdMarca" HeaderText="IdMarca" SortExpression="IdMarca" />
            <asp:BoundField DataField="IdProveedor" HeaderText="IdProveedor" SortExpression="IdProveedor" />
            <asp:BoundField DataField="FechaCompra" HeaderText="FechaCompra" SortExpression="FechaCompra" />
            <asp:BoundField DataField="FechaVencimiento" HeaderText="FechaVencimiento" SortExpression="FechaVencimiento" />
            <asp:BoundField DataField="Costo" HeaderText="Costo" SortExpression="Costo" />
            <asp:BoundField DataField="PrecioVenta" HeaderText="PrecioVenta" SortExpression="PrecioVenta" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:GROSS_LAINO_CHAPARRO_DBConnectionString %>" DeleteCommand="DELETE FROM [Inventario] WHERE [Codigo] = @original_Codigo AND [Nombre] = @original_Nombre AND [Imagen] = @original_Imagen AND [IdTipo] = @original_IdTipo AND [IdMarca] = @original_IdMarca AND [IdProveedor] = @original_IdProveedor AND [FechaCompra] = @original_FechaCompra AND (([FechaVencimiento] = @original_FechaVencimiento) OR ([FechaVencimiento] IS NULL AND @original_FechaVencimiento IS NULL)) AND [Costo] = @original_Costo AND [PrecioVenta] = @original_PrecioVenta AND [Stock] = @original_Stock AND [Estado] = @original_Estado" InsertCommand="INSERT INTO [Inventario] ([Nombre], [Imagen], [IdTipo], [IdMarca], [IdProveedor], [FechaCompra], [FechaVencimiento], [Costo], [PrecioVenta], [Stock], [Estado]) VALUES (@Nombre, @Imagen, @IdTipo, @IdMarca, @IdProveedor, @FechaCompra, @FechaVencimiento, @Costo, @PrecioVenta, @Stock, @Estado)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Inventario]" UpdateCommand="UPDATE [Inventario] SET [Nombre] = @Nombre, [Imagen] = @Imagen, [IdTipo] = @IdTipo, [IdMarca] = @IdMarca, [IdProveedor] = @IdProveedor, [FechaCompra] = @FechaCompra, [FechaVencimiento] = @FechaVencimiento, [Costo] = @Costo, [PrecioVenta] = @PrecioVenta, [Stock] = @Stock, [Estado] = @Estado WHERE [Codigo] = @original_Codigo">
        <DeleteParameters>
            <asp:Parameter Name="original_Codigo" Type="Int64" />
            <asp:Parameter Name="original_Nombre" Type="String" />
            <asp:Parameter Name="original_Imagen" Type="String" />
            <asp:Parameter Name="original_IdTipo" Type="Int64" />
            <asp:Parameter Name="original_IdMarca" Type="Int64" />
            <asp:Parameter Name="original_IdProveedor" Type="Int64" />
            <asp:Parameter DbType="Date" Name="original_FechaCompra" />
            <asp:Parameter DbType="Date" Name="original_FechaVencimiento" />
            <asp:Parameter Name="original_Costo" Type="Decimal" />
            <asp:Parameter Name="original_PrecioVenta" Type="Decimal" />
            <asp:Parameter Name="original_Stock" Type="Int32" />
            <asp:Parameter Name="original_Estado" Type="Boolean" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="Imagen" Type="String" />
            <asp:Parameter Name="IdTipo" Type="Int64" />
            <asp:Parameter Name="IdMarca" Type="Int64" />
            <asp:Parameter Name="IdProveedor" Type="Int64" />
            <asp:Parameter DbType="Date" Name="FechaCompra" />
            <asp:Parameter DbType="Date" Name="FechaVencimiento" />
            <asp:Parameter Name="Costo" Type="Decimal" />
            <asp:Parameter Name="PrecioVenta" Type="Decimal" />
            <asp:Parameter Name="Stock" Type="Int32" />
            <asp:Parameter Name="Estado" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="Imagen" Type="String" />
            <asp:Parameter Name="IdTipo" Type="Int64" />
            <asp:Parameter Name="IdMarca" Type="Int64" />
            <asp:Parameter Name="IdProveedor" Type="Int64" />
            <asp:Parameter DbType="Date" Name="FechaCompra" />
            <asp:Parameter DbType="Date" Name="FechaVencimiento" />
            <asp:Parameter Name="Costo" Type="Decimal" />
            <asp:Parameter Name="PrecioVenta" Type="Decimal" />
            <asp:Parameter Name="Stock" Type="Int32" />
            <asp:Parameter Name="Estado" Type="Boolean" />
            <asp:Parameter Name="original_Codigo" Type="Int64" />
            <asp:Parameter Name="original_Nombre" Type="String" />
            <asp:Parameter Name="original_Imagen" Type="String" />
            <asp:Parameter Name="original_IdTipo" Type="Int64" />
            <asp:Parameter Name="original_IdMarca" Type="Int64" />
            <asp:Parameter Name="original_IdProveedor" Type="Int64" />
            <asp:Parameter DbType="Date" Name="original_FechaCompra" />
            <asp:Parameter DbType="Date" Name="original_FechaVencimiento" />
            <asp:Parameter Name="original_Costo" Type="Decimal" />
            <asp:Parameter Name="original_PrecioVenta" Type="Decimal" />
            <asp:Parameter Name="original_Stock" Type="Int32" />
            <asp:Parameter Name="original_Estado" Type="Boolean" />
        </UpdateParameters>
    </asp:SqlDataSource>
           </div>
    </center>

</asp:Content>
