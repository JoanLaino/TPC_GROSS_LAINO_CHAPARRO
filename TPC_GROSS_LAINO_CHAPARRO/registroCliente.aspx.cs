using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class registroCliente : System.Web.UI.Page
    {
        AccesoDatos sentencia = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string selectTiposCliente = "SELECT * FROM TiposCliente ORDER BY Descripcion ASC";

            ddlIdTipo.DataSource = sentencia.DSET(selectTiposCliente);
            ddlIdTipo.DataMember = "datos";
            ddlIdTipo.DataTextField = "Descripcion";
            ddlIdTipo.DataValueField = "ID";
            ddlIdTipo.DataBind();

            txtApeNom.Enabled = false;
            txtRazonSocial.Enabled = false;
            txtCuitDni.Enabled = false;
            txtTelefono.Enabled = false;
            txtMail.Enabled = false;
            btnConfirmarRegistro.Enabled = false;
        }

        protected void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("turnos.aspx");
        }

        protected void btnConfirmarRegistro_Click(object sender, EventArgs e)
        {
            if (txtMail.Text == "" || txtTelefono.Text == "" || ddlIdTipo.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Hay campos vacíos ó sin seleccionar.\\n\\n" +
                "Por favor revíselos y reintente.')", true);
            }

            if (txtCuitDni.Text.Length < 7)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('El CUIT ó DNI es inválido.\\n\\n" +
                "Por favor revíselo y reintente.')", true);
            }
            else if (txtCuitDni.Text.Length > 8 && txtRazonSocial.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Razón Social sin completar. Por favor ingrésela.')", true);
            }
            else if (txtCuitDni.Text.Length <= 8 && txtApeNom.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Nombre y Apellido sin completar. Por favor ingréselos.')", true);
            }

            if (txtMail.Text == "" || txtTelefono.Text == "" || ddlIdTipo.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Hay campos vacíos ó sin seleccionar.\\n\\n" +
                "Por favor revíselos y reintente.')", true);
            }
            else
            {
                if (txtCuitDni.Text.Length > 8) { txtApeNom.Text = ""; }
                else { txtRazonSocial.Text = ""; }

                Session.Add("CuitDni", txtCuitDni.Text);
                Session.Add("ApeNom", txtApeNom.Text);
                Session.Add("RazonSocial", txtRazonSocial.Text);
                Session.Add("Telefono", txtTelefono.Text);
                Session.Add("Mail", txtMail.Text);
                Session.Add("TipoCliente", ddlIdTipo.SelectedValue.ToString());

                Response.Redirect("registroVehiculo.aspx");
            }
        }

        protected void ddlIdTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoCliente = ddlIdTipo.SelectedItem.ToString();

            if (ddlIdTipo.SelectedValue != "0")
            {
                txtCuitDni.Enabled = true;
                txtTelefono.Enabled = true;
                txtMail.Enabled = true;
                btnConfirmarRegistro.Enabled = true;
            }

            if (tipoCliente == "Particular")
            { 
                txtApeNom.Enabled = true;
                txtRazonSocial.Enabled = false;
                txtCuitDni.Attributes.Add("placeholder", "DNI");
                txtCuitDni.MaxLength = 8;
            }
            else if (ddlIdTipo.SelectedValue != "0")
            { 
                txtApeNom.Enabled = false;
                txtRazonSocial.Enabled = true;
                txtCuitDni.Attributes.Add("placeholder", "CUIT");
                txtCuitDni.MaxLength = 11;
            }
        }
    }
}