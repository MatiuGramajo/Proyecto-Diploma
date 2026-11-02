using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PAGO_SEÑA
    {
        private DAL.MP_PAGO_SEÑA mpPagoSena = new DAL.MP_PAGO_SEÑA();

        public int ProcesarPago(BE.RESERVA datosPago, BE.PRESUPUESTO presupuesto)
        {
            if (datosPago.Monto_Senia <= 0)
            {
                throw new Exception("Faltan campos para continuar con el pago.");
            }

            mpPagoSena.RegistrarCobro(datosPago);
            mpPagoSena.ActualizarEstadoPresupuesto(presupuesto);
            mpPagoSena.ActualizarEstadoFecha(datosPago);

            return datosPago.Id_Reserva;
        }
    }
}
