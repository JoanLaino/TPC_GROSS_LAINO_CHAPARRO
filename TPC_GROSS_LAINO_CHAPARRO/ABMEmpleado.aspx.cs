using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMEmpleado : System.Web.UI.Page
    {
        public List<Empleado> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpleadosDB emple = new EmpleadosDB();
            try
            {
                lista = emple.Listar();

                Session.Add("listadoempleados", lista);
            }
            catch (Exception ex)
            {
                Response.Redirect("https://www.google.com.ar");
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
