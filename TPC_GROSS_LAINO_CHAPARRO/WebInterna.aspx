<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebInterna.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.WebInterna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="web-interna-botonera">        
        <div>
            <center>
                <asp:Button ID="btnABMProductos" onclick="btnABMProductos_Click" runat="server" Text="ABM - Productos" CssClass="btn-interna-productos"/>
            </center>
        </div>
        <div>
            <center>
                <asp:Button ID="btnABMTiposProducto" onclick="btnABMTiposProducto_Click" runat="server" Text="ABM - Tipos de Producto" CssClass="btn-interna-tipos-productos" />
            </center>
        </div>
        <div>
            <center>
                <asp:Button ID="btnABMMarcasProducto" onclick="btnABMMarcasProducto_Click" runat="server" Text="ABM - Marcas (Productos)" CssClass="btn-interna-marcas-productos"/>
            </center>
        </div>
    </div>
    <div class="web-interna-botonera-2">
        <div>
            <center>
                <asp:Button ID="btnABMProveedores" onclick="btnABMProveedores_Click" runat="server" Text="ABM - Proveedores" CssClass="btn-interna-proveedores"/>
            </center>
        </div>
        <div>
            <center>
                <asp:Button ID="btnAMBMarcaVehiculos" onclick="btnAMBMarcaVehiculos_Click" runat="server" Text="ABM - Marcas (Vehiculos)" CssClass="btn-interna-marca-vehiculos"/>
            </center>
        </div>
        <div>            
            <center>
                <asp:Button ID="btnABMEmpleados" onclick="btnABMEmpleados_Click" runat="server" Text="ABM - Empleados" CssClass="btn-invisible"/>
            </center>            
        </div>
        <div>
            <center>
                <asp:Button ID="btnABMUsuario" onclick="btnABMUsuario_Click" runat="server" Text="ABM - Usuarios" CssClass="btn-invisible"/>
            </center> 
        </div>
        <div>
            <center>
                <asp:Button ID="btnABMClientes" onclick="btnABMClientes_Click" runat="server" Text="ABM - Clientes" CssClass="btn-interna-clientes"/>
            </center> 
        </div>
    </div>
              
</asp:Content>
