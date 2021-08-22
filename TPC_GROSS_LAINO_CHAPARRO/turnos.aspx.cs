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
            lblRegistro.Visible = false;
            btnRegistro.Visible = false;
            txtCuitDni.Enabled = true;
            btnBuscarCuitDni.Text = "Siguiente paso";
            btnAgregarVehículo.Visible = false;

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

                        string selectNombreCliente = "SELECT * FROM Clientes WHERE CUIT_DNI = '" + cuitDni + "'";

                        datos4.SetearConsulta(selectNombreCliente);
                        datos4.EjecutarLectura();

                        string cliente = "";
                        long IDCliente = 0;

                        if (datos4.Lector.Read())
                        {
                            IDCliente = Convert.ToInt64(datos4.Lector["ID"]);
                            cliente = (string)datos4.Lector[campo];
                        }

                        long IDVehiculo = Convert.ToInt64(ddlVehiculos.SelectedValue);
                        int idHora = Convert.ToInt32(ddlHoraTurno.SelectedValue);
                        string diaFecha = calendarioTurnos.SelectedDate.Day.ToString();
                        if (calendarioTurnos.SelectedDate.Day < 10) { diaFecha = "0" + diaFecha; }
                        string mesFecha = calendarioTurnos.SelectedDate.Month.ToString();
                        if (calendarioTurnos.SelectedDate.Month < 10) { mesFecha = "0" + mesFecha; }
                        int añoFecha = calendarioTurnos.SelectedDate.Year;
                        string fecha = diaFecha + "-" + mesFecha + "-" + añoFecha;
                        string hora = ddlHoraTurno.SelectedItem.ToString();
                        string dia = calendarioTurnos.SelectedDate.DayOfWeek.ToString();
                        if (dia == "Monday") { dia = "Lunes"; }
                        else if (dia == "Tuesday") { dia = "Martes"; }
                        else if (dia == "Wednesday") { dia = "Miércoles"; }
                        else if (dia == "Thursday") { dia = "Jueves"; }
                        else if (dia == "Friday") { dia = "Viernes"; }
                        else if (dia == "Saturday") { dia = "Sábado"; }

                        int resultadoTurnos = ContarResultadosDB_DosVariablesUnaCadena("Turnos", "CONVERT(VARCHAR(10),FechaHora,105)", fecha, "IdCliente", IDCliente, "IdVehiculo", IDVehiculo);

                        if (resultadoTurnos == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            "alert('Ya existe un turno pendiente para usted, para la patente seleccionada,\\n\\n" +
                            "para el día " + fecha + ".\\n\\n" + 
                            "Si desea modificarlo, deberá comunicarse con nosotros a la brevedad.')", true);
                        }
                        else
                        {
                            string insertTurno = "EXEC SP_AGREGAR_TURNO '" + fecha + " " + hora + "', " + idHora + ", '" + dia + "', " + IDCliente + ", " + IDVehiculo;

                            sentencia.IUD(insertTurno);

                            BindData();

                            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            "alert('El turno para el día " + dia + " " +
                            fecha + ", a las " + hora + "" +
                            "hs, para el cliente " + cliente + " " +
                            "se ha agregado correctamente')", true);

                            AccesoDatos datos5 = new AccesoDatos();

                            datos5.SetearConsulta("SELECT ID AS ID FROM Turnos WHERE " +
                                                  "IdCliente = " + IDCliente + " AND " +
                                                  "IdVehiculo = " + IDVehiculo + " AND " +
                                                  "CONVERT(VARCHAR(10),FechaHora,105) = '" + fecha + "' AND " +
                                                  "CONVERT(VARCHAR(5),FechaHora,108) = '" + hora + "'");

                            string IDTurno = "NULL";

                            if (datos5.Lector.Read())
                            {
                                IDTurno = datos.Lector["ID"].ToString();
                            }

                            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            "alert('El ID de su turno es " + ID + "\\n\\n" +
                            "Por favor consérvelo !!!.')", true);
                        }
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
                        lblRegistro.Visible = false;
                        btnRegistro.Visible = false;

                        string CuitDni = txtCuitDni.Text;
                        string campo = "ApeNom";

                        if (txtCuitDni.Text.Length > 8) { campo = "RazonSocial"; }

                        int resultadoCliente;

                        resultadoCliente = ContarResultadosDB_UnaCadena("Clientes", "CUIT_DNI", CuitDni);

                        if (resultadoCliente != 0)
                        {
                            string selectIdCliente = "SELECT * FROM Clientes WHERE CUIT_DNI = '" + CuitDni + "'";
                            long IdCliente;

                            datos2.SetearConsulta(selectIdCliente);
                            datos2.EjecutarLectura();

                            if (datos2.Lector.Read())
                            {
                                IdCliente = Convert.ToInt64(datos2.Lector["ID"]);
                                string clienteEncontrado = (string)datos2.Lector[campo];

                                int resultado2 = 0;

                                resultado2 = ContarResultadosDB_UnaVariable("Vehiculos", "IdCliente", IdCliente);

                                if (resultado2 != 0) //hay al menos un auto cargado
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                                    "alert('Bienvenido nuevamente " + clienteEncontrado + ".\\n\\n" +
                                    "En el próximo paso seleccione por favor el vehículo.\\n\\n" +
                                    "Si no está en la lista, también puede agregar uno nuevo.')", true);

                                    string selectDdlVehiculos = "SELECT * FROM Vehiculos WHERE IdCliente = " + IdCliente;

                                    ddlVehiculos.DataSource = sentencia.DSET(selectDdlVehiculos);
                                    ddlVehiculos.DataMember = "datos";
                                    ddlVehiculos.DataTextField = "Patente";
                                    ddlVehiculos.DataValueField = "ID";
                                    ddlVehiculos.DataBind();

                                    btnBuscarCuitDni.Text = "Confirmar Turno";
                                    txtCuitDni.Enabled = false;
                                    ddlHoraTurno.Enabled = false;
                                    calendarioTurnos.Enabled = false;

                                    lblVehiculos.Visible = true;
                                    ddlVehiculos.Visible = true;
                                    btnAgregarVehículo.Visible = true;

                                    //MOSTRAR BOTON PARA AGREGAR UN NUEVO VEHICULO.
                                }
                                else //no hay autos cargados
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                                    "alert('No se encontraron vehículos cargados.\\n\\n" +
                                    "Por favor contáctenos a la brevedad para resolver el problema.')", true);
                                }
                            }
                        }
                        else //no existe el cuit / dni en la DB
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            "alert('No se encontraron resultados, revise el CUIT / DNI ingresado.\\n\\n" +
                            "Si todavía no esta registrado, debe hacerlo por unica vez.')", true);

                            lblRegistro.Visible = true;
                            btnRegistro.Visible = true;
                        }
                    }
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Error al intentar reservar el turno. Por favor reintente nuevamente en unos minutos.')", true);
            }
            finally
            {
                datos.CerrarConexion();
                datos2.CerrarConexion();
            }
        }

        protected int ContarResultadosDB_UnaVariable(string tabla, string campo, long variable)
        {
            AccesoDatos datos = new AccesoDatos();

            int Resultado = 0;

            string selectDB = "SELECT COUNT(*) Cantidad FROM " + tabla + " WHERE " + campo + " = " + variable;

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

        protected int ContarResultadosDB_UnaCadena(string tabla, string campo, string cadena)
        {
            AccesoDatos datos = new AccesoDatos();

            int Resultado = 0;

            string selectDB = "SELECT COUNT(*) Cantidad FROM " + tabla + " WHERE " + campo + " = '" + cadena + "'";

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

        protected int ContarResultadosDB_DosVariablesUnaCadena(string tabla, string campo1, string cadena, string campo2, long variable1, string campo3, long variable2)
        {
            AccesoDatos datos = new AccesoDatos();

            int Resultado = 0;

            string selectDB = "SELECT COUNT(*) Cantidad FROM " + tabla + " WHERE " + campo1 + " = '" + cadena + 
                              "' AND " + campo2 + " = " + variable1 + " AND " + campo3 + " = " + variable2;

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

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("registroCliente.aspx");
        }

        protected void btnAgregarVehículo_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            long idCliente = 0;
            string cliente = "";

            string selectIdCliente = "SELECT * FROM Clientes WHERE CUIT_DNI = '" + txtCuitDni.Text + "'";

            datos.SetearConsulta(selectIdCliente);
            datos.EjecutarLectura();

            if (datos.Lector.Read()) 
            { 
                idCliente = Convert.ToInt64(datos.Lector["ID"]);
                if (txtCuitDni.Text.Length > 8)
                {
                    cliente = (string)datos.Lector["RazonSocial"];
                    Session.Add("RazonSocial", cliente);
                    Session.Add("ApeNom", "vacio");
                }
                else
                {
                    cliente = (string)datos.Lector["ApeNom"];
                    Session.Add("ApeNom", cliente);
                    Session.Add("RazonSocial", "vacio");
                }
            }

            Session.Add("idClienteRegistrado", idCliente);
            Session.Add("CuitDni", "vacio");
            Session.Add("Telefono", "vacio");
            Session.Add("Mail", "vacio");
            Session.Add("TipoCliente", "vacio");

            Response.Redirect("registroVehiculo.aspx");
        }
    }
}