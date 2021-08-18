using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMTurnos : System.Web.UI.Page
    {
        AccesoDatos sentencia = new AccesoDatos();
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
            string selectTurnos = "SELECT * FROM ExportTurnos";
            string selectCantidadTurnos = "SELECT COUNT(*) Cantidad FROM ExportTurnos";
            int resultado = 0;

            sentencia.SetearConsulta(selectCantidadTurnos);
            sentencia.EjecutarLectura();

            if (sentencia.Lector.Read())
            {
                resultado = Convert.ToInt32(sentencia.Lector["Cantidad"]);
            }
            if (resultado != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('En total, al día de hoy, hay " + resultado + " turno/s.')", true);

                dgvTurnos.DataSource = sentencia.DSET(selectTurnos);
                dgvTurnos.DataBind();

                btnExportExcel.Enabled = true;
                btnExportExcel.Visible = true;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Todavía no hay turnos cargados.')", true);

                btnExportExcel.Enabled = false;
                btnExportExcel.Visible = false;
                //ocultar botones de editar y eliminar.
            }

            dgvTurnos.Visible = true;
            ddlFiltroBuscar.SelectedValue = "0";
            txtBuscarFiltro.Text = "";
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = ExportTurnos " + DateTime.Now.ToString() + ".xls");
            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWriter = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            dgvTurnos.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());

            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void dgvTurnos_Sorting(object sender, GridViewSortEventArgs e)
        {
            ddlFiltroBuscar.SelectedValue = "0";
            txtBuscarFiltro.Text = "";
            ddlMostrar.SelectedValue = "0";

            string selectOrdenar = "SELECT * FROM ExportTurnos ORDER BY " + e.SortExpression + " "
                                    + GetSortDirection(e.SortExpression);

            dgvTurnos.DataSource = sentencia.DSET(selectOrdenar);
            dgvTurnos.DataBind();
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

        protected void ddlMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = ddlMostrar.SelectedValue.ToString();
            int resultado = ContarResultadosDB(seleccion, "null", "null");

            if (ddlMostrar.SelectedValue != "0")
            {
                if (seleccion == "Hoy")
                {
                    if (resultado != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Para el día de hoy, hay " + resultado + " turno/s.')", true);

                        string selectTurnosHoy = "SELECT * FROM ExportTurnos WHERE " +
                                                 "CONVERT(VARCHAR(10),Fecha,105) " +
                                                 "= " +
                                                 "CONVERT(VARCHAR(10),GETDATE(),105) ";

                        dgvTurnos.DataSource = sentencia.DSET(selectTurnosHoy);
                        dgvTurnos.DataBind();

                        btnExportExcel.Enabled = true;
                        btnExportExcel.Visible = true;
                        dgvTurnos.Visible = true;
                        ddlFiltroBuscar.SelectedValue = "0";
                        txtBuscarFiltro.Text = "";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Todavía no hay turnos para el día de hoy.')", true);

                        ddlFiltroBuscar.SelectedValue = "0";
                        txtBuscarFiltro.Text = "";
                    }
                }
                else if (seleccion == "Cumplidos")
                {
                    if (resultado != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Al día de hoy, hay " + resultado + " turno/s cumplido/s.')", true);

                        string selectTurnosHoy = "SELECT * FROM ExportTurnos WHERE " +
                                                 "CONVERT(VARCHAR(10),Fecha,105) " +
                                                 "< " +
                                                 "CONVERT(VARCHAR(10),GETDATE(),105) ";

                        dgvTurnos.DataSource = sentencia.DSET(selectTurnosHoy);
                        dgvTurnos.DataBind();

                        btnExportExcel.Enabled = true;
                        btnExportExcel.Visible = true;
                        dgvTurnos.Visible = true;
                        ddlFiltroBuscar.SelectedValue = "0";
                        txtBuscarFiltro.Text = "";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Todavía no hay turnos cumplidos.')", true);

                        ddlFiltroBuscar.SelectedValue = "0";
                        txtBuscarFiltro.Text = "";
                    }
                }
                else if (seleccion == "Futuros")
                {
                    if (resultado != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Al día de hoy, hay " + resultado + " turno/s futuro/s.')", true);

                        string selectTurnosHoy = "SELECT * FROM ExportTurnos WHERE " +
                                                 "CONVERT(VARCHAR(10),Fecha,105) " +
                                                 "> " +
                                                 "CONVERT(VARCHAR(10),GETDATE(),105) ";

                        dgvTurnos.DataSource = sentencia.DSET(selectTurnosHoy);
                        dgvTurnos.DataBind();

                        btnExportExcel.Enabled = true;
                        btnExportExcel.Visible = true;
                        dgvTurnos.Visible = true;
                        ddlFiltroBuscar.SelectedValue = "0";
                        txtBuscarFiltro.Text = "";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Todavía no hay turnos futuros.')", true);

                        ddlFiltroBuscar.SelectedValue = "0";
                        txtBuscarFiltro.Text = "";
                    }
                }
            }
            else
            {
                BindData();
            }
        }

        protected int ContarResultadosDB(string cadena, string campo, string variable)
        {
            AccesoDatos datos = new AccesoDatos();

            int Resultado = 0;

            string selectDB;

            if (cadena != "null")
            {
                if (cadena == "Hoy")
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM ExportTurnos WHERE " +
                               "CONVERT(VARCHAR(10),Fecha,105) " +
                               "= " +
                               "CONVERT(VARCHAR(10),GETDATE(),105) ";
                }
                else if (cadena == "Cumplidos")
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM ExportTurnos WHERE " +
                               "CONVERT(VARCHAR(10),Fecha,105) " +
                               "< " +
                               "CONVERT(VARCHAR(10),GETDATE(),105) ";
                }
                else if (cadena == "Futuros")
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM ExportTurnos WHERE " +
                               "CONVERT(VARCHAR(10),Fecha,105) " +
                               "> " +
                               "CONVERT(VARCHAR(10),GETDATE(),105) ";
                }
                else
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM ExportTurnos";
                }
            }
            else
            {
                selectDB = "SELECT COUNT(*) as Cantidad FROM ExportTurnos WHERE " + campo + " LIKE '%" + variable + "%'";
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

        protected void btnBuscarFiltro_Click(object sender, EventArgs e)
        {
            if (ddlFiltroBuscar.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Filtro de búsqueda no seleccionado.')", true);
            }
            else if (txtBuscarFiltro.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Filtro de texto vacío.')", true);
            }
            else
            {
                int resultado = ContarResultadosDB("null", ddlFiltroBuscar.SelectedValue.ToString(), txtBuscarFiltro.Text);

                if (resultado != 0 && ddlFiltroBuscar.SelectedValue.ToString() != "ID")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('" + resultado + " turno/s coincide/n con la búsqueda.')", true);

                    string filtroBusqueda = ddlFiltroBuscar.SelectedValue.ToString();
                    string filtroTexto = txtBuscarFiltro.Text;

                    string selectFiltro = "SELECT * FROM ExportTurnos WHERE " +
                                          filtroBusqueda + " LIKE '%" + filtroTexto + "%'";

                    dgvTurnos.DataSource = sentencia.DSET(selectFiltro);
                    dgvTurnos.DataBind();

                    btnExportExcel.Enabled = true;
                    btnExportExcel.Visible = true;
                    dgvTurnos.Visible = true;
                    ddlFiltroBuscar.SelectedValue = "0";
                    txtBuscarFiltro.Text = "";
                }
                else if (resultado != 0 && ddlFiltroBuscar.SelectedValue.ToString() == "ID") //EDITAR - ELIMINAR
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se muestra a continuación, el turno cuyo ID es igual a " + txtBuscarFiltro.Text + "')", true);

                    string filtroBusqueda = ddlFiltroBuscar.SelectedValue.ToString();
                    string filtroTexto = txtBuscarFiltro.Text;

                    string selectFiltro = "SELECT * FROM ExportTurnos WHERE " +
                                          filtroBusqueda + " = '" + filtroTexto + "'";

                    dgvTurnos.DataSource = sentencia.DSET(selectFiltro);
                    dgvTurnos.DataBind();

                    btnExportExcel.Enabled = true;
                    btnExportExcel.Visible = true;
                    dgvTurnos.Visible = true;
                    ddlFiltroBuscar.SelectedValue = "0";
                    txtBuscarFiltro.Text = "";
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Su búsqueda no produjo ningún resultado.')", true);
                }
            }
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            /*  
                CAMPOS DE EXPORT DGV TURNOS
               
                ID (no permitir edicion oculto)
                Día de la semana (completar automaticamente oculto)
                Fecha (utilizar fechas >= hoy)
                Hora (utilizar ddl turnos)
                Cliente (completar automaticamente oculto)
                CUIT_DNI (utilizar ddl)
                Patente (utilizar ddl)
                IDHorario (volver a calcular oculto) 

                HACER TODO CON UN TRIGGER (instead of) EN LA DB
            */
        }

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datos2 = new AccesoDatos();

            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            string dia = fecha.DayOfWeek.ToString();
            string selectCantidad;

            if (dia == "Saturday")
            {
                string selectddl = "select * from HorariosSabado";

                ddlHoraTurno.DataSource = sentencia.DSET(selectddl);
                ddlHoraTurno.DataMember = "datos";
                ddlHoraTurno.DataTextField = "Sabado";
                ddlHoraTurno.DataValueField = "ID";
                ddlHoraTurno.DataBind();

                selectCantidad = "select count(*) as Cantidad from HorariosSabado";
            }
            else
            {
                string selectddl = "select * from HorariosLunesViernes";

                ddlHoraTurno.DataSource = sentencia.DSET(selectddl);
                ddlHoraTurno.DataMember = "datos";
                ddlHoraTurno.DataTextField = "LunesViernes";
                ddlHoraTurno.DataValueField = "ID";
                ddlHoraTurno.DataBind();

                selectCantidad = "select count(*) as Cantidad from HorariosLunesViernes";
            }

            string IdHorarioTurnosCargados = "EXEC SP_TURNOS_SELECCIONADOS '" + fecha.ToShortDateString() + "'";

            try
            {
                datos.SetearConsulta(IdHorarioTurnosCargados);
                datos.EjecutarLectura();

                datos2.SetearConsulta(selectCantidad);
                datos2.EjecutarLectura();

                int cantidad = 0;

                if (datos2.Lector.Read()) { cantidad = Convert.ToInt32(datos2.Lector["Cantidad"]); }

                while (datos.Lector.Read())
                {
                    int IdHorario = Convert.ToInt32(datos.Lector["ID"]);

                    for (int i = 1; i < cantidad + 1; i++)
                    {
                        if (i == IdHorario)
                        {
                            string value = i.ToString();

                            ddlHoraTurno.SelectedValue = value;
                            ddlHoraTurno.SelectedItem.Enabled = false;
                        }
                    }
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Error al calcular la cantidad de horarios en la DB.')", true);
            }
            finally
            {
                datos.CerrarConexion();
                datos2.CerrarConexion();
            }
        }
    }
}