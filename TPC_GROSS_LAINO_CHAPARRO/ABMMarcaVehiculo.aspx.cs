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
    public partial class ABMMarcaVehiculo : System.Web.UI.Page
    {
        AccesoDatos sentencia = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('El Campo Marca no puede estar vacío.')", true);
            }
            else
            {

                if (chequeoMarca() == true)
                {
                    string Marca = txtMarca.Text;

                    string GuardarMarca = "INSERT INTO MarcasVehiculo (Descripcion) values('" + Marca + "')";                   

                    sentencia.IUD(GuardarMarca);

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se ha agregado la Marca.')" , true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('La Marca ya se encuentra ingresada.')", true);
                }
            }
        }

        protected bool chequeoMarca()
        {
            string Marca = txtMarca.Text;

            string Consulta = "select count(*) from MarcasVehiculo where Descripcion like '" + Marca + "'";

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
        
    }
}