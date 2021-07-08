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
        AccesoDatos sentencia = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectTP = "SELECT * FROM TiposProducto";
            string selectMarcas = "SELECT * FROM Marcas";
            string selectProveedores = "SELECT * FROM Proveedores";

            if(!IsPostBack)
            {
                ddlTipoProducto.DataSource = sentencia.DSET(selectTP);
                ddlTipoProducto.DataMember = "datos";
                ddlTipoProducto.DataTextField = "Descripcion";
                ddlTipoProducto.DataValueField = "ID";
                ddlTipoProducto.DataBind();

                ddlMarca.DataSource = sentencia.DSET(selectMarcas);
                ddlMarca.DataMember = "datos";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "ID";
                ddlMarca.DataBind();

                ddlProveedor.DataSource = sentencia.DSET(selectProveedores);
                ddlProveedor.DataMember = "datos";
                ddlProveedor.DataTextField = "RazonSocial";
                ddlProveedor.DataValueField = "ID";
                ddlProveedor.DataBind();

                BindData();
            }
        }

        public void BindData()
        {
            string selectEanInventario = "SELECT * FROM InventarioPrueba";

            string selectViewInventarioPrueba = "SELECT * FROM SV_INVENTARIO_PRUEBA";

            ddlEan.DataSource = sentencia.DSET(selectEanInventario);
            ddlEan.DataMember = "datos";
            ddlEan.DataTextField = "ID";
            ddlEan.DataValueField = "ID";
            ddlEan.DataBind();

            dgvInventario.DataSource = sentencia.DSET(selectViewInventarioPrueba);
            dgvInventario.DataBind();
        }

        protected void AddArticulo(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            int IdTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue);
            int IdMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            int IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);

            string sp_InsertInventarioPrueba = "EXEC SP_INSERTAR_PRODUCTO '"+Nombre+"', '"+IdTipoProducto+"', '"+IdMarca+"', '"+IdProveedor+"'";

            try
            {
                sentencia.IUD(sp_InsertInventarioPrueba);

                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha guardado el producto.')", true);

                BindData();
            }
            catch 
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha guardado el producto.')", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}