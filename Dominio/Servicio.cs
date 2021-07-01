using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Servicio
    {
        public long ID { get; set; }
        public string FechaRealizacion { get; set; } //puede ser datetime
        public Vehiculo Vehiculo { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public string Comentarios { get; set; }
        public Cliente Cliente { get; set; }
        public string FechaPedidoTurno { get; set; } //puede ser datetime
        public bool Estado { get; set; }
    }
}
