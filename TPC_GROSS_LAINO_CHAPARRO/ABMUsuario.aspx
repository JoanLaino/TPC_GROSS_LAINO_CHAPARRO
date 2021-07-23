<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMUsuario.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.ABMUsuario_aspx" %>
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

    <center>
        <div>               
            <div class="form-group stl-frm-log">
                <label for="exampleInputEmail1">Nuevo Usuario</label>
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Nuevo Usuario" />
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="*****" type="password" />       
                <label for="exampleInputPassword1">Repita su Contraseña</label>
                <asp:TextBox ID="txtPassword2" runat="server" CssClass="form-control" placeholder="*****" type="password" />
                <small id="emailHelp" class="form-text text-muted">Su contraseña no será compartida con nadie.</small>
            </div>
            <div>
                <label for="exampleInputEmail1">Mail</label>
                <asp:TextBox ID="mail" runat="server" CssClass="form-control" placeholder="Mail" />
            </div>
            <label for="exampleInputPassword1">Tipo de Usuario</label>
            <div>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </div>
            <br />
            <asp:Button ID="btnIngresar" runat="server" CssClass="btn btn-primary" Text="Iniciar Sesión" />
                            
        </div>
    </center>

</asp:Content>
