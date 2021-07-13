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
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void buscarEmpleado(object sender, EventArgs e)
        {
            List<Empleado> filtro;
            if (txtFiltro.Text != "")
            {
                filtro = lista.FindAll(Art => Art.Name.ToUpper().Contains(txtFiltro.Text.ToUpper()) || Art.CuilCuit.ToUpper().Contains(txtFiltro.Text.ToUpper()) || Art.Legajo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                lista = null;
                lista = filtro;
            }
        }
    }
}
