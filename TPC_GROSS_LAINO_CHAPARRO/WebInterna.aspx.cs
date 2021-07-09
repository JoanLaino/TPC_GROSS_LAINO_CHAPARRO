using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class WebInterna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnABMProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMProducto.aspx");
        }

        protected void btnABMTiposProducto_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ABMTiposProducto.aspx");
        }

        protected void btnABMMarcasProducto_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ABMMarcasProducto.aspx");
        }

        protected void btnABMProveedores_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ABMProveedores.aspx");
        }
    }
}