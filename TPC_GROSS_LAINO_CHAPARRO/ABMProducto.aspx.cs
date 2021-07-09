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
            string selectMarcas = "SELECT * FROM MarcasProducto";
            string selectProveedores = "SELECT * FROM Proveedores";

            if(!IsPostBack)
            {
                ddlTipoProducto.DataSource = sentencia.DSET(selectTP);
                ddlTipoProducto.DataMember = "datos";
                ddlTipoProducto.DataTextField = "Descripcion";
                ddlTipoProducto.DataValueField = "ID";
                ddlTipoProducto.DataBind();

                ddlMarcaProducto.DataSource = sentencia.DSET(selectMarcas);
                ddlMarcaProducto.DataMember = "datos";
                ddlMarcaProducto.DataTextField = "Descripcion";
                ddlMarcaProducto.DataValueField = "ID";
                ddlMarcaProducto.DataBind();

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
            string selectViewInventario = "SELECT * FROM ExportInventario";

            dgvInventario.DataSource = sentencia.DSET(selectViewInventario);
            dgvInventario.DataBind();
        }

        protected void AddArticulo(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtNombre.Text == "" || txtImagen.Text == ""
                    || txtFechaCompra.Text == "" || txtFechaVencimiento.Text == "" || txtCosto.Text == ""
                    || txtStock.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Hay campos vacíos')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    string Nombre = txtNombre.Text;
                    string Imagen = txtImagen.Text;
                    int IdTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue);
                    int IdMarca = Convert.ToInt32(ddlMarcaProducto.SelectedValue);
                    int IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
                    string FechaCompra = txtFechaCompra.Text;
                    string FechaVencimiento = txtFechaVencimiento.Text;
                    string Costo = txtCosto.Text;
                    string PrecioVenta = txtPrecioVenta.Text;
                    string Stock = txtStock.Text;

                    string sp_InsertInventario = "EXEC SP_INSERTAR_PRODUCTO '" + EAN + "', '" + Nombre + "', '" + Imagen + "', '" + IdTipoProducto
                    + "', '" + IdMarca + "', '" + IdProveedor + "', '" + FechaCompra + "', '" + FechaVencimiento + "', '" + Costo + "', '" + PrecioVenta
                    + "', '" + Stock + "'";
                
                    sentencia.IUD(sp_InsertInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha guardado el producto.')", true);

                    BindData();
                }
            }
            catch 
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha guardado el producto.')", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtNombre.Text == "" || txtImagen.Text == ""
                    || txtFechaCompra.Text == "" || txtFechaVencimiento.Text == "" || txtCosto.Text == ""
                    || txtStock.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Hay campos vacíos')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    string Nombre = txtNombre.Text;
                    string Imagen = txtImagen.Text;
                    int IdTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue);
                    int IdMarca = Convert.ToInt32(ddlMarcaProducto.SelectedValue);
                    int IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
 //ANDA SIN FECHA   //string FechaCompra = Convert.ToString(txtFechaCompra.Text);
                    //string FechaVencimiento = Convert.ToString(txtFechaVencimiento.Text);
                    string Costo = txtCosto.Text;
                    string PrecioVenta = txtPrecioVenta.Text;
                    int Stock = Convert.ToInt32(txtStock.Text);
                    int Estado = 0;
                    if (Convert.ToString(ddlEstado.SelectedValue) == "Activar") { Estado = 1; }


                    string sp_UpdateInventario = "EXEC SP_ACTUALIZAR_PRODUCTO '" + EAN + "', '" + Nombre + "', '" + Imagen + "', '" + IdTipoProducto
                    + "', '" + IdMarca + "', '" + IdProveedor + "', '" + Costo + "', '" + PrecioVenta
                    + "', '" + Stock + "', '" + Estado + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha modificado el producto.')", true);

                    BindData();
                }
            }
            catch
            { 
                //ClientScript.RegisterStartupScript(this.GetType(), "alert",
                //"alert('Se ha producido un error y no se ha modificado el producto.')", true);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('El EAN no puede estar vacío.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;

                    string sp_DeleteInventario = "EXEC SP_ELIMINAR_PRODUCTO '" + EAN + "'";

                    sentencia.IUD(sp_DeleteInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha eliminado el producto.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha eliminado el producto.')", true);
            }
        }
    }
}