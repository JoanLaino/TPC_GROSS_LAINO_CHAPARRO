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
    public partial class ABMTiposProducto : System.Web.UI.Page
    {
        AccesoDatos sentencia = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectTP = "SELECT * FROM ExportTiposProducto ORDER BY ID ASC";

            if (!IsPostBack)
            {
                ddlID.DataSource = sentencia.DSET(selectTP);
                ddlID.DataMember = "datos";
                ddlID.DataTextField = "ID";
                ddlID.DataValueField = "Descripcion";
                ddlID.DataBind();

                BindData();

                //ddlID.SelectedIndex = 1;
                //txtDescripcion.Text = Convert.ToString(ddlID.SelectedItem);
            }
        }
        public void BindData()
        {
            string selectViewTiposProducto = "SELECT * FROM ExportTiposProducto ORDER BY ID ASC";

            dgvTiposProducto.DataSource = sentencia.DSET(selectViewTiposProducto);
            dgvTiposProducto.DataBind();
        }

        protected void ddlID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlID.SelectedIndex == 0)
            {
                txtDescripcion.Text = "";
            }
            else { txtDescripcion.Text = Convert.ToString(ddlID.SelectedValue); }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlID.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('No ha seleccionado ningún ID.')", true);
                }
                else
                {

                    string ID = Convert.ToString(ddlID.SelectedItem);

                    string sp_DeleteTipoProducto = "EXEC SP_ELIMINAR_TIPO_PRODUCTO '" + ID + "'";

                    sentencia.IUD(sp_DeleteTipoProducto);

                    BindData();

                    Response.Redirect("ABMTiposProducto.aspx");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('El tipo de producto seleccionado está asignado a uno o varios productos y no se puede eliminar.')", true);
            }
        }

        protected void btnUpdateDescription_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddlID.SelectedIndex == 0 || txtDescripcion.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('ID no seleccionado o Descripción vacía.')", true);
                }
                else
                {
                    string ID = Convert.ToString(ddlID.SelectedItem);
                    string Descripcion = txtDescripcion.Text;

                    string sp_UpdateTipoProducto = "UPDATE TiposProducto SET Descripcion = '" + Descripcion + "' WHERE ID = '" + ID + "'";

                    sentencia.IUD(sp_UpdateTipoProducto);

                    BindData();

                    Response.Redirect("ABMTiposProducto.aspx");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado el tipo de producto.')", true);
            }
        }

        protected void btnAddTipoProducto_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtDescripcion.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Descripción vacía.')", true);
                }
                else
                {
                    string Descripcion = txtDescripcion.Text;

                    string sp_InsertTipoProducto = "EXEC SP_INSERTAR_TIPO_PRODUCTO '" + Descripcion + "'";

                    sentencia.IUD(sp_InsertTipoProducto);

                    BindData();

                    Response.Redirect("ABMTiposProducto.aspx");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Error. Ya existe el tipo de producto ingresado.')", true);
            }
        }
    }
}