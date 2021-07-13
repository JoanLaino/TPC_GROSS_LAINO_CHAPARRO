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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtDescripcion.Text == "" || txtUrlImagen.Text == ""
                    || txtFechaCompra.Text == "" || txtFechaVencimiento.Text == "" || txtCosto.Text == ""
                    || txtStock.Text == "" || ddlMarcaProducto.SelectedIndex == 0 ||
                    ddlTipoProducto.SelectedIndex == 0 || ddlProveedor.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Hay campos vacíos')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    string Descripcion = txtDescripcion.Text;
                    string Imagen = txtUrlImagen.Text;
                    int IdTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue);
                    int IdMarca = Convert.ToInt32(ddlMarcaProducto.SelectedValue);
                    int IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
                    DateTime FechaCompra = Convert.ToDateTime(txtFechaCompra.Text);
                    DateTime FechaVencimiento = Convert.ToDateTime(txtFechaVencimiento.Text);
                    FechaCompra.ToShortDateString();
                    FechaVencimiento.ToShortDateString();
                    string Costo = txtCosto.Text;
                    string PrecioVenta = txtPrecioVenta.Text;
                    string Stock = txtStock.Text;

                    string sp_InsertInventario = "EXEC SP_INSERTAR_PRODUCTO '" + EAN + "', '" + Descripcion + "', '" + Imagen + "', '" + IdTipoProducto
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
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        /*protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtDescripcion.Text == "" || txtImagen.Text == ""
                    || txtFechaCompra.Text == "" || txtFechaVencimiento.Text == "" || txtCosto.Text == ""
                    || txtStock.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Hay campos vacíos.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    string Descripcion = txtDescripcion.Text;
                    string Imagen = txtUrlImagen.Text;
                    int IdTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue);
                    int IdMarca = Convert.ToInt32(ddlMarcaProducto.SelectedValue);
                    int IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
                    DateTime FechaCompra = Convert.ToDateTime(txtFechaCompra.Text);
                    DateTime FechaVencimiento = Convert.ToDateTime(txtFechaVencimiento.Text);
                    string Costo = txtCosto.Text;
                    string PrecioVenta = txtPrecioVenta.Text;
                    int Stock = Convert.ToInt32(txtStock.Text);
                    int Estado = 0;
                    if (ddlEstado.SelectedValue == "Activar") { Estado = 1; }

                    string sp_UpdateInventario = "EXEC SP_ACTUALIZAR_PRODUCTO '" + EAN + "', '" + Descripcion + "', '" + Imagen + "', " + IdTipoProducto
                    + ", " + IdMarca + ", " + IdProveedor + ", '" + FechaCompra.ToShortDateString() + "', '" + FechaVencimiento.ToShortDateString() + "', '" + Costo + "', '" + PrecioVenta
                    + "', '" + Stock + "', " + Estado;

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha modificado el producto.')", true);

                    BindData();
                }
            }
            catch
            { 
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el producto.')", true);
            }
        }*/

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
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateDescription_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtDescripcion.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN o Descipción vacíos.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    string Descripcion = txtDescripcion.Text;

                    string sp_UpdateInventario = "UPDATE Inventario SET Descripcion = '" + Descripcion + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha actualizado la descripción.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado la descripción.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateUrlImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtUrlImagen.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN o Url Imágen vacíos.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    string UrlImagen = txtUrlImagen.Text;

                    string sp_UpdateInventario = "UPDATE Inventario SET UrlImagen = '" + UrlImagen + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha actualizado la URL de la imágen.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado la URL de la imágen.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateTipoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || ddlTipoProducto.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN vacío o Tipo de Producto no seleccionado.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    int IdTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue);

                    string sp_UpdateInventario = "UPDATE Inventario SET IdTipo = '" + IdTipoProducto + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha actualizado el tipo de producto.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el tipo de producto.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateMarcaProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || ddlMarcaProducto.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN vacío o Marca no seleccionada.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    int IdMarcaProducto = Convert.ToInt32(ddlMarcaProducto.SelectedValue);

                    string sp_UpdateInventario = "UPDATE Inventario SET IdMarca = '" + IdMarcaProducto + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha actualizado la marca del producto.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado la marca del producto.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || ddlProveedor.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN vacío o Proveedor no seleccionado.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    int IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);

                    string sp_UpdateInventario = "UPDATE Inventario SET IdProveedor = '" + IdProveedor + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha actualizado el proveedor del producto.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el proveedor del producto.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateFechaCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtFechaCompra.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN o Fecha de Compra vacíos')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    DateTime FechaCompra = Convert.ToDateTime(txtFechaCompra.Text);

                    string sp_UpdateInventario = "UPDATE Inventario SET FechaCompra = '" + FechaCompra.ToShortDateString() + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha actualizado la fecha de compra del producto.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado la fecha de compra del producto.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateFechaVencimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtFechaVencimiento.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN o Fecha de Vencimiento vacíos')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    DateTime FechaVencimiento = Convert.ToDateTime(txtFechaVencimiento.Text);

                    string sp_UpdateInventario = "UPDATE Inventario SET FechaVencimiento = '" + FechaVencimiento.ToShortDateString() + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha actualizado la fecha de vencimiento del producto.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado la fecha de vencimiento del producto.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateCosto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtCosto.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN o Costo vacíos.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    string Costo = txtCosto.Text;

                    string sp_UpdateInventario = "UPDATE Inventario SET Costo = '" + Costo + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha modificado el costo del producto.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el costo producto.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdatePrecioVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtPrecioVenta.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN o Precio de Venta vacíos.')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    string PrecioVenta = txtPrecioVenta.Text;

                    string sp_UpdateInventario = "UPDATE Inventario SET PrecioVenta = '" + PrecioVenta + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha actualizado el precio de venta del producto.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el precio de venta del producto.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "" || txtStock.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN o Stock vacíos')", true);
                }
                else
                {
                    string EAN = txtEAN.Text;
                    int Stock = Convert.ToInt32(txtStock.Text);

                    string sp_UpdateInventario = "UPDATE Inventario SET Stock = Stock+'" + Stock + "' WHERE EAN = '" + EAN + "'";

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha Actualizado el stock.')", true);

                    BindData();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el stock.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnUpdateEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEAN.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('EAN vacío.')", true);
                }
                else
                {
                    if (ddlEstado.SelectedValue == "0")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Seleccione Estado...')", true);
                    }
                    else
                    {
                        string EAN = txtEAN.Text;
                        if (ddlEstado.SelectedValue == "Activar")
                        {
                            string sp_UpdateInventario = "UPDATE Inventario SET Estado = '1' WHERE EAN = '" + EAN + "'";

                            sentencia.IUD(sp_UpdateInventario);

                            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            "alert('Se ha activado el producto.')", true);

                            BindData();
                        }
                        else if (ddlEstado.SelectedValue == "Desactivar")
                        {
                            string sp_UpdateInventario = "UPDATE Inventario SET Estado = '0' WHERE EAN = '" + EAN + "'";

                            sentencia.IUD(sp_UpdateInventario);

                            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            "alert('Se ha desactivado el producto.')", true);

                            BindData();
                        }
                    }
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el estado del producto.')", true);
            }
            finally
            {
                Response.Redirect("ABMProductos.aspx");
            }
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if(ddlCampo.SelectedValue == "Seleccione...")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Campo no Seleccionado.')", true);
            }
            else if (txtCampo.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Complete el texto para buscar.')", true);
            }
            else if(ddlCampo.SelectedValue != "Seleccione" && txtCampo.Text != "")
            {
                string Campo = ddlCampo.SelectedValue;
                string Valor = txtCampo.Text;
                string selectFiltroProducto = "SELECT * FROM ExportInventario" +
                                            " WHERE " + Campo + " LIKE '%" + Valor + "%'";

                dgvInventario.DataSource = sentencia.DSET(selectFiltroProducto);
                dgvInventario.DataBind();
            }
        }
    }
}