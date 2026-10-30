using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FICHA_TECNICA
    {
        private DAL.MP_FICHA_TECNICA mpFicha = new DAL.MP_FICHA_TECNICA();
        private BLL.RESERVA gestorReserva = new BLL.RESERVA();

        public void ConsolidarFicha(BE.FICHA_TECNICA datosFicha)
        {
            mpFicha.RegistrarDetalles(datosFicha);

            CalcularCostoYSaldo(datosFicha);
        }

        private void CalcularCostoYSaldo(BE.FICHA_TECNICA datosFicha)
        {
            decimal costoCatering = datosFicha.Cantidad_Invitados_Final * datosFicha.CateringAsociado.Precio_Por_Persona;

            decimal costoProveedores = 0;
            foreach (var prov in datosFicha.PrestadoresAsignados)
            {
                costoProveedores += prov.Precio_Servicio;
            }

            decimal costoTotal = costoCatering + costoProveedores;
            decimal saldoPendiente = costoTotal - datosFicha.ReservaAsociada.Monto_Senia;
            datosFicha.Costo_Total_Real = costoTotal;
            datosFicha.Saldo_Pendiente = saldoPendiente;

            if(datosFicha.ReservaAsociada!=null)
            {
                datosFicha.ReservaAsociada.Costo_Total_Real = costoTotal;
                datosFicha.ReservaAsociada.Saldo_Pendiente = saldoPendiente;
                datosFicha.ReservaAsociada.Estado = "Planificado";
            }
            gestorReserva.ActualizarCostosyEstadoReserva(datosFicha.Id_Reserva, costoTotal, saldoPendiente, "Planificado");
        }
    }
}

