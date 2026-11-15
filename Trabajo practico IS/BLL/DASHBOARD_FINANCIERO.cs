using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DASHBOARD_FINANCIERO
    {
        private DAL.MP_DASHBORD_FINANCIERO mpFinanciero = new DAL.MP_DASHBORD_FINANCIERO();

        public List<BE.SALDO_CLIENTE_DTO> ListarSaldosPendientes(DateTime desde, DateTime hasta)
        {
            return mpFinanciero.ObtenerSaldosPendientes(desde, hasta);
        }

        public BE.INGRESOS_PROYECTADOS_DTO ObtenerIngresosProyectados(DateTime desde, DateTime hasta)
        {
            return mpFinanciero.ObtenerIngresosProyectados(desde, hasta);
        }

        public BE.CONVERSION_PRESUPUESTO_DTO ObtenerConversionPresupuestos(DateTime desde, DateTime hasta)
        {
            var dto = mpFinanciero.ObtenerConversionPresupuestos(desde, hasta);
            if (dto.Total_Presupuestos > 0)
            {
                dto.Porcentaje_Aprobacion = Math.Round(((decimal)dto.Cantidad_Aprobados / dto.Total_Presupuestos) * 100, 2);
            }
            else
            {
                dto.Porcentaje_Aprobacion = 0;
            }
            return dto;
        }
    }
}
