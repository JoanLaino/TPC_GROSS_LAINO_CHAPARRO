using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMProveedores : System.Web.UI.Page
    {
        AccesoDatos sentencia = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            dgvProveedores.DataSource = sentencia.DSET("SELECT * FROM ExportProveedores ORDER BY RazonSocial ASC");
            dgvProveedores.DataBind();
        }
    }
}