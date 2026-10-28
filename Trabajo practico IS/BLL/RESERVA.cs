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
        private BLL.PRESUPUESTO gestorPresupuesto = new BLL.PRESUPUESTO();
        public bool ConsultarDisponibilidad(DateTime fecha)
        {
            // Devuelve true si la fecha está disponible, false si está ocupada
            return mpReserva.VerificarEstado(fecha);
        }

        public List<BE.RESERVA> ListarReservasConfirmadas()
        {
            return mpReserva.ListarConfirmadas();
        }
        // Diagrama CU-01: ConsultarFechasCercanas(fecha) (Flujo Alternativo)
        public List<DateTime> ConsultarFechasCercanas(DateTime fecha)
        {
            return mpReserva.ObtenerFechasAlternativas(fecha);
        }
        public void RegistrarReserva(BE.RESERVA nuevaReserva, BE.PRESUPUESTO presupuestoSeleccionado)
        {
            nuevaReserva.Estado = "Confirmada"; 
            mpReserva.Alta(nuevaReserva);

            gestorPresupuesto.ActualizarEstado(presupuestoSeleccionado.Id_Presupuesto, "Aprobado");
        }
        public List<DateTime> ListarFechasOcupadas()
        {
            return mpReserva.ObtenerFechasOcupadas();
        }
        public void ActualizarCostosyEstadoReserva(int idReserva, decimal costoTotal, decimal saldoPendiente, string estado)
        {
            mpReserva.ActualizarCostosyEstado(idReserva, costoTotal, saldoPendiente, estado);
        }
    }
}
