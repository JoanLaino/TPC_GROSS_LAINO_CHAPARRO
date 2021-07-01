using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario_Interno:Persona
    {
        public string TipoUsuario { get; set; }
        public string ClaveAcceso { get; set; }
    }
}
