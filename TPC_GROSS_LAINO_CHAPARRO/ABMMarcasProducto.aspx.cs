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
    public partial class ABMMarcasProducto : System.Web.UI.Page
    {
        AccesoDatos sentencia = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

            txtIdMarca.Enabled = false;
            txtMarca.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        public void BindData()
        {
            string selectMarcasProducto = "SELECT * from MarcasProducto";

            dgvMarcasProducto.DataSource = sentencia.DSET(selectMarcasProducto);
            dgvMarcasProducto.DataBind();

            txtBuscar.Text = "";
            txtIdMarca.Text = "";
            txtMarca.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtMarca2.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Descripción vacía.')", true);
            }
            else
            {

                if (chequeoMarca() == true)
                {
                    string Marca = txtMarca2.Text;

                    string GuardarMarca = "INSERT INTO MarcasProducto (Descripcion) values('" + Marca + "')";                   

                    sentencia.IUD(GuardarMarca);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha agregado la Marca.')" , true);

                    BindData();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('La Marca ya se encuentra ingresada.')", true);

                    BindData();
                }
            }
        }

        protected bool chequeoMarca()
        {
            string Marca = txtMarca2.Text;

            string Consulta = "select count(*) from MarcasProducto where Descripcion like '" + Marca + "'";

            int existe = sentencia.IUDquery(Consulta);

            if (existe >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }           
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datos2 = new AccesoDatos();

            if (txtBuscar.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Descripción vacía.')", true);
            }
            else
            {
                string valor = txtBuscar.Text;
                string selectBuscarMarcaGrilla = "SELECT * FROM MarcasProducto WHERE Descripcion LIKE '%" + valor + "%'";
                string selectBuscarMarcaCampos = "SELECT * FROM MarcasProducto WHERE Descripcion = '" + valor + "'";

                datos2.SetearConsulta(selectBuscarMarcaGrilla);
                datos2.EjecutarLectura();

                dgvMarcasProducto.DataSource = sentencia.DSET(selectBuscarMarcaGrilla);
                dgvMarcasProducto.DataBind();

                datos.SetearConsulta(selectBuscarMarcaCampos);
                datos.EjecutarLectura();

                if(datos.Lector.Read() == true)
                {
                    txtIdMarca.Text = datos.Lector["ID"].ToString();
                    txtMarca.Text = (string)datos.Lector["Descripcion"];

                    txtMarca.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    if (datos2.Lector.Read() == false)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('No se encontraron coincidencias.')", true);

                        BindData();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontró más de un resultado.')", true);
                    }
                }
            }
        }

        protected void btnCerraPopup_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtIdMarca.Text = "";
            txtMarca.Text = "";

            BindData();
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtMarca.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Descripción vacía.')", true);
                }
                else
                {
                    string id = txtIdMarca.Text;
                    string descripcion = txtMarca.Text;

                    sentencia.IUD("DELETE FROM MarcasProducto WHERE ID = '" + id + "' AND Descripcion = '" + descripcion + "'");

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Marca eliminada con éxito.')", true);

                    BindData();
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('La marca seleccionada está asignada a uno o varios vehículos y no se puede eliminar.')", true);

                BindData();
            }
        }

        protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtMarca.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Descripción vacía.')", true);
                }
                else
                {
                    string id = txtIdMarca.Text;
                    string descripcion = txtMarca.Text;

                    sentencia.IUD("UPDATE MarcasProducto SET Descripcion = '" + descripcion + "' WHERE ID = '" + id + "'");

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Descripción de marca actualizada con éxito.')", true);

                    BindData();
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se ha producido un error y no se ha modificado la marca.')", true);

                BindData();
            }
        }
    }
}