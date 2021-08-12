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
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            ddlFiltroBuscar.SelectedValue = "0";
            txtBuscarFiltro.Text = "";
            ddlMostrar.SelectedValue = "0";
            btnExportExcel.Visible = false;
            btnExportExcel.Enabled = false;
            dgvTurnos.Visible = false;
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
            BindData();

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
                ddlFiltroBuscar.SelectedValue = "0";
                txtBuscarFiltro.Text = "";

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
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Todavía no hay turnos para el día de hoy.')", true);

                        BindData();
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
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Todavía no hay turnos cumplidos.')", true);

                        BindData();
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
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Todavía no hay turnos futuros.')", true);

                        BindData();
                    }
                }
                else if (seleccion == "Todos")
                {
                    if (resultado != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            "alert('En total, al día de hoy, hay " + resultado + " turno/s.')", true);

                        string selectTurnosHoy = "SELECT * FROM ExportTurnos";

                        dgvTurnos.DataSource = sentencia.DSET(selectTurnosHoy);
                        dgvTurnos.DataBind();

                        btnExportExcel.Enabled = true;
                        btnExportExcel.Visible = true;
                        dgvTurnos.Visible = true;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Todavía no hay turnos cargados.')", true);

                        BindData();
                    }
                }
            }
            else
            {
                Response.Redirect("ABMTurnos.aspx");
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
                               "<= " +
                               "CONVERT(VARCHAR(10),GETDATE(),105) ";
                }
                else if (cadena == "Futuros")
                {
                    selectDB = "SELECT COUNT(*) as Cantidad FROM ExportTurnos WHERE " +
                               "CONVERT(VARCHAR(10),Fecha,105) " +
                               ">= " +
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
            int resultado = ContarResultadosDB("null", ddlFiltroBuscar.SelectedValue.ToString(), txtBuscarFiltro.Text);

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
                if (resultado != 0)
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
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Su búsqueda no produjo ningún resultado.')", true);
                }
            }
        }
    }
}