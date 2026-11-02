using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PARAMETRO_RATIO
    {
        private DAL.MP_PARAMETRO_RATIO mpRatio = new DAL.MP_PARAMETRO_RATIO();
        private DAL.MP_RESERVA mpReserva = new DAL.MP_RESERVA();

        public BE.CALIBRACION_DTO ObtenerCalibracionRatios()
        {
            List<BE.RESERVA> eventosEvaluados = mpReserva.ListarEvaluados();
            List<BE.PARAMETRO_RATIO> ratiosActuales = mpRatio.Listar();

            BE.CALIBRACION_DTO dto = new BE.CALIBRACION_DTO
            {
                TotalEventosEvaluados = eventosEvaluados.Count,
                RatiosActuales = ratiosActuales
            };

            if (dto.TotalEventosEvaluados < 10)
            {
                return dto;
            }

            dto.CantidadAprobados = eventosEvaluados.Count(e => e.Evaluacion_Personal == 1);
            dto.CantidadDesaprobados = eventosEvaluados.Count(e => e.Evaluacion_Personal == 0);

            dto.PorcentajeAprobacion = Math.Round(((decimal)dto.CantidadAprobados / dto.TotalEventosEvaluados) * 100, 2);
            dto.PorcentajeDesaprobacion = Math.Round(((decimal)dto.CantidadDesaprobados / dto.TotalEventosEvaluados) * 100, 2);

            int deltaInvitados = 0;

            if (dto.PorcentajeAprobacion >= 85m)
            {
                deltaInvitados = 2; 
                dto.RecomendacionAjuste = "Optimizar Costos (Incrementar la cobertura por personal).";
            }
            else if (dto.PorcentajeAprobacion >= 70m)
            {
                deltaInvitados = 0; 
                dto.RecomendacionAjuste = "Mantener ratios operativos vigentes.";
            }
            else
            {
                deltaInvitados = -2; 
                dto.RecomendacionAjuste = "Reforzar Dotación (Reducir la cobertura por personal para mejorar la calidad).";
            }

            foreach (var rActual in ratiosActuales)
            {
                int nuevoValor = rActual.Cantidad_Invitados_Por_Personal + deltaInvitados;
                if (nuevoValor < 4) nuevoValor = 4;

                dto.RatiosSugeridos.Add(new BE.PARAMETRO_RATIO
                {
                    Id_Ratio = rActual.Id_Ratio,
                    Categoria = rActual.Categoria,
                    Cantidad_Invitados_Por_Personal = nuevoValor,
                    Estado = rActual.Estado
                });
            }

            return dto;
        }
        public List<BE.PARAMETRO_RATIO> ListarRatiosVigentes()
        {
            return mpRatio.Listar();
        }
        public void GuardarNuevosRatios(BE.CALIBRACION_DTO objCalibracion)
        {
            if (objCalibracion == null || objCalibracion.RatiosSugeridos == null || objCalibracion.RatiosSugeridos.Count == 0)
            {
                throw new Exception("No hay ratios calculados para actualizar.");
            }

            mpRatio.GuardarCalibracion(objCalibracion);
        }
    }
}
