<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TPC_GROSS_LAINO_CHAPARRO.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <center>
        <div>               
            <div class="form-group stl-frm-log">
                <label for="exampleInputEmail1">Usuario</label>
                <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Contraseña</label>
                <input type="password" class="form-control" id="exampleInputPassword1">
                <small id="emailHelp" class="form-text text-muted">Su contraseña no será compartida con nadie.</small>
            </div>
            <div class="form-group form-check">
                <input type="checkbox" class="form-check-input" id="exampleCheck1">
                <label class="form-check-label" for="exampleCheck1">Recordar Usuario</label>
            </div>
                <button type="submit" class="btn btn-primary">Iniciar Sesión</button>            
        </div>
    </center>

</asp:Content>
