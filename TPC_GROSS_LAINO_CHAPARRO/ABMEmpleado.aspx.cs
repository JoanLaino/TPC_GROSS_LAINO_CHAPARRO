using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMEmpleado : System.Web.UI.Page
    {
        //public List<Empleado> lista;
        AccesoDatos sentencia = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            txtBuscar.Text = "";

            txtLegajo.Text = "";
            txtCuil.Text = "";
            txtApeNom.Text = "";
            txtFechaAlta.Text = "";
            txtFechaNacimiento.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
            txtServiciosRealizados.Text = "";

            txtLegajo.Enabled = false;
            txtCuil.Enabled = false;
            txtApeNom.Enabled = false;
            txtFechaAlta.Enabled = false;
            txtFechaNacimiento.Enabled = false;
            txtMail.Enabled = false;
            txtTelefono.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            string selectViewEmpleados = "SELECT * FROM ExportEmpleados ORDER BY [ApeNom], [FechaAlta]";

            dgvEmpleados.DataSource = sentencia.DSET(selectViewEmpleados);
            dgvEmpleados.DataBind();
        }

        protected void imgBtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                if (txtBuscar.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('No se ha ingresado ningún nombre / apellido.')", true);

                    BindData();
                }
                else
                {
                    string Valor = txtBuscar.Text;

                    string selectDgv = "SELECT * from ExportEmpleados " +
                                               "WHERE ApeNom LIKE '%" + Valor + "%'";

                    string selectCampos = "SELECT * from ExportEmpleados " +
                                               "WHERE ApeNom = '" + Valor + "'";

                    datos2.SetearConsulta(selectDgv);
                    datos2.EjecutarLectura();

                    datos.SetearConsulta(selectCampos);
                    datos.EjecutarLectura();

                    dgvEmpleados.DataSource = sentencia.DSET(selectDgv);
                    dgvEmpleados.DataBind();

                    if (datos.Lector.Read() == true)
                    {
                        txtLegajo.Text = datos.Lector["Legajo"].ToString();
                        txtCuil.Text = datos.Lector["Cuil"].ToString();
                        txtApeNom.Text = datos.Lector["ApeNom"].ToString();
                        txtFechaAlta.Text = datos.Lector["FechaAlta"].ToString();
                        txtFechaNacimiento.Text = datos.Lector["FechaNacimiento"].ToString();
                        txtMail.Text = datos.Lector["Mail"].ToString();
                        txtTelefono.Text = datos.Lector["Telefono"].ToString();
                        txtServiciosRealizados.Text = datos.Lector["ServiciosRealizados"].ToString();

                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;

                        txtLegajo.Enabled = true;
                        txtCuil.Enabled = true;
                        txtApeNom.Enabled = true;
                        txtFechaAlta.Enabled = true;
                        txtFechaNacimiento.Enabled = true;
                        txtMail.Enabled = true;
                        txtTelefono.Enabled = true;
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        //protected void buscarEmpleado(object sender, EventArgs e)
        //{
        //List<Empleado> filtro;
        //if (txtFiltro.Text != "")
        //{
        //    filtro = lista.FindAll(Art => Art.Name.ToUpper().Contains(txtFiltro.Text.ToUpper()) || Art.CuilCuit.ToUpper().Contains(txtFiltro.Text.ToUpper()) || Art.Legajo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
        //    lista = null;
        //    lista = filtro;
        //}
        //}


    }
}
