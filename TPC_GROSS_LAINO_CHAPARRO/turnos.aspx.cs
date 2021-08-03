using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_GROSS_LAINO_CHAPARRO
{
    public partial class turnos : System.Web.UI.Page
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
            ddlHoraTurno.Visible = false;

            string selectDgvTurnos = "SELECT * FROM ExportTurnos ORDER BY ID";

            dgvTurnos.DataSource = sentencia.DSET(selectDgvTurnos);
            dgvTurnos.DataBind();
        }

        protected void calendarioTurnos_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }

            if ( e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }

            if (e.Day.Date.Year < DateTime.Today.Year)
            {
                e.Day.IsSelectable = false;
            }

            if (e.Day.Date.Year == DateTime.Today.Year && e.Day.Date.Month < DateTime.Today.Month)
            {
                e.Day.IsSelectable = false;
            }

            if (e.Day.Date.Year == DateTime.Today.Year && e.Day.Date.Month == DateTime.Today.Month && e.Day.Date.Day <= DateTime.Today.Day)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void calendarioTurnos_SelectionChanged(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datos2 = new AccesoDatos();

            ddlHoraTurno.Visible = true;
            string dia = calendarioTurnos.SelectedDate.DayOfWeek.ToString();
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

            string fechaSeleccionada = calendarioTurnos.SelectedDate.ToShortDateString();

            string IdHorarioTurnosCargados = "EXEC SP_TURNOS_SELECCIONADOS '" + fechaSeleccionada + "'";

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
                    
                    for (int i = 1; i < cantidad+1; i++)
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
                "alert('Error al calcular cantidades.')", true);
            }
            finally
            {
                datos.CerrarConexion();
                datos2.CerrarConexion();
            }
        }

        protected void btnConfirmarFechaHora_Click(object sender, EventArgs e)
        {
            try
            {
                string cliente = "CLIENTE"; //Reemplazar valor por la variable del nombre del cliente.
                int idHora = Convert.ToInt32(ddlHoraTurno.SelectedValue);
                string fecha = calendarioTurnos.SelectedDate.ToShortDateString();
                string hora = ddlHoraTurno.SelectedItem.ToString();
                string dia = calendarioTurnos.SelectedDate.DayOfWeek.ToString();
                if (dia == "Monday") { dia = "Lunes"; }
                else if (dia == "Tuesday") { dia = "Martes"; }
                else if (dia == "Wednesday") { dia = "Miércoles"; }
                else if (dia == "Thursday") { dia = "Jueves"; }
                else if (dia == "Friday") { dia = "Viernes"; }
                else if (dia == "Saturday") { dia = "Sábado"; }

                string insertTurno = "EXEC SP_AGREGAR_TURNO '" + fecha + " " + hora + "', " + idHora + ", '" + dia + "'";

                sentencia.IUD(insertTurno);

                BindData();

                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('El turno para el día " + dia + " " + fecha + ", a las " + hora  + "hs, para el cliente " + cliente + " se ha agregado correctamente')", true);
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Error al intentar agregar el turno. Por favor reintente nuevamente en unos minutos.')", true);
            }
        }

    }
}