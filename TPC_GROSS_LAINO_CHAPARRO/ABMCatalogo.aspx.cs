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
    public partial class ABMCatalogo : System.Web.UI.Page
    {
        public List<Producto> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoDB productoDB = new ProductoDB();
            try
            {
                lista = productoDB.Listar();

                Session.Add("listadoProductos", lista);

                dgvProductos.DataSource = lista;
                dgvProductos.DataBind();
                Producto seleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}