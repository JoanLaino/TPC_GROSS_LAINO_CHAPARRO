using System;
using System.Web;
using System.Web.UI;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarConexiónUsuario();

            cerrarConexiónUsuario();
        }


        protected void validarConexiónUsuario()
        {
            if (!(Session["usuario"] == null))
            {
                btnIniciarSesion.CssClass = "btn-invisible";
            }
        }

        protected void cerrarConexiónUsuario()
        {
            if (Session["usuario"] == null)
            {
                btnCerrarSesion2.CssClass = "btn-invisible";
            }
        }

        protected void btnCerrarSesion2_Click(object sender, EventArgs e)
        {
            Logout();
            Response.Redirect("Login.aspx", false);
        }

        public void Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }
    }
}