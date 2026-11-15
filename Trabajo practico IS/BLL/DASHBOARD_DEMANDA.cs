using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DASHBOARD_DEMANDA
    {
        private DAL.MP_DASHBOARD_DEMANDA mpDemanda = new DAL.MP_DASHBOARD_DEMANDA();

        public List<BE.VOLUMEN_EVENTOS_DTO> ObtenerVolumenEventosPorMes(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha desde no puede ser mayor a la fecha hasta.");

            return mpDemanda.ObtenerVolumenEventosPorMes(fechaDesde, fechaHasta);
        }

        public List<BE.DEMANDA_TIPO_EVENTO_DTO> ObtenerDemandaTiposEvento(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha desde no puede ser mayor a la fecha hasta.");

            return mpDemanda.ObtenerDemandaTiposEvento(fechaDesde, fechaHasta);
        }
    }
}
