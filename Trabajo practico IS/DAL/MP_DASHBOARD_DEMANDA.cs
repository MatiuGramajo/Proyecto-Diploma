using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_DASHBOARD_DEMANDA : MAPPER<BE.VOLUMEN_EVENTOS_DTO>
    {
        public List<BE.VOLUMEN_EVENTOS_DTO> ObtenerVolumenEventosPorMes(DateTime fechaDesde, DateTime fechaHasta)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@FechaDesde", fechaDesde),
                new SqlParameter("@FechaHasta", fechaHasta)
            };
            DataTable dt = acceso.Leer("OBTENER_VOLUMEN_EVENTOS_POR_MES", parametros);
            acceso.Cerrar();

            List<BE.VOLUMEN_EVENTOS_DTO> lista = new List<BE.VOLUMEN_EVENTOS_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new BE.VOLUMEN_EVENTOS_DTO
                {
                    Mes_Año = row["MesAño"].ToString(),
                    Cantidad_Eventos = Convert.ToInt32(row["CantidadEventos"])
                });
            }
            return lista;
        }

        public List<BE.DEMANDA_TIPO_EVENTO_DTO> ObtenerDemandaTiposEvento(DateTime fechaDesde, DateTime fechaHasta)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@FechaDesde", fechaDesde),
                new SqlParameter("@FechaHasta", fechaHasta)
            };
            DataTable dt = acceso.Leer("OBTENER_DEMANDA_TIPOS_EVENTO", parametros);
            acceso.Cerrar();

            List<BE.DEMANDA_TIPO_EVENTO_DTO> lista = new List<BE.DEMANDA_TIPO_EVENTO_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new BE.DEMANDA_TIPO_EVENTO_DTO
                {
                    Tipo_Evento = row["TipoEvento"].ToString(),
                    Cantidad_Eventos = Convert.ToInt32(row["CantidadEventos"])
                });
            }
            return lista;
        }
        public override void Alta(VOLUMEN_EVENTOS_DTO obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(VOLUMEN_EVENTOS_DTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<VOLUMEN_EVENTOS_DTO> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(VOLUMEN_EVENTOS_DTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(VOLUMEN_EVENTOS_DTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
