using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ASIGNACION_PERSONAL
    {

        private DAL.MP_ASIGNACION_PERSONAL mpAsignacion = new DAL.MP_ASIGNACION_PERSONAL();
        private BLL.PARAMETRO_RATIO bllRatio = new BLL.PARAMETRO_RATIO();
        private BLL.PERSONAL bllPersonal = new BLL.PERSONAL();

        public BE.DOTACION_DTO ObtenerDotacionYPersonalDisponible(BE.RESERVA reservaSeleccionada)
        {
            BE.DOTACION_DTO dto = new BE.DOTACION_DTO();

            List<BE.PARAMETRO_RATIO> ratios = bllRatio.ListarRatiosVigentes();
            dto.ListaPersonalDisponible = bllPersonal.ListarPersonalActivo();

            int invitados = (reservaSeleccionada.PresupuestoAsociado != null)
                ? reservaSeleccionada.PresupuestoAsociado.Cantidad_Invitados_Estimada
                : 0;

            foreach (BE.PARAMETRO_RATIO r in ratios)
            {
                if (r.Cantidad_Invitados_Por_Personal > 0)
                {
                    int cantidadRequerida = (int)Math.Ceiling((decimal)invitados / r.Cantidad_Invitados_Por_Personal);
                    dto.DotacionesRequeridas.Add(r.Categoria, cantidadRequerida);
                }
            }

            return dto;
        }

        public void GuardarAsignacion(int idReserva, List<BE.PERSONAL> listaPersonalAsignado, Dictionary<string, int> dotacionesRequeridas)
        {
            foreach (var req in dotacionesRequeridas)
            {
                string categoria = req.Key;
                int requeridos = req.Value;

                int asignados = listaPersonalAsignado.Count(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase));

                if (asignados < requeridos)
                {
                    throw new Exception($"Debe seleccionar la cantidad mínima de personal requerida para cada puesto antes de guardar. (Faltan {requeridos - asignados} para '{categoria}').");
                }
            }

            mpAsignacion.GuardarAsignacion(idReserva, listaPersonalAsignado);
        }
    }
}

