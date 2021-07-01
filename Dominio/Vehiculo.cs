using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public Marca Marca { get; set; }
        public double Modelo { get; set; } //puede ser int?
        public double AnioFabricacion { get; set; } //puede ser int?
        public string FechaAlta { get; set; } //puede ser datetime
        public string CUIL_CUIT { get; set; }
        
        public Vehiculo(string patente)
        {
            Patente = patente;
        }
        public override string ToString()
        {
            return Patente;
        }
    }
}
