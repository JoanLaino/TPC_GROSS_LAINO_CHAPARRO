using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoProducto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public TipoProducto(string descripcion)
        {
            Descripcion = descripcion;
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
