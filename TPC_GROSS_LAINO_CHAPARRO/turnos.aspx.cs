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
            ddlHoraTurno.Visible = false;          
            
            if (!IsPostBack)
            {
                
            }
        }

        protected void calendarioTurnos_DayRender(object sender, DayRenderEventArgs e)
        {
            if(e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }

            if ( e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
                //e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void calendarioTurnos_SelectionChanged(object sender, EventArgs e)
        {
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

                selectCantidad = "select count(*) Cantidad from HorariosSabado";
            }
            else
            {
                string selectddl = "select * from HorariosLunesViernes";

                ddlHoraTurno.DataSource = sentencia.DSET(selectddl);
                ddlHoraTurno.DataMember = "datos";
                ddlHoraTurno.DataTextField = "LunesViernes";
                ddlHoraTurno.DataValueField = "ID";
                ddlHoraTurno.DataBind();

                selectCantidad = "select count(*) Cantidad from HorariosSabado";
            }
                        
            int cantidad = Convert.ToInt32(sentencia.DSET(selectCantidad));

            for (int i = 0; i < cantidad; i++)
            {
                string value = i.ToString();

                ddlHoraTurno.SelectedValue = value;

                if (ddlHoraTurno.SelectedValue == "ID traes de la otra consulta")
                {
                    ddlHoraTurno.SelectedValue = value;
                    ddlHoraTurno.SelectedItem.Enabled = false;
                }
            }
        }

        protected void btnAgregarTurno_Click(object sender, EventArgs e)
        {

            int idHora = Convert.ToInt32(ddlHoraTurno.SelectedValue);
            string fecha = calendarioTurnos.SelectedDate.ToShortDateString();
            string hora = ddlHoraTurno.SelectedItem.ToString();
            string insertTurno = "EXEC SP_AGREGAR_TURNO '" + fecha + " " + hora + "', " + idHora;

            sentencia.IUD(insertTurno);

            TextBox1.Text = fecha + " " + hora + " " + idHora;
        }
    }
}