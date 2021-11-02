using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using Negocio;
using Dominio;
using System.Data;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMCatalogo : System.Web.UI.Page
    {
        string urlImagenVacia = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1024px-Imagen_no_disponible.svg.png";

        AccesoDatos sentencia = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            validarNivelUsuario();

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

                ddlTipoProducto2.DataSource = sentencia.DSET(selectTP);
                ddlTipoProducto2.DataMember = "datos";
                ddlTipoProducto2.DataTextField = "Descripcion";
                ddlTipoProducto2.DataValueField = "ID";
                ddlTipoProducto2.DataBind();

                ddlMarcaProducto2.DataSource = sentencia.DSET(selectMarcas);
                ddlMarcaProducto2.DataMember = "datos";
                ddlMarcaProducto2.DataTextField = "Descripcion";
                ddlMarcaProducto2.DataValueField = "ID";
                ddlMarcaProducto2.DataBind();

                ddlProveedor2.DataSource = sentencia.DSET(selectProveedores);
                ddlProveedor2.DataMember = "datos";
                ddlProveedor2.DataTextField = "RazonSocial";
                ddlProveedor2.DataValueField = "ID";
                ddlProveedor2.DataBind();

                BindData();
            }
        }

        protected void validarNivelUsuario()
        {
            if (!(Session["usuario"] != null))
            {
                Session.Add("error", "Para ingresar a esta página debes estar logueado.");
                Response.Redirect("Error.aspx", false);
            }
        }

        public void BindData()
        {
            txtBuscar.Text = "";

            txtEan.Text = "";
            txtDescripcion.Text = "";
            ddlTipoProducto.SelectedValue = "0";
            ddlMarcaProducto.SelectedValue = "0";
            ddlProveedor.SelectedValue = "0";
            txtFechaCompra.Text = "";
            txtFechaVencimiento.Text = "";
            txtCosto.Text = "";
            txtPrecioVenta.Text = "";
            txtStock.Text = "";
            ddlEstado.SelectedValue = "0";

            txtEan2.Text = "";
            txtDescripcion2.Text = "";
            txtUrlImagen2.Text = "";
            ddlTipoProducto2.SelectedValue = "0";
            ddlMarcaProducto2.SelectedValue = "0";
            ddlProveedor2.SelectedValue = "0";
            txtFechaCompra2.Text = "";
            txtFechaVencimiento2.Text = "";
            txtCosto2.Text = "";
            txtPrecioVenta2.Text = "";
            txtStock2.Text = "";
            ddlEstado2.SelectedValue = "0";

            txtEan.Enabled = false;
            txtDescripcion.Enabled = false;
            ddlTipoProducto.Enabled = false;
            ddlMarcaProducto.Enabled = false;
            ddlProveedor.Enabled = false;
            txtFechaCompra.Enabled = false;
            txtFechaVencimiento.Enabled = false;
            txtCosto.Enabled = false;
            txtPrecioVenta.Enabled = false;
            txtStock.Enabled = false;
            ddlEstado.Enabled = false;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnUpdateImage.Visible = true;
            btnUpdateImage.Enabled = false;
            btnDeleteImage.Visible = true;
            btnDeleteImage.Enabled = false;
            fileUploadImgProd.Visible = false;
            btnExportExcel.Visible = true;
            dgvInventario.Visible = true;

            CargarInventario();
        }

        public void mostrarScriptMensaje(string mensaje)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert",
            "alert('" + mensaje + "')", true);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEan2.Text == "" || txtDescripcion2.Text == "" || txtUrlImagen2.Text == ""
                    || txtFechaCompra2.Text == "" || txtFechaVencimiento2.Text == "" || txtCosto2.Text == ""
                    || txtStock2.Text == "" || ddlMarcaProducto2.SelectedIndex == 0 ||
                    ddlTipoProducto2.SelectedIndex == 0 || ddlProveedor2.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Hay campos vacíos o sin seleccionar.')", true);
                }
                else
                {
                    string EAN = txtEan2.Text;
                    string Descripcion = txtDescripcion2.Text;
                    string Imagen = txtUrlImagen2.Text;
                    int IdTipoProducto = Convert.ToInt32(ddlTipoProducto2.SelectedValue);
                    int IdMarca = Convert.ToInt32(ddlMarcaProducto2.SelectedValue);
                    int IdProveedor = Convert.ToInt32(ddlProveedor2.SelectedValue);
                    DateTime FechaCompra = Convert.ToDateTime(txtFechaCompra2.Text);
                    DateTime FechaVencimiento = Convert.ToDateTime(txtFechaVencimiento2.Text);
                    FechaCompra.ToShortDateString();
                    FechaVencimiento.ToShortDateString();
                    string Costo = txtCosto2.Text;
                    string PrecioVenta = txtPrecioVenta2.Text;
                    string Stock = txtStock2.Text;
                    int Estado = 1;

                    if(ddlEstado2.SelectedValue == "2") { Estado = 0; }

                    string sp_InsertInventario = "EXEC SP_INSERTAR_PRODUCTO '" + EAN + "', '" + Descripcion + "', '" + Imagen + "', '" + IdTipoProducto
                    + "', '" + IdMarca + "', '" + IdProveedor + "', '" + FechaCompra + "', '" + FechaVencimiento + "', '" + Costo + "', '" + PrecioVenta
                    + "', '" + Stock + "', '" + Estado + "'";
                
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
                if (txtEan.Text == "" || txtDescripcion.Text == "" || ddlTipoProducto.SelectedIndex == 0 
                    || ddlMarcaProducto.SelectedIndex == 0
                    || ddlProveedor.SelectedIndex == 0 || txtFechaCompra.Text == ""
                    || txtFechaVencimiento.Text == "" || txtCosto.Text == ""
                    || txtStock.Text == "" || ddlEstado.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Hay campos vacíos o sin seleccionar.')", true);
                }
                else
                {
                    string ID = txtID.Text;
                    string EAN = txtEan.Text;
                    string Descripcion = txtDescripcion.Text;
                    int IdTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue);
                    int IdMarca = Convert.ToInt32(ddlMarcaProducto.SelectedValue);
                    int IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
                    DateTime FechaCompra = Convert.ToDateTime(txtFechaCompra.Text);
                    DateTime FechaVencimiento = Convert.ToDateTime(txtFechaVencimiento.Text);
                    string Costo = txtCosto.Text;
                    string PrecioVenta = txtPrecioVenta.Text;
                    int Stock = Convert.ToInt32(txtStock.Text);
                    int Estado = 0;
                    if (ddlEstado.SelectedValue == "1") { Estado = 1; }

                    string sp_UpdateInventario = "EXEC SP_ACTUALIZAR_PRODUCTO " + ID + ", " + EAN + ", '" + Descripcion + "', " + IdTipoProducto
                    + ", " + IdMarca + ", " + IdProveedor + ", '" + FechaCompra.ToShortDateString() + "', '" + FechaVencimiento.ToShortDateString() + "', " + Costo + ", " + PrecioVenta
                    + ", " + Stock + ", " + Estado;

                    sentencia.IUD(sp_UpdateInventario);

                    int tamanio = fileUploadImgProd.PostedFile.ContentLength;

                    try
                    {
                        //Obtener datos de la imagen
                        byte[] imagenOriginal = new byte[tamanio];
                        fileUploadImgProd.PostedFile.InputStream.Read(imagenOriginal, 0, tamanio);
                        Bitmap imagenOriginalBinaria = new Bitmap(fileUploadImgProd.PostedFile.InputStream);
                        
                        //Crear imagen Thumbnail (redimensionar imagen)
                        System.Drawing.Image imgThumbnail;
                        int tamanioThumbnail = 200;
                        imgThumbnail = RedimensionarImagen(imagenOriginalBinaria, tamanioThumbnail);
                        byte[] bImgThumbnail = new byte[tamanioThumbnail];
                        ImageConverter convertidor = new ImageConverter();
                        bImgThumbnail = (byte[])convertidor.ConvertTo(imgThumbnail, typeof(byte[]));

                        //Actualizar tabla Inventario en DB
                        string cadenaConexion = "data source=.\\SQLEXPRESS; initial catalog=GROSS_LAINO_CHAPARRO_DB; integrated security=sspi";
                        SqlConnection conexionSql = new SqlConnection(cadenaConexion);
                        SqlCommand comandoSql = new SqlCommand();
                        comandoSql.CommandText = "UPDATE ImagenesInventario SET Imagen = @Imagen where EAN = " + txtEan.Text;
                        comandoSql.Parameters.Add("@Imagen", SqlDbType.Image).Value = bImgThumbnail;
                        comandoSql.CommandType = CommandType.Text;
                        comandoSql.Connection = conexionSql;

                        try
                        {
                            conexionSql.Open();
                            comandoSql.ExecuteNonQuery();

                            AccesoDatos datos = new AccesoDatos();

                            if (tamanio != 0)
                            {
                                mostrarScriptMensaje("La imágen para el EAN: " + txtEan.Text + " se ha subido correctamente.");
                            }
                            else
                            {
                                mostrarScriptMensaje("Se han guardado los cambios para el EAN: " + txtEan.Text + ".");
                            }

                            CargarInventario();
                        }
                        catch
                        {
                            mostrarScriptMensaje("Error al cargar la imágen para el EAN: " + txtEan.Text + ".");
                        }
                        finally
                        {
                            conexionSql.Close();
                        }
                    }
                    catch
                    {
                        if (tamanio == 0)
                        {
                            mostrarScriptMensaje("Se produjo un error.");
                        }
                    }

                    BindData();
                }
            }
            catch
            { 
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el producto.')", true);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEan.Text == "" || txtDescripcion.Text == "" || txtFechaCompra.Text == "" 
                    || txtFechaVencimiento.Text == "" || txtCosto.Text == ""
                    || txtStock.Text == "" || ddlMarcaProducto.SelectedIndex == 0 ||
                    ddlTipoProducto.SelectedIndex == 0 || ddlProveedor.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Hay campos vacíos o sin seleccionar.')", true);
                }
                else
                {

                    string ID = txtID.Text;

                    string sp_DeleteInventario = "DELETE FROM Inventario WHERE ID = '" + ID + "'";

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
                BindData();
            }
        }

        //protected void btnUpdateDescription_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || txtDescripcion.Text == "")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN o Descipción vacíos.')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            string Descripcion = txtDescripcion.Text;

        //            string sp_UpdateInventario = "UPDATE Inventario SET Descripcion = '" + Descripcion + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha actualizado la descripción.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado la descripción.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateUrlImagen_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || txtUrlImagen.Text == "")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN o Url Imágen vacíos.')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            string UrlImagen = txtUrlImagen.Text;

        //            string sp_UpdateInventario = "UPDATE Inventario SET UrlImagen = '" + UrlImagen + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha actualizado la URL de la imágen.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado la URL de la imágen.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateTipoProducto_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || ddlTipoProducto.SelectedIndex == 0)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN vacío o Tipo de Producto no seleccionado.')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            int IdTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue);

        //            string sp_UpdateInventario = "UPDATE Inventario SET IdTipo = '" + IdTipoProducto + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha actualizado el tipo de producto.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado el tipo de producto.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateMarcaProducto_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || ddlMarcaProducto.SelectedIndex == 0)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN vacío o Marca no seleccionada.')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            int IdMarcaProducto = Convert.ToInt32(ddlMarcaProducto.SelectedValue);

        //            string sp_UpdateInventario = "UPDATE Inventario SET IdMarca = '" + IdMarcaProducto + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha actualizado la marca del producto.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado la marca del producto.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateProveedor_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || ddlProveedor.SelectedIndex == 0)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN vacío o Proveedor no seleccionado.')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            int IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);

        //            string sp_UpdateInventario = "UPDATE Inventario SET IdProveedor = '" + IdProveedor + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha actualizado el proveedor del producto.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado el proveedor del producto.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateFechaCompra_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || txtFechaCompra.Text == "")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN o Fecha de Compra vacíos')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            DateTime FechaCompra = Convert.ToDateTime(txtFechaCompra.Text);

        //            string sp_UpdateInventario = "UPDATE Inventario SET FechaCompra = '" + FechaCompra.ToShortDateString() + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha actualizado la fecha de compra del producto.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado la fecha de compra del producto.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateFechaVencimiento_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || txtFechaVencimiento.Text == "")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN o Fecha de Vencimiento vacíos')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            DateTime FechaVencimiento = Convert.ToDateTime(txtFechaVencimiento.Text);

        //            string sp_UpdateInventario = "UPDATE Inventario SET FechaVencimiento = '" + FechaVencimiento.ToShortDateString() + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha actualizado la fecha de vencimiento del producto.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado la fecha de vencimiento del producto.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateCosto_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || txtCosto.Text == "")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN o Costo vacíos.')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            string Costo = txtCosto.Text;

        //            string sp_UpdateInventario = "UPDATE Inventario SET Costo = '" + Costo + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha modificado el costo del producto.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado el costo producto.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdatePrecioVenta_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || txtPrecioVenta.Text == "")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN o Precio de Venta vacíos.')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            string PrecioVenta = txtPrecioVenta.Text;

        //            string sp_UpdateInventario = "UPDATE Inventario SET PrecioVenta = '" + PrecioVenta + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha actualizado el precio de venta del producto.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado el precio de venta del producto.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateStock_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "" || txtStock.Text == "")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN o Stock vacíos')", true);
        //        }
        //        else
        //        {
        //            string EAN = txtEAN.Text;
        //            int Stock = Convert.ToInt32(txtStock.Text);

        //            string sp_UpdateInventario = "UPDATE Inventario SET Stock = Stock+'" + Stock + "' WHERE EAN = '" + EAN + "'";

        //            sentencia.IUD(sp_UpdateInventario);

        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('Se ha Actualizado el stock.')", true);

        //            BindData();
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado el stock.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        //protected void btnUpdateEstado_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtEAN.Text == "")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //            "alert('EAN vacío.')", true);
        //        }
        //        else
        //        {
        //            if (ddlEstado.SelectedValue == "0")
        //            {
        //                ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //                "alert('Seleccione Estado...')", true);
        //            }
        //            else
        //            {
        //                string EAN = txtEAN.Text;
        //                if (ddlEstado.SelectedValue == "Activar")
        //                {
        //                    string sp_UpdateInventario = "UPDATE Inventario SET Estado = '1' WHERE EAN = '" + EAN + "'";

        //                    sentencia.IUD(sp_UpdateInventario);

        //                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //                    "alert('Se ha activado el producto.')", true);

        //                    BindData();
        //                }
        //                else if (ddlEstado.SelectedValue == "Desactivar")
        //                {
        //                    string sp_UpdateInventario = "UPDATE Inventario SET Estado = '0' WHERE EAN = '" + EAN + "'";

        //                    sentencia.IUD(sp_UpdateInventario);

        //                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //                    "alert('Se ha desactivado el producto.')", true);

        //                    BindData();
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //        "alert('Se ha producido un error y no se ha modificado el estado del producto.')", true);
        //    }
        //    finally
        //    {
        //        BindData();
        //    }
        //}

        protected void imgBtnBuscarProducto_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                if (txtBuscar.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Ingresa un filtro de búsqueda.')", true);

                    BindData();
                }
                else
                {
                    string Valor = txtBuscar.Text;

                    string columnasSelectCamposProducto = "SELECT ID, EAN, Descripción, Imagen," +
                                                        " Convert(varchar(10), IdTipo) IdTipo, TipoProducto," +
                                                        " Convert(varchar(10), IdMarca) IdMarca, Marca," +
                                                        " Convert(varchar(10), IdProveedor) IdProveedor, Proveedor," +
                                                        " Convert(varchar(10), [Fecha de Compra], 105) FechaCompra, " +
                                                        " Convert(varchar(10), [Fecha de Vencimiento], 105) FechaVencimiento," +
                                                        " Convert(varchar(10), Costo) Costo, " +
                                                        " Convert(varchar(10), PrecioVenta) PrecioVenta," +
                                                        " Convert(varchar(10), Stock) Stock, Convert(varchar(10), Estado) Estado " +
                                                        " FROM ExportInventario";

                    string selectDgvProducto = "SELECT EAN, Descripción, Imagen, TipoProducto, Marca, " +
                                               "Proveedor, [Fecha de Compra], [Fecha de Vencimiento], Costo, " +
                                               "PrecioVenta, Stock, Estado FROM ExportInventario " +
                                               "WHERE EAN LIKE '%" + Valor + "%'" +
                                               " OR Descripción LIKE '%" + Valor + "%'" +
                                               " OR TipoProducto LIKE '%" + Valor + "%'" +
                                               " OR Marca LIKE '%" + Valor + "%'" +
                                               " OR Proveedor LIKE '%" + Valor + "%'";

                    datos2.SetearConsulta(selectDgvProducto);
                    datos2.EjecutarLectura();

                    if (Valor.All(char.IsDigit) == true)
                    {
                        string selectCamposProducto = columnasSelectCamposProducto +
                                                " WHERE EAN = '" + Valor + "'";

                        datos.SetearConsulta(selectCamposProducto);
                        datos.EjecutarLectura();
                    }
                    else
                    {
                        string selectCamposProducto = columnasSelectCamposProducto +
                                                " WHERE Descripción = '" + Valor + "'";

                        datos.SetearConsulta(selectCamposProducto);
                        datos.EjecutarLectura();
                    }
                    
                    if (datos.Lector.Read() == true)
                    {
                        string base64StringImagenVacia = "VkFDSU8=";
                        txtID.Text = datos.Lector["ID"].ToString();
                        txtEan.Text = datos.Lector["EAN"].ToString();
                        txtDescripcion.Text = (string)datos.Lector["Descripción"];
                        string Imagen = Convert.ToBase64String((byte[])datos.Lector["Imagen"]);
                        if (Imagen == base64StringImagenVacia) 
                        { 
                            btnDeleteImage.Enabled = false;
                            btnUpdateImage.Enabled = true;
                        }
                        else 
                        {
                            btnUpdateImage.Enabled = false;
                            btnDeleteImage.Enabled = true;
                        }
                        //mostrarImagenPrueba.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])datos.Lector["Imagen"]);
                        ddlTipoProducto.SelectedValue = datos.Lector["IdTipo"].ToString();
                        ddlMarcaProducto.SelectedValue = datos.Lector["IdMarca"].ToString();
                        ddlProveedor.SelectedValue = datos.Lector["IdProveedor"].ToString();
                        txtFechaCompra.Text = datos.Lector["FechaCompra"].ToString();
                        txtFechaVencimiento.Text = datos.Lector["FechaVencimiento"].ToString();
                        txtCosto.Text = datos.Lector["Costo"].ToString();
                        txtPrecioVenta.Text = datos.Lector["PrecioVenta"].ToString();
                        txtStock.Text = datos.Lector["Stock"].ToString();
                        if (datos.Lector["Estado"].ToString() == "1") { ddlEstado.SelectedValue = "1"; }
                        else { ddlEstado.SelectedValue = "2"; }

                        dgvInventario.DataSource = sentencia.DSET(selectDgvProducto);
                        dgvInventario.DataBind();

                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;

                        txtEan.Enabled = false;
                        txtDescripcion.Enabled = true;
                        ddlTipoProducto.Enabled = true;
                        ddlMarcaProducto.Enabled = true;
                        ddlProveedor.Enabled = true;
                        txtFechaCompra.Enabled = true;
                        txtFechaVencimiento.Enabled = true;
                        txtCosto.Enabled = true;
                        txtPrecioVenta.Enabled = true;
                        txtStock.Enabled = true;
                        ddlEstado.Enabled = true;
                    }
                    else
                    {
                        if (datos2.Lector.Read() == false)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            "alert('No se econtró ninguna coincidencia.')", true);

                            BindData();
                        }
                        else
                        {
                            dgvInventario.DataSource = sentencia.DSET(selectDgvProducto);
                            dgvInventario.DataBind();

                            txtEan.Text = "";
                            txtDescripcion.Text = "";
                            ddlTipoProducto.SelectedValue = "0";
                            ddlMarcaProducto.SelectedValue = "0";
                            ddlProveedor.SelectedValue = "0";
                            txtFechaCompra.Text = "";
                            txtFechaVencimiento.Text = "";
                            txtCosto.Text = "";
                            txtPrecioVenta.Text = "";
                            txtStock.Text = "";
                            ddlEstado.SelectedValue = "0";

                            txtEan.Enabled = false;
                            txtDescripcion.Enabled = false;
                            ddlTipoProducto.Enabled = false;
                            ddlMarcaProducto.Enabled = false;
                            ddlProveedor.Enabled = false;
                            txtFechaCompra.Enabled = false;
                            txtFechaVencimiento.Enabled = false;
                            txtCosto.Enabled = false;
                            txtPrecioVenta.Enabled = false;
                            txtStock.Enabled = false;
                            ddlEstado.Enabled = false;
                        }
                    }
                }
            }
            catch
            {
                mostrarScriptMensaje("Se produjo un error en la búsqueda. Por favor reintente en unos minutos.");
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        protected void btnCerraPopup_Click(object sender, EventArgs e)
        {
            txtEan2.Text = "";
            txtDescripcion2.Text = "";
            txtUrlImagen2.Text = "";
            ddlTipoProducto2.SelectedValue = "0";
            ddlMarcaProducto2.SelectedValue = "0";
            ddlProveedor2.SelectedValue = "0";
            txtFechaCompra2.Text = "";
            txtFechaVencimiento2.Text = "";
            txtCosto2.Text = "";
            txtPrecioVenta2.Text = "";
            txtStock2.Text = "";
            ddlEstado2.SelectedValue = "0";

            BindData();
        }

        protected void dgvInventario_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindData();

            string selectOrdenar = "SELECT * FROM ExportInventario ORDER BY " + e.SortExpression + " "
                                    + GetSortDirection(e.SortExpression);

            dgvInventario.DataSource = sentencia.DSET(selectOrdenar);
            dgvInventario.DataBind();            
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";

            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = ExportInventario " + DateTime.Now.ToString() + ".xls");
            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWriter = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            dgvInventario.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());

            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        /*protected void btnPreviewImage_Click(object sender, EventArgs e)
        {
            int tamanio = fileUploadImgProd.PostedFile.ContentLength;

            try
            {
                //Obtener datos de la imagen
                byte[] imagenOriginal = new byte[tamanio];
                fileUploadImgProd.PostedFile.InputStream.Read(imagenOriginal, 0, tamanio);
                Bitmap imagenOriginalBinaria = new Bitmap(fileUploadImgProd.PostedFile.InputStream);
                //Crear imagen Thumbnail
                System.Drawing.Image imgThumbnail;
                int tamanioThumbnail = 200;
                imgThumbnail = RedimensionarImagen(imagenOriginalBinaria, tamanioThumbnail);
                byte[] bImgThumbnail = new byte[tamanioThumbnail];
                ImageConverter convertidor = new ImageConverter();
                bImgThumbnail = (byte[])convertidor.ConvertTo(imgThumbnail, typeof(byte[]));
                //Mostrar vista previa
                string imagenDataUrl64 = "data:image/jpg;base64," + Convert.ToBase64String(bImgThumbnail);
                //mostrarImagenPrueba.ImageUrl = imagenDataUrl64;
            }
            catch
            {
                if (tamanio == 0)
                {
                    mostrarScriptMensaje("No se ha seleccionado ninguna imágen.");
                }
            }
        }*/

        public System.Drawing.Image RedimensionarImagen(System.Drawing.Image imagenOriginal, int alto)
        {
            var Radio = (double)alto / imagenOriginal.Height;
            var NuevoAncho = (int)(imagenOriginal.Width * Radio);
            var NuevoAlto = (int)(imagenOriginal.Height * Radio);
            var imagenRedimensionada = new Bitmap(NuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(imagenRedimensionada);
            g.DrawImage(imagenOriginal, 0, 0, NuevoAncho, NuevoAlto);

            return imagenRedimensionada;
        }

        protected void CargarInventario()
        {
            AccesoDatos sentencia = new AccesoDatos();
            string selectViewInventario = "SELECT * FROM ExportInventario";

            dgvInventario.DataSource = sentencia.DSET(selectViewInventario);
            dgvInventario.DataBind();
        }

        protected void btnUpdateImage_Click(object sender, EventArgs e)
        {
            fileUploadImgProd.Visible = true;
            btnUpdateImage.Visible = false;
            btnDeleteImage.Visible = false;
        }

        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
            string Ean = txtEan.Text;

            AccesoDatos sentencia = new AccesoDatos();

            string deleteImage = "DELETE FROM ImagenesInventario WHERE EAN = " + Ean;

            try
            {
                sentencia.IUD(deleteImage);

                mostrarScriptMensaje("La imágen del EAN: " + Ean + " se ha borrado correctamente.");

                btnDeleteImage.Enabled = false;
                btnUpdateImage.Enabled = true;
            }
            catch
            {
                mostrarScriptMensaje("Se produjo un error y no se pudo borrar la imágen del producto.");
            }
        }
    }
}