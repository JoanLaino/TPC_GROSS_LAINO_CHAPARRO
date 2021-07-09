using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoDB
    {
        public static void ActualizarProducto()
        {

        }

        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from ExportInventario");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.EAN = (long)datos.Lector["EAN"];
                    aux.Descripción = (string)datos.Lector["Descripción"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    aux.TipoProducto = new TipoProducto((string)datos.Lector["TipoProducto"]);
                    aux.MarcaProducto= new MarcaProducto((string)datos.Lector["Marca"]);
                    aux.Proveedor = new Proveedor((string)datos.Lector["Proveedor"]);
                    aux.Costo = Math.Truncate((decimal)datos.Lector["Costo"] * 100) / 100;
                    aux.PrecioVenta = Math.Truncate((decimal)datos.Lector["PrecioVenta"] * 100) / 100;
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    if (aux.Estado == true)
                    {
                        lista.Add(aux);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
