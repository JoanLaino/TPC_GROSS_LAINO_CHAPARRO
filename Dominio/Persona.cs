using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public string ApeNom_RazonSocial { get; set; }
        public string FechaAlta { get; set; } //puede ser datetime
        public string Mail { get; set; }
        public string Celular { get; set; }
        public string FechaNacimiento { get; set; } //puede ser datetime
        public string CUIL_CUIT { get; set; }
        public bool Estado { get; set; }
        
        public Persona(string apeNom_RazonSocial)
        {
            ApeNom_RazonSocial = apeNom_RazonSocial;
        }
        public override string ToString()
        {
            return ApeNom_RazonSocial;
        }
    }
}
