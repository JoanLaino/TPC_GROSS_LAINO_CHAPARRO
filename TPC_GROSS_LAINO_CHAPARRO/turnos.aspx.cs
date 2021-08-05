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
            lblHora.Visible = false;
            ddlHoraTurno.Visible = false;
            ddlHoraTurno.Enabled = true;
            txtCuitDni.Visible = false;
            txtCuitDni.Text = "";
            btnBuscarCuitDni.Visible = false;
            calendarioTurnos.Enabled = true;
            ddlVehiculos.Visible = false;
            lblVehiculos.Visible = false;
            lblCuitDni.Visible = false;
            btnRegistro.Visible = false;
            btnBuscarCuitDni.Text = "Siguiente paso";

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

            lblHora.Visible = true;
            ddlHoraTurno.Visible = true;
            lblCuitDni.Visible = true;
            txtCuitDni.Visible = true;
            btnBuscarCuitDni.Visible = true;
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

        protected void btnBuscarCuitDni_Click(object sender, EventArgs e)
        {
            //Si existe, mostrar patentes del cliente en un DDL y luego confirmar turno. (también mostrar opción de agregar vehículo nuevo).

            //Si no existe, mostrar boton para que el cliente se registre y ocultar todo lo demás. (en un pop up)

            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                if (btnBuscarCuitDni.Text == "Confirmar Turno")
                {
                    AccesoDatos datos4 = new AccesoDatos();
                    try
                    {
                        string cuitDni = txtCuitDni.Text;
                        string campo;

                        if (txtCuitDni.Text.Length > 8) //si es mayor a 8, se ingresó un CUIT
                        { campo = "RazonSocial"; }
                        else { campo = "ApeNom"; }

                        string selectNombreCliente = "SELECT * FROM Clientes WHERE CUIT_DNI = " + cuitDni;

                        datos4.SetearConsulta(selectNombreCliente);
                        datos4.EjecutarLectura();

                        string cliente = "";
                        long IDCliente = 0;

                        if (datos4.Lector.Read())
                        {
                            cliente = (string)datos4.Lector[campo];
                            IDCliente = Convert.ToInt64(datos4.Lector["ID"]);
                        }

                        long IDVehiculo = Convert.ToInt64(ddlVehiculos.SelectedValue);
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

                        string insertTurno = "EXEC SP_AGREGAR_TURNO '" + fecha + " " + hora + "', " + idHora + ", '" + dia + "', " + IDCliente + ", " + IDVehiculo;

                        sentencia.IUD(insertTurno);

                        BindData();

                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('El turno para el día " + dia + " " + 
                        fecha + ", a las " + hora + "" +
                        "hs, para el cliente " + cliente + " " +
                        "se ha agregado correctamente')", true);
                    }
                    catch
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Error al intentar reservar el turno. Por favor reintente nuevamente en unos minutos.')", true);
                    }
                    finally
                    {
                        datos4.CerrarConexion();
                    }
                }
                else
                {
                    if (txtCuitDni.Text == "")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Debe ingresar un CUIT ó DNI por favor.')", true);
                    }
                    else
                    {
                        string CuitDni = txtCuitDni.Text;
                        
                        int resultado = 0;

                        resultado = ContarResultadosDB("Clientes", "CUIT_DNI", 0, CuitDni);

                        if (resultado != 0)
                        {
                            string selectIdCliente = "SELECT ID FROM Clientes WHERE CUIT_DNI = '" + CuitDni + "'";
                            long IdCliente;

                            datos2.SetearConsulta(selectIdCliente);
                            datos2.EjecutarLectura();

                            if (datos2.Lector.Read())
                            {
                                IdCliente = Convert.ToInt64(datos2.Lector["ID"]);

                                int resultado2 = 0;

                                resultado2 = ContarResultadosDB("Vehiculos", "IdCliente", IdCliente, "null");

                                if (resultado != 0) //hay al menos un auto cargado
                                {
                                    string selectDdlVehiculos = "SELECT * FROM Vehiculos WHERE IdCliente = " + IdCliente;

                                    ddlVehiculos.DataSource = sentencia.DSET(selectDdlVehiculos);
                                    ddlVehiculos.DataMember = "datos";
                                    ddlVehiculos.DataTextField = "Patente";
                                    ddlVehiculos.DataValueField = "ID";
                                    ddlVehiculos.DataBind();

                                    btnBuscarCuitDni.Text = "Confirmar Turno";

                                    lblVehiculos.Visible = true;
                                    ddlVehiculos.Visible = true;
                                }
                                else //no hay autos cargados
                                {
                                    
                                }
                            }
                        }
                        else //no existe el cuit / dni en la DB
                        {
                            if (txtCuitDni.Text.Length > 8)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                                "alert('No se encontró el CUIT " +  txtCuitDni.Text + " en la base de datos. Por favor registrese.')", true);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                                "alert('No se encontró el DNI " + txtCuitDni.Text + " en la base de datos. Por favor registrese.')", true);
                            }

                            BindData();

                            btnRegistro.Visible = true;
                        }
                    }
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
                datos2.CerrarConexion();
            }
        }

        protected int ContarResultadosDB(string tabla, string campo, long variable, string cadena)
        {
            AccesoDatos datos = new AccesoDatos();

            int Resultado = 0;

            string selectDB;

            if (cadena == "null")
            {
                selectDB = "SELECT COUNT(*) Cantidad FROM " + tabla + " WHERE " + campo + " = " + variable;
            }
            else
            {
                selectDB = "SELECT COUNT(*) Cantidad FROM " + tabla + " WHERE " + campo + " = '" + cadena + "'";
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
                "alert('Se produjo un error al intentar leer la tabla: " + tabla + " en la base de datos.')", true);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return Resultado;
        }
    }
}