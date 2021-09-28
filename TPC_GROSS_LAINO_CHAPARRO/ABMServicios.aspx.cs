using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarNivelUsuario();
            
            if (!IsPostBack)
            {
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
            AccesoDatos sentencia = new AccesoDatos();

            txtBorrarServiciosPorPatente.Visible = false;
            ddlFiltroBuscar.SelectedValue = "0";
            txtBuscarFiltro.Text = "";
            ddlMostrar.SelectedValue = "Todos";

            string selectServicios = "SELECT * FROM ExportServicios ORDER BY Fecha DESC, Hora DESC";
            int resultado = ContarResultadosDB("Todos", "null", "null", "null");

            mostrarCantidadServicios(resultado, "Todos");

            dgvServicios.DataSource = sentencia.DSET(selectServicios);
            dgvServicios.DataBind();
        }

        protected void btnBuscarFiltro_Click(object sender, EventArgs e)
        {

        }

        protected void btnBorrarServiciosPorPatente_Click(object sender, EventArgs e)
        {
            if (txtBorrarServiciosPorPatente.Visible == false)
            {
                txtBorrarServiciosPorPatente.Visible = true;
            }
            else
            {
                if (txtBorrarServiciosPorPatente.Text == "")
                {
                    mostrarScriptMensaje("Debe ingresar una patente.");
                }
                else
                {
                    string patente = txtBorrarServiciosPorPatente.Text.ToUpper();
                    int resultadoServicios = ContarResultadosDB("Servicios", "PatenteVehiculo", patente, "y");
                    int resultadoDB = ContarResultadosDB("Vehículos", "Patente", patente, "y");

                    if (resultadoDB == 0)
                    {
                        mostrarScriptMensaje("La Patente " + patente + ", no existe en el sistema.");
                    }
                    else if (resultadoServicios != 0)
                    {
                        AccesoDatos sentencia = new AccesoDatos();

                        string deleteServicios = "DELETE FROM Servicios WHERE PatenteVehiculo = '" + patente + "'";

                        try
                        {
                            sentencia.IUD(deleteServicios);

                            mostrarScriptMensaje("Los servicios correspondientes a la Patente " + patente + ", se eliminaron correctamente.");

                            BindData();
                        }
                        catch
                        {
                            mostrarScriptMensaje("Se produjo un error al intentar borrar los servicios " +
                                                 "correspondientes a la pantente " + patente + ".");
                        }
                    }
                    else
                    {
                        mostrarScriptMensaje("La Patente " + patente + ", no registra servicios aún.");
                    }
                }
            }
        }

        public void mostrarScriptMensaje(string mensaje)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert",
            "alert('" + mensaje + "')", true);
        }

        public void mostrarCantidadServicios(int cantidad, string referencia)
        {
            if (cantidad != 0)
            {
                if (cantidad > 1)
                {
                    if (referencia == "Todos")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontraron " + cantidad + " servicios, cargados en el sistema.')", true);
                    }
                    else if (referencia == "Hoy")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontraron " + cantidad + " servicios, cargados hoy al sistema.')", true);
                    }
                    else if (referencia == "Completados")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontraron " + cantidad + " servicios completados, cargados en el sistema.')", true);
                    }
                    else if (referencia == "Pendientes")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontraron " + cantidad + " servicios pendientes, cargados en el sistema.')", true);
                    }
                    else if (referencia == "Futuros")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontraron " + cantidad + " servicios futuros, cargados en el sistema.')", true);
                    }
                }
                else
                {
                    if (referencia == "Todos")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontró " + cantidad + " solo servicio, cargado en el sistema.')", true);
                    }
                    else if (referencia == "Hoy")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontró " + cantidad + " solo servicio, cargado hoy al sistema.')", true);
                    }
                    else if (referencia == "Completados")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontró " + cantidad + " solo servicio completado, cargado en el sistema.')", true);
                    }
                    else if (referencia == "Pendientes")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontró " + cantidad + " solo servicio pendiente, cargado en el sistema.')", true);
                    }
                    else if (referencia == "Futuros")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Se encontró " + cantidad + " solo servicio futuro, cargado en el sistema.')", true);
                    }
                }
            }
            else
            {
                if (referencia == "Todos")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Todavía no hay servicios cargados en el sistema.')", true);
                }
                else if (referencia == "Hoy")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Por el momento, hoy no se cargaron servicios en el sistema.')", true);
                }
                else if (referencia == "Completados")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Por el momento, no hay servicios completados cargados en el sistema.')", true);
                }
                else if (referencia == "Pendientes")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Por el momento, no hay servicios pendientes cargados en el sistema.')", true);
                }
                else if (referencia == "Futuros")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Todavía no hay servicios futuros cargados en el sistema.')", true);
                }
            }
        }

        protected void ddlMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesoDatos sentencia = new AccesoDatos();

            string seleccion = ddlMostrar.SelectedValue.ToString();
            int resultado = ContarResultadosDB("Todos", "null", "null", "null");

            string consulta_1 = "SELECT * FROM ExportServicios ";
            string consulta_2 = "WHERE TRANSLATE(Fecha,'-','/')";
            string consulta_3 = "GETDATE()";

            if (resultado != 0)
            {
                switch (seleccion)
                {
                    case ("Todos"):
                        {
                            resultado = ContarResultadosDB(seleccion, "null", "null", "null");
                            string selectTodos = "SELECT * FROM ExportServicios";

                            dgvServicios.DataSource = sentencia.DSET(selectTodos);
                            dgvServicios.DataBind();

                            mostrarCantidadServicios(resultado, seleccion);
                        }
                        break;
                    case ("Hoy"):
                        {
                            resultado = ContarResultadosDB(seleccion, "null", "null", "null");
                            string selectTodos = "SELECT * FROM ExportServicios WHERE CONVERT(date, Fecha, 105) = " +
                                                 "CONVERT(date, GETDATE(), 105) ORDER BY Hora DESC";

                            dgvServicios.DataSource = sentencia.DSET(selectTodos);
                            dgvServicios.DataBind();

                            mostrarCantidadServicios(resultado, seleccion);
                        }
                        break;
                    case ("Completados"):
                        {
                            resultado = ContarResultadosDB(seleccion, "null", "null", "null");
                            string selectTodos = consulta_1  + " WHERE Estado = 'Completado'";

                            dgvServicios.DataSource = sentencia.DSET(selectTodos);
                            dgvServicios.DataBind();

                            mostrarCantidadServicios(resultado, seleccion);
                        }
                        break;
                    case ("Futuros"):
                        {
                            resultado = ContarResultadosDB(seleccion, "null", "null", "null");
                            string selectTodos = consulta_1 + consulta_2 + " > " + consulta_3;

                            dgvServicios.DataSource = sentencia.DSET(selectTodos);
                            dgvServicios.DataBind();

                            mostrarCantidadServicios(resultado, seleccion);
                        }
                        break;
                    case ("Pendientes"):
                        {
                            resultado = ContarResultadosDB(seleccion, "null", "null", "null");
                            string selectTodos = consulta_1 + " WHERE Estado = 'Pendiente'";

                            dgvServicios.DataSource = sentencia.DSET(selectTodos);
                            dgvServicios.DataBind();

                            mostrarCantidadServicios(resultado, seleccion);
                        }
                        break;
                }
            }
            else
            {
                mostrarCantidadServicios(resultado, "Todos");

                BindData();
            }
        }

        protected void dgvTurnos_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected int ContarResultadosDB(string var, string campo, string valor, string comillas)
        {
            AccesoDatos datos = new AccesoDatos();

            int Resultado = 0;

            string selectDB;

            if (var == "Todos")
            {
                selectDB = "SELECT COUNT(*) as Cantidad FROM ExportServicios";
            }
            else if (var == "Hoy" || var == "Completados" || var == "Futuros" || var == "Pendientes")
            {
                string consulta_1 = "SELECT COUNT(*) as Cantidad FROM ExportServicios WHERE CONVERT(date,Fecha,105)";
                string consulta_2 = "CONVERT(date,GETDATE(),105)";

                if (var == "Hoy")
                {
                    selectDB = consulta_1 + " = " + consulta_2;
                }
                else if (var == "Completados")
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM ExportServicios WHERE Estado = 'Completado'";
                }
                else if (var == "Futuros")
                {
                    selectDB = consulta_1 + " > " + consulta_2;
                }
                else if (var == "Pendientes")
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM ExportServicios WHERE Estado = 'Pendiente'";
                }
                else
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM ExportTurnos";
                }
            }
            else
            {
                if (comillas == "y")
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM " + var + " WHERE " + campo + " = '" + valor + "'";
                }
                else
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM " + var + " WHERE " + campo + " = " + valor;
                }
            }

            try
            {
                datos.SetearConsulta(selectDB);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    Resultado = Convert.ToInt32(datos.Lector["Cantidad"]);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Se produjo un error al intentar leer la base de datos.')", true);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return Resultado;
        }
    }
}