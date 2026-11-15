using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DASHBOARD_PERSONAL
    {
        private DAL.MP_DASHBOARD_PERSONAL mpPersonal = new DAL.MP_DASHBOARD_PERSONAL();

        public List<BE.PERSONAL_ASISTENCIA_DTO> ObtenerTopPersonalAsistencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha desde no puede ser mayor a la fecha hasta.");

            return mpPersonal.ObtenerTopPersonalAsistencia(fechaDesde, fechaHasta);
        }

        public List<BE.DISTRIBUCION_CATEGORIA_DTO> ObtenerDistribucionCategoria(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha desde no puede ser mayor a la fecha hasta.");

            return mpPersonal.ObtenerDistribucionCategoria(fechaDesde, fechaHasta);
        }
    }
}
