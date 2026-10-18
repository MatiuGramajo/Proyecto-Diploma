using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PRESUPUESTO
    {
        private DAL.MP_PRESUPUESTO mpPresupuesto = new DAL.MP_PRESUPUESTO();

        // Diagrama CU-02: CalcularCotizacion(invitados, tipoEvento)
        public decimal CalcularCotizacion(int invitados, string tipoEvento)
        {
            // Bloque de Flujo Alternativo: Invitados cargados erróneamente
            if (invitados <= 0)
            {
                throw new Exception("Ingrese la cantidad de invitados correcta.");
            }

            decimal tarifaValor = mpPresupuesto.ObtenerTarifa(tipoEvento);

            // Retorna el subtotal calculado
            return tarifaValor * invitados;
        }

        // Diagrama CU-02: GuardarPresupuesto(presupuesto)
        public void GuardarPresupuesto(BE.PRESUPUESTO presupuesto)
        {
            mpPresupuesto.Alta(presupuesto);
        }
    }
}
