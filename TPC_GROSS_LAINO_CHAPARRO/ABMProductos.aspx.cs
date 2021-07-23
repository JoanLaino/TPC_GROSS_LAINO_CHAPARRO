﻿using System;
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

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        public void BindData()
        {
            txtEan.Text = "";
            txtDescripcion.Text = "";
            txtUrlImagen.Text = "";
            ddlTipoProducto.SelectedValue = "0";
            ddlMarcaProducto.SelectedValue = "0";
            ddlProveedor.SelectedValue = "0";
            txtFechaCompra.Text = "";
            txtFechaVencimiento.Text = "";
            txtCosto.Text = "";
            txtPrecioVenta.Text = "";
            txtStock.Text = "";
            ddlEstado.SelectedValue = "0";

            txtDescripcion.Enabled = false;
            txtUrlImagen.Enabled = false;
            ddlTipoProducto.Enabled = false;
            ddlMarcaProducto.Enabled = false;
            ddlProveedor.Enabled = false;
            txtFechaCompra.Enabled = false;
            txtFechaVencimiento.Enabled = false;
            txtCosto.Enabled = false;
            txtPrecioVenta.Enabled = false;
            txtStock.Enabled = false;
            ddlEstado.Enabled = false;

            string selectViewInventario = "SELECT * FROM ExportInventario";

            dgvInventario.DataSource = sentencia.DSET(selectViewInventario);
            dgvInventario.DataBind();
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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEan.Text == "" || txtDescripcion.Text == "" || txtUrlImagen.Text == ""
                    || ddlTipoProducto.SelectedIndex == 0 || ddlMarcaProducto.SelectedIndex == 0
                    || ddlProveedor.SelectedIndex == 0 || txtFechaCompra.Text == ""
                    || txtFechaVencimiento.Text == "" || txtCosto.Text == ""
                    || txtStock.Text == "" || ddlEstado.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Hay campos vacíos o sin seleccionar.')", true);
                }
                else
                {
                    string EAN = txtEan.Text;
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
                    if (ddlEstado.SelectedValue == "1") { Estado = 1; }

                    string sp_UpdateInventario = "EXEC SP_ACTUALIZAR_PRODUCTO '" + EAN + "', '" + Descripcion + "', '" + Imagen + "', " + IdTipoProducto
                    + ", " + IdMarca + ", " + IdProveedor + ", '" + FechaCompra.ToShortDateString() + "', '" + FechaVencimiento.ToShortDateString() + "', '" + Costo + "', '" + PrecioVenta
                    + "', '" + Stock + "', " + Estado;

                    sentencia.IUD(sp_UpdateInventario);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se han guardado los cambios.')", true);

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
                if (txtEan.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('El EAN no puede estar vacío.')", true);
                }
                else
                {

                    string EAN = txtEan.Text;

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
            try
            {
                if (txtEan.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('No se ha ingresado ningún EAN.')", true);

                    BindData();
                }
                else
                {
                    string Valor = txtEan.Text;

                    string selectDgvProducto = "SELECT * from ExportInventario " +
                                               "WHERE EAN = '" + Valor + "'";

                    string selectCamposProducto = "Select EAN, Descripcion, UrlImagen, Convert(varchar(10), IdTipo) IdTipo, Convert(varchar(10), IdMarca) IdMarca, Convert(varchar(10), IdProveedor) IdProveedor, Convert(varchar(10), FechaCompra, 105) FechaCompra, Convert(varchar(10), FechaVencimiento, 105) FechaVencimiento, Convert(varchar(10), Costo) Costo, Convert(varchar(10), PrecioVenta) PrecioVenta, Convert(varchar(10), Stock) Stock, Convert(varchar(10), Estado) Estado from Inventario" +
                                                " WHERE EAN = '" + Valor + "'";

                    datos.SetearConsulta(selectCamposProducto);
                    datos.EjecutarLectura();


                    if (datos.Lector.Read() == true)
                    {
                        txtDescripcion.Text = (string)datos.Lector["Descripcion"];
                        txtUrlImagen.Text = (string)datos.Lector["UrlImagen"];
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

                        txtDescripcion.Enabled = true;
                        txtUrlImagen.Enabled = true;
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
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('No se econtró ninguna coincidencia.')", true);

                        BindData();
                    }
                }
            }
            catch (Exception)
            {
                throw;
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
    }
}