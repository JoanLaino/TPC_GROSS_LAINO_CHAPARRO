using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class ABMVehiculos : System.Web.UI.Page
    {
        AccesoDatos sentencia = new AccesoDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            validarNivelUsuario();

            string MarcasVehiculo = "SELECT * FROM MarcasVehiculo ORDER BY Descripcion";

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
            string selectVehiculos = "SELECT * FROM ExportVehiculos ORDER BY [Fecha de alta] ASC";

            cargarDdlAños();

            dgvVehiculos.DataSource = sentencia.DSET(selectVehiculos);
            dgvVehiculos.DataBind();
        }

        private void cargarDdlAños()
        {
            List<int> listaAños = new List<int>();

            int añoDesde = 1970;
            int añoHasta = DateTime.Today.Year;

            for (int i = añoDesde; i <= añoHasta; i++)
            {
                listaAños.Add(i);
            }

            int tamaño = añoHasta - añoDesde;

            for (int i = 0; i <= tamaño; i++)
            {
                ddlAnioFabricacion.Items.Add(listaAños[i].ToString());
                ddlAnioFabricacion2.Items.Add(listaAños[i].ToString());
            }
        }

        protected void dgvVehiculos_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindData();

            string selectOrdenar = "SELECT * FROM ExportVehiculos ORDER BY " + e.SortExpression + " "
                                    + GetSortDirection(e.SortExpression);

            dgvVehiculos.DataSource = sentencia.DSET(selectOrdenar);
            dgvVehiculos.DataBind();
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
            Response.AddHeader("content-disposition", "attachment;filename = ExportVehiculos " + DateTime.Now.ToString() + ".xls");
            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWriter = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            dgvVehiculos.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());

            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void imgBtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            if (txtBuscar.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Filtro de texto vacío.')", true);

                BindData();
            }
            else
            {
                string selectBuscar = "SELECT * FROM ExportVehiculos " +
                                      "WHERE " + ddlFiltroBuscar.SelectedValue 
                                      + " = '" + txtBuscar.Text +
                                      "' ORDER BY [Fecha de alta] ASC";

                dgvVehiculos.DataSource = sentencia.DSET(selectBuscar);
                dgvVehiculos.DataBind();

                try
                {
                    datos.SetearConsulta(selectBuscar);
                    datos.EjecutarLectura();

                    if (datos.Lector.Read() && ddlFiltroBuscar.SelectedValue == "Patente")
                    {
                        long id = Convert.ToInt64(datos.Lector["ID"]);
                        string Patente = datos.Lector["Patente"].ToString();
                        string Marca = datos.Lector["Marca"].ToString();
                        string Modelo = datos.Lector["Modelo"].ToString();
                        string AnioFabricacion = datos.Lector["Año de fabricación"].ToString();
                        string Cliente = datos.Lector["Cliente"].ToString();
                        string Estado = datos.Lector["Estado"].ToString();
                    }
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Se produjo un error en la búsqueda.\n\n" +
                    "Por favor reintenta más tarde.')", true);

                    BindData();
                }
            }
        }
    }
}