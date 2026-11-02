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

        public decimal CalcularCotizacion(int invitados, string tipoEvento)
        {
            if (invitados <= 0)
            {
                throw new Exception("Ingrese la cantidad de invitados correcta.");
            }

            decimal tarifaValor = mpPresupuesto.ObtenerTarifa(tipoEvento);

            return tarifaValor * invitados;
        }

        public void GuardarPresupuesto(BE.PRESUPUESTO presupuesto)
        {
            mpPresupuesto.Alta(presupuesto);
        }
        public List<BE.PRESUPUESTO> ObtenerPresupuestosPendientes()
        {
            return mpPresupuesto.ListarPresupuestosPendientes();
        }
        public void ActualizarEstado(int idPresupuesto, string estado)
        {
            mpPresupuesto.ModificarEstado(idPresupuesto, estado);
        }
    }
}
