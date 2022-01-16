using System;
using System.Web;
using System.Web.UI;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pagina = HttpContext.Current.Request.Url.AbsoluteUri;

            if (pagina == "https://localhost:44347/index" || pagina == "https://localhost:44347/turnos"
            || pagina == "https://localhost:44347/catalogoProductos" || pagina == "https://localhost:44347/contacto"
            || pagina == "https://localhost:44347/login" || pagina == "https://localhost:44347/registroVehiculo"
            || pagina == "https://localhost:44347/registroCliente")
            {
                if (!(Session["usuario"] == null))
                {
                    lblWebInterna.Visible = true;
                }
                else
                {
                    btnIniciarSesion.CssClass = "btn-invisible";
                    lblWebInterna.Visible = false;
                }
            }
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
            Response.Redirect("index.aspx", false);
        }

        public void Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }
    }
}
