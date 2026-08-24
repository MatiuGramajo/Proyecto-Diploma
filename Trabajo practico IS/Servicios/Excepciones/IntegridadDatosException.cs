using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Excepciones
{
    public class IntegridadDatosException : Exception
    {
        public string TablaCorrupta { get; private set; }
        public string RegistroAfectado { get; private set; }
        public string DetalleTecnico { get; private set; }

        public IntegridadDatosException(string tabla, string registro, string detalle) : base("Error crítico de integridad en la base de datos.")
        {
            TablaCorrupta = tabla;
            RegistroAfectado = registro;
            DetalleTecnico = detalle;
        }
    }
}
