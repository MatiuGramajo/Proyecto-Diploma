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
            // 1. Guardar detalles
            mpFicha.RegistrarDetalles(datosFicha);

            // 2. Realizar los cálculos auto-llamados
            CalcularCostoYSaldo(datosFicha);
        }

        private void CalcularCostoYSaldo(BE.FICHA_TECNICA datosFicha)
        {
            decimal costoCatering = datosFicha.Cantidad_Invitados_Final * datosFicha.CateringAsociado.Precio_Por_Persona;

            // 2. Suma de los honorarios de cada proveedor seleccionado
            decimal costoProveedores = 0;
            foreach (var prov in datosFicha.PrestadoresAsignados)
            {
                costoProveedores += prov.Precio_Servicio;
            }

            // 3. Costo Total Real y Saldo Pendiente
            decimal costoTotal = costoCatering + costoProveedores;
            decimal saldoPendiente = costoTotal - datosFicha.ReservaAsociada.Monto_Senia;

            // 4. Actualización en la base de datos a través de la BLL de Reserva
            gestorReserva.ActualizarCostosyEstadoReserva(datosFicha.Id_Reserva, costoTotal, saldoPendiente, "Planificado");
        }
    }
}

