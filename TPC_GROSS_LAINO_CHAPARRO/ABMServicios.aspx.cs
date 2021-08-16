using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarNivelUsuario(); //El validar usuario siempre primero!


        }

        protected void validarNivelUsuario()
        {
            if (!(Session["usuario"] != null))
            {
                Session.Add("error", "Para ingresar a esta página debes estar logueado.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}