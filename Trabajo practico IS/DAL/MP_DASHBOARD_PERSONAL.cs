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
    public class MP_DASHBOARD_PERSONAL : MAPPER<BE.PERSONAL_ASISTENCIA_DTO>
    {
        public List<BE.PERSONAL_ASISTENCIA_DTO> ObtenerTopPersonalAsistencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@FechaDesde", fechaDesde),
                new SqlParameter("@FechaHasta", fechaHasta)
            };
            DataTable dt = acceso.Leer("OBTENER_TOP_PERSONAL_ASISTENCIA", parametros);
            acceso.Cerrar();

            List<BE.PERSONAL_ASISTENCIA_DTO> lista = new List<BE.PERSONAL_ASISTENCIA_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new BE.PERSONAL_ASISTENCIA_DTO
                {
                    Nombre_Completo = row["NombreCompleto"].ToString(),
                    Categoria = row["Categoria"].ToString(),
                    Cantidad_Eventos = Convert.ToInt32(row["CantidadEventos"])
                });
            }
            return lista;
        }

        public List<BE.DISTRIBUCION_CATEGORIA_DTO> ObtenerDistribucionCategoria(DateTime fechaDesde, DateTime fechaHasta)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@FechaDesde", fechaDesde),
                new SqlParameter("@FechaHasta", fechaHasta)
            };
            DataTable dt = acceso.Leer("OBTENER_DISTRIBUCION_CATEGORIA_PERSONAL", parametros);
            acceso.Cerrar();

            List<BE.DISTRIBUCION_CATEGORIA_DTO> lista = new List<BE.DISTRIBUCION_CATEGORIA_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new BE.DISTRIBUCION_CATEGORIA_DTO
                {
                    Categoria = row["Categoria"].ToString(),
                    Cantidad_Asignaciones = Convert.ToInt32(row["CantidadAsignaciones"])
                });
            }
            return lista;
        }
        public override void Alta(PERSONAL_ASISTENCIA_DTO obj)
        {
            throw new NotImplementedException();
        }

        public override void Baja(PERSONAL_ASISTENCIA_DTO obj)
        {
            throw new NotImplementedException();
        }

        public override List<PERSONAL_ASISTENCIA_DTO> Listar()
        {
            throw new NotImplementedException();
        }

        public override void Modificar(PERSONAL_ASISTENCIA_DTO obj)
        {
            throw new NotImplementedException();
        }

        public override bool Verificar(PERSONAL_ASISTENCIA_DTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
