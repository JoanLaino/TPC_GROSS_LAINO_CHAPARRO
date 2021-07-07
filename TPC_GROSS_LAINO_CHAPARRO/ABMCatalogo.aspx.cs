using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMCatalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TiposProductoDB tiposProducto = new TiposProductoDB();
            try
            {
               
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                //Response.Redirect("Error.aspx");
            }
        }
    }
}