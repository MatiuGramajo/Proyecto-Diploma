using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_DASHBORD_FINANCIERO : MAPPER<MP_DASHBORD_FINANCIERO>
    {
        public List<BE.SALDO_CLIENTE_DTO> ObtenerSaldosPendientes(DateTime desde, DateTime hasta)
        {
            acceso.Abrir();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Desde", desde));
            parametros.Add(acceso.CrearParametro("@Hasta", hasta));

            DataTable dt = acceso.Leer("OBTENER_SALDOS_PENDIENTES_CLIENTES", parametros);
            acceso.Cerrar();

            List<BE.SALDO_CLIENTE_DTO> lista = new List<BE.SALDO_CLIENTE_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new BE.SALDO_CLIENTE_DTO
                {
                    Id_Reserva = Convert.ToInt32(row["Id_Reserva"]),
                    Cliente = row["Cliente"].ToString(),
                    Fecha_Evento = Convert.ToDateTime(row["Fecha_Evento"]),
                    Costo_Total = Convert.ToDecimal(row["Costo_Total"]),
                    Monto_Senia = Convert.ToDecimal(row["Monto_Senia"]),
                    Saldo_Pendiente = Convert.ToDecimal(row["Saldo_Pendiente"])
                });
            }
            return lista;
        }

        public BE.INGRESOS_PROYECTADOS_DTO ObtenerIngresosProyectados(DateTime desde, DateTime hasta)
        {
            acceso.Abrir();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Desde", desde));
            parametros.Add(acceso.CrearParametro("@Hasta", hasta));

            DataTable dt = acceso.Leer("OBTENER_INGRESOS_FINANCIEROS", parametros);
            acceso.Cerrar();

            BE.INGRESOS_PROYECTADOS_DTO dto = new BE.INGRESOS_PROYECTADOS_DTO();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                dto.Total_Cobrado = Convert.ToDecimal(row["TotalCobrado"]);
                dto.Total_Pendiente = Convert.ToDecimal(row["TotalPendiente"]);
                dto.Total_Proyectado = Convert.ToDecimal(row["TotalProyectado"]);
            }
            return dto;
        }
        public BE.CONVERSION_PRESUPUESTO_DTO ObtenerConversionPresupuestos(DateTime desde, DateTime hasta)
        {
            acceso.Abrir();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Desde", desde));
            parametros.Add(acceso.CrearParametro("@Hasta", hasta));

            DataTable dt = acceso.Leer("OBTENER_ESTADISTICAS_PRESUPUESTOS", parametros);
            acceso.Cerrar();

            BE.CONVERSION_PRESUPUESTO_DTO dto = new BE.CONVERSION_PRESUPUESTO_DTO();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                dto.Cantidad_Aprobados = Convert.ToInt32(row["Aprobados"]);
                dto.Cantidad_Pendientes = Convert.ToInt32(row["Pendientes"]);
                dto.Cantidad_Rechazados = Convert.ToInt32(row["Rechazados"]);
                dto.Total_Presupuestos = Convert.ToInt32(row["Total"]);
            }
            return dto;
        }
       
        public override void Alta(MP_DASHBORD_FINANCIERO obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(MP_DASHBORD_FINANCIERO obj)
        {
            throw new NotImplementedException();
        }

        public override List<MP_DASHBORD_FINANCIERO> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(MP_DASHBORD_FINANCIERO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(MP_DASHBORD_FINANCIERO obj)
        {
            throw new NotImplementedException();
        }
    }
}
