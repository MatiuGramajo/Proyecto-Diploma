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
        private Servicios.GESTOR_PDF gestorPDF= new Servicios.GESTOR_PDF();
        public bool ConsultarDisponibilidad(DateTime fecha)
        {
            return mpReserva.VerificarEstado(fecha);
        }

        public List<BE.RESERVA> ListarReservasConfirmadas()
        {
            return mpReserva.ListarConfirmadas();
        }
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
        public List<BE.RESERVA> ObtenerEventosPlanificados()
        {
            return mpReserva.ListarEventosPlanificados();
        }
        public void RegistrarLiquidacion(BE.RESERVA reservaSeleccionada, string metodoPago)
        {
            mpReserva.SaldarReserva(reservaSeleccionada.Id_Reserva);

            reservaSeleccionada.Saldo_Pendiente = 0;
            reservaSeleccionada.Estado = "Saldado";

            gestorPDF.GenerarComprobantePDF(reservaSeleccionada);
        }
    }
}
