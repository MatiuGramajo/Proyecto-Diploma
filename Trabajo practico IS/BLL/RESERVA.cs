using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RESERVA
    {
        private DAL.MP_RESERVA mpReserva = new DAL.MP_RESERVA();

        public bool ConsultarDisponibilidad(DateTime fecha)
        {
            // Devuelve true si la fecha está disponible, false si está ocupada
            return mpReserva.VerificarEstado(fecha);
        }

        // Diagrama CU-01: ConsultarFechasCercanas(fecha) (Flujo Alternativo)
        public List<DateTime> ConsultarFechasCercanas(DateTime fecha)
        {
            return mpReserva.ObtenerFechasAlternativas(fecha);
        }
    }
}
