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
            // Flujo Alternativo: Datos cargados incorrectamente
            if (datosPago.Monto_Senia <= 0)
            {
                throw new Exception("Faltan campos para continuar con el pago.");
            }

            // Flujo principal en cascada hacia la DAL
            mpPagoSena.RegistrarCobro(datosPago);
            mpPagoSena.ActualizarEstadoPresupuesto(presupuesto);
            mpPagoSena.ActualizarEstadoFecha(datosPago);

            // Retornamos el ID como NroComprobante que pide la GUI al final del diagrama
            return datosPago.Id_Reserva;
        }
    }
}
