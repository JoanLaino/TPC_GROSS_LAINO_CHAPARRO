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
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    aux.TipoProducto = new TipoProducto((string)datos.Lector["TipoProducto"]);
                    aux.Marca = new Marca((string)datos.Lector["Marca"]);
                    aux.Proveedor = new Proveedor((string)datos.Lector["Proveedor"]);
                    aux.FechaCompra = ((DateTime)datos.Lector["FechaCompra"]);
                    aux.FechaVencimiento = ((DateTime)datos.Lector["FechaVencimiento"]);
                    aux.Costo = Math.Truncate((decimal)datos.Lector["Costo"] * 100) / 100;
                    aux.PrecioVenta = Math.Truncate((decimal)datos.Lector["PrecioVenta"] * 100) / 100;
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    
                    lista.Add(aux);
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
